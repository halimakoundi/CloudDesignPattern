using System;

namespace CircuitBreakerPattern
{
    interface CircuitBreakerStateStore
    {
        CircuitBreakerStates State { get; }

        Exception LastException { get; }

        DateTime? LastStateChangedDateUtc { get; }

        void Trip(Exception ex);

        void Reset();

        void HalfOpen();

        bool IsClosed { get; }
    }
}