using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Models
{
    public class UndertakingOfficerModel
    {
        public Guid ComplianceUndertakingId { get; set; }
        public Guid QualityViolationsAttributeId { get; set; }
        [DisplayName("Upload Signed Document or Evidence of Missing Attributes")]
        //[UnsupportedFileFormat]
        public string SignedDocument { get; set; }
        [DisplayName("Name of Person who Prepared the Document")]
        public string PreparedBy { get; set; }
        [DisplayName("Document Signed Date")]
        public string SignedDate { get; set; }
        [DisplayName("Document Posted Date")]
        public string UploadDate { get; set; }
        [DisplayName("Choose Action")]
        public string ActionChosen { get; set; }

        public bool IsSigned { get; set; }
    }
}
