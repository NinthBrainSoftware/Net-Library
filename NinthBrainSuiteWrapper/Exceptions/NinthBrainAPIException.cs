using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinthBrainSoftware.HostedEngine.Client.Exceptions
{
    /// <summary>
    /// General exception.
    /// </summary>
    public class NinthBrainAPIException : Exception
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public NinthBrainAPIException() { }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="message">Error message.</param>
        public NinthBrainAPIException(string message) : base(message) { }
    }
}
