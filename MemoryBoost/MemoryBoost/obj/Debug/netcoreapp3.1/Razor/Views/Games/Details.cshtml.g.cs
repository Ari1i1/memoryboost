#pragma checksum "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5956c8d2ea00a749e53801e85fb38d16df1a9566"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5956c8d2ea00a749e53801e85fb38d16df1a9566", @"/Views/Games/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15a8b521c8d2b4577f7cf8319d37faf8fd7db740", @"/Views/_ViewImports.cshtml")]
    public class Views_Games_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MemoryBoost.Models.Game>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "numberOfCards", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "secForMemorizing", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
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
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
 using (Html.BeginForm("Results", "Games"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row justify-content-between\">\r\n        <div>\r\n            <div>\r\n                <a class=\"text-white px-xl-5 px-lg-5 px-md-4 timer\" style=\"font-size: 20px;\">time left: 00:00:");
#nullable restore
#line 12 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
                                                                                                         Write(Model.Level.SecForMemorizing);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                <input type=\"hidden\" name=\"timer\"");
            BeginWriteAttribute("value", " value=\"", 402, "\"", 410, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n        <div class=\"my-2 mr-5\">\r\n            <a class=\"text-white px-xl-5 px-lg-5 px-md-4\" style=\"font-size: 20px;\">level: ");
#nullable restore
#line 17 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
                                                                                     Write(Model.Level.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5956c8d2ea00a749e53801e85fb38d16df1a95666025", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 18 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Level.CardsNumber);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5956c8d2ea00a749e53801e85fb38d16df1a95667873", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 19 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.Level.SecForMemorizing);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"row justify-content-between\">\r\n        <div>\r\n            <div>\r\n                <a class=\"text-white px-xl-5 px-lg-5 px-md-4\" name=\"score\" style=\"font-size: 20px;\">points: ");
#nullable restore
#line 25 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
                                                                                                       Write(Model.Score);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
            </div>
        </div>
        <div class=""row my-2"">
            <div class=""mr-2"">
                <input name=""pause"" value=""pause"" type=""button"" class=""btn btn-lg btn-block btn-outline px-xl-5 px-lg-5 px-md-4"" 
                       style=""background-color: #59F9CC; color: #806CDD; border-radius: 35px;""/>
            </div>
            <div class=""mr-5"">
                <input type=""hidden"" name=""score""");
            BeginWriteAttribute("value", " value=\"", 1457, "\"", 1465, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"id\"");
            BeginWriteAttribute("value", " value=\"", 1517, "\"", 1534, 1);
#nullable restore
#line 35 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
WriteAttributeValue("", 1525, Model.Id, 1525, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                <input type=""submit"" class=""btn btn-lg btn-block btn-outline text-white px-xl-5 px-lg-5 px-md-4"" value=""stop""
                       style=""border-color: white; border-radius: 35px;"" />
            </div>
        </div>
    </div>
");
#nullable restore
#line 41 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div style=""background-color: rgba(255,255,255,0.5); color: #806CDD; border-radius: 35px;""
         class=""container h-100 d-flex flex-column align-self-center justify-content-center"">
        <div class=""cardWrapper"">
            <div class=""row d-flex justify-content-center"">
");
#nullable restore
#line 48 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
                 for (int j = 0; j < Model.Cards.Count / 2; j++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-lg-1 col-md-1 col-sm-1 col-xs-6 my-5 cardContainer align-self-center"">
                        <div class=""card"">
                            <div class=""front""><h3 class=""cardTitle"">Flip me!</h3></div>
                            <div class=""back d-flex justify-content-center"">
                                <img");
            BeginWriteAttribute("src", " src=\"", 2544, "\"", 2574, 1);
#nullable restore
#line 54 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
WriteAttributeValue("", 2550, Model.Cards[j].FilePath, 2550, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2575, "\"", 2605, 1);
#nullable restore
#line 54 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
WriteAttributeValue("", 2581, Model.Cards[j].FileName, 2581, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"align-self-center\" style=\"width: 100%; height: 80%;\" />\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 58 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"row d-flex justify-content-center\">\r\n");
#nullable restore
#line 61 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
                 for (int j = Model.Cards.Count / 2; j < Model.Cards.Count; j++)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-lg-1 col-md-1 col-sm-1 col-xs-6 my-5 cardContainer align-self-center"">
                        <div class=""card"">
                            <div class=""front""><h3 class=""cardTitle"">Flip me!</h3></div>
                            <div class=""back d-flex justify-content-center"">
                                <img");
            BeginWriteAttribute("src", " src=\"", 3324, "\"", 3354, 1);
#nullable restore
#line 67 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
WriteAttributeValue("", 3330, Model.Cards[j].FilePath, 3330, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 3355, "\"", 3385, 1);
#nullable restore
#line 67 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
WriteAttributeValue("", 3361, Model.Cards[j].FileName, 3361, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"align-self-center\" style=\"width: 100%; height: 80%;\" />\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 71 "D:\unik\MemoryBoost\MemoryBoost\MemoryBoost\Views\Games\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
