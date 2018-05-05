using Blockchain.Strategy.Mining;
using System;
using System.Collections;
using System.Text;

namespace Blockchain
{
    public class Chain
    {
        public Block[] Blocks { get; set; }
        public string LastHash => Blocks.Length > 0 ? Blocks[Blocks.Length - 1].Hash : null;
        public int Complexity {
            get => _strategy == null ? 0 : _strategy.Complexity;
        }
        private IStrategy _strategy;

        public Chain(IStrategy strategy = null)
        {
            _strategy = strategy ?? new ProofOfWorkStrategy();

            // initialize the chain
            Blocks = new Block[0];

            // intialize the Genesis Block
            var dataBlock = new DataBlock("Genesis block rocks!");
            var block = MineBlock(Block.GetHash("first-hash"), dataBlock);

            // add the Genesis Block
            AddBlock(block);
        }

        public Chain(Block[] blocks)
        {
            // TODO: validate the chain

            Blocks = blocks;
        }

        public Block MineBlock(string lastHash, IDataBlock data)
        {
            if (this.Blocks.Length > 0 && lastHash != this.Blocks[this.Blocks.Length - 1].Hash)
                throw new ArgumentException("Invalid LastHash provided!");

            var block = new Block(lastHash, data, this.Complexity);
            _strategy.MineBlock(block);

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
            _strategy.IncreaseComplexity();
        }

        public void DecreaseComplexity()
        {
            _strategy.DecreaseComplexity();
        }
    }
}