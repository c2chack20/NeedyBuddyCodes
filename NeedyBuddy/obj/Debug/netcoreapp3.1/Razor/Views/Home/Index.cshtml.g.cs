#pragma checksum "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41371edac257ac80fc3102799b8a04c279b4dfe8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\_ViewImports.cshtml"
using NeedyBuddy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\_ViewImports.cshtml"
using NeedyBuddy.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41371edac257ac80fc3102799b8a04c279b4dfe8", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a4739e18981068739688d9519a4027bcd66e4f1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NeedyBuddy.Data.Model.ServiceCategory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("main-search-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MyAction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41371edac257ac80fc3102799b8a04c279b4dfe84728", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"">

    $(document).ready(function () {
        $(function () {


            $('.select-service, input[name=""serviceList""]').change(updateServiceElements);

            function updateServiceElements(e) {
                var serviceValueAttribute = '[value=""' + e.target.value + '""]';
                //$('input:checked').removeAttr('checked');
                $(':radio').each(function () {
                    $('input[type=""radio""]').prop('checked', false);
                })
                $('.select-service option' + serviceValueAttribute).prop('selected', true);
                $('input[name=""serviceList""]' + serviceValueAttribute).prop('checked', true);
            }

        });
    });
</script>
<!-- Header Section end -->
<!-- Hero Section end -->
<section class=""hero-section set-bg"" data-setbg=""~/img/hero-bg.jpg"">
    <div class=""container"">
        <div class=""hero-warp"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41371edac257ac80fc3102799b8a04c279b4dfe86746", async() => {
                WriteLiteral("\r\n\r\n");
                WriteLiteral("                <div class=\"search-type\">\r\n");
#nullable restore
#line 37 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
                      
                        var isFirstChecked = false;
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
                     foreach (var item in Model.Take(3))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <div class=\"st-item\">\r\n                            <input ");
#nullable restore
#line 43 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
                               Write(isFirstChecked ? "" : "checked");

#line default
#line hidden
#nullable disable
                WriteLiteral(" type=\"radio\" name=\"serviceList\" id=\"");
#nullable restore
#line 43 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
                                                                                                     Write(item.ServiceName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" value=\"");
#nullable restore
#line 43 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
                                                                                                                               Write(item.ServiceCategoryId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\" >\r\n                            <label");
                BeginWriteAttribute("for", " for=\"", 1761, "\"", 1784, 1);
#nullable restore
#line 44 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
WriteAttributeValue("", 1767, item.ServiceName, 1767, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 1785, "\"", 1813, 1);
#nullable restore
#line 44 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
WriteAttributeValue("", 1790, item.ServiceCategoryId, 1790, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 44 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
                                                                                   Write(item.ServiceName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                        </div>\r\n");
#nullable restore
#line 46 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
                        isFirstChecked = true;
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                </div>\r\n                <div class=\"search-input\">\r\n                    <input type=\"text\" placeholder=\"Search by state, postcode or suburb\" name=\"searchtext\" id=\"searchtext\">\r\n");
                WriteLiteral("\r\n                    <select name=\"serviceList\" id=\"serviceList\" class=\"select-service\">\r\n");
#nullable restore
#line 56 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41371edac257ac80fc3102799b8a04c279b4dfe810626", async() => {
                    WriteLiteral("\r\n                                ");
#nullable restore
#line 59 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
                           Write(item.ServiceName);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
                               WriteLiteral(item.ServiceCategoryId);

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
#line 61 "C:\Users\Mann\Documents\TeamGIt\NeedyBuddy\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </select>\r\n\r\n");
                WriteLiteral(@"                    <button class=""site-btn"">Search</button>
                </div>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices gravida. </p>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- Hero Section end -->\r\n<!-- Stories Section end -->\r\n<section class=\"stories-section spad\">\r\n    <div class=\"container\">\r\n        <div class=\"row \">\r\n");
            WriteLiteral(@"           
            <div class=""col-lg-7 order-lg-1"">
                <div class=""about-text"">
                    <h2 class=""text-white"">Success Stories</h2>
                    <hr />
                    <h4 class=""text-danger"">What the world can learn from Kerala about how to fight covid-19</h4><br />
                    <p class=""text-white"">The sun had already set on March 7 when Nooh Pullichalil Bava received the call. “I have bad news,” his boss warned. On February 29, a family of three had arrived in the Indian state of Kerala from Italy, where they lived. The trio skipped a voluntary screening for covid-19 at the airport and took a taxi 125 miles (200 kilometers) to their home in the town of Ranni. When they started developing symptoms soon afterward, they didn’t alert the hospital. Now, a whole week after taking off from Venice, all three—a middle-­aged man and woman and their adult son—had tested positive for the virus, and so had two of their elderly relatives. </p>
                </di");
            WriteLiteral(@"v>
                <a target=""_blank"" href=""https://www.technologyreview.com/2020/04/13/999313/kerala-fight-covid-19-india-coronavirus/"" class=""readmore-btn"">Find out more</a>
            </div>
        </div>
    </div>
</section>
<!-- Stories Section end -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NeedyBuddy.Data.Model.ServiceCategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
