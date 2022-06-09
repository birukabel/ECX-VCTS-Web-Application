using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Models
{
    public class QualityViolationAttributesModel
    {
        public Guid QualityViolationsAttributeId { get; set; }
        [DisplayName("Arrival Date")]
        public string ArrivalDate { get; set; }
        [DisplayName("GRN Refernce Number")]
        //[Required(ErrorMessage = "GRN Refernce Number is Required")]
        public string GRNReference { get; set; }
        [DisplayName("Dispatch Number")]
        //[Required(ErrorMessage = "Dispatch Number is Required")]
        public string DispatchNumber { get; set; }
        [DisplayName("Authorized Representative Name")]
        //[Required(ErrorMessage = "Member Representative Name is Required")]
        public string MemberRepresentativeName { get; set; }
        [DisplayName("Driver Name")]
        //[Required(ErrorMessage = "Driver Name is Required")]
        public string DriverName { get; set; }
        [DisplayName("Truck Plate Number")]
        //[Required(ErrorMessage = "Truck Plate Number is Required")]
        public string TruckPlateNumber { get; set; }
        [DisplayName("Trailer Plate Number")]
        public string TrailerPlateNumber { get; set; }
        [DisplayName("Total Number of Bags")]
        //[Required(ErrorMessage = "Total Number of Bags is Required")]
        public int TotalNumberofBags { get; set; }
        [DisplayName("Number of Mixed or Adultrated Bags")]
        //[Required(ErrorMessage = "Number of Mixed or Adultrated Bags is Required")]
        public int NumberofAdultratedBags { get; set; }
        [DisplayName("Sampler Name")]
        //[Required(ErrorMessage = "Sampler Name is Required")]
        public string SamplerName { get; set; }
        [DisplayName("Sampling Inspector Name")]
        //[Required(ErrorMessage = "Sampling Inspector Name is Required")]
        public string SamplingInspectorName { get; set; }
        [DisplayName("Comment on the Sampling Ticket")]
        public string SamplingTicketComment { get; set; }
        [DisplayName("Laboratory Decision")]
        //[Required(ErrorMessage = "Laboratory Decision is Required")]
        public string LaboratoryDecision { get; set; }
        [DisplayName("Quality Grade Result")]
        //[Required(ErrorMessage = "Quality Grade Result is Required")]
        public string QualityGradeResult { get; set; }
        [DisplayName("Lab Result Comment")]
        public string LabResultComment { get; set; }
        [DisplayName("Violation Sub Category")]
        public string QualitySubCategory { get; set; }
        [DisplayName("State Reason to Send case Back")]
        public string UndertakingOfficerRemark { get; set; }
    }
}
