#pragma checksum "C:\Users\minht\source\repos\WebApplication6\WebApplication6\Views\Shared\_NotficationPartitial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3b49fd67b18bd8682d54cfbc2fa34a30474f482"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__NotficationPartitial), @"mvc.1.0.view", @"/Views/Shared/_NotficationPartitial.cshtml")]
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
#nullable restore
#line 1 "C:\Users\minht\source\repos\WebApplication6\WebApplication6\Views\_ViewImports.cshtml"
using WebApplication6;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\minht\source\repos\WebApplication6\WebApplication6\Views\_ViewImports.cshtml"
using WebApplication6.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3b49fd67b18bd8682d54cfbc2fa34a30474f482", @"/Views/Shared/_NotficationPartitial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"865b2ca0dedbd6d16882aa8f14a3148527d098b0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__NotficationPartitial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "C:\Users\minht\source\repos\WebApplication6\WebApplication6\Views\Shared\_NotficationPartitial.cshtml"
 if(TempData["Success"] != null){

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div class=\"alert alert-success notification\">\n\t\t");
#nullable restore
#line 4 "C:\Users\minht\source\repos\WebApplication6\WebApplication6\Views\Shared\_NotficationPartitial.cshtml"
   Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\t</div>\n");
#nullable restore
#line 6 "C:\Users\minht\source\repos\WebApplication6\WebApplication6\Views\Shared\_NotficationPartitial.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\minht\source\repos\WebApplication6\WebApplication6\Views\Shared\_NotficationPartitial.cshtml"
 if(TempData["Error"] != null){

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div class=\"alert alert-danger notification\">\n\t\t");
#nullable restore
#line 9 "C:\Users\minht\source\repos\WebApplication6\WebApplication6\Views\Shared\_NotficationPartitial.cshtml"
   Write(TempData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\t</div>\n");
#nullable restore
#line 11 "C:\Users\minht\source\repos\WebApplication6\WebApplication6\Views\Shared\_NotficationPartitial.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
