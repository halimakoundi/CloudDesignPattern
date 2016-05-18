namespace CircuitBreakerPattern
{
    internal class CircuitBreakerStateStoreFactory
    {
        public static CircuitBreakerStateStore GetClosedCircuitBreakerStateStore()
        {
            return new CircuitBreakerStateStoreImpl(CircuitBreakerStates.Closed);
        }
    }
}