using ECX.VCTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ViewModels
{
    public class BCCPenaltyViewModel
    {
        public ViolationCaseModel PenalizedModel { get; set; }
        public bool IsChosen { get; set; }
        public Guid PenaltyId { get; set; }
        public List<ViolationCaseModel> violations { get; set; }
    }

    public class PenalizedViolationList
    {
        public List<BCCPenaltyViewModel> PenalizedList { get; set; }
    }
}
