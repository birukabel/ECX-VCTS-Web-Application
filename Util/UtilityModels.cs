using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECX.VCTS.Util
{
    public class UtilityModels
    {
        public static IEnumerable<string> ExchangeCenters()
        {
            List<string> centerList = new List<string>();
            centerList.Add("Adama Nazreth");
            centerList.Add("Addis Ababa");
            centerList.Add("Dansha");
            centerList.Add("Humera");
            return centerList;
        }

        public static IEnumerable<string> ViolationTypes()
        {
            List<string> violationList = new List<string>();
            violationList.Add("Other");
            violationList.Add("Quality");
            violationList.Add("Surveillance");
            violationList.Add("Trade");
            return violationList;
        }

        public static IEnumerable<string> QualitySubCategories()
        {
            List<string> qualitySubs = new List<string>();
            qualitySubs.Add("Adultration");
            qualitySubs.Add("Segregation");
            qualitySubs.Add("Origin Mixing");
            qualitySubs.Add("Production Year Related");
            qualitySubs.Add("Other");
            return qualitySubs;
        }

        public static IEnumerable<string> PenaltyTypes()
        {
            List<string> penTypes = new List<string>();
            penTypes.Add("Financial");
            penTypes.Add("Suspension");
            penTypes.Add("Termination");
            return penTypes;
        }

        public static IEnumerable<string> CaseStatusTypes()
        {
            List<string> statusTypes = new List<string>();
            statusTypes.Add("Draft");
            statusTypes.Add("Waiting");
            statusTypes.Add("Sent Back");
            statusTypes.Add("To Drop");
            statusTypes.Add("Dropped");
            statusTypes.Add("Under Investigation");
            statusTypes.Add("Sent to BCC");
            statusTypes.Add("Penalized");
            return statusTypes;
        }

        public static IEnumerable<string> TradeTypes()
        {
            List<string> tradeList = new List<string>();
            tradeList.Add("e-Auction");
            tradeList.Add("e-trade");
            tradeList.Add("Out Cry");
            return tradeList;
        }
        public static IEnumerable<string> AllowedExtensions()
        {
            List<string> extList = new List<string>();
            extList.Add(".doc");
            extList.Add(".docx");
            extList.Add(".xlsx");
            extList.Add(".txt");
            extList.Add(".pdf");
            extList.Add(".png");
            extList.Add(".jpeg");
            extList.Add(".jpg");
            extList.Add(".gif");
            extList.Add(".rar");
            extList.Add(".zip");
            return extList;
        }

        public static IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();
            //if(some.GetType().FullName.Equals("ViolationCasesTrackingSystem."))
            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {

                    Value = element.ToString(),
                    Text = element.ToString()

                });

            }

            return selectList;
        }
    }
}
