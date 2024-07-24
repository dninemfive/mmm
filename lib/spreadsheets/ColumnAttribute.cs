using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm;
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class ColumnAttribute(int index, string? name = null) : Attribute
{
    public int Index = index;
    public string? Name = name;
}
