using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitBreakerPattern
{
    public interface CircuitBreaker
    {
        void ExecuteAction(Action action);
    }
}
