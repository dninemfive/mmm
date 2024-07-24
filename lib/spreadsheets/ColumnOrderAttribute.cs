using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class ColumnOrderAttribute(params string[] columns)
    : Attribute
{
    public readonly string[] Columns = columns;
    public static implicit operator string[](ColumnOrderAttribute columnOrder)
        => columnOrder.Columns;
}
