#pragma checksum "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0518a1cab5298ef9e60e1c55b3c1cd80399c08b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuarios_AutenticarUsuario), @"mvc.1.0.view", @"/Views/Usuarios/AutenticarUsuario.cshtml")]
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
#line 1 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\_ViewImports.cshtml"
using RpgMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\_ViewImports.cshtml"
using RpgMvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0518a1cab5298ef9e60e1c55b3c1cd80399c08b", @"/Views/Usuarios/AutenticarUsuario.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ea8742186739939b51d95376aeaeffef3697b50", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuarios_AutenticarUsuario : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RpgMvc.Models.UsuarioViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
  
ViewBag.Title = "Autenticar";

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
 if(@TempData["Mensagem"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success\" role=\"alert\">\r\n        ");
#nullable restore
#line 7 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
   Write(TempData["Mensagem"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 9 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
 if (TempData["MensagemErro"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\" role=\"alert\">\r\n        ");
#nullable restore
#line 14 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
   Write(TempData["MensagemErro"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 16 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Aréa de login do Úsuario</h2>\r\n<hr>\r\n");
#nullable restore
#line 19 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
 using (Html.BeginForm("Autenticar", "Usuarios", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
                            
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-horizontal\">\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label col-md-2\">\r\n                    Usuario\r\n                </label>\r\n                <div class=\"col-md-6\">\r\n                    ");
#nullable restore
#line 29 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
               Write(Html.EditorFor(model => model.UserName, new {htmlattributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label class=\"control-label col-md-2\">\r\n                    Senha\r\n                </label>\r\n                <div class=\"col-md-6\">\r\n                    ");
#nullable restore
#line 37 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
               Write(Html.PasswordFor(model => model.PasswordString, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>
            <br>
            <input type=""submit"" value=""Acessar"" class=""btn btn-success"">
            <br>
            <div class=""form-group"">
                <p><a href=""/Usuarios"">Nunca acessou nosso sistema? Clique aqui para registrar-se!!</a></p>
            </div>
        </div>
");
#nullable restore
#line 47 "D:\ETEC\etec2\DS-I\RPGapi\Front-end\RpgMvc\RpgMvc\Views\Usuarios\AutenticarUsuario.cshtml"
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RpgMvc.Models.UsuarioViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591