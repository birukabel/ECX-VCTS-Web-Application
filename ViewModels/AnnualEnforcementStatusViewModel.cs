using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class AnnualEnforcementStatusViewModel
    {
        public Guid ViolationCaseId { get; set; }
        public string ViolatorName { get; set; }
        public string ViolationType { get; set; }
        public string DateOfViolation { get; set; }
        public string DecisionSummary { get; set; }
        public string DecisionPassedDate { get; set; }
        public string EnforcementStatus { get; set; }
    }
}
