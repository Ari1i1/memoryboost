#pragma checksum "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0744171e26518c163a093f130c714b83e6c9c6da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Games_Details), @"mvc.1.0.view", @"/Views/Games/Details.cshtml")]
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
#line 1 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\_ViewImports.cshtml"
using MemoryBoost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\_ViewImports.cshtml"
using MemoryBoost.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\_ViewImports.cshtml"
using MemoryBoost.Models.AccountViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0744171e26518c163a093f130c714b83e6c9c6da", @"/Views/Games/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15a8b521c8d2b4577f7cf8319d37faf8fd7db740", @"/Views/_ViewImports.cshtml")]
    public class Views_Games_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MemoryBoost.Models.Game>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row justify-content-between"">
    <div>
        <div>
            <a class=""text-white px-xl-5 px-lg-5 px-md-4"" style=""font-size: 20px;"">time:</a>
        </div>
    </div>
    <div class=""my-2 mr-5"">
        <a class=""text-white px-xl-5 px-lg-5 px-md-4"" style=""font-size: 20px;"">level: ");
#nullable restore
#line 14 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
                                                                                 Write(Model.Level.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </div>\r\n\r\n</div>\r\n\r\n<div class=\"row justify-content-between\">\r\n    <div>\r\n        <div>\r\n            <a class=\"text-white px-xl-5 px-lg-5 px-md-4\" style=\"font-size: 20px;\">points: ");
#nullable restore
#line 22 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
                                                                                      Write(Model.Score);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
        </div>
    </div>
    <div class=""row my-2"">
        <div class=""mr-2"">
            <a type=""button"" class=""btn btn-lg btn-block btn-outline px-xl-5 px-lg-5 px-md-4"" style=""background-color: #59F9CC; color: #806CDD; border-radius: 35px;"">pause</a>
        </div>
        <div class=""mr-5"">
            <a type=""button"" class=""btn btn-lg btn-block btn-outline text-white px-xl-5 px-lg-5 px-md-4"" style=""border-color: white; border-radius: 35px;"">stop</a>
        </div>
    </div>
</div>

<div class=""row"">
    <div style=""background-color: rgba(255,255,255,0.5); color: #806CDD; border-radius: 35px;""
         class=""container h-100 d-flex flex-column align-self-center justify-content-center"">
        <div class=""cardWrapper"">
");
#nullable restore
#line 39 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
             for (int i = 0; i < Model.Cards.Count/(Model.Cards.Count/2); i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row\">\r\n");
#nullable restore
#line 42 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
                     for (int j = 0; j < Model.Cards.Count/(Model.Cards.Count/(Model.Cards.Count/2)); j++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""col-lg-1 col-md-1 col-sm-1 col-xs-6 my-5 cardContainer"">
                            <div class=""card"">
                                <div class=""front""><h3 class=""cardTitle"">Flip me!</h3></div>
                                <div class=""back"">
                                    <div class=""content"">
                                        <h3 class=""cardTitle"">I was made with CSS3</h3>
                                        <br />
                                        <p id=""happy""></p>
                                    </div>
                                </div>
                            </div>
                        </div>
");
#nullable restore
#line 56 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 58 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MemoryBoost.Models.Game> Html { get; private set; }
    }
}
#pragma warning restore 1591