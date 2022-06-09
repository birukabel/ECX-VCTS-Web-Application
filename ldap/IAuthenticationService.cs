using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ldap
{
    public interface IAuthenticationService
    {
        DirectoryEntry getUserdetail(string name);
        Guid loadList(string Name);

    }
}
