#pragma checksum "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2264b589c4583bf8b8bf22b4eb3d70c2c85faf3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Assessment_Index), @"mvc.1.0.view", @"/Views/Assessment/Index.cshtml")]
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
#line 1 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\_ViewImports.cshtml"
using MemberOutReachSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\_ViewImports.cshtml"
using MemberOutReachSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2264b589c4583bf8b8bf22b4eb3d70c2c85faf3e", @"/Views/Assessment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08c67e00924b8e95713f56406db6d1c8a441d78e", @"/Views/_ViewImports.cshtml")]
    public class Views_Assessment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MemberOutReachSystem.Domain.Assessment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1> Assessment</h1>\r\n<hr />\r\n<br />\r\n\r\n");
#nullable restore
#line 7 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
 foreach (var row in Model)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
     using (Html.BeginForm("SaveAssessment", "Assessment", FormMethod.Post))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
         foreach (int row1 in row.QuestionId)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\r\n                <h4>  ");
#nullable restore
#line 14 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                 Write(Html.DisplayFor(QUESTION => row.QuestionMapping.FirstOrDefault(QUS => QUS.QUESTION_CD_ID == row1).QUESTION_NM));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n             </div>\r\n");
            WriteLiteral("                <br />\r\n                <div class=\"row\">\r\n");
#nullable restore
#line 19 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                     foreach (var a in row.QuestionMapping.Where(QusAns => QusAns.QUESTION_CD_ID == row1 && QusAns.DISEASE_CD_ID == row.DiseaseTypeId ))
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                         if (a.CONTROL_TYPE_ID == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-md-2\">\r\n                                ");
#nullable restore
#line 24 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                           Write(Html.RadioButton(row1.ToString(), a.SGK_MAPPING_ID, new { @class = "form-check-input" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 25 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                           Write(Html.DisplayFor(OPTION => a.OPTION_NM));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n");
#nullable restore
#line 27 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                        }
                        else if (a.CONTROL_TYPE_ID == 2)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-md-2\">\r\n                                ");
#nullable restore
#line 31 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                           Write(Html.CheckBox(row1.ToString(), false, new { value = a.SGK_MAPPING_ID, @checked = true, @class = "form-check-input" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 32 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                           Write(Html.DisplayFor(OPTION => a.OPTION_NM));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n");
#nullable restore
#line 34 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                        }
                        else if (a.CONTROL_TYPE_ID == 3)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-md-12\">\r\n                                ");
#nullable restore
#line 38 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                           Write(Html.TextBox(a.SGK_MAPPING_ID.ToString(), "", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n");
#nullable restore
#line 40 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <hr />\r\n                <br />\r\n");
#nullable restore
#line 45 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <input type=\"submit\" value=\"Submit\" class=\"btn btn-primary\" />\r\n");
#nullable restore
#line 48 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\Assessment\Index.cshtml"
                 
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MemberOutReachSystem.Domain.Assessment>> Html { get; private set; }
    }
}
#pragma warning restore 1591