using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Models
{
    public class ViolationCaseHistory
    {
        public Guid ViolationCaseHistoryId { get; set; }
        public Guid ViolationCaseId { get; set; }
        public string StatusName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
