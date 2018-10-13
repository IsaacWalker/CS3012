using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineering
{
    /// <summary>
    /// ADT that Represents a DAG
    /// </summary>
    public class Graph : IGraph
    {
        private IList<GraphNode> Nodes = new List<GraphNode>();

        private int size;

        /// <summary>
        /// Creates an unweighted Directed acyclic graph
        /// </summary>
        public Graph()
        {
            size = 0;
        }
        /// <summary>
        /// Determines if a graph contains a Node with given data
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool Contains(string Data)
        {
            return Get(Data) != null;
        }

        /// <summary>
        /// Removes the node with the given Data
        /// </summary>
        /// <param name="Data"></param>
        public void Remove(string Data)
        {
            if (Contains(Data)) Nodes.Remove(Get(Data));
        }

        /// <summary>
        /// Adds a data node to the graph
        /// </summary>
        /// <param name="Data"></param>
        public void Add(string Data)
        {
            if (Contains(Data))
            {
                Remove(Data);
            }
            else
            {
                size++;
            }
            Nodes.Add(new GraphNode(Data));
        }

        /// <summary>
        /// Adds a connection One->Two
        /// </summary>
        /// <param name="DataOne"></param>
        /// <param name="DataTwo"></param>
        public void AddConnection(string DataOne, string DataTwo)
        {
            if (!AreConnected(DataOne, DataTwo))
            {
                Get(DataOne).AddConnection(Get(DataTwo));
            }
        }

        /// <summary>
        /// Returns number of nodes in the graph
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return size;
        }

        /// <summary>
        /// Returns whether A->B is true
        /// </summary>
        /// <param name="DataOne"></param>
        /// <param name="DataTwo"></param>
        /// <returns></returns>
        public bool AreConnected(string DataOne, string DataTwo)
        {
            GraphNode A = Get(DataOne);
            GraphNode B = Get(DataTwo);
            return (A.Connections.Contains(B));
        }

        private GraphNode Get(string Data)
        {
            return Nodes.Where((n) => (n.Data == Data)).FirstOrDefault();
        }

        /// <summary>
        /// Represents a Node of a graph, which has data and connections to other ndoes
        /// </summary>
        class GraphNode
        {
            public readonly string Data;

            public IList<GraphNode> Connections = new List<GraphNode>();

            public GraphNode(string Data)
            {
                this.Data = Data;
            }

            public void AddConnection(GraphNode Node)
            {
                Connections.Add(Node);
            }
        }


        //LCA Implementation

        /// <summary>
        /// Finds the Lowest common ancestor of two nodes
        /// </summary>
        /// <param name="NodeOneString"></param>
        /// <param name="NodeTwoString"></param>
        /// <returns></returns>
        public string LCA(string NodeOneString, string NodeTwoString)
        {
            GraphNode NodeOne = Get(NodeOneString);
            GraphNode NodeTwo = Get(NodeTwoString);

            if (NodeOne == null || NodeTwo == null) return null;

            GraphNode ReturnNode = LCA(NodeOne, NodeTwo);
            return (ReturnNode != null) ? ReturnNode.Data : null;
        }

        private GraphNode LCA(GraphNode NodeOne, GraphNode NodeTwo)
        {
            List<GraphNode> NodeOneAncestors = GetOrderedAncestors(NodeOne);

            List<GraphNode> NodeTwoAncestors = GetOrderedAncestors(NodeTwo);

            foreach (GraphNode CurrentNode in NodeOneAncestors)
            {
                if (NodeTwoAncestors.Contains(CurrentNode)) return CurrentNode;
            }

            return null;
        }

        private List<GraphNode> GetOrderedAncestors(GraphNode Input)
        {
            List<GraphNode> OrderedAncestors = new List<GraphNode>();

            List<GraphNode> ImmediateAncestors = GetImmediateParents(Input);

            while (ImmediateAncestors.Count != 0)
            {
                List<GraphNode> TempAncestors = new List<GraphNode>();

                foreach (GraphNode Node in ImmediateAncestors)
                {
                    if (!OrderedAncestors.Contains(Node)) OrderedAncestors.Add(Node);
                    TempAncestors.AddRange(GetImmediateParents(Node));
                }

                ImmediateAncestors = TempAncestors;
            }

            return OrderedAncestors;
        }

        private List<GraphNode> GetImmediateParents(GraphNode Input)
        {
            return Nodes.Where((N) => (N.Connections.Contains(Input))).ToList();
        }

        public static void Main(String[] args)
        {

        }


    }
}
