#pragma checksum "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0933b5928467a4275ef8f133d5fa14007015d6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ViolationReporter_SentBackCases), @"mvc.1.0.view", @"/Views/ViolationReporter/SentBackCases.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ViolationReporter/SentBackCases.cshtml", typeof(AspNetCore.Views_ViolationReporter_SentBackCases))]
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
#line 1 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\_ViewImports.cshtml"
using ECX.VCTS;

#line default
#line hidden
#line 2 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\_ViewImports.cshtml"
using ECX.VCTS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0933b5928467a4275ef8f133d5fa14007015d6c", @"/Views/ViolationReporter/SentBackCases.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4879086291623894965006ec21c2edb233fc2b", @"/Views/_ViewImports.cshtml")]
    public class Views_ViolationReporter_SentBackCases : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ECX.VCTS.ViewModels.SentBackCasesViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
  
    ViewData["Title"] = "SentBackCases";
    ViewBag.Subtitle = "Sent Back Violation Cases to Review and Modify";

#line default
#line hidden
            BeginContext(187, 219, true);
            WriteLiteral("\r\n<div id=\"zero\" hidden>\r\n    <h2 style=\"text-align:center\">No Sent Back Cases</h2>\r\n</div>\r\n\r\n<div id=\"nonzero\">\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(407, 78, false);
#line 16 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
               Write(Html.DisplayNameFor(m => m.FirstOrDefault().violationModel.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(485, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(553, 72, false);
#line 19 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
               Write(Html.DisplayNameFor(m => m.FirstOrDefault().violationModel.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(625, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(693, 75, false);
#line 22 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
               Write(Html.DisplayNameFor(m => m.FirstOrDefault().qualityModel.TotalNumberofBags));

#line default
#line hidden
            EndContext();
            BeginContext(768, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(836, 82, false);
#line 25 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
               Write(Html.DisplayNameFor(m => m.FirstOrDefault().qualityModel.UndertakingOfficerRemark));

#line default
#line hidden
            EndContext();
            BeginContext(918, 126, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 33 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1101, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1174, 68, false);
#line 37 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
                   Write(Html.DisplayFor(modelItem => item.violationModel.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(1242, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1322, 62, false);
#line 40 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
                   Write(Html.DisplayFor(modelItem => item.violationModel.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(1384, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1464, 65, false);
#line 43 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
                   Write(Html.DisplayFor(modelItem => item.qualityModel.TotalNumberofBags));

#line default
#line hidden
            EndContext();
            BeginContext(1529, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1609, 72, false);
#line 46 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
                   Write(Html.DisplayFor(modelItem => item.qualityModel.UndertakingOfficerRemark));

#line default
#line hidden
            EndContext();
            BeginContext(1681, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1761, 111, false);
#line 49 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
                   Write(Html.ActionLink("ReExamine Case", "ReExamineCase", new { id = item.qualityModel.QualityViolationsAttributeId }));

#line default
#line hidden
            EndContext();
            BeginContext(1872, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 52 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
            }

#line default
#line hidden
            BeginContext(1939, 46, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2002, 100, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n\r\n        $(document).ready(function () {\r\n\r\n            if (");
                EndContext();
                BeginContext(2103, 20, false);
#line 64 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SentBackCases.cshtml"
           Write(Model.ToList().Count);

#line default
#line hidden
                EndContext();
                BeginContext(2123, 226, true);
                WriteLiteral(" > 0) {\r\n                $(\'#nonzero\').show();\r\n                $(\'#zero\').hide();\r\n            } else {\r\n                $(\'#nonzero\').hide();\r\n                $(\'#zero\').show();\r\n            }\r\n        });\r\n\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(2352, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ECX.VCTS.ViewModels.SentBackCasesViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
