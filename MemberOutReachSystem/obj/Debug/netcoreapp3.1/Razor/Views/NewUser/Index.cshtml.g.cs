#pragma checksum "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\NewUser\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bca4bd26164cb18a5c10ae87b1f2b4b89bbb81bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NewUser_Index), @"mvc.1.0.view", @"/Views/NewUser/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bca4bd26164cb18a5c10ae87b1f2b4b89bbb81bd", @"/Views/NewUser/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08c67e00924b8e95713f56406db6d1c8a441d78e", @"/Views/_ViewImports.cshtml")]
    public class Views_NewUser_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MemberOutReachSystem.Domain.LookUpData>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"col-lg-12\">\r\n    <div class=\"col-lg-5\">\r\n\r\n    </div>\r\n    <div class=\"col-lg-7\" style=\"align-content:center\">\r\n        <div>\r\n            <h1> New User Registeration </h1>\r\n            <hr />\r\n        </div>\r\n        <div class=\"col-lg-7\">\r\n");
#nullable restore
#line 12 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\NewUser\Index.cshtml"
             using (Html.BeginForm("RegisterUser", "NewUser", FormMethod.Post, new { @class = "was-validated" }))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""form-group"">
                    <label for=""Name"">Name</label>
                    <input type=""text"" class=""form-control"" maxlength=""50"" name=""Name"" placeholder=""Enter Name"" id=""Name"" required>
                    <div class=""valid-feedback"">Valid.</div>
                    <div class=""invalid-feedback"">Please fill Name.</div>
                </div>
                <div class=""form-group"">
                    <label for=""UserName"">User Name</label>
                    <input type=""text"" class=""form-control"" maxlength=""15"" placeholder=""Enter User Name"" name=""UserName"" id=""UserName"" required>
                    <div class=""valid-feedback"">Valid.</div>
                    <div class=""invalid-feedback"">Please fill UserName.</div>
                </div>
                <div class=""form-group"">
                    <label for=""pwd"">Password:</label>
                    <input type=""password"" class=""form-control"" maxlength=""15"" placeholder=""Enter password"" name=""pwd"" id=""p");
            WriteLiteral(@"wd"" required>
                    <div class=""valid-feedback"">Valid.</div>
                    <div class=""invalid-feedback"">Please fill Password.</div>
                </div>
                <div class=""form-group"">
                    <label for=""Address1"">Address1:</label>
                    <input type=""text"" class=""form-control"" maxlength=""100"" placeholder=""Enter Address1"" name=""Address1"" id=""Address1"">
                </div>
                <div class=""form-group"">
                    <label for=""Address2"">Address2:</label>
                    <input type=""text"" class=""form-control"" maxlength=""100"" placeholder=""Enter Address2"" name=""Address2"" id=""Address2"">
                </div>
                <div class=""form-group"">
                    <label for=""ddlState"">State:</label>
                    <select id=""ddlState"" name=""ddlState"" class=""form-control"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bca4bd26164cb18a5c10ae87b1f2b4b89bbb81bd6090", async() => {
                WriteLiteral("Please select");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 44 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\NewUser\Index.cshtml"
                         foreach (var row in Model.Where(a => a.MOSLOOKUP == "STATE"))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bca4bd26164cb18a5c10ae87b1f2b4b89bbb81bd7588", async() => {
#nullable restore
#line 46 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\NewUser\Index.cshtml"
                                                          Write(row.LOOKUP_NAME);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\NewUser\Index.cshtml"
                               WriteLiteral(row.SGK_LOOKUP_ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 47 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\NewUser\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </select>
                </div>
                <div class=""form-group"">
                    <label for=""ddlCountry"">Country:</label>
                    <select id=""ddlCountry"" name=""ddlCountry"" class=""form-control"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bca4bd26164cb18a5c10ae87b1f2b4b89bbb81bd9906", async() => {
                WriteLiteral("Please select");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 54 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\NewUser\Index.cshtml"
                         foreach (var row in Model.Where(a => a.MOSLOOKUP == "COUNTRY"))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bca4bd26164cb18a5c10ae87b1f2b4b89bbb81bd11406", async() => {
#nullable restore
#line 56 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\NewUser\Index.cshtml"
                                                          Write(row.LOOKUP_NAME);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\NewUser\Index.cshtml"
                               WriteLiteral(row.SGK_LOOKUP_ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 57 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\NewUser\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </select>
                </div>
                <div class=""form-group"">
                    <label for=""email"">Email address:</label>
                    <input type=""email"" class=""form-control"" maxlength=""50"" placeholder=""Enter email"" id=""email"" name=""email"" required>
                    <div class=""valid-feedback"">Valid.</div>
                    <div class=""invalid-feedback"">Please fill EmailID.</div>
                </div>
                <div class=""form-group"">
                    <label for=""Phone"">Phone Number:</label>
                    <input type=""text"" class=""form-control"" maxlength=""12"" placeholder=""Enter PhoneNo"" id=""Phone"" name=""Phone"" required>
                    <div class=""valid-feedback"">Valid.</div>
                    <div class=""invalid-feedback"">Please fill PhoneNo.</div>
                </div>
                <div class=""form-group"">
                    <label for=""DOB"">Date Of Birth:</label>
                    <input type=""text"" class=""form-con");
            WriteLiteral("trol\" placeholder=\"Enter DOB\" id=\"DOB\" name=\"DOB\" required>\r\n                    <div class=\"valid-feedback\">Valid.</div>\r\n                    <div class=\"invalid-feedback\">Please fill DOB.</div>\r\n                </div>\r\n");
            WriteLiteral("                <button type=\"submit\" class=\"btn btn-primary\">Create User</button>\r\n");
#nullable restore
#line 80 "D:\data\C_drive\source\repos\MemberOutReachSystem\Views\NewUser\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MemberOutReachSystem.Domain.LookUpData>> Html { get; private set; }
    }
}
#pragma warning restore 1591