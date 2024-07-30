//$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//
using System;
using System.Collections.Generic;

namespace System.Numerics.Adapters
{
    public struct Rect
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
}
