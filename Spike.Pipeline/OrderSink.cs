using System.Collections.Generic;

namespace Spike.Pipeline
{
    public class OrderSink : IDataSink<Order>
    {
        private List<Order> _results = new List<Order>();

        public IEnumerable<Order> Orders { get { return _results; } }

        public void Execute(IEnumerable<Order> input)
        {
            _results.AddRange(input);
        }
    }
}