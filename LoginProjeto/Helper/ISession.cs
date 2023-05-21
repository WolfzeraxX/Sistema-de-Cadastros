using LoginProjeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProjeto.Helper
{
    public interface ISession
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoveSessaoUsuario();

        UsuarioModel BuscarSessaoUsuario();
    }
}
