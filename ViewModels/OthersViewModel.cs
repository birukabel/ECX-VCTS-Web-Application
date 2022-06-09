using ECX.VCTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class OthersViewModel
    {
        public ViolationCaseModel ViolationModel { get; set; }
        public OtherViolationAttributesModel OthersModel { get; set; }
        public bool IsActive { get; set; }
    }
}
