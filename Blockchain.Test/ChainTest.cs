using Blockchain;
using Blockchain.Strategy.Mining;
using System;
using Xunit;

namespace Blockchain.Test
{
    public class ChainTest
    {
        [Fact]
        public void MustMatchComplexity()
        {
            var strategy = new ProofOfWorkStrategy(2);
            var blockchain = new Chain(strategy);
            
            Assert.Equal(2, blockchain.Complexity);
        }
        
        [Fact]
        public void MustIncreaseComplexity()
        {
            var strategy = new ProofOfWorkStrategy(2);
            var blockchain = new Chain(strategy);
            blockchain.IncreaseComplexity();

            Assert.Equal(3, blockchain.Complexity);
        }
        
        [Fact]
        public void MustDecreaseComplexity()
        {
            var strategy = new ProofOfWorkStrategy(2);
            var blockchain = new Chain(strategy);
            blockchain.DecreaseComplexity();

            Assert.Equal(1, blockchain.Complexity);
        }
        
        [Fact]
        public void MustAddBlock()
        {
            var strategy = new ProofOfWorkStrategy(2);
            var blockchain = new Chain(strategy);
            
            var dataBlock = new DataBlock("first block");
            var block = blockchain.MineBlock(blockchain.LastHash, dataBlock);
            blockchain.AddBlock(block);

            Assert.Equal(blockchain.Blocks[blockchain.Blocks.Length - 1], block);
            Assert.Equal(blockchain.Blocks[blockchain.Blocks.Length - 1].Hash, block.Hash);
        }
        
        [Fact]
        public void MustPointToLastHash()
        {
            var strategy = new ProofOfWorkStrategy(2);
            var blockchain = new Chain(strategy);
            
            var dataBlock = new DataBlock("first block");
            var block = blockchain.MineBlock(blockchain.LastHash, dataBlock);
            blockchain.AddBlock(block);

            Assert.Equal(blockchain.LastHash, block.Hash);
        }
    }
}
