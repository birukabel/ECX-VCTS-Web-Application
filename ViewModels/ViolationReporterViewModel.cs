using ECX.VCTS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class ViolationReporterViewModel
    {
        public ViolationCaseModel violationCases { get; set; }
        public SurveillanceViolationAttributesModel surveillanceModel { get; set; }
        public TradeViolationAttributesModel tradeModel { get; set; }
        public QualityViolationAttributesModel qualityModel { get; set; }
        public OtherViolationAttributesModel othersModel { get; set; }
        public IEnumerable<SelectListItem> ViolationTypes { get; set; }
        public IEnumerable<SelectListItem> QualitySubCategories { get; set; }
        public IEnumerable<SelectListItem> TradeTypes { get; set; }
        public IEnumerable<SelectListItem> Centers { get; set; }
        public IEnumerable<SelectListItem> Warehouses { get; set; }
    }
}
