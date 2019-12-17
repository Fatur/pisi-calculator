using Jace;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisi.Calculator
{
    public static class PisiFunctions
    {
        public static void AddPisiFunctions(this CalculationEngine calculator)
        {
            AddIIFFunction(calculator);
        }

        private static void AddIIFFunction(CalculationEngine calculator)
        {
            calculator.AddFunction("iif", (a, b, c) => a != 0.0 ? b : c);
        }
    }
}
