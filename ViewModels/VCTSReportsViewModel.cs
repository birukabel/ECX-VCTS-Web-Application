using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class VCTSReportsViewModel
    {
        public Guid ReportId { get; set; }
        [DisplayName("Date From")]
        public string DateFrom { get; set; }
        [DisplayName("Date To")]
        public string DateTo { get; set; }
        [DisplayName("Violation Type")]
        public string ViolationType { get; set; }

        [DisplayName("Case Status")]
        public string CaseStatus { get; set; }

        [DisplayName("Investigator")]
        public string InvestigatorName { get; set; }

        [DisplayName("Warehouse/Exchange Center")]
        public string ExchangeCenterName { get; set; }

        [DisplayName("Alleged Violator")]
        public string ViolatorName { get; set; }
        [DisplayName("Penalty type")]
        public string PenaltyType { get; set; }

        public List<OthersViewModel> OthersModel { get; set; }
        public List<QualityViewModel> QualityModel { get; set; }
        public List<SurveillanceViewModel> SurveillanceModel { get; set; }
        public List<TradeViewModel> TradeModel { get; set; }

        public IEnumerable<SelectListItem> Centers { get; set; }
        public IEnumerable<SelectListItem> Warehouses { get; set; }
        public IEnumerable<SelectListItem> ViolationTypes { get; set; }
        public IEnumerable<SelectListItem> PenaltyTypes { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }
        public IEnumerable<SelectListItem> Violators { get; set; }
        public IEnumerable<SelectListItem> StatusTypes { get; set; }
    }
}
