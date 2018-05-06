using Blockchain;
using Blockchain.Strategy.Mining;
using System;
using Xunit;

namespace Blockchain.Test
{
    public class ChainTest
    {
        [Fact]
        public void MustNotHaveStrategy()
        {
            var blockchain = new Chain();
            Assert.Equal(blockchain.Strategy.GetType(), new NoStrategy().GetType());
        }
        
        [Fact]
        public void MustMatchComplexity()
        {
            var blockchain = new Chain(StrategyEnum.ProofOfWork, 2);   
            Assert.Equal(2, blockchain.Complexity);
        }
        
        [Fact]
        public void MustIncreaseComplexity()
        {
            var blockchain = new Chain(StrategyEnum.ProofOfWork, 2);
            blockchain.IncreaseComplexity();

            Assert.Equal(3, blockchain.Complexity);
        }
        
        [Fact]
        public void MustDecreaseComplexity()
        {
            var blockchain = new Chain(StrategyEnum.ProofOfWork, 2);
            blockchain.DecreaseComplexity();

            Assert.Equal(1, blockchain.Complexity);
        }
        
        [Fact]
        public void MustAddBlock()
        {
            var blockchain = new Chain(StrategyEnum.ProofOfWork, 2);
            
            var block = blockchain.MineBlock(blockchain.LastHash, "first block");
            blockchain.AddBlock(block);

            Assert.Equal(blockchain.Blocks[blockchain.Blocks.Length - 1], block);
            Assert.Equal(blockchain.Blocks[blockchain.Blocks.Length - 1].Hash, block.Hash);
        }
        
        [Fact]
        public void MustPointToLastHash()
        {
            var blockchain = new Chain(StrategyEnum.ProofOfWork, 2);
            
            var block = blockchain.MineBlock(blockchain.LastHash, "first block");
            blockchain.AddBlock(block);

            Assert.Equal(blockchain.LastHash, block.Hash);
        }
    }
}
