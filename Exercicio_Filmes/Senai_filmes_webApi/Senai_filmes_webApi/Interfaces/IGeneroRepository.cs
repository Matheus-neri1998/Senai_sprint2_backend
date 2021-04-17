using Senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_filmes_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        // TipoRetorno NomeMetodo(TipoParamentro NomeParametro);

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos(); // Método Read

        /// <summary>
        /// Busca um gênero através de seu Id
        /// </summary>
        /// <param name="id">Id do gênero que será buscado</param>
        /// <returns>Um objeto gênero que foi buscado</returns>
        GeneroDomain BuscarPorId(int id); // Método Read

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto chamado "novoGenero" com as informações que serão cadastradas</param>
        void Cadastrar(GeneroDomain novoGenero); // Método Create

        /// <summary>
        /// Atualiza um gênero existente passando o Id pelo corpo da requisição  
        /// </summary>
        /// <param name="genero">Objeto gênero com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero); // Método UpDate

        /// <summary>
        /// Atualiza um gênero existente passando pela Url da requisição
        /// </summary>
        /// <param name="id">Id do gênero que será atualizado</param>
        /// <param name="genero">Objeto gênero que com as novas informações </param>
        void AtualizarIdUrl(int id, GeneroDomain genero); // Método Update

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        void Deletar(int id); // Método Delete 

    } // Fim da interface IGeneroRepository
}
