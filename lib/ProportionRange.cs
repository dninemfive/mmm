using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d9.mmm;
public readonly struct ProportionRange(double min, double max)
{
    public readonly double Minimum = min, Maximum = max;
    public override string ToString()
        => $"{Minimum:P2} - {Maximum:P2}";
    public static implicit operator ProportionRange((double min, double max) tuple)
        => new(tuple.min, tuple.max);
}
