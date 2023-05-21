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
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositoio)
        {
            _contatoRepositorio = contatoRepositoio;

        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
         

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possivel Cadastrar seu Contato, erro :{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Editar(contato);
                    TempData["MensagemSucesso"] = "Contato Editado com Sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi Possivel Alterar o cadastro seu Contato, erro :{erro.Message}";
                return RedirectToAction("Index");
            }



        }

        public IActionResult Deletar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Deletar(id);
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
        }
    }

