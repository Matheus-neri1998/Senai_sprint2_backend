using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Busca um usuário através de seu email e senha
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Senha"></param>
        /// <returns></returns>
        UsuarioDomain BuscarPorEmailSenha(string Email, string Senha);
    }
}
