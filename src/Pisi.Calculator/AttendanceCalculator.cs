using Jace;
using System;
using System.Collections.Generic;

namespace Pisi.Calculator
{
    public class AttendanceCalculator
    {
        private CalculationEngine mcalcEnggine;
        public AttendanceCalculator()
        {
            mcalcEnggine = new CalculationEngine();
            mcalcEnggine.AddPisiFunctions();
        }

        public double Calculate(string statement, AttendanceData attData)
        {
            var dataDict = PisiAttendanceDataMapping.CreateAttendanceDataDictionary(attData);
            return mcalcEnggine.Calculate(statement, dataDict);
        }

        public double Calculate(string statement)
        {
            return mcalcEnggine.Calculate(statement);
        }

        public AttendanceCalculationResult Calculate(AttendanceFormula attFormula, AttendanceData attData)
        {
            return new AttendanceCalculationResult
            {
                OT = Calculate(attFormula.OT, attData),
                OT1 = Calculate(attFormula.OT1, attData)
            };
        }

        public AttendanceCalculationResult Calculate(IAttendanceClassification classification, AttendanceData attData)
        {
            var formulas = classification.LoadFormulasById(attData.Classification);
            return Calculate(formulas, attData);
        }
    }
}
