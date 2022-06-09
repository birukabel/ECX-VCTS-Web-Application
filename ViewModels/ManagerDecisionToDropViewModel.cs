using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class ManagerDecisionToDropViewModel
    {
        public Guid ManagerDecisionId { get; set; }
        public string ViolationType { get; set; }
        [DisplayName("Manager Remark on Decision")]
        public string ManagerDecisionRemark { get; set; }
        public OthersViewModel Others { get; set; }
        public QualityViewModel Quality { get; set; }
        public SurveillanceViewModel Surveillance { get; set; }
        public TradeViewModel Trade { get; set; }
    }
}
