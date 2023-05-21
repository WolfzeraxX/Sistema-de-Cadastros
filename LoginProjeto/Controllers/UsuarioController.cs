using HtmlAgilityPack;
using LoginProjeto.Models;
using LoginProjeto.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProjeto.Controllers
{
    public class UsuarioController :Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possivel Cadastrar seu Usuario, erro :{erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Deletar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Deletar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato Deletado com Sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = $"Não foi Possivel Deletar o cadastro seu Contato";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possivel Deletar o cadastro seu Contato, erro :{erro.Message}";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {

                UsuarioModel usuario = null;
                               
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Email = usuarioSemSenhaModel.Email,
                        
                    };
                    

                    usuario =  _usuarioRepositorio.Editar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Editado com Sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possivel Alterar o cadastro seu Usuario, erro :{erro.Message}";
                return RedirectToAction("Index");
            }



        }
    }



}

