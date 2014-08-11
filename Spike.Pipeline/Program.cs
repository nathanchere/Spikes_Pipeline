using System;
using System.Text;
using System.Threading.Tasks;

namespace Spike.Pipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            var prefilterPump = new OrderSource();
            var prefilterSink = new OrderSink();

            var prefilter = new Pipeline<Order>(prefilterPump, prefilterSink, "prefiltering")
                .Register(new CalculateSubtotal() { Name = "Subtotal calculator" })
                .Register(new CalculateTax() { Name = "Tax calculator" })
                .Register(new CalculateTotal() { Name = "Total calculator" })
                ;

            prefilter.Execute();

            Console.WriteLine("".PadRight(50, '='));
            foreach (var input in prefilterSink.Orders)
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
            }
            Console.WriteLine("".PadRight(50, '='));

            Console.ReadKey();
        }
    }
}
