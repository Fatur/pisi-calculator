using System;
using System.Collections.Generic;
using System.Text;

namespace Pisi.Calculator
{
    public interface IAttendanceClassification
    {
        AttendanceFormula LoadFormulasById(string classId);
    }
}
