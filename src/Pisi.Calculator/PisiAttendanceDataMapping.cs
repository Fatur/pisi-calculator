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
            attandance.Add("DateIn", attData.DateIn.Ticks);
            attandance.Add("DateOut", attData.DateOut.Ticks);
            attandance.Add("DateOfDateIn", attData.DateIn.Date.Ticks);
            attandance.Add("DateOfDateOut", attData.DateOut.Date.Ticks);
            attandance.Add("TimeOfDateIn", attData.DateIn.TimeOfDay.Ticks);
            attandance.Add("TimeOfDateOut", attData.DateOut.TimeOfDay.Ticks);
            attandance.Add("IsNullDateIn", attData.DateIn.TimeOfDay.Ticks==new DateTime().Ticks?1:0);
            attandance.Add("IsNullDateOut", attData.DateOut.TimeOfDay.Ticks==new DateTime().Ticks?1:0);
            return attandance;
        }
    }
}
