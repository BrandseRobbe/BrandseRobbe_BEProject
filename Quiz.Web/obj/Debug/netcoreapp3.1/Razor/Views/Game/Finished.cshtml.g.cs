#pragma checksum "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b9b1587957ff23020d28fc1a8678b7c276b491a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Finished), @"mvc.1.0.view", @"/Views/Game/Finished.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b9b1587957ff23020d28fc1a8678b7c276b491a", @"/Views/Game/Finished.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8e4f3ce3fab4392851cd800cf57c713c6991dc2", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Finished : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Quiz.Web.ViewModels.Finished_VM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ScoreBoard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
  
    ViewData["Title"] = "Finished";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
Write(Html.DisplayFor(model => model.QuizDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 7 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
                                                 Write(Html.DisplayFor(model => model.QuizDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral(" finished</h1>\r\n\r\n<h2>Final score: ");
#nullable restore
#line 9 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
            Write(Html.DisplayFor(model => model.userscore));

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 9 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
                                                       Write(Html.DisplayFor(model => model.maxscore));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h2>Completion time: ");
#nullable restore
#line 10 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
                Write(Html.DisplayFor(model => model.completetime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b9b1587957ff23020d28fc1a8678b7c276b491a6321", async() => {
                WriteLiteral("See scoreboard");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n");
#nullable restore
#line 15 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
 foreach (IEnumerable<Question> questions in Model.gameresults)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <dl class=\"row c-border-bottom\">\r\n        <dt class=\"col-sm-2\">\r\n            Descritpion\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
       Write(questions.ElementAt(0).Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Date created\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
       Write(questions.ElementAt(0).DateCreated);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Options\r\n        </dt>\r\n");
#nullable restore
#line 34 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
          
            var correctoptions = questions.ElementAt(0).PossibleOptions.OrderBy(e => e.OptionDescription);
            var useroptions = questions.ElementAt(1).PossibleOptions.OrderBy(e => e.OptionDescription);
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
         for (int i = 0; i < correctoptions.Count(); i++)
        {
            if (correctoptions.ElementAt(i).CorrectAnswer)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <dd class=\"col-sm-10 text-success\">\r\n                    ");
#nullable restore
#line 43 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
               Write(correctoptions.ElementAt(i).OptionDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 43 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
                                                              Write(Html.Raw(((char)10003).ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n");
#nullable restore
#line 45 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
            }
            else if (useroptions.ElementAt(i).CorrectAnswer)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <dd class=\"col-sm-10 text-danger\">\r\n                    ");
#nullable restore
#line 49 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
               Write(correctoptions.ElementAt(i).OptionDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 49 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
                                                              Write(Html.Raw(((char)10005).ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n");
#nullable restore
#line 51 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
            }
            else if (!correctoptions.ElementAt(i).CorrectAnswer)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 55 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
               Write(correctoptions.ElementAt(i).OptionDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 55 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
                                                              Write(Html.Raw(((char)10005).ToString()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n");
#nullable restore
#line 57 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
            }
            if (correctoptions.Last<Option>() != correctoptions.ElementAt(i))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <dt class=\"col-sm-2\"></dt>\r\n");
#nullable restore
#line 61 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\r\n");
#nullable restore
#line 64 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Game\Finished.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Quiz.Web.ViewModels.Finished_VM> Html { get; private set; }
    }
}
#pragma warning restore 1591
