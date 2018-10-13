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
        /// <summary>
        /// Checks if the graph contains the data
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        bool Contains(string Data);


        /// <summary>
        /// Removes Data from the graph
        /// </summary>
        /// <param name="Data"></param>
        void Remove(string Data);


        /// <summary>
        /// Adds a new node to the graph with the specified data
        /// </summary>
        /// <param name="Data"></param>
        void Add(string Data);


        /// <summary>
        /// Adds a connection DataOne->DataTwo
        /// </summary>
        /// <param name="DataOne"></param>
        /// <param name="DataTwo"></param>
        void AddConnection(string DataOne, string DataTwo);


        /// <summary>
        /// Computes the Lowest Common ancestor of the two nodes,
        /// returns null if none are present
        /// </summary>
        /// <param name="NodeOne"></param>
        /// <param name="NodeTwo"></param>
        /// <returns></returns>
        string LCA(string NodeOne, string NodeTwo);
    }
}
