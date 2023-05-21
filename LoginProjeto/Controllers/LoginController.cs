using LoginProjeto.Helper;
using LoginProjeto.Models;
using LoginProjeto.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProjeto.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISession _isession;
        private readonly IEmail _email;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                                ISession session, 
                                IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _isession = session;
            _email = email;
        }
        public IActionResult Index()
        {
            if (_isession.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Email);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _isession.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"A é senha Invalida , verifique os dados";

                    }
                    TempData["MensagemErro"] = $"Usuario e/ou senha Invalido(os) , verifique os dados";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possivel Realizar o Login{ erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost] 
        public IActionResult EnviarLinkSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(redefinirSenhaModel.Email);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        
                        string mensagem = $"Sua nova senha é:{novaSenha}";
                        bool EmailEnviado = _email.Enviar(usuario.Email, "Sistema de Contatos - Nova senha", mensagem);
                        if (EmailEnviado)
                        {
                            _usuarioRepositorio.Editar(usuario);
                            TempData["MensagemSucesso"] = "Enviamos um E-Mail de Recuperação de senha para você :)";
                        }
                        else
                        {
                            TempData["MensagemErro"] = "Não Conseguimos enviar o Email  , Por favor tente novamente.";
                        }


                        
                        return RedirectToAction("Index", "Login");

                    }
                    TempData["MensagemErro"] = "E-Mail informado Invalido Por favor , escreva um E-Mail Cadastrado";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possivel Recuperar sua Senha{ erro.Message}";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Sair()
        {
            _isession.RemoveSessaoUsuario();

            return RedirectToAction("Index", "Login");
        }
    }
}
