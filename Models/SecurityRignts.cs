using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Models
{
    public class SecurityRight
    {

        public string SecurityRightVal { get; set; }
        public SecurityRights SecurityRightss { get; set; }
        public string SecurityPermissionVal { get; set; }
        public SecurityPermissions SecurityPermissionss { get; set; }

    }
    public enum SecurityRights
    {
        isInvestigator,
        isManager,
        isOfficer,
        isReporter,
        isSecretary,
        isUndertaker,
    }
    public enum SecurityPermissions
    {
        NotAssigned = 0,
        Grant = 1,
        Deny = 2,
        GrantAllLocation = 3
    }
}
