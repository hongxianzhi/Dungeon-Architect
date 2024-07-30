//$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//
using DungeonArchitect.Graphs.Adapters;

namespace DungeonArchitect.Flow.Exec.Adapters
{
    public class FlowExecGraphNodeBase : GraphNode
    {
        public override void Initialize(string id, Graph graph)
        {
            base.Initialize(id, graph);
            Size = new Vector2(120, 120);
        }
    }
}
