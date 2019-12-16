using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pisi.CalculatorInterfaces
{
    public interface IAttandanceCalculator:IGrainWithStringKey
    {
        Task<AttandanceCalculationResult> Calculate(AttandanceData data);
    }
}
