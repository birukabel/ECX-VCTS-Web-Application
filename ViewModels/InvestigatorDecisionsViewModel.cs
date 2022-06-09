using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class InvestigatorDecisionsViewModel

    {
        public Guid DecisionId { get; set; }
        public string ViolationType { get; set; }
        public string ReportDate { get; set; }
        [DisplayName("Summary of Decision on  Case")]
        public string InvestigatorDecisionSummary { get; set; }
        [DisplayName("Evidences Supporting your Decision")]
        public IFormFile InvestigatorEvidence { get; set; }
        public OthersViewModel Others { get; set; }
        public QualityViewModel Quality { get; set; }
        public SurveillanceViewModel Surveillance { get; set; }
        public TradeViewModel Trade { get; set; }
    }
}
