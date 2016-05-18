using System;
using System.Runtime.Serialization;

namespace CircuitBreakerPattern
{
    [Serializable]
    public class CircuitBreakerOpenException : Exception
    {
        public CircuitBreakerOpenException()
        {
        }

        public CircuitBreakerOpenException(string message) : base(message)
        {
        }

        public CircuitBreakerOpenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CircuitBreakerOpenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}