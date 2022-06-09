
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Models
{
	public class ViolationCaseBulk
	{
		public Guid  ViolationCaseId{set;get;}
		public string ViolationType { set; get; }
		public string CaseStatus { get; set; }
        public string ViolationSummary { get; set; }
        public bool InvestigatorAssigned { get; set; }
        public string SupportingDocuments { get; set; }
        public DateTime AssignDate { get; set; }
        public string InvestigatorSummary { get; set; }
        public string PenaltyType { get; set; }
        public bool PenaltyPaid { get; set; }
        public DateTime SuspensionBeginingDate { get; set; }
        public DateTime SuspensionEndDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string ViolatorName { get; set; }
        public decimal AmountPenalized { get; set; }
        public DateTime DecisionPassedDate { get; set; }
        public bool Notified { get; set; }
        public string InvestigatorDocuments { get; set; }
        public string PenaltyNotice { get; set; }
        public string ExchangeCenterName { get; set; }
        public string InvestigatorName { get; set; }
        public string ReasontoDrop { get; set; }
        public DateTime ReportDate { get; set; }
        public string ManagerRemark { get; set; }
        public string ReportedBy { get; set; }
        public string Enforcement { get; set; }
        public string BCCSummary { get; set; }
        public Guid BCCDecisionId { get; set; }
    }
}
