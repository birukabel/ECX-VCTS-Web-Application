using ECX.VCTS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class NotificationsViewModel
    {
        public Guid ViolationCaseId { get; set; }
        [DisplayName("Decision Passed Date")]
        public string DecisionPassedDate { get; set; }
        [DisplayName("Assign Date")]
        public string AssignDate { get; set; }
        [DisplayName("Violation Summary")]
        public string ViolationSummary { get; set; }
        [DisplayName("Investigator Summary")]
        public string InvestigatorSummary { get; set; }
        [DisplayName("Alleged Violation Name")]
        public string ViolatorName { get; set; }
        [DisplayName("Investigator Name")]
        public string InvestigatorName { get; set; }
        [DisplayName("Exchange Center Name")]
        public string ExchangeCenterName { get; set; }
        [DisplayName("Violation Type")]
        public string ViolationType { get; set; }

        public int OverdueCaseCount { get; set; }
        public int ExtendedCasesCount { get; set; }
        public int PenalizedCasesCount { get; set; }
        public int OverduePenaltyCount { get; set; }
        public int FirstNoticeCount { get; set; }
        public int SecondNoticeCount { get; set; }
        public int SuspensionsToLiftCount { get; set; }
        public int UnenforcedCount { get; set; }
        [DisplayName("Late For")]
        public int DateDiffPen { get; set; }
        [DisplayName("Late For")]
        public int DateDiffOC { get; set; }
        [DisplayName("Remaining Days")]
        public int DateDiffSus { get; set; }
        [DisplayName("BCC Decision Summary")]
        public string BCCDecisionSummary { get; set; }

        public IEnumerable<SelectListItem> Investigators { get; set; }

        public List<ViolationCaseModel> OverdueCasesList = new List<ViolationCaseModel>();
        public List<ViolationCaseModel> ExtendedCasesList = new List<ViolationCaseModel>();
        public List<ViolationCaseModel> PenalizedCasesList = new List<ViolationCaseModel>();
        public List<ViolationCaseModel> OverduePenalizedCasesList = new List<ViolationCaseModel>();
        public List<ViolationCaseModel> PenalizedFirstNoticeList = new List<ViolationCaseModel>();
        public List<ViolationCaseModel> PenalizedSecondNoticeList = new List<ViolationCaseModel>();
        public List<ViolationCaseModel> SuspensionsToLiftCasesList = new List<ViolationCaseModel>();
        public List<ViolationCaseModel> UnenforcedOverduePenalizedList = new List<ViolationCaseModel>();
        public List<ViolationCaseModel> AllViolationCases = new List<ViolationCaseModel>();
    }
}
