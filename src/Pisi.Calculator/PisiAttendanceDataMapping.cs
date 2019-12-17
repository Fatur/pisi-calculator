using System;
using System.Collections.Generic;
using System.Text;

namespace Pisi.Calculator
{
    internal class PisiAttendanceDataMapping
    {
        public static Dictionary<string, double> CreateAttendanceDataDictionary(AttendanceData attData)
        {
            Dictionary<string, double> attandance = new Dictionary<string, double>();
            attandance.Add("Regular", attData.Regular);
            attandance.Add("Remark", attData.Remark);
            return attandance;
        }
    }
}
