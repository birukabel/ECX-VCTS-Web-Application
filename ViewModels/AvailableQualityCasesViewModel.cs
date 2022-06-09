using ECX.VCTS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class AvailableQualityCasesViewModel
    {
        [DisplayName("Investigator Name")]
        public string InvestigatorName { get; set; }
        public ViolationCaseModel ViolationCase { get; set; }
        public QualityViolationAttributesModel QualityCase { get; set; }
    }
}
