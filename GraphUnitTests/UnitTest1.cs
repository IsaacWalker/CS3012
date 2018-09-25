using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareEngineering;

namespace GraphUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSize()
        {
            Graph G = new Graph();

            G.Add("one");
            G.Add("two");
            G.Add("three");
            G.Add("four");
            G.Add("five");
            G.Add("six");
        }

        [TestMethod]
        public void TestAddRemove()
        {

        }

        [TestMethod]
        public void TestAreConnected()
        {
            Graph G = new Graph();

            G.Add("one");
            G.Add("two");
            G.Add("three");
            G.Add("four");
            G.Add("five");
            G.Add("six");
        }
    }
}
