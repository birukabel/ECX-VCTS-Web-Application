#pragma checksum "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48b74599476efadec6a084f82550f2f1eaa39444"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ViolationManager_AssignCases), @"mvc.1.0.view", @"/Views/ViolationManager/AssignCases.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ViolationManager/AssignCases.cshtml", typeof(AspNetCore.Views_ViolationManager_AssignCases))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48b74599476efadec6a084f82550f2f1eaa39444", @"/Views/ViolationManager/AssignCases.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4879086291623894965006ec21c2edb233fc2b", @"/Views/_ViewImports.cshtml")]
    public class Views_ViolationManager_AssignCases : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ECX.VCTS.ViewModels.CasesAssignmentViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:block;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("violatorbox"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Alleged Violator Name"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "ViolatorName", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:80%; height:30px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "InvestigatorName", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("investigatorname"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:inline; width:50%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ViolationManager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AssignInvestigator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
  
    ViewData["Title"] = "AssignCases";
    ViewBag.Subtitle = "Assign Investigator for Cases";

#line default
#line hidden
            BeginContext(157, 25, true);
            WriteLiteral("\r\n<div id=\"filterarea\">\r\n");
            EndContext();
#line 8 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
            BeginContext(220, 139, true);
            WriteLiteral("        <table class=\"table\">\r\n            <tbody>\r\n                <tr id=\"searchcol\">\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(359, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ddaf1f4ea2c46cf84ac49f8345dfc1b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 14 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ViolatorName);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(442, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(468, 149, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c015c1bdc2314b838fea952832249c49", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 15 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ViolatorName);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(617, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(742, 77, true);
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(820, 35, false);
#line 19 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
                   Write(Html.LabelFor(m => m.ViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(855, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(882, 181, false);
#line 20 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
                   Write(Html.DropDownListFor(m => m.ViolationType, Model.ViolationTypes,
                       "Choose Type", new { @class = "form-control", @id = "typechosen", @name = "ViolationType" }));

#line default
#line hidden
            EndContext();
            BeginContext(1063, 274, true);
            WriteLiteral(@"

                    </td>
                    <td style=""padding-top:35px;"">
                        <input type=""submit"" value=""Search"" id=""srchbtn"" class=""btn btn-primary"" />
                    </td>
                </tr>
            </tbody>
        </table>
");
            EndContext();
#line 30 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
    }

#line default
#line hidden
            BeginContext(1344, 303, true);
            WriteLiteral(@"</div>

<div id=""messagearea"" style=""text-align:center;"" hidden>
    <h2>No Reported Cases to Assign!!!</h2>
</div>

<div id=""resultarea"">
    <table class=""table"">

        <thead>
            <tr>
                <th hidden>Violation Case Id</th>
                <th>
                    ");
            EndContext();
            BeginContext(1648, 85, false);
#line 44 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
               Write(Html.DisplayNameFor(m => m.OthersModel.FirstOrDefault().ViolationModel.ViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(1733, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1801, 84, false);
#line 47 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
               Write(Html.DisplayNameFor(m => m.OthersModel.FirstOrDefault().ViolationModel.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(1885, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1953, 90, false);
#line 50 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
               Write(Html.DisplayNameFor(m => m.OthersModel.FirstOrDefault().ViolationModel.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(2043, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(2111, 82, false);
#line 53 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
               Write(Html.DisplayNameFor(m => m.OthersModel.FirstOrDefault().OthersModel.ViolationDate));

#line default
#line hidden
            EndContext();
            BeginContext(2193, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(2261, 82, false);
#line 56 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
               Write(Html.DisplayNameFor(m => m.OthersModel.FirstOrDefault().ViolationModel.ReportDate));

#line default
#line hidden
            EndContext();
            BeginContext(2343, 81, true);
            WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n\r\n        <tbody>\r\n");
            EndContext();
#line 62 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
             foreach (var item in Model.OthersModel)
            {

#line default
#line hidden
            BeginContext(2493, 67, true);
            WriteLiteral("            <tr>\r\n                <td hidden>\r\n                    ");
            EndContext();
            BeginContext(2561, 65, false);
#line 66 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
               Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationCaseId));

#line default
#line hidden
            EndContext();
            BeginContext(2626, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2694, 63, false);
#line 69 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
               Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(2757, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2825, 62, false);
#line 72 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
               Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(2887, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2955, 68, false);
#line 75 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
               Write(Html.DisplayFor(modelItem => item.ViolationModel.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(3023, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3091, 60, false);
#line 78 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
               Write(Html.DisplayFor(modelItem => item.OthersModel.ViolationDate));

#line default
#line hidden
            EndContext();
            BeginContext(3151, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(3219, 60, false);
#line 81 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
               Write(Html.DisplayFor(modelItem => item.ViolationModel.ReportDate));

#line default
#line hidden
            EndContext();
            BeginContext(3279, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 84 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
            }

#line default
#line hidden
            BeginContext(3338, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 85 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
             foreach (var item in Model.SurveillanceModel)
            {

#line default
#line hidden
            BeginContext(3413, 55, true);
            WriteLiteral("        <tr>\r\n            <td hidden>\r\n                ");
            EndContext();
            BeginContext(3469, 65, false);
#line 89 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationCaseId));

#line default
#line hidden
            EndContext();
            BeginContext(3534, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3590, 63, false);
#line 92 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(3653, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3709, 62, false);
#line 95 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(3771, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3827, 68, false);
#line 98 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationModel.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(3895, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3951, 66, false);
#line 101 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.SurveillanceModel.ViolationDate));

#line default
#line hidden
            EndContext();
            BeginContext(4017, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4073, 60, false);
#line 104 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationModel.ReportDate));

#line default
#line hidden
            EndContext();
            BeginContext(4133, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 107 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
            }

#line default
#line hidden
            BeginContext(4184, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 108 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
             foreach (var item in Model.TradeModel)
            {

#line default
#line hidden
            BeginContext(4252, 55, true);
            WriteLiteral("        <tr>\r\n            <td hidden>\r\n                ");
            EndContext();
            BeginContext(4308, 65, false);
#line 112 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationCaseId));

#line default
#line hidden
            EndContext();
            BeginContext(4373, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4429, 63, false);
#line 115 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolationType));

#line default
#line hidden
            EndContext();
            BeginContext(4492, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4548, 62, false);
#line 118 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationModel.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(4610, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4666, 68, false);
#line 121 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationModel.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(4734, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4790, 59, false);
#line 124 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.TradeModel.ViolationDate));

#line default
#line hidden
            EndContext();
            BeginContext(4849, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4905, 60, false);
#line 127 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationModel.ReportDate));

#line default
#line hidden
            EndContext();
            BeginContext(4965, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 130 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
            }

#line default
#line hidden
            BeginContext(5016, 67, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<div id=\"assignarea\">\r\n    ");
            EndContext();
            BeginContext(5083, 453, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6061920e0a54657b12861eaf581d1fb", async() => {
                BeginContext(5155, 55, true);
                WriteLiteral("\r\n        <b>Investigator Name to Assign:</b>\r\n        ");
                EndContext();
                BeginContext(5210, 147, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "63f092850764439ca684844aa8fadb9e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 137 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.InvestigatorName);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("autofocus", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5357, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(5445, 84, true);
                WriteLiteral("        <input type=\"submit\" value=\"Assign Cases\" class=\"btn btn-primary\" />\r\n\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5536, 14, true);
            WriteLiteral("\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5567, 96, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        $(document).ready(function () {\r\n            if (");
                EndContext();
                BeginContext(5664, 23, false);
#line 148 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Model.OthersModel.Count);

#line default
#line hidden
                EndContext();
                BeginContext(5687, 25, true);
                WriteLiteral(" > 0 ||\r\n                ");
                EndContext();
                BeginContext(5713, 29, false);
#line 149 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Model.SurveillanceModel.Count);

#line default
#line hidden
                EndContext();
                BeginContext(5742, 25, true);
                WriteLiteral(" > 0 ||\r\n                ");
                EndContext();
                BeginContext(5768, 22, false);
#line 150 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
           Write(Model.TradeModel.Count);

#line default
#line hidden
                EndContext();
                BeginContext(5790, 635, true);
                WriteLiteral(@" > 0) {

                if ($('#violatorbox').val() != """" || $('#violationbox').val() != """") {
                    //$('#assignarea').show();
                    $('#resultarea').show();
                    $('#assignall').hide();
                    //$('#filterarea').hide();
                    $('#messagearea').hide();
                }
            } else {
                $('#messagearea').show();
                $('#assignarea').hide();
                $('#filterarea').hide();
                $('#resultarea').hide();
            }

            $('#violatorbox').autocomplete({
                    source: '");
                EndContext();
                BeginContext(6426, 26, false);
#line 167 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignCases.cshtml"
                        Write(Url.Action("GetViolators"));

#line default
#line hidden
                EndContext();
                BeginContext(6452, 52, true);
                WriteLiteral("\'\r\n            });\r\n\r\n        });\r\n\r\n    </script>\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ECX.VCTS.ViewModels.CasesAssignmentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
