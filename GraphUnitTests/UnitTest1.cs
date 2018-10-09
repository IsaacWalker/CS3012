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

            Assert.AreEqual(G.GetSize(), 6);
        }

        [TestMethod]
        public void TestAddRemove()
        {
            Graph G = new Graph();

            G.Add("one");
            G.Add("two");

            Assert.IsTrue(G.Contains("one"));
            Assert.IsTrue(G.Contains("two"));

            G.Remove("one");
            G.Remove("two");

            Assert.IsTrue(!G.Contains("one"));
            Assert.IsTrue(!G.Contains("two"));
        }

        [TestMethod]
        public void TestAreConnected()
        {
            Graph G = new Graph();

            G.Add("one");
            G.Add("two");
            G.Add("three");
            G.Add("four");

            G.AddConnection("one", "two");
            G.AddConnection("one", "three");
            G.AddConnection("two", "four");
            G.AddConnection("three", "four");

            Assert.IsTrue(G.AreConnected("one", "two"));
        }

        [TestMethod]
        public void TestBasicLCA()
        {
            Graph G = new Graph();

            G.Add("one");
            G.Add("two");
            G.Add("three");
            G.Add("four");
            G.Add("five");

            G.AddConnection("one", "two");   //     one
            G.AddConnection("one", "three"); //     / \
            G.AddConnection("two", "five");  //   two  three
            G.AddConnection("three", "four");//    |      \
                                             //   five    four

            Assert.IsTrue(G.LCA("five", "four").Equals("one"));

        }

        [TestMethod]
        public void TestComplexLCA()
        {
            Graph G = new Graph();

            G.Add("one");
            G.Add("two");
            G.Add("three");
            G.Add("four");
            G.Add("five");
            G.Add("six");
            G.Add("seven");
            G.Add("eight");

            G.AddConnection("one", "two");            //     one
            G.AddConnection("one", "three");          //     / \
            G.AddConnection("two", "five");          //   two  three
            G.AddConnection("three", "four");        //    |      \
            G.AddConnection("five", "six");          //   five     four
            G.AddConnection("four", "six");          //     \     /  \
            G.AddConnection("four", "seven");       //        six      seven
            G.AddConnection("six", "eight");        //        |   
                                                    //       eight

            Assert.IsTrue(G.LCA("eight", "seven").Equals("four"));

        }
    }
}
