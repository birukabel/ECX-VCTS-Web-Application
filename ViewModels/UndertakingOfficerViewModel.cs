using ECX.VCTS.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class UndertakingOfficerViewModel
    {
        public ViolationCaseModel violationModel { get; set; }
        public QualityViolationAttributesModel qualityModel { get; set; }
        public UndertakingOfficerModel officerModel { get; set; }
        [DisplayName("Upload Signed Document or Evidence of Missing Attributes")]
        public IFormFile UploadedDocument { get; set; }
    }
}
