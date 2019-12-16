using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Runtime;
using Pisi.CalculatorInterfaces;
using System.Threading.Tasks;

namespace Pisi.CalculatorGrains
{
    public class AttandanceCalculatorGrain : Grain, IAttandanceCalculator
    {
        private readonly IPersistentState<AttandanceClassification> mclassification;
        private readonly ILogger mlogger;
        public AttandanceCalculatorGrain(ILogger<AttandanceCalculatorGrain> logger, 
            [PersistentState("tblClassification", "profileStore")] IPersistentState<AttandanceClassification> classification)
        {
            mlogger = logger;
            mclassification = classification;
        }
        public Task<AttandanceCalculationResult> Calculate(AttandanceData data)
        {
            if (mlogger.IsEnabled(LogLevel.Warning))
                mlogger.LogWarning("Test Logging debug Enabled");
            return Task.FromResult(new AttandanceCalculationResult { EmployeeId=this.GetPrimaryKeyString() });
        }
    }
}
