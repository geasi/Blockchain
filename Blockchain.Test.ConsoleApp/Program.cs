using System;
using Blockchain;
using Blockchain.Strategy.Mining;

namespace Blockchain.Test.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var blockchain = new Chain(StrategyEnum.ProofOfWork, 3);
            Console.WriteLine(blockchain.Blocks[0].ToString());

            for (int i = 0; i < 10; i++)
            {
                var newBlock = blockchain.MineBlock(blockchain.Blocks[i].Hash, $"{i+1}nth block in the chain");
                blockchain.AddBlock(newBlock);
                
                Console.WriteLine(newBlock.ToString());
            }
        }
    }
}
