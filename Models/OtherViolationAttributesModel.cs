using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Models
{
    public class OtherViolationAttributesModel
    {
        public Guid OtherViolationAttributesId { get; set; }
        [DisplayName("Violation Date")]
        public string ViolationDate { get; set; }
        [DisplayName("Incident Occured")]
        public string Incident { get; set; }
        [DisplayName("Further Explanation")]
        public string Evidences { get; set; }
        [DisplayName("Witnesses")]
        public string Witnesses { get; set; }
        [DisplayName("Further Comment")]
        public string FurtherComment { get; set; }
    }
}
