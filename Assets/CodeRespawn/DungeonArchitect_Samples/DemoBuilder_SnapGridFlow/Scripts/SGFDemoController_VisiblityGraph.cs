//\$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved \$//\n
using DungeonArchitect;
using DungeonArchitect.Builders.SnapGridFlow;
using UnityEngine;

namespace DungeonArchitect.Samples.SnapGridFlow
{
    public class SGFDemoController_VisiblityGraph : MonoBehaviour
    {
        public Dungeon dungeon;

        protected virtual void Start()
        {
            if (dungeon != null)
            {
                dungeon.Build();
                
                // Setup the visibility graph to track the player
                var playerObject = GameObject.FindWithTag("Player");
                if (playerObject != null)
                {
                    var visibilityGraph = dungeon.GetComponent<SnapGridFlowVisibilityGraph>();
                    if (visibilityGraph != null)
                    {
                        visibilityGraph.trackedObjects = new Transform[] { playerObject.transform };
                    }
                    
                    // Detach the spawned player object from the room prefab (we don't want to hide the player's camera when the spawn room hides)
                    playerObject.transform.SetParent(null, true);
                }
            }
        }

    }
}
