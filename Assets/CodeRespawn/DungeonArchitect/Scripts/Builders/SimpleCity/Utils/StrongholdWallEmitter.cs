//$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//
using UnityEngine;

namespace DungeonArchitect.Builders.SimpleCity
{
    /// <summary>
    /// Adds a wall around the edge of the city .  This makes it look like a stronghold defending the city
    /// </summary>
    public class StrongholdWallEmitter : DungeonMarkerEmitter
    {
        /// <summary>
        /// The distance to move the wall away from the city boundary
        /// </summary>
        public int padding = 0;
        public int doorSize = 2;
        public string WallMarkerName = "CityWall";
        public string DoorMarkerName = "CityDoor";
        public string GroundMarkerName = "CityGround";
        public string CornerTowerMarkerName = "CornerTower";
        public string WallPaddingMarkerName = "CityWallPadding";

        /// <summary>
        /// Called by the dungeon object right after the dungeon is created
        /// </summary>
        /// <param name="builder">reference to the builder object used to build the dungeon</param>
        public override void EmitMarkers(DungeonBuilder builder)
        {
            base.EmitMarkers(builder);

            var model = builder.Model as SimpleCityDungeonModel;
            var config = model.Config;
            var cells = model.Cells;

            var width = cells.GetLength(0);
            var length = cells.GetLength(1);

            var cellSize = new Vector3(config.CellSize.x, 0, config.CellSize.y);
            for (int p = 1; p <= padding; p++)
            {

                var currentPadding = p;

                var sx = -currentPadding;
                var sz = -currentPadding;
                var ex = width + currentPadding - 1;
                var ez = length + currentPadding - 1;

                if (currentPadding == padding)
                {
                    var halfDoorSize = doorSize / 2.0f;
                    // Insert markers along the 4 wall sides
                    for (float x = sx; x < ex; x++)
                    {
                        if ((int)x == (int)((sx + ex) / 2 - halfDoorSize))
                        {
                            EmitDoorMarker(builder, cellSize, x + halfDoorSize, sz, 0);
                            EmitDoorMarker(builder, cellSize, x + halfDoorSize, ez + 0.5f, 180);
                            x += halfDoorSize;
                            continue;
                        }
                        EmitWallMarker(builder, cellSize, x + 0.5f, sz, 0);
                        EmitWallMarker(builder, cellSize, x + 0.5f, ez + 0.5f, 180);
                    }

                    for (float z = sz; z < ez; z++)
                    {
                        if ((int)z == (int)((sz + ez) / 2 - halfDoorSize))
                        {
                            EmitDoorMarker(builder, cellSize, sx, z + halfDoorSize, 90);
                            EmitDoorMarker(builder, cellSize, ex + 0.5f, z + halfDoorSize, 270);
                            z += halfDoorSize;
                            continue;
                        }
                        EmitWallMarker(builder, cellSize, sx, z + 0.5f, 90);
                        EmitWallMarker(builder, cellSize, ex + 0.5f, z + 0.5f, 270);
                    }


                    EmitMarkerAt(builder, cellSize, CornerTowerMarkerName, sx, sz, 0);
                    EmitMarkerAt(builder, cellSize, CornerTowerMarkerName, ex + 0.5f, sz, 0);
                    EmitMarkerAt(builder, cellSize, CornerTowerMarkerName, sx, ez + 0.5f, 0);
                    EmitMarkerAt(builder, cellSize, CornerTowerMarkerName, ex + 0.5f, ez + 0.5f, 0);
                }
                else
                {
                    // Fill it with city wall padding marker
                    for (float x = sx; x < ex; x++)
                    {
                        EmitMarkerAt(builder, cellSize, WallPaddingMarkerName, x + 0.5f, sz, 0);
                        EmitMarkerAt(builder, cellSize, WallPaddingMarkerName, x + 0.5f, ez + 0.5f, 180);
                    }

                    for (float z = sz; z < ez; z++)
                    {
                        EmitMarkerAt(builder, cellSize, WallPaddingMarkerName, sx, z + 0.5f, 90);
                        EmitMarkerAt(builder, cellSize, WallPaddingMarkerName, ex + 0.5f, z + 0.5f, 270);
                    }
                }
            }

            // Emit a ground marker since the city builder doesn't emit any ground.  
            // The theme can add a plane here if desired (won't be needed if building on a landscape)
            EmitGroundMarker(builder, width, length, cellSize);


        }

        void EmitWallMarker(DungeonBuilder builder, Vector3 cellSize, float x, float z, float angle)
        {
            EmitMarkerAt(builder, cellSize, WallMarkerName, x, z, angle);
        }

        void EmitDoorMarker(DungeonBuilder builder, Vector3 cellSize, float x, float z, float angle)
        {
            EmitMarkerAt(builder, cellSize, DoorMarkerName, x, z, angle);
        }

        void EmitGroundMarker(DungeonBuilder builder, int sizeX, int sizeZ, Vector3 cellSize)
        {
            var position = Vector3.Scale(new Vector3(sizeX, 0, sizeZ) / 2.0f, cellSize) + transform.position;
            var scale = new Vector3(sizeX, 1, sizeZ);
            var trans = Matrix4x4.TRS(position, Quaternion.identity, scale);
            builder.EmitMarker(GroundMarkerName, trans, IntVector.Zero, -1);
        }

        void EmitMarkerAt(DungeonBuilder builder, Vector3 cellSize, string markerName, float x, float z, float angle)
        {
            var worldPosition = Vector3.Scale(new Vector3(x, 0, z), cellSize) + transform.position;
            var rotation = Quaternion.Euler(0, angle, 0);
            var transformation = Matrix4x4.TRS(worldPosition, rotation, Vector3.one);
            var gridPosition = new IntVector((int)x, 0, (int)z); // Optionally provide where this marker is in the grid position
            builder.EmitMarker(markerName, transformation, gridPosition, -1);
        }
    }

}