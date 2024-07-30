//$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//
namespace DungeonArchitect.Graphs.Adapters
{
    /// <summary>
    /// A graph link is a directional connection between two graph nodes
    /// </summary>
    [System.Serializable]
    public class GraphLink
    {
        int id;
        string name;
        /// <summary>
        /// The ID of the link
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                UpdateName();
            }
        }

        GraphPin input;
        /// <summary>
        /// The input pin this link originates from
        /// </summary>
        public GraphPin Input
        {
            get
            {
                return input;
            }
            set
            {
                input = value;
            }
        }

        GraphPin output;
        /// <summary>
        /// The output pin this link points to
        /// </summary>
        public GraphPin Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
            }
        }

        Graph graph;
        /// <summary>
        /// The graph this link belongs to
        /// </summary>
        public Graph Graph
        {
            get
            {
                return graph;
            }
            set
            {
                graph = value;
            }
        }

        void UpdateName()
        {
            this.name = "Link_" + id;
        }


        /// <summary>
        /// Determines the spring strength of the link.  
        /// It reduces as it gets smaller to draw good looking link at any distance
        /// </summary>
        /// <returns></returns>
        public float GetTangentStrength()
        {
            var distance = (output.WorldPosition - input.WorldPosition).magnitude;
            var tangentStrength = System.Math.Min(output.TangentStrength, distance / 2.0f);
            return tangentStrength;
        }
    }
}