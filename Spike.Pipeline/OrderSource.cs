using System.Collections.Generic;
using System.Linq;

namespace Spike.Pipeline
{
    public class OrderSource : IPump<Order>
    {       
        public IEnumerable<Order> Execute()
        {
            return new[] {
                new Order("Baguette", 0.5m, 1.0m),
                new Order("Ham", 8.5m, 0.3m),
                new Order("Cheese", 6.5m, 0.2m),
                new Order("Lettuce", 1.5m, 1.0m),
            }.AsEnumerable();
        }
    }
}