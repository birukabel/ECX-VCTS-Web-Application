#pragma checksum "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e48d07b65a1325bc4df270bca605f03af327ff00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ViolationManager_PassBCC), @"mvc.1.0.view", @"/Views/ViolationManager/PassBCC.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ViolationManager/PassBCC.cshtml", typeof(AspNetCore.Views_ViolationManager_PassBCC))]
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
#line 1 "E:\Tariku\Finalized\ECX.VCTS\Views\_ViewImports.cshtml"
using ECX.VCTS;

#line default
#line hidden
#line 2 "E:\Tariku\Finalized\ECX.VCTS\Views\_ViewImports.cshtml"
using ECX.VCTS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e48d07b65a1325bc4df270bca605f03af327ff00", @"/Views/ViolationManager/PassBCC.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4879086291623894965006ec21c2edb233fc2b", @"/Views/_ViewImports.cshtml")]
    public class Views_ViolationManager_PassBCC : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ECX.VCTS.ViewModels.BCCCasesViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DecideSelectedBCCCases", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ViolationManager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
  
    ViewData["Title"] = "Pass BCC Decision";
    ViewBag.Subtitle = "List of Cases Recommended for BCC Decision";

#line default
#line hidden
            BeginContext(184, 131, true);
            WriteLiteral("\r\n<div id=\"zero\" hidden>\r\n    <h2 style=\"text-align:center\">No Cases Ready for Decision!!!</h2>\r\n</div>\r\n\r\n<div id=\"nonzero\">\r\n    ");
            EndContext();
            BeginContext(315, 670, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b4538f60830649b89cb0792fc8a0c280", async() => {
                BeginContext(404, 574, true);
                WriteLiteral(@"

        <table class=""table"">
            <tbody>
                <tr id=""searchcol"">
                    <td align=""center"">
                        <b>Alleged Violator Name:</b>
                        <input class=""violatorboxcls"" type=""text"" id=""violatorbox""
                               placeholder=""Alleged Violator Name"" name=""violatorname"" ViolatorName />
                        <input type=""submit"" value=""Search"" id=""srchbtn"" class=""btn btn-primary"" />
                    </td>
                </tr>
            </tbody>
        </table>

    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(985, 155, true);
            WriteLiteral("\r\n\r\n    <div id=\"resultarea\">\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1141, 64, false);
#line 35 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
                   Write(Html.DisplayNameFor(m => m.FirstOrDefault().ViolationCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(1205, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1285, 61, false);
#line 38 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
                   Write(Html.DisplayNameFor(m => m.FirstOrDefault().ViolationSummary));

#line default
#line hidden
            EndContext();
            BeginContext(1346, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1426, 65, false);
#line 41 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
                   Write(Html.DisplayNameFor(m => m.FirstOrDefault().DecisionViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(1491, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1571, 66, false);
#line 44 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
                   Write(Html.DisplayNameFor(m => m.FirstOrDefault().DecisionViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(1637, 95, true);
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 49 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(1797, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1882, 54, false);
#line 53 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ViolationCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(1936, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2028, 51, false);
#line 56 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ViolationSummary));

#line default
#line hidden
            EndContext();
            BeginContext(2079, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2171, 55, false);
#line 59 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DecisionViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(2226, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2318, 56, false);
#line 62 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DecisionViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(2374, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 65 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
                }

#line default
#line hidden
            BeginContext(2453, 68, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2538, 100, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n\r\n        $(document).ready(function () {\r\n\r\n            if (");
                EndContext();
                BeginContext(2639, 20, false);
#line 79 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\PassBCC.cshtml"
           Write(Model.ToList().Count);

#line default
#line hidden
                EndContext();
                BeginContext(2659, 226, true);
                WriteLiteral(" > 0) {\r\n                $(\'#nonzero\').show();\r\n                $(\'#zero\').hide();\r\n            } else {\r\n                $(\'#nonzero\').hide();\r\n                $(\'#zero\').show();\r\n            }\r\n        });\r\n\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(2888, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ECX.VCTS.ViewModels.BCCCasesViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
