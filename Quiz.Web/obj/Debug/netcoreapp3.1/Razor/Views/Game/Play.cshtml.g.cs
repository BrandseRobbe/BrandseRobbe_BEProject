#pragma checksum "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a27584e84623665bd5abd9cbeb53df991872987"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Play), @"mvc.1.0.view", @"/Views/Game/Play.cshtml")]
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
#line 1 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\_ViewImports.cshtml"
using Quiz.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\_ViewImports.cshtml"
using Quiz.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\_ViewImports.cshtml"
using Quiz.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a27584e84623665bd5abd9cbeb53df991872987", @"/Views/Game/Play.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8e4f3ce3fab4392851cd800cf57c713c6991dc2", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Play : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Quiz.Web.ViewModels.Game_VM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Play", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
  
    ViewData["Title"] = "Play";
    var imgSrc = "";
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
     if (Model.ImageData != null)
    {
        var base64 = Convert.ToBase64String(Model.ImageData);
        imgSrc = String.Format("data:image/gif;base64,{0}", base64);
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Play</h1>\r\n\r\n<h4>Game_VM</h4>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        <img style=\"max-height: 300px; max-width: 300px;\"");
            BeginWriteAttribute("src", " src=\"", 431, "\"", 444, 1);
#nullable restore
#line 19 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
WriteAttributeValue("", 437, imgSrc, 437, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a27584e84623665bd5abd9cbeb53df9918729876071", async() => {
                WriteLiteral("\r\n            ");
#nullable restore
#line 21 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
       Write(Html.HiddenFor(model => model.GameId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
                WriteLiteral("\r\n            ");
#nullable restore
#line 25 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
       Write(Html.HiddenFor(model => model.QuestionDescription));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <h2>");
#nullable restore
#line 26 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
           Write(Html.DisplayFor(model => model.QuestionId));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n            ");
#nullable restore
#line 27 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
       Write(Html.HiddenFor(model => model.QuestionId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <h2>");
#nullable restore
#line 28 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
           Write(Html.DisplayFor(model => model.QuestionDescription));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n");
#nullable restore
#line 29 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
             foreach (KeyValuePair<string, bool> item in Model.Options)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"card text-white bg-primary mb-3\" style=\"max-width: 20rem;\">\r\n                    <div class=\"card-body\">\r\n                        <p class=\"card-text\">");
#nullable restore
#line 33 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
                                        Write(item.Key);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                        ");
#nullable restore
#line 34 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
                   Write(Html.CheckBoxFor(model => model.Options[item.Key]));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 37 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Play.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a27584e84623665bd5abd9cbeb53df99187298711109", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Quiz.Web.ViewModels.Game_VM> Html { get; private set; }
    }
}
#pragma warning restore 1591