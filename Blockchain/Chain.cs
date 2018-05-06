using Blockchain.Strategy.Mining;
using Blockchain.Strategy.Mining.Factory;
using System;
using System.Collections;
using System.Text;

namespace Blockchain
{
    public class Chain
    {
        public Block[] Blocks { get; set; }
        public string LastHash => Blocks.Length > 0 ? Blocks[Blocks.Length - 1].Hash : null;
        public int Complexity
        {
            get => Strategy == null ? 0 : Strategy.Complexity;
        }
        public IStrategy Strategy;

        protected Chain()
        {
            Strategy = StrategyFactory.GetStrategy(StrategyEnum.NoStrategy, 0);

            // initialize the chain
            Blocks = new Block[0];

            // intialize the Genesis Block
            var block = MineBlock(Block.GetHash("first-hash"), "Genesis block rocks!");

            // add the Genesis Block
            AddBlock(block);
        }

        public Chain(StrategyEnum strategyEnum = StrategyEnum.NoStrategy, int complexity = 0)
        {
            Strategy = StrategyFactory.GetStrategy(strategyEnum, complexity);

            // initialize the chain
            Blocks = new Block[0];

            // intialize the Genesis Block
            var block = MineBlock(Block.GetHash("first-hash"), "Genesis block rocks!");

            // add the Genesis Block
            AddBlock(block);
        }

        public Chain(Block[] blocks)
        {
            // TODO: validate the chain

            Blocks = blocks;
        }

        public Block MineBlock(string lastHash, string data)
        {
            if (this.Blocks.Length > 0 && lastHash != this.Blocks[this.Blocks.Length - 1].Hash)
                throw new ArgumentException("Invalid LastHash provided!");

            var block = new Block(lastHash, data, this.Complexity);
            Strategy.MineBlock(block);

            return block;
        }

        public void AddBlock(Block block)
        {
            var blocks = Blocks;
            Array.Resize(ref blocks, blocks.Length + 1);
            blocks[blocks.Length - 1] = block;
            Blocks = blocks;
        }

        public void IncreaseComplexity()
        {
            Strategy.IncreaseComplexity();
        }

        public void DecreaseComplexity()
        {
            Strategy.DecreaseComplexity();
        }
    }
}