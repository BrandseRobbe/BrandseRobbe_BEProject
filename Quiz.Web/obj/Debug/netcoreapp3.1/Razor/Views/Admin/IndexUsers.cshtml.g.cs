#pragma checksum "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff3fc25c3c7670f539e89f2fcbe3bc012d919638"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_IndexUsers), @"mvc.1.0.view", @"/Views/Admin/IndexUsers.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff3fc25c3c7670f539e89f2fcbe3bc012d919638", @"/Views/Admin/IndexUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8e4f3ce3fab4392851cd800cf57c713c6991dc2", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_IndexUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Quiz.Models.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
  
    ViewData["Title"] = "IndexUsers";
    //https://localhost:5001/admin/indexusers

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>IndexUsers</h1>\r\n<a href=\"/Identity/Account/Register\">Maak een nieuwe gebruiker aan</a>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 24 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 28 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 31 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 34 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
               Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 37 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
               Write(Html.ActionLink("Details", "User", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 38 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
               Write(Html.ActionLink("Edit roles", "EditRoles", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                    ");
#nullable restore
#line 39 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
               Write(Html.ActionLink("Delete", "DeleteUser", new { id = item.Id }, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 42 "C:\Users\Robbe Brandse\OneDrive - Hogeschool West-Vlaanderen\School\Semester 4\Backend Development\BrandseRobbe_BEProject\Quiz.Web\Views\Admin\IndexUsers.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Quiz.Models.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
