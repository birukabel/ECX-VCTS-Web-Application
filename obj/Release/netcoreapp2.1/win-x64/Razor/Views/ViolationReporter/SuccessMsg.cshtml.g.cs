#pragma checksum "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\ViolationReporter\SuccessMsg.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "188198b5921cafc6a1d2e616456baa9060fe874b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ViolationReporter_SuccessMsg), @"mvc.1.0.view", @"/Views/ViolationReporter/SuccessMsg.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ViolationReporter/SuccessMsg.cshtml", typeof(AspNetCore.Views_ViolationReporter_SuccessMsg))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"188198b5921cafc6a1d2e616456baa9060fe874b", @"/Views/ViolationReporter/SuccessMsg.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4879086291623894965006ec21c2edb233fc2b", @"/Views/_ViewImports.cshtml")]
    public class Views_ViolationReporter_SuccessMsg : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 118, true);
            WriteLiteral("\r\n    \r\n<div id=\"confirmDialog\" title=\"Send Report\" >\r\n        <p>Your Report is Sent Successfully</p>\r\n    </div>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(135, 424, true);
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