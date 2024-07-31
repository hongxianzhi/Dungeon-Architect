//$ Copyright 2015-22, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//
using System;
using System.Collections.Generic;

namespace System.Numerics.Adapters
{
    public class Debug
    {
        static System.Action<string> _LogError = (message) => { };
        public static System.Action<string> LogError
        {
            get { return _LogError; }
            set { _LogError = value; }
        }

        static System.Action<string> _Log = (message) => { };
        public static System.Action<string> Log
        {
            get { return _Log; }
            set { _Log = value; }
        }

        static System.Action<string, string> _LogFormat = (message, format) => { };
        public static System.Action<string, string> LogFormat
        {
            get { return _LogFormat; }
            set { _LogFormat = value; }
        }

        static System.Action<bool> _Assert = (condition) => { };
        public static System.Action<bool> Assert
        {
            get { return _Assert; }
            set { _Assert = value; }
        }
    }
}
