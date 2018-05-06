using System.IO;
using System.Text;
using System.Threading.Tasks;
using Blockchain.Hub;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.Hubs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChainController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Chain> GetChain()
        {
            return Ok(NodeHub.Blockchain);
        }

        [HttpGet("blocks")]
        public ActionResult<Block[]> GetBlocks()
        {
            return Ok(NodeHub.Blockchain.Blocks);
        }

        [HttpGet("lasthash")]
        public ActionResult<string> GetLastHash()
        {
            return Ok(NodeHub.Blockchain.LastHash);
        }

        [HttpPost("block")]
        public async Task<ActionResult> CreateBlock()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                var block = NodeHub.MineBlock(NodeHub.Blockchain.LastHash, body);
                
                return Ok(block);
            }
        }

        [HttpGet("blocks/{id}")]
        public ActionResult<Block> GetBlockByIndex(int id)
        {
            if (id >= 0 && id < NodeHub.Blockchain.Blocks.Length)
                return Ok(NodeHub.Blockchain.Blocks[id]);

            return NotFound();
        }
    }
}