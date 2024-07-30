//$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//
using System;
using System.Collections.Generic;

namespace DungeonArchitect.Graphs.Adapters
{
    public class Vector2
    {
        private static readonly Vector2 zeroVector = new Vector2(0f, 0f);

        private static readonly Vector2 oneVector = new Vector2(1f, 1f);

        private static readonly Vector2 upVector = new Vector2(0f, 1f);

        private static readonly Vector2 downVector = new Vector2(0f, -1f);

        private static readonly Vector2 leftVector = new Vector2(-1f, 0f);

        private static readonly Vector2 rightVector = new Vector2(1f, 0f);

        private static readonly Vector2 positiveInfinityVector = new Vector2(float.PositiveInfinity, float.PositiveInfinity);

        private static readonly Vector2 negativeInfinityVector = new Vector2(float.NegativeInfinity, float.NegativeInfinity);

        public static Vector2 zero
        {
            get
            {
                return zeroVector;
            }
        }

        public Vector2()
        {
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt(x * x + y * y);
            }
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }

        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(0f - a.x, 0f - a.y);
        }

        public static Vector2 operator *(Vector2 a, float d)
        {
            return new Vector2(a.x * d, a.y * d);
        }

        public static Vector2 operator *(float d, Vector2 a)
        {
            return new Vector2(a.x * d, a.y * d);
        }

        public static Vector2 operator /(Vector2 a, float d)
        {
            return new Vector2(a.x / d, a.y / d);
        }

        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            float num = lhs.x - rhs.x;
            float num2 = lhs.y - rhs.y;
            return num * num + num2 * num2 < 9.9999994E-11f;
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return !(lhs == rhs);
        }

        public float x;
        public float y;
    }

    public class Rect
    {
        public Rect(float x, float y, float width, float height)
        {
            m_XMin = x;
            m_YMin = y;
            m_Width = width;
            m_Height = height;
        }

        public Rect(Vector2 position, Vector2 size)
        {
            m_XMin = position.x;
            m_YMin = position.y;
            m_Width = size.x;
            m_Height = size.y;
        }

        public Rect(Rect source)
        {
            m_XMin = source.m_XMin;
            m_YMin = source.m_YMin;
            m_Width = source.m_Width;
            m_Height = source.m_Height;
        }

        public static Rect zero => new Rect(0f, 0f, 0f, 0f);

        public float x
        {
            get
            {
                return m_XMin;
            }
            set
            {
                m_XMin = value;
            }
        }

        public float y
        {
            get
            {
                return m_YMin;
            }
            set
            {
                m_YMin = value;
            }
        }

        public Vector2 position
        {
            get
            {
                return new Vector2(m_XMin, m_YMin);
            }
            set
            {
                m_XMin = value.x;
                m_YMin = value.y;
            }
        }

        public Vector2 center
        {
            get
            {
                return new Vector2(x + m_Width / 2f, y + m_Height / 2f);
            }
            set
            {
                m_XMin = value.x - m_Width / 2f;
                m_YMin = value.y - m_Height / 2f;
            }
        }

        public Vector2 min
        {
            get
            {
                return new Vector2(xMin, yMin);
            }
            set
            {
                xMin = value.x;
                yMin = value.y;
            }
        }

        public Vector2 max
        {
            get
            {
                return new Vector2(xMax, yMax);
            }
            set
            {
                xMax = value.x;
                yMax = value.y;
            }
        }

        public float width
        {
            get
            {
                return m_Width;
            }
            set
            {
                m_Width = value;
            }
        }

        public float height
        {
            get
            {
                return m_Height;
            }
            set
            {
                m_Height = value;
            }
        }

        public Vector2 size
        {
            get
            {
                return new Vector2(m_Width, m_Height);
            }
            set
            {
                m_Width = value.x;
                m_Height = value.y;
            }
        }

        public float xMin
        {
            get
            {
                return m_XMin;
            }
            set
            {
                float num = xMax;
                m_XMin = value;
                m_Width = num - m_XMin;
            }
        }

        public float yMin
        {
            get
            {
                return m_YMin;
            }
            set
            {
                float num = yMax;
                m_YMin = value;
                m_Height = num - m_YMin;
            }
        }

        public float xMax
        {
            get
            {
                return m_Width + m_XMin;
            }
            set
            {
                m_Width = value - m_XMin;
            }
        }

        public float yMax
        {
            get
            {
                return m_Height + m_YMin;
            }
            set
            {
                m_Height = value - m_YMin;
            }
        }

        public bool Contains(Vector2 point)
        {
            return point.x >= xMin && point.x < xMax && point.y >= yMin && point.y < yMax;
        }

        private float m_XMin;
        private float m_YMin;
        private float m_Width;
        private float m_Height;
    }

    /// <summary>
    /// Represents a graph node in the theme graph.  This is the base class for all graph nodes
    /// </summary>
    public class GraphNode
    {
        
        
		protected string id;
        /// <summary>
        /// The ID of the graph node
        /// </summary>
        public string Id
        {
            get
            {
                return id;
            }
			set { id = value; }
        }

        
        
        protected string caption;
        /// <summary>
        /// The caption label of the node. It is up to the implementation to draw this label, if needed
        /// </summary>
        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
            }
        }

        
        
        protected Rect bounds = new Rect(10, 10, 120, 120);
        /// <summary>
        /// The bounds of the node
        /// </summary>
        public Rect Bounds
        {
            get
            {
                return bounds;
            }
            set
            {
                bounds = value;
            }
        }

        
        
        protected bool canBeDeleted = true;
        public bool CanBeDeleted
        {
            get { return canBeDeleted; }
        }

        
        
        protected bool canBeSelected = true;
        public bool CanBeSelected
        {
            get { return canBeSelected; }
        }

        
        
        protected bool canBeMoved = true;
        public bool CanBeMoved
        {
            get { return canBeMoved; }
        }

        
        
        protected bool selected = false;
        /// <summary>
        /// Flag to indicate if the node has been selected
        /// </summary>
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (canBeSelected)
                {
                    selected = value;
                }
                else
                {
                    selected = false;
                }
            }
        }

        /// <summary>
        /// The size of the node
        /// </summary>
        public Vector2 Size
        {
            get { return bounds.size; }
            set
            {
                bounds.size = value;
            }
        }

        /// <summary>
        /// The position of the node
        /// </summary>
        public Vector2 Position
        {
            get { return bounds.position; }
            set
            {
                bounds.position = value;
            }
        }

        
        
        protected int zIndex;
        /// <summary>
        /// The Z-index of the node.  It determines if the node is on top of other nodes
        /// </summary>
        public int ZIndex
        {
            get
            {
                return zIndex;
            }
            set
            {
                zIndex = value;
            }
        }

        
        
        protected List<GraphPin> inputPins;
        /// <summary>
        /// List of input pins owned by this node
        /// </summary>
        public GraphPin[] InputPins
        {
            get
            {
                return inputPins != null ? inputPins.ToArray() : new GraphPin[0];
            }
        }

        
        
        protected List<GraphPin> outputPins;
        /// <summary>
        /// List of output pins owned by this node
        /// </summary>
        public GraphPin[] OutputPins
        {
            get
            {
                return outputPins != null ? outputPins.ToArray() : new GraphPin[0];
            }
        }

        /// <summary>
        /// Gets the first output pin. Returns null if no output pins are defined
        /// </summary>
        public GraphPin OutputPin
        {
            get
            {
                if (outputPins == null || outputPins.Count == 0) return null;
                return outputPins[0];
            }
        }

        /// <summary>
        /// Gets the first input pin. Returns null if no input pins are defined
        /// </summary>
        public GraphPin InputPin
        {
            get
            {
                if (inputPins == null || inputPins.Count == 0) return null;
                return inputPins[0];
            }
        }

        
        
        protected Graph graph;

        /// <summary>
        /// The graph that owns this node
        /// </summary>
        public Graph Graph
        {
            get
            {
                return graph;
            }
        }

		public virtual void Initialize(string id, Graph graph)
        {
            this.id = id;
            this.graph = graph;
        }

        /// <summary>
        /// Called when the node is copied.  
        /// The implementations should implement copy here (e.g. deep / shallow copy depending on implementation)
        /// </summary>
        /// <param name="node"></param>
        public virtual void CopyFrom(GraphNode node)
        {
            if (node != null)
            {
                caption = node.Caption;
                this.bounds = node.Bounds;
            }
        }

        public string name;
        protected void UpdateName(string prefix)
        {
            this.name = prefix + id;
        }

        private bool dragging = false;
        public bool Dragging
        {
            get { return dragging; }
            set { dragging = value; }
        }

        /// <summary>
        /// Gets the list of parent graph nodes
        /// </summary>
        /// <returns>List of parent graph nodes</returns>
        public GraphNode[] GetParentNodes()
        {
            var parents = new List<GraphNode>();
            if (InputPins.Length > 0)
            {
                foreach (var link in InputPins[0].GetConntectedLinks())
                {
                    if (link != null && link.Output != null && link.Output.Node != null)
                    {
                        parents.Add(link.Output.Node);
                    }
                }
            }
            return parents.ToArray();
        }

        /// <summary>
        /// Gets the list of child nodes
        /// </summary>
        /// <returns>List of child nodes</returns>
        public GraphNode[] GetChildNodes()
        {
            var children = new List<GraphNode>();
            if (OutputPins.Length > 0)
            {
                foreach (var link in OutputPins[0].GetConntectedLinks())
                {
                    if (link != null && link.Input != null && link.Input.Node != null)
                    {
                        children.Add(link.Input.Node);
                    }
                }
            }
            return children.ToArray();
        }

        /// <summary>
        /// Moves the node by the specified delta
        /// </summary>
        /// <param name="delta">The delta offset to move the node by</param>
        public void DragNode(Vector2 delta)
        {
            Position += delta;
        }
        
    }
}
