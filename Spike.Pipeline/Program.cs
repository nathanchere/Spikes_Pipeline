using System;
using System.Text;
using System.Threading.Tasks;

namespace Spike.Pipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var prefilterPump = new OrderList();
                var prefilterSink = new PrefilterSink();

                var prefilter = new Pipeline<Order>(prefilterPump, prefilterSink, "prefiltering")
                    .Register(new CalculateSubtotal() {Name = "Subtotal calculator"})
                    .Register(new CalculateTax() {Name = "Tax calculator"})
                    .Register(new CalculateTotal() {Name = "Total calculator"})
                    .Register(new OutputResults() {Name = "Output results"})
                    ;

                prefilter.Execute();
            }
            catch (Exception ex)
            {
            }

            Console.WriteLine("".PadRight(50,'='));
            Console.ReadKey();
        }
    }   
}
