#pragma checksum "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\Notifications\LiftSuspension.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10be0a4f7d8af215d60106a19cd3d0cb69406b27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notifications_LiftSuspension), @"mvc.1.0.view", @"/Views/Notifications/LiftSuspension.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Notifications/LiftSuspension.cshtml", typeof(AspNetCore.Views_Notifications_LiftSuspension))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10be0a4f7d8af215d60106a19cd3d0cb69406b27", @"/Views/Notifications/LiftSuspension.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4879086291623894965006ec21c2edb233fc2b", @"/Views/_ViewImports.cshtml")]
    public class Views_Notifications_LiftSuspension : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 111, true);
            WriteLiteral("<div id=\"confirmDialog\" title=\"Suspension Lifted\">\r\n    <p>Suspension is successfully Lifted!!!</p>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(128, 431, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
       $(document).ready(function () {
           $('#confirmDialog').dialog({
               autoOpen: true,
               Modal: true,
               resizable: false,
               buttons: {
                   ""Ok"": function () {
                       window.location = ""/Notifications/index"";
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