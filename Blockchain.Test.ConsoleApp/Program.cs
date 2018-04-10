using System;
using Blockchain;

namespace Blockchain.Test.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var blockchain = new Chain();
            Console.WriteLine(blockchain.Blocks[0].ToString());

            for (int i = 0; i < 10; i++)
            {
                var data = new DataBlock($"{i+1}nth block in the chain");
                var newBlock = blockchain.MineBlock(blockchain.Blocks[i].Hash, data);
                blockchain.AddBlock(newBlock);
                
                Console.WriteLine(newBlock.ToString());
            }
        }
    }
}
