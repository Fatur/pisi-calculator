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
            mcalcEnggine.AddPisiConstants();
        }

        public double Calculate(string statement, AttendanceData attData)
        {
            var dataDict = PisiAttendanceDataMapping.CreateAttendanceDataDictionary(attData);
            var formula = statement.TransformToJaceFormat();
            return mcalcEnggine.Calculate(formula, dataDict);
        }

        public double Calculate(string statement)
        {
            return mcalcEnggine.Calculate(statement.TransformToJaceFormat());
        }

        public void LoadCompanyStaticDataAsConstant(IStaticDataRepository staticDataRepo)
        {
            var remarks = staticDataRepo.LoadRemark();
            foreach (Remark remark in remarks)
            {
                mcalcEnggine.AddConstant(remark.Code,remark.Value);
            }
        }

        public AttendanceCalculationResult Calculate(AttendanceFormula attFormula, AttendanceData attData)
        {
            return new AttendanceCalculationResult
            {
                AbsentDay = Calculate(attFormula.AbsentDay, attData),
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
