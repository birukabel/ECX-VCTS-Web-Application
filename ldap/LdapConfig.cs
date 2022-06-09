using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ldap
{
    public class LdapConfig
    {
        /// <summary>
        /// Strongly type setup AD 
        /// </summary>
        public string LdapHost { get; set; }
        public string LoginDN { get; set; }
        public string Password { get; set; }
        public int LdapPort { get; set; }
        public string SearchBase { get; set; }
        public string SearchFilter { get; set; }

    }
}
