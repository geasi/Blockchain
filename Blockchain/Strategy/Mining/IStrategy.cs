namespace Blockchain.Strategy.Mining {
    public interface IStrategy {
        int Complexity { get; set; }

        void IncreaseComplexity();

        void DecreaseComplexity();

        void MineBlock(Block block);
    }
}