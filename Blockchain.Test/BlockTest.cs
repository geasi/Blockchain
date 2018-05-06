using Blockchain;
using System;
using Xunit;

namespace Blockchain.Test
{
    public class BlockTest
    {
        [Fact]
        public void MustMatchLastHash()
        {
            var block = new Block("last-hash", "data", 2);
            
            Assert.Equal("last-hash", block.LastHash);
        }
        
        [Fact]
        public void MustMatchData()
        {
            var block = new Block("last-hash", "data", 2);
            
            Assert.Equal("data", block.Data);
        }
        
        [Fact]
        public void MustMatchComplexity()
        {
            var block = new Block("last-hash", "data", 2);
            
            Assert.Equal(2, block.Complexity);
        }
    }
}
