#pragma checksum "E:\Projects\c2chack20\NeedyBuddyCodes\NeedyBuddy\Views\ContactUs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5e02aa47156fa79ccb263d7a078cf44f7ccb8dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContactUs_Index), @"mvc.1.0.view", @"/Views/ContactUs/Index.cshtml")]
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
#line 1 "E:\Projects\c2chack20\NeedyBuddyCodes\NeedyBuddy\Views\_ViewImports.cshtml"
using NeedyBuddy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projects\c2chack20\NeedyBuddyCodes\NeedyBuddy\Views\_ViewImports.cshtml"
using NeedyBuddy.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5e02aa47156fa79ccb263d7a078cf44f7ccb8dd", @"/Views/ContactUs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a4739e18981068739688d9519a4027bcd66e4f1", @"/Views/_ViewImports.cshtml")]
    public class Views_ContactUs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("contact-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Projects\c2chack20\NeedyBuddyCodes\NeedyBuddy\Views\ContactUs\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""contact-section"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-5"">
                <div class=""section-title text-left"">
                    <h2>Get in touch</h2>
                </div>
                <div class=""contact-text"">
                    <p>
                        We love hearing from readers and people from the design community. We really appreciate you taking the time to get in touch. Please fill out the form below. *Please note: We will get back to you shortly, usually within 2-3 days. Also note that if you send an email on a Friday, we may get back to you only on the following Monday or Tuesday. If you are contacting us for a business proposal or regarding advertising please mention it in your message. You may also reach us on Twitter and Facebook. We’re looking forward to hearing from you!

                    </p>
                </div>
            </div>
            <div class=""col-lg-7"">
                <div class=""ro");
            WriteLiteral(@"w"">
                    <div class=""col-sm-4"">
                        <div class=""contact-info-box"">
                            <div class=""ci-icon"">
                                <span>TA</span>
                            </div>
                            <h4>Telengana</h4>
                            <p>500032 Gachibowli circle, Hyderabad, India </p>
                        </div>
                    </div>
                    <div class=""col-sm-4"">
                        <div class=""contact-info-box"">
                            <div class=""ci-icon"">
                                <span>OD</span>
                            </div>
                            <h4>Odisha</h4>
                            <p>752081 Bhubaneswar, India </p>
                        </div>
                    </div>
                    <div class=""col-sm-4"">
                        <div class=""contact-info-box"">
                            <div class=""ci-icon"">
                                <span>KA");
            WriteLiteral(@"</span>
                            </div>
                            <h4>Karnataka</h4>
                            <p>987388 Indiranagar, Bangaluru, India </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5e02aa47156fa79ccb263d7a078cf44f7ccb8dd6242", async() => {
                WriteLiteral(@"
            <div class=""row"">
                <div class=""col-lg-4"">
                    <input type=""text"" placeholder=""Your name"">
                </div>
                <div class=""col-lg-4"">
                    <input type=""text"" placeholder=""Your e-mail"">
                </div>
                <div class=""col-lg-4"">
                    <input type=""text"" placeholder=""Subject"">
                </div>
                <div class=""col-lg-12"">
                    <textarea placeholder=""Message""></textarea>
                    <button class=""site-btn sb-big"">Send message</button>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</section>\r\n<!-- Contact Section end -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591