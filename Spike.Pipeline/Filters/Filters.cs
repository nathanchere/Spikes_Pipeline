using System;

namespace Spike.Pipeline
{
    public class CalculateSubtotal : Filter<Order>
    {
        public override Order DoOperation(Order input)
        {
            return new Order(input.Name, input.Price, input.Quantity)
            {
                Subtotal = input.Price * input.Quantity
            };
        }
    }

    public class CalculateTax : Filter<Order>
    {
        public override Order DoOperation(Order input)
        {
            //if(input.Quantity < 1) throw new Exception("Too low quantity");
            return new Order(input.Name, input.Price, input.Quantity)
            {
                Subtotal = input.Subtotal,
                Tax = input.Subtotal * 0.1m,
            };
        }
    }

    public class CalculateTotal : Filter<Order>
    {
        public override Order DoOperation(Order input)
        {
            return new Order(input.Name, input.Price, input.Quantity)
            {
                Subtotal = input.Subtotal,
                Tax = input.Tax,
                Total = input.Tax + input.Subtotal,
            };
        }
    }
}
