using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoint (pontos de requisição) referentes aos funcionários (People)
/// </summary>
namespace Senai.Peoples.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/nomeController (people)
    // Ex: http://localhost:5001/api/people
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class PeopleController : ControllerBase
    {
        /// <summary>
        /// Objeto _peopleRepository que irá receber todos os métodos definidos na interface IPeopleRepository
        /// </summary>
        private IPeopleRepository _peopleRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _peopleRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public PeopleController()
        {

            _peopleRepository = new PeopleRepository();
        }

        /// <summary>
        /// Lista todos os funcionários
        /// </summary>
        /// <returns>Uma lista de funcionários e um status code - 200 (Ok) </returns>
        /// http://localhost:5001/api/people
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada "ListaPeoples" para receber os dados
            List<PeopleDomain> ListaPeoples = _peopleRepository.Listar();

            // Retorna o status code 200 (Ok) com a lista de funcionários no formato JSON
            return Ok(ListaPeoples);
        }

        /// <summary>
        /// Busca um funcionário através do seu id
        /// </summary>
        /// <param name="id">id do funcionário que será buscado</param>
        /// <returns>Um funcionário ou NotFound caso nenhum funcionário seja encontrado</returns>
        /// http://localhost:5000/api/people/1
        [HttpGet ("{Id}")]

        public IActionResult GetById(int id)
        {
            // Cria um objeto "peopleBuscado" que irá receber o funcionário buscado no banco de dados
            PeopleDomain peopleBuscado = _peopleRepository.BuscarPorId(id);

            // Verifica se nenhum funcionário foi encontrado
            if (peopleBuscado == null) // Fazendo uma comparação
            {
                // Caso não seja encontrado, retorna um status code 404 - NotFound com a mensagem personalizada
                return NotFound("Nenhum funcionário foi encontrado");
            }
            // Caso seja encontrado, retorna um funcionário com o status code 200 - Ok
            return Ok(peopleBuscado);
        }

        /// <summary>
        /// Insere um novo funcionário
        /// </summary>
        /// <param name="newPeople">Objeto "newPeople" com as novas informações</param>
        /// <returns>Um status code 201 - Created</returns>
        /// http://localhost:5001/api/people/11
        [HttpPost]

        public IActionResult Post(PeopleDomain newPeople)
        {
            // Faz a chamada para o método Inserir
            _peopleRepository.Inserir(newPeople);

            // Retorna um status code - 201 - Created
            return StatusCode(201);
        }

        [HttpPut ("{Id}")]

        public IActionResult PutIdUrl(int id, PeopleDomain PeopleAtualizado)
        {
            PeopleDomain PeopleBuscado = _peopleRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada e um booleano para apresentar que houve erro
            if (PeopleBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Funcionário não encontrado",
                            erro = true
                        }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método AtualizarIdUrl
                _peopleRepository.AtualizarIdUrl(id, PeopleAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception CodErro)
            {
                // Retorna um BadRequest - 404 e o código do erro
                return BadRequest(CodErro);
            }
        }

        /// <summary>
        /// Deleta um funcionário existente através do seu id
        /// </summary>
        /// <param name="id">id do funcionário que será deletado</param>
        /// <returns>Retorna um Status code 204 - No Content</returns>
        ///  http://localhost:5001/api/people/9
        [HttpDelete("{Id}")]

        public IActionResult Delete(int id)
        {
            // Faz a chamada para método Deletar
            _peopleRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
           
        }
    }
}
