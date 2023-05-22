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
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISession _session;
        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio,
                                        ISession session)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _session = session;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        { // Metodo de alteração de Senha
            try
            {
                UsuarioModel usuarioLogado = _session.BuscarSessaoUsuario();
                alterarSenhaModel.id = usuarioLogado.Id;
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha Alterada com Sucesso";
                    return View("Index", alterarSenhaModel);
                }
                return View("Index", alterarSenhaModel);
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi Possivel alterar a sua senha erro {ex.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
