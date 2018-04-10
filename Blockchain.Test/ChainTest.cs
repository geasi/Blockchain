using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blockchain.Test
{
    [TestClass]
    public class ChainTest
    {
        [TestMethod]
        public void CreateChain()
        {
            var chain = new Blockchain.Chain();
            System.Diagnostics.Debug.WriteLine(chain.ToString());
        }
    }
}
