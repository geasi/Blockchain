using System;

namespace Blockchain.Strategy.Mining {
    public class ProofOfWorkStrategy : IStrategy {
        public ProofOfWorkStrategy()
        {
            Console.WriteLine("Proof of Work strategy chosen!");
        }
        
        public void MineBlock(Block block) {
            while (!block.Hash.StartsWith("00")) block.Nonce++;
        }
    }
}