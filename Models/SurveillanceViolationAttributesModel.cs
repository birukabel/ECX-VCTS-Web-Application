using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Models
{
    public class SurveillanceViolationAttributesModel
    {
        public Guid SurveillanceViolationAttributesId { get; set; }
        [DisplayName("Violation Date")]
        public string ViolationDate { get; set; }
        [DisplayName("Incident Occured")]
        public string Incident { get; set; }
        [DisplayName("Further Explanation")]
        public string FurtherExplanation { get; set; }
        [DisplayName("Evidences Found")]
        public string Evidences { get; set; }
        [DisplayName("Witnesses")]
        public string Witnesses { get; set; }
        [DisplayName("Further Comment")]
        public string FurtherComment { get; set; }
        [DisplayName("Type of Alert")]
        public string TypeOfAlert { get; set; }
        [DisplayName("Seller Member Name")]
        public string SellMemberName { get; set; }
        [DisplayName("Buyer Member Name")]
        public string BuyMemberName { get; set; }
    }
}
