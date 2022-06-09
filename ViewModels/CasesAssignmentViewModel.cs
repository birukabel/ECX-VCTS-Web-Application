using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class CasesAssignmentViewModel
    {
        public string InvestigatorName { get; set; }
        public List<SurveillanceViewModel> SurveillanceModel { get; set; }
        public List<TradeViewModel> TradeModel { get; set; }
        public List<OthersViewModel> OthersModel { get; set; }
        [DisplayName("Select Violation type")]
        public string ViolationType { get; set; }
        [DisplayName("Alleged Violator")]
        public string ViolatorName { get; set; }
        [DisplayName("Reported Date")]
        public string ReportDate { get; set; }
        public IEnumerable<SelectListItem> ViolationTypes { get; set; }
    }
}
