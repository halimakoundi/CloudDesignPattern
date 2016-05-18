using System;

namespace CircuitBreakerPattern
{
    public class CircuitBreakerImpl : CircuitBreaker
    {
        private readonly CircuitBreakerStateStore _stateStore = CircuitBreakerStateStoreFactory.GetClosedCircuitBreakerStateStore();

        public bool IsOpen { get { return !_stateStore.IsClosed; } }

        public void ExecuteAction(Action action)
        {
            if (this.IsOpen)
            {
                if (_stateStore.LastStateChangedDateUtc + OpenToHalfOpenWaitTime < DateTime.UtcNow)
                {
                    try
                    {
                        this._stateStore.HalfOpen();

                        action();

                        this._stateStore.Reset();
                        return;
                    }
                    catch (Exception ex)
                    {
                        this._stateStore.Trip(ex);

                        throw;
                    }   
                }
                throw new CircuitBreakerOpenException();
            }
            try
            {
                action();
            }
            catch (Exception ex)
            {
                TrackException(ex);

                throw;
            }
        }

        public TimeSpan OpenToHalfOpenWaitTime { get; set; }= new TimeSpan(100000);

        private void TrackException(Exception ex)
        {
            //TODO Add Logic for threshold before failure

            this._stateStore.Trip(ex);
        }
    }
}
