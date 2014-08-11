using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Spike.Pipeline
{
    public interface IFilter<T>
    {
        string Name { get; set; }
        IEnumerable<T> Execute(IEnumerable<T> input);
    }
}