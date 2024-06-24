using Decider.Csp.Integer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d9.lcm.gui;
public class ModpackConstraintProblem
{
    public static void SolveProblem(Dictionary<string, int> desiredMods)
    {
        IEnumerable<VariableInteger> modIntegers = desiredMods.Select(x => new VariableInteger(x.Key, 0, 1));
        
    }
}
