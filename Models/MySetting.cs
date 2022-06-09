using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Models
{
    public class MySetting
    {
        public string DefaultConnectionstring { get; set; }
        public string ECXMembershipConnectionstring { get; set; }
        public string ECXLookupConnectionstring { get; set; }
        public string ECXGRNConnectionstring { get; set; }
        public string Url { get; set; }

    }
}
