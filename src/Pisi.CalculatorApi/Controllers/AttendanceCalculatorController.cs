using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pisi.Calculator;
using Pisi.CalculatorApi.ACL;
using Pisi.CalculatorApi.Requests;
using Pisi.CalculatorApi.Responses;

namespace Pisi.CalculatorApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttendanceCalculatorController :ControllerBase
    {

        private IStaticDataRepository mstaticRepo;
        public AttendanceCalculatorController(IStaticDataRepository staticRepo)
        {
            mstaticRepo = staticRepo;
        }
        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] CalculateFormulaRequest postRequest)
        {
            var calc = new AttendanceCalculator();
            await calc.LoadCompanyStaticDataAsConstantAsync(mstaticRepo);
            var result = calc.Calculate(postRequest.Formula,await postRequest.Attandance.ToAttendanceDataAsync(mstaticRepo));

            return Ok(new FormulaCalculatedResponse { Result=result });
        }
    }
}
