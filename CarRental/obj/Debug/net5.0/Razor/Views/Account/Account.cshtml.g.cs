#pragma checksum "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67206f62c3707dab2502942a5a2eb0755f83ebd2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Account), @"mvc.1.0.view", @"/Views/Account/Account.cshtml")]
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
#line 1 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\_ViewImports.cshtml"
using CarRental;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\_ViewImports.cshtml"
using CarRental.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67206f62c3707dab2502942a5a2eb0755f83ebd2", @"/Views/Account/Account.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"529c8bd122fb22e8a9a1a9692f07307d414d2a18", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Account : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarRental.Models.Uzytkownik>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary px-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger px-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditUserPassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
  
    ViewData["Title"] = "Mój profil";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .card {
        position: relative;
        display: flex;
        flex-direction: column;
        min-width: 0;
        word-wrap: break-word;
        background-clip: border-box;
        border: 0 solid transparent;
        border-radius: .25rem;
        margin-bottom: 1.5rem;
        box-shadow: 0 2px 6px 0 rgb(218 218 253 / 65%), 0 2px 6px 0 rgb(206 206 238 / 54%);
    }

    .me-2 {
        margin-right: .5rem !important;
    }
</style>

<div>
    <div class=""container"">
        <div class=""main-body"">
            <div class=""row"">
                <div class=""col-lg-4"">
                    <div class=""card"">
                        <div class=""card-body"" style=""background:#f7f7ff"">
                            <div class=""d-flex flex-column align-items-center text-center"">
                                <img src=""https://bootdey.com/img/Content/avatar/avatar6.png"" class=""rounded-circle p-1 bg-prim@ary"" width=""110"">
                                <div class=""mt-3"">");
            WriteLiteral("\r\n");
#nullable restore
#line 34 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
                                     if (User.IsInRole("A"))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <p class=\"text-secondary mb-1\"><b>Admin</b></p> ");
#nullable restore
#line 36 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
                                                                                        }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <p class=\"text-secondary mb-1\"><b>Użytkownik</b></p>\r\n                                        <p class=\"text-secondary mb-1\">");
#nullable restore
#line 40 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
                                                                  Write(Model.Imie);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 40 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
                                                                              Write(Model.Nazwisko);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 41 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>
                            <hr class=""my-4"">
                            <ul class=""list-group list-group-flush"">
                            </ul>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-8"">
                    <div class=""card"">
                        <div class=""card-body"" style=""background:#f7f7ff"">
                            <div class=""d-flex align-items-center row mb-3"">
                                <div class=""col-sm-3"">
                                    <h6 class=""mb-0"">Nazwa użytkownika:</h6>
                                </div>
                                <div class=""col-sm-9 text-secondary"">
                                    <input class=""form-control"" type=""text""");
            BeginWriteAttribute("value", " value=\"", 2488, "\"", 2520, 1);
#nullable restore
#line 58 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
WriteAttributeValue("", 2496, Model.Nazwa_uzytkownika, 2496, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled />\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 61 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
                             if (!(User.IsInRole("A")))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""d-flex align-items-center row mb-3"">
                                    <div class=""col-sm-3"">
                                        <h6 class=""mb-0"">Imię:</h6>
                                    </div>
                                    <div class=""col-sm-9 text-secondary"">
                                        <input class=""form-control"" placeholder=""Brak Danych"" type=""text""");
            BeginWriteAttribute("value", " value=\"", 3134, "\"", 3153, 1);
#nullable restore
#line 68 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
WriteAttributeValue("", 3142, Model.Imie, 3142, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled />
                                    </div>
                                </div>
                                <div class=""d-flex align-items-center row mb-3"">
                                    <div class=""col-sm-3"">
                                        <h6 class=""mb-0"">");
#nullable restore
#line 73 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
                                                    Write(Html.DisplayNameFor(model => model.Nazwisko));

#line default
#line hidden
#nullable disable
            WriteLiteral(":</h6>\r\n                                    </div>\r\n                                    <div class=\"col-sm-9 text-secondary\">\r\n                                        <input class=\"form-control\" placeholder=\"Brak Danych\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 3728, "\"", 3751, 1);
#nullable restore
#line 76 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
WriteAttributeValue("", 3736, Model.Nazwisko, 3736, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled />
                                    </div>
                                </div>
                                <div class=""d-flex align-items-center row mb-3"">
                                    <div class=""col-sm-3"">
                                        <h6 class=""mb-0"">");
#nullable restore
#line 81 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
                                                    Write(Html.DisplayNameFor(model => model.Numer_telefonu));

#line default
#line hidden
#nullable disable
            WriteLiteral(":</h6>\r\n                                    </div>\r\n                                    <div class=\"col-sm-9 text-secondary\">\r\n                                        <input class=\"form-control\" placeholder=\"Brak Danych\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 4332, "\"", 4361, 1);
#nullable restore
#line 84 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
WriteAttributeValue("", 4340, Model.Numer_telefonu, 4340, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled />
                                    </div>
                                </div>
                                <div class=""d-flex align-items-center row mb-3"">
                                    <div class=""col-sm-3"">
                                        <h6 class=""mb-0"">");
#nullable restore
#line 89 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
                                                    Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(":</h6>\r\n                                    </div>\r\n                                    <div class=\"col-sm-9 text-secondary\">\r\n                                        <input class=\"form-control\" placeholder=\"Brak Danych\" type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 4933, "\"", 4953, 1);
#nullable restore
#line 92 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
WriteAttributeValue("", 4941, Model.Email, 4941, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled />
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-sm-3""></div>
                                    <div class=""col-sm-9 text-secondary"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67206f62c3707dab2502942a5a2eb0755f83ebd214527", async() => {
                WriteLiteral("Edytuj dane");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67206f62c3707dab2502942a5a2eb0755f83ebd216100", async() => {
                WriteLiteral("Zmień Hasło");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n                                </div> ");
#nullable restore
#line 101 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
                                       }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"row\">\r\n                                    <div class=\"col-sm-3\"></div>\r\n                                    <div class=\"col-sm-9 text-secondary\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67206f62c3707dab2502942a5a2eb0755f83ebd218261", async() => {
                WriteLiteral("Zmień Hasło");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </div>\r\n                                </div>");
#nullable restore
#line 109 "C:\Users\Mateusz\source\repos\CarRental\CarRental\Views\Account\Account.cshtml"
                                      }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-sm-12"">
                            <div class=""card"">

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarRental.Models.Uzytkownik> Html { get; private set; }
    }
}
#pragma warning restore 1591