using ECX.VCTS.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class SentBackCasesViewModel
    {
        public QualityViolationAttributesModel qualityModel { get; set; }
        public ViolationCaseModel violationModel { get; set; }
        [DisplayName("Change Evidence ?")]
        public bool EvidenceModifiable { get; set; }
        [DisplayName("Upload Modified Evidence")]
        public IFormFile ChangedEvidence { get; set; }
    }
}
