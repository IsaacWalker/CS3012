using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineering
{
    /// <summary>
    /// Interface for a directed graph
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IGraph
    {
        bool Contains(string Data);

        void Remove(string Data);

        void Add(string Data);

        void AddConnection(string DataOne, string DataTwo);
    }
}
