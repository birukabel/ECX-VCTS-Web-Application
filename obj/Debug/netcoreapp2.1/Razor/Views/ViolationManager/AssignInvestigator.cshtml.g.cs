#pragma checksum "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignInvestigator.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebd6bc660080cb84dc86a00c5cee990b50a6c245"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ViolationManager_AssignInvestigator), @"mvc.1.0.view", @"/Views/ViolationManager/AssignInvestigator.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ViolationManager/AssignInvestigator.cshtml", typeof(AspNetCore.Views_ViolationManager_AssignInvestigator))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebd6bc660080cb84dc86a00c5cee990b50a6c245", @"/Views/ViolationManager/AssignInvestigator.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4879086291623894965006ec21c2edb233fc2b", @"/Views/_ViewImports.cshtml")]
    public class Views_ViolationManager_AssignInvestigator : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ECX.VCTS.ViewModels.CasesAssignmentViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignInvestigator.cshtml"
  
    ViewData["Title"] = "AssignInvestigator";

#line default
#line hidden
            BeginContext(107, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(110, 51, false);
#line 6 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignInvestigator.cshtml"
Write(Model.OthersModel[0].ViolationModel.ViolationCaseId);

#line default
#line hidden
            EndContext();
            BeginContext(161, 10, true);
            WriteLiteral("\r\n<br />\r\n");
            EndContext();
            BeginContext(172, 22, false);
#line 8 "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationManager\AssignInvestigator.cshtml"
Write(Model.InvestigatorName);

#line default
#line hidden
            EndContext();
            BeginContext(194, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ECX.VCTS.ViewModels.CasesAssignmentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
