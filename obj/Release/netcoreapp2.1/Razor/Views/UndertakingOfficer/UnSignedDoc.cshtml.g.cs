#pragma checksum "E:\Tariku\Finalized\ECX.VCTS\Views\UndertakingOfficer\UnSignedDoc.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4715f24b402d4ff24a128cd2af51c269032248f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UndertakingOfficer_UnSignedDoc), @"mvc.1.0.view", @"/Views/UndertakingOfficer/UnSignedDoc.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UndertakingOfficer/UnSignedDoc.cshtml", typeof(AspNetCore.Views_UndertakingOfficer_UnSignedDoc))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4715f24b402d4ff24a128cd2af51c269032248f", @"/Views/UndertakingOfficer/UnSignedDoc.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4879086291623894965006ec21c2edb233fc2b", @"/Views/_ViewImports.cshtml")]
    public class Views_UndertakingOfficer_UnSignedDoc : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 144, true);
            WriteLiteral("\r\n<div id=\"confirmDialog\" title=\"UnSigned Document\">\r\n    <p>You have Successfully Sent the Undertaking Document without Signing</p>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(161, 417, true);
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
