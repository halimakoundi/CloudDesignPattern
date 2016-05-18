using System;
using CircuitBreakerPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace CircuitBreakerPatternTest
{
    [TestFixture]
    public class CircuitBreakerTests
    {
        [Test]
        public void CbExecuteActionSuccessfully()
        {
            var circuitBreaker = new CircuitBreakerImpl();
            var greeting = "Hello";
            circuitBreaker.ExecuteAction(() =>
            {
                greeting = "Hello Circuit Breaker!";
            });
            Assert.That(greeting, Is.EqualTo("Hello Circuit Breaker!"));
        }

        [Test]
        [ExpectedException(typeof(CircuitBreakerOpenException))]
        public void CircuitBreakerFailsToExecuteAction()
        {
            var circuitBreaker = new CircuitBreakerImpl();
            var greeting = "Hello";
            try
            {
                circuitBreaker.ExecuteAction(() =>
                {
                    var zero = 0;
                    var calc = 3/zero;
                    greeting = "Hello Circuit Breaker!" + calc;
                });
            }
            catch (Exception ex)
            {
                Assert.That(ex, Is.Not.Null);
            }
            
            circuitBreaker.ExecuteAction(() =>
            {
                greeting = "Hello Circuit Breaker!";
            });
        }
    }
}
