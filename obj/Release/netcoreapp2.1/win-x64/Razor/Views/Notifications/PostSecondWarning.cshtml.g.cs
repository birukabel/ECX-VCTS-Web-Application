#pragma checksum "C:\Users\tariku.worku\Desktop\Assigned\V3.0_Buckups\afterUAT\Published Code\ECX.VCTS\Views\Notifications\PostSecondWarning.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29cf5192df81c25ee0c1dc7a242c49fc03220706"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notifications_PostSecondWarning), @"mvc.1.0.view", @"/Views/Notifications/PostSecondWarning.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Notifications/PostSecondWarning.cshtml", typeof(AspNetCore.Views_Notifications_PostSecondWarning))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29cf5192df81c25ee0c1dc7a242c49fc03220706", @"/Views/Notifications/PostSecondWarning.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc4879086291623894965006ec21c2edb233fc2b", @"/Views/_ViewImports.cshtml")]
    public class Views_Notifications_PostSecondWarning : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 112, true);
            WriteLiteral("<div id=\"confirmDialog\" title=\"Second Warning\">\r\n    <p>Second Warning is successfully Posted!!!</p>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(129, 431, true);
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
