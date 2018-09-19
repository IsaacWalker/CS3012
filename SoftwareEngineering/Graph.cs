using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineering
{
    class Graph
    {
        private IList<GraphNode> Nodes = new List<GraphNode>();



        class GraphNode
        {
            readonly string Data;

            IList<GraphNode> Connections = new List<GraphNode>();

            GraphNode(string Data)
            {
                this.Data = Data;
            }

            void AddConnection(GraphNode Node)
            {
                Connections.Add(Node);
            }

        }

    }
}
