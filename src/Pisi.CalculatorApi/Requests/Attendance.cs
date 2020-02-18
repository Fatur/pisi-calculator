using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pisi.CalculatorApi.Requests
{
    public class Attendance
    {
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public string Remark { get; set; }
    }
}
