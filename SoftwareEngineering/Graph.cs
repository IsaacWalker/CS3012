using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineering
{
    public class Graph : IGraph
    {
        private IList<GraphNode> Nodes = new List<GraphNode>();

        private int size;

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

        public void Add(string Data)
        {
            if (Contains(Data))
            {
                Remove(Data);
                size++;
            }
            Nodes.Add(new GraphNode(Data));
        }

        public void AddConnection(string DataOne, string DataTwo)
        {
            throw new NotImplementedException();
        }

        private GraphNode Get(string Data)
        {
            return Nodes.Where(n => n.Data.Equals(Data)).First();
        }

        class GraphNode
        {
            public readonly string Data;

            IList<GraphNode> Connections = new List<GraphNode>();

            public GraphNode(string Data)
            {
                this.Data = Data;
            }

            public void AddConnection(GraphNode Node)
            {
                Connections.Add(Node);
            }



        }

    }
}
