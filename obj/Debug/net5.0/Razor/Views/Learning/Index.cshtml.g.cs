#pragma checksum "C:\Users\Ogy\Desktop\New folder\eLearningPlatform\Views\Learning\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e239ad96c1618f760a4cc9a8f8ed697bff962cdc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Learning_Index), @"mvc.1.0.view", @"/Views/Learning/Index.cshtml")]
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
#line 2 "C:\Users\Ogy\Desktop\New folder\eLearningPlatform\Views\_ViewImports.cshtml"
using eLearning.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ogy\Desktop\New folder\eLearningPlatform\Views\_ViewImports.cshtml"
using eLearning.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e239ad96c1618f760a4cc9a8f8ed697bff962cdc", @"/Views/Learning/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d08e203c7621157923377933e15beec8e9ae5562", @"/Views/_ViewImports.cshtml")]
    public class Views_Learning_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Ogy\Desktop\New folder\eLearningPlatform\Views\Learning\Index.cshtml"
  
    ViewBag.Title = "E-learning";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Navigation -->
<nav>
    <div class=""logo"">
        <a href=""index.html""><span>e</span>Learning</a>
    </div>
    <!-- KORISNIK NIJE REGISTROVAN -->
    <div class=""content"">
        <a href=""register.html"">Register</a>
        <a href=""login.html"">Login</a>
    </div>
    <!-- SAMO KADA JE KORISNIK REGISTROVAN  -->
    <!-- <div class=""user"">
        <i class=""fas fa-user fa-2x""></i>
        <p><span>Welcome</span> Jovan Jovanovic</p>
    </div> -->
</nav>


<!-- INTRO SECTION -->
<section class=""main"">
    <div class=""main-left"">
        <h1>Best free <br> Online Courses</h1>
        <!-- KORISNIK NIJE REGISTROVAN -->
        <a href=""register.html"">Sign in to see the content we offer</a>
        <!-- SAMO KADA JE KORISNIK REGISTROVAN (PRIKAZ SKOLA I KURSEVA) -->
        <!-- <div class=""content"">
            <a href=""#"">Courses</a>
            <a href=""#"">Schools</a>
        </div> -->
    </div>
    <div class=""main-right"">
        <img src=""images/slika2.png""");
            BeginWriteAttribute("alt", " alt=\"", 1061, "\"", 1067, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n    </div>\r\n</section>");
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
