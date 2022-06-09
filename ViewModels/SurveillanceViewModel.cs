using ECX.VCTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class SurveillanceViewModel
    {
        public ViolationCaseModel ViolationModel { get; set; }
        public SurveillanceViolationAttributesModel SurveillanceModel { get; set; }
        public bool IsActive { get; set; }
    }
}
