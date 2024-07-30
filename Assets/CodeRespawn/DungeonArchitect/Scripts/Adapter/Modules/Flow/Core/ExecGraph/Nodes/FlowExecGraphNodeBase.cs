//$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//
using DungeonArchitect.Graphs.Adapters;
using System.Numerics.Adapters;

namespace DungeonArchitect.Flow.Exec.Adapters
{
    public class FlowExecGraphNodeBase : GraphNode
    {
        public override void Initialize(string id, Graph graph)
        {
            base.Initialize(id, graph);
            Size = new Vector2(120, 120);

            // Create an input pin on the top
            CreatePinOfType<FlowExecGraphNodePin>(GraphPinType.Input,
                        Vector2.zero,
                        Rect.zero,
                        new Vector2(0, -1));

            // Create an output pin at the bottom
            CreatePinOfType<FlowExecGraphNodePin>(GraphPinType.Output,
                        Vector2.zero,
                        Rect.zero,
                        new Vector2(0, -1));

        }
    }
}
