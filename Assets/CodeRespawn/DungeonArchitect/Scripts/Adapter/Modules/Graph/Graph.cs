//$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//
using System;
using System.Linq;
using System.Collections.Generic;

namespace DungeonArchitect.Graphs.Adapters
{
    /// <summary>
    /// An ID provider for graph objects
    /// </summary>
    [Serializable]
    public class IndexCounter
    {
        
        int index = 0;

        public int GetNext()
        {
            index++;
            return index;
        }
    }
    
    /// <summary>
    /// Theme Graph data structure holds all the theme nodes and their connections
    /// </summary>
    [Serializable]
    public class Graph
    {
        
        IndexCounter indexCounter;
        public IndexCounter IndexCounter
        {
            get { return indexCounter; }
        }

        
        IndexCounter topZIndex;

        
        List<GraphNode> nodes;
        /// <summary>
        /// List of graph nodes
        /// </summary>
        public List<GraphNode> Nodes
        {
            get
            {
                return nodes;
            }
        }

        
        List<GraphLink> links;

        /// <summary>
        /// List of graph links connecting the nodes
        /// </summary>
        public List<GraphLink> Links
        {
            get
            {
                return links;
            }
        }

        /// <summary>
        /// The z index of the top most node
        /// </summary>
        public IndexCounter TopZIndex
        {
            get
            {
                return topZIndex;
            }
        }

        /// <summary>
        /// Gets the node by it's id
        /// </summary>
        /// <param name="id">The ID of the node</param>
        /// <returns>The retrieved node.  null if node with this id doesn't exist</returns>
        public GraphNode GetNode(string id)
        {
            var result = from node in Nodes
                         where node.Id == id
                         select node;

            return (result.Count() > 0) ? result.Single() : null;
        }

        /// <summary>
        /// Get all nodes of the specified type
        /// </summary>
        /// <typeparam name="T">The type of nodes to retrieve. Should be a subclass of GraphNode</typeparam>
        /// <returns>List of all the nodes of the specified type</returns>
        public T[] GetNodes<T>() where T : GraphNode
        {
            var targetNodes = new List<T>();
            foreach (var node in nodes)
            {
                if (node is T)
                {
                    targetNodes.Add(node as T);
                }
            }
            return targetNodes.ToArray();
        }      
    }
}
