#pragma checksum "E:\Tariku\Finalized\ECX.VCTS\Views\ViolationInvestigator\RecommendationSuccess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d873bbdb787f83e8a16b135832fa88da04f5b37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ViolationInvestigator_RecommendationSuccess), @"mvc.1.0.view", @"/Views/ViolationInvestigator/RecommendationSuccess.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ViolationInvestigator/RecommendationSuccess.cshtml", typeof(AspNetCore.Views_ViolationInvestigator_RecommendationSuccess))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d873bbdb787f83e8a16b135832fa88da04f5b37", @"/Views/ViolationInvestigator/RecommendationSuccess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4879086291623894965006ec21c2edb233fc2b", @"/Views/_ViewImports.cshtml")]
    public class Views_ViolationInvestigator_RecommendationSuccess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 116, true);
            WriteLiteral("\r\n<div id=\"confirmDialog\" title=\"Recommended\">\r\n    <p>Recommendation and Summary Saved Successfully</p>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(133, 417, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
       $(document).ready(function () {
           $('#confirmDialog').dialog({
               autoOpen: true,
               Modal: true,
               resizable: false,
               buttons: {
                   ""Ok"": function () {
                       window.location = ""/Home/"";
                   }
               },
           });

    });
    </script>
");
                EndContext();
            }
            );
            BeginContext(553, 6, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
