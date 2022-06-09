using ECX.VCTS.Models;
using ECXSecurityAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ECX.VCTS
{
    public class SecurityController : Controller
    {
        /// <summary>
        /// To get user access right from web service 
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="endpoint"></param>
        /// <returns>List of rights</returns>
        public List<SecurityRights> GetUserRights(string userGuid, string endpoint)
        {
            string[] right = Enum.GetNames(typeof(SecurityRights));
            int length = right.Count();
            int[] permission = new int[length];
            List<SecurityRights> userRights = new List<SecurityRights>();
            //try {
            for (int i = 0; i < right.Count(); i++)
            {
                //---To Fetch right from web service
                ECXSecurityAccessSoapClient soapObj = new ECXSecurityAccessSoapClient(new BasicHttpBinding(), new EndpointAddress(endpoint));
                var access = soapObj.HasRightAsync(userGuid, right[i], "").Result;
                permission[i] = Convert.ToInt32(access.Body.HasRightResult);

                //---To check if permission has granted and add to userright list
                if ((SecurityPermissions)permission[i] == SecurityPermissions.Grant || (SecurityPermissions)permission[i] == SecurityPermissions.GrantAllLocation)
                {
                    userRights.Add((SecurityRights)Enum.Parse(typeof(SecurityRights), right[i]));
                }

            }
            //    }
            //catch(Exception e) {
            //    Console.WriteLine(e);
            //}

            return userRights;
        }

    }
}
