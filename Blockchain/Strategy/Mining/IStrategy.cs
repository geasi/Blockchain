namespace Blockchain.Strategy.Mining {
    public interface IStrategy {
        void MineBlock(Block block);
    }
}