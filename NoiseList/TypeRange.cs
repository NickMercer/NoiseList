using System;
using System.Collections.Generic;
using System.Text;

namespace NoiseLists
{
    internal class TypeRange<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }

        public TypeRange(T min, T max)
        {
            Min = min;
            Max = max;
        }
    }
}
