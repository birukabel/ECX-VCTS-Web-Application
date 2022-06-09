using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.ldap
{
    public class LdapAuthenticationService : IAuthenticationService
    {



        /// <summary>
        /// To get logged user details from AD using Directory Services
        /// </summary>
        /// <param name="name"></param>
        /// <returns>DirectoryEntry</returns>

        public System.DirectoryServices.DirectoryEntry getUserdetail(string name)
        {



            string username = name.Split('\\').Last();
            string Username = username.Replace(".", " ");
            //--- Code to use the current address for the LDAP and query it for the user---                  
            DirectorySearcher dssearch = new DirectorySearcher();
            dssearch.Filter = "(CN=" + Username + ")";
            SearchResult sresult = dssearch.FindOne();
            System.DirectoryServices.DirectoryEntry dsresult = sresult.GetDirectoryEntry();



            return dsresult;
        }

        /// <summary>
        /// To get employee Guid from AD using name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns>EmployeeGuid</returns>
        public Guid loadList(string Name)
        {
            Name = Name.ToUpper();
            List<Employee> empList = new List<Employee>();
            SearchResultCollection results = null;
            DirectorySearcher dssearch = new DirectorySearcher();
            Employee e = new Employee();
            dssearch.Filter = "(CN=" + Name + ")";

            SecurityController sc = new SecurityController();
            results = dssearch.FindAll();


            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].GetDirectoryEntry().Properties["CN"].Value != null && results[i].GetDirectoryEntry().Properties["CN"].Value.ToString().Contains(" ") == true)
                {
                    if (results[i].GetDirectoryEntry().Properties["CN"].Value.ToString().ToUpper().StartsWith(Name.ToUpper()) == true)
                    {

                        e.Name = results[i].GetDirectoryEntry().Properties["CN"].Value.ToString();
                        e.Guid = results[i].GetDirectoryEntry().Guid;
                        empList.Add(e);
                    }
                }
            }
            empList.Sort();


            return e.Guid;

        }

        public class Employee
        {
            public string Name { get; set; }
            public Guid Guid { get; set; }

        }
    }
}
