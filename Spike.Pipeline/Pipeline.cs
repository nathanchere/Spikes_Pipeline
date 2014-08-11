using System;
using System.Collections.Generic;

namespace Spike.Pipeline
{
    public class Pipeline<T>
    {
        private readonly IPump<T> _pump;
        private readonly IDataSink<T> _sink;
        private readonly string _pipelineName;
        private readonly List<Filter<T>> _operations = new List<Filter<T>>();

        public Pipeline(IPump<T> pump, IDataSink<T> sink, string pipelineName = "")
        {
            _pump = pump;
            _sink = sink;
            _pipelineName = pipelineName;
        }

        public Pipeline<T> Register(Filter<T> operation)
        {
            _operations.Add(operation);
            return this;
        }

        public void Execute()
        {
            Console.WriteLine("Starting the pipeline - {0}", _pipelineName);

            IEnumerable<T> current = _pump.Execute();

            Console.WriteLine("Fetched items from pump");

            foreach (IFilter<T> operation in _operations)
            {
                current = operation.Execute(current);
            }

            _sink.Execute(current);

            Console.WriteLine("Completed pipeline - {0}", _pipelineName);
        }
    }
}