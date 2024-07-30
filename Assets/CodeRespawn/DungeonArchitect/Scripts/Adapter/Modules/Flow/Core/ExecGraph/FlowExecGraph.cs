//$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//
using System.Collections.Generic;
using DungeonArchitect.Graphs.Adapters;

namespace DungeonArchitect.Flow.Exec.Adapters
{
    public class FlowExecGraph : Graph
    {
        public FlowExecResultGraphNode resultNode;
    }

    public class FlowExecGraphUtils
    {
        public static FlowExecRuleGraphNode[] GetIncomingNodes(FlowExecRuleGraphNode node)
        {
            var result = new List<FlowExecRuleGraphNode>();
            var incomingNodes = GraphUtils.GetIncomingNodes(node);
            foreach (var incomingNode in incomingNodes)
            {
                var incomingExecNode = incomingNode as FlowExecRuleGraphNode;
                if (incomingExecNode != null)
                {
                    result.Add(incomingExecNode);
                }
            }
            return result.ToArray();
        }

    }
}
