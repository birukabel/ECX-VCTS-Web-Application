using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Models
{
    public class ViolationCaseModel
    {
        public Guid ViolationCaseId { get; set; }
        [DisplayName("Violation Type")]
        public string ViolationType { get; set; }
        [DisplayName("Case Status")]
        public string CaseStatus { get; set; }
        [DisplayName("Violation Summary")]
        public string ViolationSummary { get; set; }
        [DisplayName("Investigator Summary")]
        public string InvestigatorSummary { get; set; }
        [DisplayName("Supporting Documents")]
        public string SupportingDocuments { get; set; }
        [DisplayName("Penalty Type")]
        public string PenaltyType { get; set; }
        [DisplayName("Alleged violator")]
        public string ViolatorName { get; set; }
        [DisplayName("Investigator Document")]
        public string InvestigatorDocument { get; set; }
        [DisplayName("Exchange Center Name")]
        public string ExchangeCenterName { get; set; }
        [DisplayName("Investigator Name")]
        public string InvestigatorName { get; set; }
        [DisplayName("Manager Remark")]
        public string ManagerRemark { get; set; }
        [DisplayName("Reason to Drop")]
        public string ReasontoDrop { get; set; }
        [DisplayName("Amount Penalized")]
        public double AmountPenalized { get; set; }
        [DisplayName("Suspension Begining Date")]
        public string SuspensionBeginingDate { get; set; }
        [DisplayName("Suspension End Date")]
        public string SuspensionEndDate { get; set; }
        [DisplayName("Termination Date")]
        public string TerminationDate { get; set; }
        [DisplayName("Decision Passed Date")]
        public string DecisionPassedDate { get; set; }
        [DisplayName("Date of Assignment")]
        public string AssignDate { get; set; }
        [DisplayName("Reported Date")]
        public string ReportDate { get; set; }
        [DisplayName("Late For")]
        public int DateDiffPen { get; set; }
        [DisplayName("Late For")]
        public int DateDiffOC { get; set; }

        [DisplayName("Remaining Days")]
        public int DateDiffSus { get; set; }
        [DisplayName("Documents or Evidences to Upload")]

        public IFormFile SupportingFile { get; set; }
        [DisplayName("BCC Decision Summary")]
        public string BCCDecisionSummary { get; set; }
    }
}
