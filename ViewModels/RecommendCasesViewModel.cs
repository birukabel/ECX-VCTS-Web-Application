using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class RecommendCasesViewModel
    {
        public Guid RecommendId { get; set; }
        public string ViolationType { get; set; }
        [DisplayName("Summary of Case")]
        public string InvestigatorSummary { get; set; }
        public OthersViewModel Others { get; set; }
        public QualityViewModel Quality { get; set; }
        public SurveillanceViewModel Surveillance { get; set; }
        public TradeViewModel Trade { get; set; }
    }
}
