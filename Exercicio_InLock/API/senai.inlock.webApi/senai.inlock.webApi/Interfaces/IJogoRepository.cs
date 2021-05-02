using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IJogoRepository
    {
        
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista com todos os jogos</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto "novoJogo" com as informações a serem cadastradas</param>
        void Cadastrar(JogoDomain novoJogo);
    }
}

