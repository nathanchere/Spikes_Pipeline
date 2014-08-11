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

    public class OutputResults : Filter<Order>
    {
        public override Order DoOperation(Order input)
        {
            var result = string.Format("{0}  {1:C}  {2}  {3:C}  {4:C}  {5:C}",
                input.Name.PadRight(10),
                input.Price,
                input.Quantity,
                input.Subtotal,
                input.Tax,
                input.Total
                );
            Console.WriteLine(result);
            return input;
        }
    }

    public class CalculateTax : Filter<Order>
    {
        public override Order DoOperation(Order input)
        {
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
