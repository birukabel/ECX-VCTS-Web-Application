using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class CasesToDropViewModel
    {
        public string ViolationType { get; set; }
        public Guid CaseToDropId { get; set; }
        public List<OthersViewModel> OthersModel { get; set; }
        public List<QualityViewModel> QualityModel { get; set; }
        public List<SurveillanceViewModel> SurveillanceModel { get; set; }
        public List<TradeViewModel> TradeModel { get; set; }
    }
}
