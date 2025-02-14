﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{

    /// <summary>
    /// An exception that is thrown when a database related problem happens
    /// </summary>
    [Serializable]
    public class DatabaseException : Exception
    {
        public DatabaseException() { }
        public DatabaseException(string message) : base(message) { }
        public DatabaseException(string message, Exception inner) : base(message, inner) { }
        protected DatabaseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
