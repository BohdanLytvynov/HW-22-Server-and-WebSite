#pragma checksum "D:\C# Projects\HW22 MVC\HW21 MVC\Areas\User\Views\User\AddNoteResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d615b5572d140c07b83ba650e5b3e6f4fbb55a88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_User_AddNoteResult), @"mvc.1.0.view", @"/Areas/User/Views/User/AddNoteResult.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d615b5572d140c07b83ba650e5b3e6f4fbb55a88", @"/Areas/User/Views/User/AddNoteResult.cshtml")]
    public class Areas_User_Views_User_AddNoteResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("footbutton"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/User/User/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\C# Projects\HW22 MVC\HW21 MVC\Areas\User\Views\User\AddNoteResult.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1 class=\"hadres\">\r\n\r\n");
#nullable restore
#line 47 "D:\C# Projects\HW22 MVC\HW21 MVC\Areas\User\Views\User\AddNoteResult.cshtml"
     switch (ViewData["operType"])
    {
        case 1: //Add
            ShowAddResult();
            break;
        default:
            ShowRemoveresult();
            break;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</h1>\r\n\r\n<div style=\"padding:20px; margin-left:20px\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d615b5572d140c07b83ba650e5b3e6f4fbb55a884044", async() => {
                WriteLiteral("\r\n    <span class=\"ftbtnspan\">Back to Viewer</span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
        }
        #pragma warning restore 1998
#nullable restore
#line 6 "D:\C# Projects\HW22 MVC\HW21 MVC\Areas\User\Views\User\AddNoteResult.cshtml"
 
    private void ShowAddResult()
    {
        if ((bool)ViewData["OperRes"])
        {

#line default
#line hidden
#nullable disable
        WriteLiteral("            <span class=\"succes\">Operation Result Success.</span>\r\n");
#nullable restore
#line 12 "D:\C# Projects\HW22 MVC\HW21 MVC\Areas\User\Views\User\AddNoteResult.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
        WriteLiteral("            <span class=\"error\">\r\n                Operation Result Failure! Incorrect input! Check Fields!\r\n                Here is error info list:\r\n            </span>\r\n");
        WriteLiteral("            <div>\r\n");
#nullable restore
#line 21 "D:\C# Projects\HW22 MVC\HW21 MVC\Areas\User\Views\User\AddNoteResult.cshtml"
                  
                    var errors = (List<string>)ViewData["Errors"];
                    for (int i = 0; i < errors.Count; i++)
                    {

#line default
#line hidden
#nullable disable
        WriteLiteral("                        <ul class=\"erlist\">");
#nullable restore
#line 25 "D:\C# Projects\HW22 MVC\HW21 MVC\Areas\User\Views\User\AddNoteResult.cshtml"
                                      Write(errors[i]);

#line default
#line hidden
#nullable disable
        WriteLiteral("</ul>\r\n");
#nullable restore
#line 26 "D:\C# Projects\HW22 MVC\HW21 MVC\Areas\User\Views\User\AddNoteResult.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
        WriteLiteral("            </div>\r\n");
#nullable restore
#line 29 "D:\C# Projects\HW22 MVC\HW21 MVC\Areas\User\Views\User\AddNoteResult.cshtml"
        }
    }

    private void ShowRemoveresult()
    {
        if ((bool)ViewData["OperRes"])
        {

#line default
#line hidden
#nullable disable
        WriteLiteral("            <span class=\"succes\">Operation Result Success.</span>\r\n");
#nullable restore
#line 37 "D:\C# Projects\HW22 MVC\HW21 MVC\Areas\User\Views\User\AddNoteResult.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
        WriteLiteral("            <span class=\"error\">Operation Result Failure.</span>\r\n");
#nullable restore
#line 41 "D:\C# Projects\HW22 MVC\HW21 MVC\Areas\User\Views\User\AddNoteResult.cshtml"
        }
    }   

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591