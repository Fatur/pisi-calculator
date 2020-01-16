using Jace;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisi.Calculator
{
    public static class PisiConstants
    {
        public static void AddPisiConstants(this CalculationEngine calculator)
        {
            AddTrueFalseConstanta(calculator);
        }

        private static void AddTrueFalseConstanta(CalculationEngine calculator)
        {
            calculator.AddConstant("true", 1);
            calculator.AddConstant("false", 0);
        }
    }
}
