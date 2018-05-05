namespace Blockchain.Strategy.Mining
{
    public abstract class StrategyBase : IStrategy
    {
        public StrategyBase(int complexity)
        {
            this.Complexity = complexity;
        }

        public int Complexity { get; set; }

        public void DecreaseComplexity()
        {
            if (this.Complexity > 1) Complexity--;
        }
        public void IncreaseComplexity()
        {
            Complexity++;
        }

        public virtual void MineBlock(Block block) { }
    }
}