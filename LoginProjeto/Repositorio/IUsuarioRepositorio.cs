using LoginProjeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProjeto.Repositorio
{
    public interface IUsuarioRepositorio
    {   
        UsuarioModel BuscarPorLogin(string Email);
        UsuarioModel ListarPorId(int Id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);

        UsuarioModel Editar(UsuarioModel usuario);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        bool Deletar(int id);
    }
}
