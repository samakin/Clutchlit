#pragma checksum "E:\Clutchlit2\Clutchlit\Clutchlit\Views\AllegroAuctions\EditOffer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91f119b6e5de0cd85470bd37418614009d2fc7f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AllegroAuctions_EditOffer), @"mvc.1.0.view", @"/Views/AllegroAuctions/EditOffer.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AllegroAuctions/EditOffer.cshtml", typeof(AspNetCore.Views_AllegroAuctions_EditOffer))]
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
#line 1 "E:\Clutchlit2\Clutchlit\Clutchlit\Views\_ViewImports.cshtml"
using Clutchlit;

#line default
#line hidden
#line 2 "E:\Clutchlit2\Clutchlit\Clutchlit\Views\_ViewImports.cshtml"
using Clutchlit.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91f119b6e5de0cd85470bd37418614009d2fc7f1", @"/Views/AllegroAuctions/EditOffer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3906bc195ced385164f3d15e7c37db7594154460", @"/Views/_ViewImports.cshtml")]
    public class Views_AllegroAuctions_EditOffer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Clutchlit.Models.Auction>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Clutchlit2\Clutchlit\Clutchlit\Views\AllegroAuctions\EditOffer.cshtml"
   
    ViewData["Title"] = "Edytuj aukcję | Aukcje | Dział allegro";
    ViewData["Title_1"] = "Aukcje";
    ViewData["Title_2"] = "Edytuj aukcję";

#line default
#line hidden
            BeginContext(189, 1481, true);
            WriteLiteral(@"
<div class=""box"">
    
    <div class=""box-header with-border"">
        <h3 class=""box-title"">Edytuj aukcję</h3>
        <div class=""box-tools pull-right"">
            <button type=""button"" class=""btn btn-box-tool"" data-widget=""collapse"" data-toggle=""tooltip"" title="""" data-original-title=""Zwiń"">
                <i class=""fa fa-minus""></i>
            </button>
            <button type=""button"" class=""btn btn-box-tool"" data-widget=""remove"" data-toggle=""tooltip"" title="""" data-original-title=""Zamknij"">
                <i class=""fa fa-times""></i>
            </button>
        </div>
    </div>
    <div class=""box-body "">

        <table id=""example3"" class=""table table-bordered table-hover"">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Tytuł aukcji</th>
                    <th>Kategoria</th>
                    <th>Miniatura</th>
                    <th>Cena</th>
                    <th>Obserwujący</th>
                    <th>Odwiedzin");
            WriteLiteral(@"</th>
                </tr>
            </thead>

            <tfoot>
                <tr>
                    <th>Id</th>
                    <th>Tytuł aukcji</th>
                    <th>Kategoria</th>
                    <th>Miniatura</th>
                    <th>Cena</th>
                    <th>Obserwujący</th>
                    <th>Odwiedzin</th>
                </tr>
            </tfoot>
        </table>

    </div>

</div>
");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Clutchlit.Models.Auction> Html { get; private set; }
    }
}
#pragma warning restore 1591
