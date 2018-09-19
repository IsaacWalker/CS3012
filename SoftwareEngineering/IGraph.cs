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
    interface IGraph<T>
    {
        bool Contains(T Data);

        void Remove(T Data);

        IList<T> GetConnections(T DataNode)
    }
}
