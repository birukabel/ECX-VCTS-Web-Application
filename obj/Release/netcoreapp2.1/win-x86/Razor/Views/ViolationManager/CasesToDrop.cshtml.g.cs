#pragma checksum "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15f100cef82ca3c503c45e7d5def166cc730d81c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ViolationManager_CasesToDrop), @"mvc.1.0.view", @"/Views/ViolationManager/CasesToDrop.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ViolationManager/CasesToDrop.cshtml", typeof(AspNetCore.Views_ViolationManager_CasesToDrop))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\_ViewImports.cshtml"
using ECX.VCTS;

#line default
#line hidden
#line 2 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\_ViewImports.cshtml"
using ECX.VCTS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15f100cef82ca3c503c45e7d5def166cc730d81c", @"/Views/ViolationManager/CasesToDrop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4879086291623894965006ec21c2edb233fc2b", @"/Views/_ViewImports.cshtml")]
    public class Views_ViolationManager_CasesToDrop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ECX.VCTS.ViewModels.CasesToDropViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
  
    ViewData["Title"] = "CasesToDrop";
    ViewBag.Dubtitle = "Cases Suggested to be Dropped by Incestigators";

#line default
#line hidden
            BeginContext(170, 86, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(257, 90, false);
#line 11 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
           Write(Html.DisplayNameFor(m => m.OthersModel.FirstOrDefault().ViolationModel.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(347, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(403, 88, false);
#line 14 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
           Write(Html.DisplayNameFor(m => m.OthersModel.FirstOrDefault().ViolationModel.ViolationSummary));

#line default
#line hidden
            EndContext();
            BeginContext(491, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(547, 84, false);
#line 17 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
           Write(Html.DisplayNameFor(m => m.OthersModel.FirstOrDefault().ViolationModel.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(631, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(687, 85, false);
#line 20 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
           Write(Html.DisplayNameFor(m => m.OthersModel.FirstOrDefault().ViolationModel.ViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(772, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <td></td>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 26 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
         if (Model.OthersModel.Count > 0)
        {
            

#line default
#line hidden
#line 28 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
             foreach (var item in Model.OthersModel)
            {

#line default
#line hidden
            BeginContext(981, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1054, 68, false);
#line 32 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(1122, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1202, 66, false);
#line 35 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationSummary));

#line default
#line hidden
            EndContext();
            BeginContext(1268, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1348, 62, false);
#line 38 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(1410, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1490, 63, false);
#line 41 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(1553, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1633, 103, false);
#line 44 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.ActionLink("Review To Decide", "ReviewToDecide", new { id = item.ViolationModel.ViolationCaseId }));

#line default
#line hidden
            EndContext();
            BeginContext(1736, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 47 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
            }

#line default
#line hidden
#line 47 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
             
        }

#line default
#line hidden
            BeginContext(1814, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 49 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
         if (Model.QualityModel.Count > 0)
        {
            

#line default
#line hidden
#line 51 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
             foreach (var item in Model.QualityModel)
            {

#line default
#line hidden
            BeginContext(1939, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2012, 68, false);
#line 55 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(2080, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2160, 66, false);
#line 58 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationSummary));

#line default
#line hidden
            EndContext();
            BeginContext(2226, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2306, 62, false);
#line 61 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(2368, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2448, 63, false);
#line 64 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(2511, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2591, 103, false);
#line 67 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.ActionLink("Review To Decide", "ReviewToDecide", new { id = item.ViolationModel.ViolationCaseId }));

#line default
#line hidden
            EndContext();
            BeginContext(2694, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 70 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
            }

#line default
#line hidden
#line 70 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
             
        }

#line default
#line hidden
            BeginContext(2772, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 72 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
         if (Model.SurveillanceModel.Count > 0)
        {
            

#line default
#line hidden
#line 74 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
             foreach (var item in Model.SurveillanceModel)
            {

#line default
#line hidden
            BeginContext(2907, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2980, 68, false);
#line 78 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(3048, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3128, 66, false);
#line 81 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationSummary));

#line default
#line hidden
            EndContext();
            BeginContext(3194, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3274, 62, false);
#line 84 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(3336, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3416, 63, false);
#line 87 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(3479, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3559, 103, false);
#line 90 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.ActionLink("Review To Decide", "ReviewToDecide", new { id = item.ViolationModel.ViolationCaseId }));

#line default
#line hidden
            EndContext();
            BeginContext(3662, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 93 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
            }

#line default
#line hidden
#line 93 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
             
        }

#line default
#line hidden
            BeginContext(3740, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 95 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
         if (Model.TradeModel.Count > 0)
        {
            

#line default
#line hidden
#line 97 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
             foreach (var item in Model.TradeModel)
            {

#line default
#line hidden
            BeginContext(3861, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3934, 68, false);
#line 101 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(4002, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4082, 66, false);
#line 104 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationSummary));

#line default
#line hidden
            EndContext();
            BeginContext(4148, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4228, 62, false);
#line 107 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(4290, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4370, 63, false);
#line 110 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(4433, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4513, 103, false);
#line 113 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
                   Write(Html.ActionLink("Review To Decide", "ReviewToDecide", new { id = item.ViolationModel.ViolationCaseId }));

#line default
#line hidden
            EndContext();
            BeginContext(4616, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 116 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
            }

#line default
#line hidden
#line 116 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationManager\CasesToDrop.cshtml"
             
        }

#line default
#line hidden
            BeginContext(4694, 26, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ECX.VCTS.ViewModels.CasesToDropViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591