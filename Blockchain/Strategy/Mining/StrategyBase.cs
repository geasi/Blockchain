namespace Blockchain.Strategy.Mining {
    public abstract class StrategyBase : IStrategy
    {
        public StrategyBase(int complexity)
        {
            this.Complexity = complexity;
        }

        public int Complexity { get; set; }

        public void DecreaseComplexity()
        {
            if (this.Complexity >1) Complexity--;
        }
        public void IncreaseComplexity()
        {
            Complexity++;
        }

        public abstract void MineBlock(Block block);
    }
}