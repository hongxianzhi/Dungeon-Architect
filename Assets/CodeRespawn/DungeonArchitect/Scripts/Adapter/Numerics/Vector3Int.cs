//$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//
using System;
using System.Collections.Generic;

namespace System.Numerics.Adapters
{
    public struct Vector3Int
    {
        private int m_X;

        private int m_Y;

        private int m_Z;

        private static readonly Vector3Int s_Zero = new Vector3Int(0, 0, 0);

        private static readonly Vector3Int s_One = new Vector3Int(1, 1, 1);

        private static readonly Vector3Int s_Up = new Vector3Int(0, 1, 0);

        private static readonly Vector3Int s_Down = new Vector3Int(0, -1, 0);

        private static readonly Vector3Int s_Left = new Vector3Int(-1, 0, 0);

        private static readonly Vector3Int s_Right = new Vector3Int(1, 0, 0);

        private static readonly Vector3Int s_Forward = new Vector3Int(0, 0, 1);

        private static readonly Vector3Int s_Back = new Vector3Int(0, 0, -1);

        //
        // 摘要:
        //     X component of the vector.
        public int x
        {
            get
            {
                return m_X;
            }
            set
            {
                m_X = value;
            }
        }

        //
        // 摘要:
        //     Y component of the vector.
        public int y
        {
            get
            {
                return m_Y;
            }
            set
            {
                m_Y = value;
            }
        }

        //
        // 摘要:
        //     Z component of the vector.
        public int z
        {
            get
            {
                return m_Z;
            }
            set
            {
                m_Z = value;
            }
        }

        public Vector3Int(int x, int y)
        {
            m_X = x;
            m_Y = y;
            m_Z = 0;
        }

        public Vector3Int(int x, int y, int z)
        {
            m_X = x;
            m_Y = y;
            m_Z = z;
        }
    }
}
