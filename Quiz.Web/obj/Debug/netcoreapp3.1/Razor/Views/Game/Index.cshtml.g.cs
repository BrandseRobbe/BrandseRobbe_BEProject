#pragma checksum "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f43536e96be403cdc7a71d1e32da30b1dfa4be9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Index), @"mvc.1.0.view", @"/Views/Game/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f43536e96be403cdc7a71d1e32da30b1dfa4be9", @"/Views/Game/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8e4f3ce3fab4392851cd800cf57c713c6991dc2", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Quiz.Models.QuizClass>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "QuizOverview", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateQuiz", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n");
#nullable restore
#line 8 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
 if (Model.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No quizzes have been made yet</p>\r\n");
#nullable restore
#line 11 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
     if (User.Identity.IsAuthenticated && User.IsInRole("Creator"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6f43536e96be403cdc7a71d1e32da30b1dfa4be95479", async() => {
                WriteLiteral("Qreate a quiz");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <br>\r\n");
#nullable restore
#line 15 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>You will have to wait for a quiz to be made</p>\r\n");
#nullable restore
#line 19 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
     
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card text-white bg-primary mb-3\" style=\"max-width: 20rem;\">\r\n");
            WriteLiteral("            <div class=\"card-body\">\r\n                <h4 class=\"card-title\">");
#nullable restore
#line 28 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
                                  Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                <p class=\"card-text\">");
#nullable restore
#line 29 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
                                Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Difficulty: ");
#nullable restore
#line 30 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
                                            Write(Html.DisplayFor(modelItem => item.Difficulty));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                ");
#nullable restore
#line 31 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
           Write(Html.ActionLink("Spelen", "StartGame", new { id = item.QuizId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 34 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Index.cshtml"
     
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Quiz.Models.QuizClass>> Html { get; private set; }
    }
}
#pragma warning restore 1591
