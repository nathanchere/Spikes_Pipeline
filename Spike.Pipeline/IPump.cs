using System.Collections.Generic;

namespace Spike.Pipeline
{
    public interface IPump<T>
    {
        IEnumerable<T> Execute();
    }
}