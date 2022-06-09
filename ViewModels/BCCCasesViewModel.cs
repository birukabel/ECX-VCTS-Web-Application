using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class BCCCasesViewModel
    {
        //public Guid BCCDecisionId { get; set; }
        public Guid ViolationCaseId { get; set; }
        [DisplayName("Violation Type To Pass Decision On")]
        public string DecisionViolationType { get; set; }
        [DisplayName("Allged Violator Name To Pass Decision Name")]
        public string DecisionViolatorName { get; set; }
        [DisplayName("Penalty Type Decided")]
        public string DecisionPenaltyType { get; set; }
        //[DisplayName("Amount Decided To Be Penalized")]
        //public double DecisionAmountPenalized { get; set; }
        //[DisplayName("Suspension Begining Date")]
        //public string SuspensionBeginingDate { get; set; }
        //[DisplayName("Suspension Ending Date")]
        //public string SuspensionEndingDate { get; set; }
        //[DisplayName("Termination Date")]
        //public string TerminationDate { get; set; }
        //[DisplayName("Decision Effective Date")]
        //public string DecisionPassedDate { get; set; }
        //[DisplayName("Passed Decision Summary")]
        //public string BCCSummary { get; set; }
        [DisplayName("Violation Summary")]
        public string ViolationSummary { get; set; }
        [DisplayName("Violation Center Name")]
        public string ViolationCenterName { get; set; }
        public bool IsActive { get; set; }
        //public IEnumerable<SelectListItem> PenaltyTypes { get; set; }
    }

    public class BCCCasesListClass
    {
        public Guid BCCDecisionId { get; set; }
        public List<BCCCasesViewModel> BCCCasesList { get; set; }
        public IEnumerable<SelectListItem> PenaltyTypes { get; set; }
        [DisplayName("Amount Decided To Be Penalized")]
        public double DecisionAmountPenalized { get; set; }
        [DisplayName("Suspension Begining Date")]
        public string SuspensionBeginingDate { get; set; }
        [DisplayName("Suspension Ending Date")]
        public string SuspensionEndingDate { get; set; }
        [DisplayName("Termination Date")]
        public string TerminationDate { get; set; }
        [DisplayName("Decision Effective Date")]
        public string DecisionPassedDate { get; set; }
        [DisplayName("Passed Decision Summary")]
        public string BCCSummary { get; set; }
        [DisplayName("Penalty Type Decided")]
        public string DecisionPenaltyType { get; set; }
        public bool IsActive { get; set; }

    }
}
