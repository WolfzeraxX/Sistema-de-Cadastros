using LoginProjeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProjeto.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int Id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Editar(ContatoModel contato);

        bool Deletar(int id);
    }
}
