using System;
using System.Collections.Generic;
using Spike.Pipeline;

namespace Spike.Pipeline{
    public abstract class Filter<T> : IFilter<T>
    {        
        public IEnumerable<T> Execute(IEnumerable<T> input)
        {
            long inputCount = 0;
            long outputCount = 0;

            foreach (var item in input)
            {
                inputCount++;
                bool doYield = false;
                T toReturn = item;

                try
                {
                    toReturn = DoOperation(item);
                    doYield = toReturn != null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0} had a problem processing item {1}", Name, item);
                }

                if (doYield)
                {
                    outputCount++;
                    yield return toReturn;
                }
            }

            Console.WriteLine("{0} processed {1} items, and filtered out {2} items", Name, inputCount, inputCount - outputCount);
        }

        public abstract T DoOperation(T input);

        public string Name { get; set; }
    }


}
