using System;

namespace Blockchain.Strategy.Mining {
    public class NoStrategy : StrategyBase, IStrategy {
        public NoStrategy(int complexity = 2) : base(complexity)
        {
            Console.WriteLine("No strategy chosen!");
        }
    }
}