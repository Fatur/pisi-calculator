using Pisi.Calculator;
using Pisi.CalculatorApi.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pisi.CalculatorApi.ACL
{
    public static class TransformerExtentions
    {
        public static async Task<AttendanceData> ToAttendanceDataAsync(this Attendance attendance, IStaticDataRepository staticData)
        {

            var transformed = new AttendanceData();
            if (attendance != null)
            {
                transformed.DateIn = attendance.DateIn;
                transformed.DateOut = attendance.DateOut;
                transformed.Remark = await FindRemarkIdAsync(staticData, attendance.Remark);
            }
            return transformed;
        }

        private static async Task<int> FindRemarkIdAsync(IStaticDataRepository staticData, string remarkCode)
        {
            if (remarkCode == null)
                return 0;
            else
            {
                var listOfRemark = await staticData.LoadRemarkAsync();
                var remark = listOfRemark.Where(x => x.Code.ToLower().Equals(remarkCode.ToLower()))
                                        .FirstOrDefault();
                if (remark != null)
                    return (int)remark.Value;
                else
                    return 0;
            }
        }
    }
}
