using System;

namespace CircuitBreakerPattern
{
    public class CircuitBreakerStateStoreImpl : CircuitBreakerStateStore
    {
        private DateTime? _lastStateChangedDateUtc;
        private CircuitBreakerStates _state;
        private Exception _lastException;

        public CircuitBreakerStateStoreImpl(CircuitBreakerStates state)
        {
            _state = state;
        }

        public CircuitBreakerStates State { get { return _state; } }
        public Exception LastException { get { return _lastException; } }
        public DateTime? LastStateChangedDateUtc { get {return _lastStateChangedDateUtc;} }
        public bool IsClosed { get { return this.State == CircuitBreakerStates.Closed; } }

        public void Trip(Exception ex)
        {
            _lastStateChangedDateUtc = DateTime.UtcNow;
            _state = CircuitBreakerStates.Open;
            _lastException = ex;

        }

        public void Reset()
        {
            _lastStateChangedDateUtc = null;
            _state = CircuitBreakerStates.Open;
            _lastException = null;
        }

        public void HalfOpen()
        {
            _lastStateChangedDateUtc = DateTime.UtcNow;
            _state = CircuitBreakerStates.HalfOpen;
        }

    }
}