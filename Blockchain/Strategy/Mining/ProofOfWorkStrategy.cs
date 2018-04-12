using System;

namespace Blockchain.Strategy.Mining {
    public class ProofOfWorkStrategy : StrategyBase, IStrategy {
        public ProofOfWorkStrategy(int complexity = 2) : base(complexity)
        {
            Console.WriteLine("Proof of Work strategy chosen!");
        }
        
        public override void MineBlock(Block block) {
            var leadingZeros = new String('0', Complexity);
            while (!block.Hash.StartsWith(leadingZeros)) block.Nonce++;
        }
    }
}