#pragma checksum "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07d4ea5cafaba6c895929607c9d488490715bc0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DashProfessor_CardsProfessor), @"mvc.1.0.view", @"/Views/DashProfessor/CardsProfessor.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DashProfessor/CardsProfessor.cshtml", typeof(AspNetCore.Views_DashProfessor_CardsProfessor))]
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
#line 1 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\_ViewImports.cshtml"
using ProjetoPista.WebApp;

#line default
#line hidden
#line 2 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\_ViewImports.cshtml"
using ProjetoPista.WebApp.Models;

#line default
#line hidden
#line 2 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#line 3 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml"
using X.PagedList;

#line default
#line hidden
#line 4 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml"
using X.PagedList.Mvc.Common;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07d4ea5cafaba6c895929607c9d488490715bc0e", @"/Views/DashProfessor/CardsProfessor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cee33ac5527cd15db0c887a24e0e9b1bdd3d6584", @"/Views/_ViewImports.cshtml")]
    public class Views_DashProfessor_CardsProfessor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<ProjetoPista.Model.Dtos.ProfessorDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/PagedList.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DashProfessor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(136, 2, true);
            WriteLiteral("\n\n");
            EndContext();
            BeginContext(138, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "07d4ea5cafaba6c895929607c9d488490715bc0e7061", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(206, 112, true);
            WriteLiteral("\n\n<div class=\"container-fluid\">\n    <ul class=\"list-group list-group-horizontal align-items-stretch flex-wrap\">\n");
            EndContext();
#line 11 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(365, 74, true);
            WriteLiteral("<li class=\"list-group-item border-0\">\n    <div class=\"card my-3\">\n        ");
            EndContext();
            BeginContext(439, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "07d4ea5cafaba6c895929607c9d488490715bc0e8921", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 449, "~/imagensProf/", 449, 14, true);
#line 15 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml"
AddHtmlAttributeValue("", 463, item.nm_profile, 463, 16, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(517, 68, true);
            WriteLiteral("\n        <div class=\"card-body\">\n            <h4 class=\"card-title\">");
            EndContext();
            BeginContext(586, 31, false);
#line 17 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml"
                              Write(item.nm_professor.Split(" ")[0]);

#line default
#line hidden
            EndContext();
            BeginContext(617, 39, true);
            WriteLiteral("</h4>\n            <p class=\"card-text\">");
            EndContext();
            BeginContext(657, 15, false);
#line 18 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml"
                            Write(item.nm_apelido);

#line default
#line hidden
            EndContext();
            BeginContext(672, 17, true);
            WriteLiteral("</p>\n            ");
            EndContext();
            BeginContext(689, 153, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07d4ea5cafaba6c895929607c9d488490715bc0e11604", async() => {
                BeginContext(782, 56, true);
                WriteLiteral("<i class=\"fas fa-arrow-circle-left\"></i>Mais informa????es");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(842, 33, true);
            WriteLiteral("\n        </div>\n    </div>\n</li>\n");
            EndContext();
#line 23 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml"
}

#line default
#line hidden
            BeginContext(877, 30, true);
            WriteLiteral("    </ul>\n    <br />\n    Page ");
            EndContext();
            BeginContext(909, 57, false);
#line 26 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml"
     Write(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber);

#line default
#line hidden
            EndContext();
            BeginContext(967, 4, true);
            WriteLiteral(" of ");
            EndContext();
            BeginContext(972, 15, false);
#line 26 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml"
                                                                    Write(Model.PageCount);

#line default
#line hidden
            EndContext();
            BeginContext(987, 6, true);
            WriteLiteral("\n\n    ");
            EndContext();
            BeginContext(994, 333, false);
#line 28 "C:\Users\lucia\Desktop\Projeto Plataforma Pistas\ProjetoPista\ProjetoPista\ProjetoPista.WebApp\Views\DashProfessor\CardsProfessor.cshtml"
Write(Html.PagedListPager(Model, page => Url.Action("Consultar",new { page, sortOrder = ViewBag.CurrentSort, currentFilter = ViewBag.CurrentFilter }),
    new X.PagedList.Web.Common.PagedListRenderOptions
    {
        LiElementClasses = new string[] { "page-item" },
        PageClasses = new string[] { "page-link" }
    }
        ));

#line default
#line hidden
            EndContext();
            BeginContext(1327, 9, true);
            WriteLiteral("\n\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<ProjetoPista.Model.Dtos.ProfessorDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
