//$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//
using System;
using System.Collections.Generic;

namespace System.Numerics.Adapters
{
    public struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public Color(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            a = 1f;
        }

        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public static Color red
        {
            get
            {
                return new Color(1f, 0f, 0f, 1f);
            }
        }

        public static Color green
        {
            get
            {
                return new Color(0f, 1f, 0f, 1f);
            }
        }

        public static Color blue
        {
            get
            {
                return new Color(0f, 0f, 1f, 1f);
            }
        }

        public static Color white
        {
            get
            {
                return new Color(1f, 1f, 1f, 1f);
            }
        }

        public static Color black
        {
            get
            {
                return new Color(0f, 0f, 0f, 1f);
            }
        }

        public static Color yellow
        {
            get
            {
                return new Color(1f, 47f / 51f, 0.015686275f, 1f);
            }
        }

        public static Color cyan
        {
            get
            {
                return new Color(0f, 1f, 1f, 1f);
            }
        }

        public static Color magenta
        {
            get
            {
                return new Color(1f, 0f, 1f, 1f);
            }
        }

        public static Color gray
        {
            get
            {
                return new Color(0.5f, 0.5f, 0.5f, 1f);
            }
        }

        public static Color grey
        {
            get
            {
                return new Color(0.5f, 0.5f, 0.5f, 1f);
            }
        }

        public static Color clear
        {
            get
            {
                return new Color(0f, 0f, 0f, 0f);
            }
        }

        public float grayscale
        {
            get
            {
                return 0.299f * r + 0.587f * g + 0.114f * b;
            }
        }
    }
}
