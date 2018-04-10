using Blockchain.Strategy.Mining;
using System;
using System.Collections;
using System.Text;

namespace Blockchain
{
    public class Chain
    {
        public Block[] Blocks { get; set; }
        private IStrategy _strategy;

        public Chain(IStrategy strategy = null)
        {
            _strategy = strategy ?? new ProofOfWorkStrategy();

            // initialize the chain
            Blocks = new Block[0];

            // intialize the Genesis Block
            var dataBlock = new DataBlock("Genesis block rocks!");
            var block = MineBlock(Block.GetHash("first-hash"), dataBlock);

            // add the Genesis Block
            AddBlock(block);
        }

        public Chain(Block[] blocks)
        {
            // TODO: validate the chain

            Blocks = blocks;
        }

        public Block MineBlock(string lastHash, DataBlockBase data)
        {
            if (this.Blocks.Length > 0 && lastHash != this.Blocks[this.Blocks.Length - 1].Hash)
                throw new ArgumentException("Invalid LastHash provided!");

            var block = new Block(lastHash, data);
            _strategy.MineBlock(block);

            return block;
        }

        public void AddBlock(Block block)
        {
            var blocks = Blocks;
            Array.Resize(ref blocks, blocks.Length + 1);
            blocks[blocks.Length - 1] = block;
            Blocks = blocks;
        }
    }
}