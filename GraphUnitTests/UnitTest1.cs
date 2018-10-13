using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareEngineering;

namespace GraphUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        //Ensures that the size method on the graph works as expected
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

        ///Tests that the functionality for adding and removing nodes from the graph 
        /// work as expected
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

        /// <summary>
        /// Ensures that Connecting two nodes registers in the graph
        /// </summary>
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

        /// <summary>
        /// Tests the Lowest common ancestor implementation on a Basic graph
        /// </summary>
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

        /// <summary>
        /// Tests the LCA on a more complicated graph
        /// </summary>
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

        /// <summary>
        /// Ensures that the test swill fail on a graph without 
        /// a common ancestor. LCA returns null when theres is no common ancestor
        /// </summary>
        [TestMethod]
        public void TestFailLCA()
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
            G.Add("nine");

            G.AddConnection("one", "two");            //     one
            G.AddConnection("one", "three");          //     / \
            G.AddConnection("two", "five");          //   two  three
            G.AddConnection("three", "four");        //    |      \
            G.AddConnection("five", "six");          //   five     four
            G.AddConnection("four", "six");          //     \     /  \
            G.AddConnection("four", "seven");       //        six      seven
            G.AddConnection("six", "eight");        //        |   
                                                    //       eight          nine

            Assert.IsTrue(G.LCA("eight", "nine") == null);

        }
    }
}
