using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spike.Pipeline
{
    public interface IDataSink<T>
    {
        void Execute(IEnumerable<T> input);
    }
}
