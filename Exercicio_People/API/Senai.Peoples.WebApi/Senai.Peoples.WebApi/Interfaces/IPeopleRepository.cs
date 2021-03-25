using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório PeopleRepository
    /// </summary>
    public interface IPeopleRepository
    {
        // TipoRetorno NomeMetodo(TipoParametro NomeParametro)

        /// <summary>
        /// Método Listar irá listar todos os funcionários
        /// </summary>
        /// <returns>Uma lista de Funcionários</returns>
        List<PeopleDomain> Listar();

        /// <summary>
        /// Método BuscarPorId irá buscar um funcionário através do seu Id
        /// </summary>
        /// <param name="id">Id do Funcionario que será buscado</param>
        /// <returns>Um objeto Funcionario que foi buscado</returns>
        PeopleDomain BuscarPorId(int id);

        /// <summary>
        /// Insere um novo funcionário
        /// </summary>
        /// <param name="newPeople">Objeto chamado "newPeople" com as informações que serão inseridas</param>
        void Inserir(PeopleDomain newPeople);

        /// <summary>
        /// Atualiza um genero existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do funcionário que será atualizado</param>
        /// <param name="people">Objeto people com as novas informações</param>
        void AtualizarIdUrl(int id, PeopleDomain people);

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do funcionário que será deletado</param>
        void Deletar(int id);
    }
}
