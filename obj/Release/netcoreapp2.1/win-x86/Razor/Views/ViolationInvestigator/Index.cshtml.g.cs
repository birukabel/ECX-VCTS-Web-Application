#pragma checksum "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "686b1f5e1f0f102064521290a9e19d2c15319f25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ViolationInvestigator_Index), @"mvc.1.0.view", @"/Views/ViolationInvestigator/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ViolationInvestigator/Index.cshtml", typeof(AspNetCore.Views_ViolationInvestigator_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"686b1f5e1f0f102064521290a9e19d2c15319f25", @"/Views/ViolationInvestigator/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4879086291623894965006ec21c2edb233fc2b", @"/Views/_ViewImports.cshtml")]
    public class Views_ViolationInvestigator_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ECX.VCTS.ViewModels.AvailableQualityCasesViewModel>>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
  
    ViewData["Title"] = "Index";
    ViewBag.Subtitle = "Available Quality Related Violation Cases";

#line default
#line hidden
            BeginContext(182, 88, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(270, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e994f3751ec7464da4ce2b4ed83d7664", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 12 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.FirstOrDefault().ViolationCase.ExchangeCenterName);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(352, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(407, 76, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b5d9c78086d4bc78a7b5b77caecbac8", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 15 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.FirstOrDefault().ViolationCase.ViolatorName);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(483, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(538, 80, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "21e04ac54e104ab29434bb575e2b4e72", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 18 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.FirstOrDefault().QualityCase.LaboratoryDecision);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(618, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(673, 80, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5be90a6081649b182bf3850bcc0966b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 21 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.FirstOrDefault().QualityCase.QualityGradeResult);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(753, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(808, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8e34a56b44b84a14afddf56096eb348b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 24 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.FirstOrDefault().ViolationCase.ReportDate);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(882, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 30 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1017, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1066, 67, false);
#line 34 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationCase.ExchangeCenterName));

#line default
#line hidden
            EndContext();
            BeginContext(1133, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1189, 61, false);
#line 37 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationCase.ViolatorName));

#line default
#line hidden
            EndContext();
            BeginContext(1250, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1306, 65, false);
#line 40 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.QualityCase.LaboratoryDecision));

#line default
#line hidden
            EndContext();
            BeginContext(1371, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1427, 65, false);
#line 43 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.QualityCase.QualityGradeResult));

#line default
#line hidden
            EndContext();
            BeginContext(1492, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1548, 59, false);
#line 46 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ViolationCase.ReportDate));

#line default
#line hidden
            EndContext();
            BeginContext(1607, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1663, 95, false);
#line 49 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
           Write(Html.ActionLink("Process Case", "ProcessCase", new { id = item.ViolationCase.ViolationCaseId }));

#line default
#line hidden
            EndContext();
            BeginContext(1758, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 52 "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\ECX.VCTS\Views\ViolationInvestigator\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1805, 24, true);
            WriteLiteral("    </tbody>\r\n\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ECX.VCTS.ViewModels.AvailableQualityCasesViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
