#pragma checksum "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc77a1392c630b14e42bb7ea17699f8bb32450e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Index), @"mvc.1.0.view", @"/Views/Student/Index.cshtml")]
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
#line 1 "C:\Users\User\source\repos\IB\IB\Views\_ViewImports.cshtml"
using IB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\IB\IB\Views\_ViewImports.cshtml"
using IB.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc77a1392c630b14e42bb7ea17699f8bb32450e2", @"/Views/Student/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ec75703d32f7b266232e93d12556d89114da280", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IB.Models.StudentExam>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n");
#nullable restore
#line 8 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
 if (!Model.Equals(null)) { 

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Exam.Teacher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Exam.Subject));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Exam.Grade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Exam.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 32 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Exam.Teacher));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 35 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Exam.Subject));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Exam.Grade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Exam.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 46 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
#nullable restore
#line 49 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
}
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <label>No exams</label>\r\n");
#nullable restore
#line 53 "C:\Users\User\source\repos\IB\IB\Views\Student\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IB.Models.StudentExam>> Html { get; private set; }
    }
}
#pragma warning restore 1591