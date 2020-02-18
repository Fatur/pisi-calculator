using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pisi.CalculatorApi.Requests
{
    public class CalculateFormulaRequest
    {
        public string Formula { get; set; }
        public Attendance Attandance { get; set; }
    }
}
