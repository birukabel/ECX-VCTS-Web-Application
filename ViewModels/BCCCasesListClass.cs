using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class BCCCasesListClassSecond
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
        //[DisplayName("Violation Summary")]

    }
}
