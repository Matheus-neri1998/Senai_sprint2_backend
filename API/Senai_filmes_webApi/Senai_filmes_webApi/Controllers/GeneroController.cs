using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_filmes_webApi.Domains;
using Senai_filmes_webApi.Interfaces;
using Senai_filmes_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoint (são os pontos onde será feito a requisição) referentes aos gêneros
/// </summary>
namespace Senai_filmes_webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato "json"
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/nomeController
    // ex: http://localhost:5000/api/genero 
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto "_generoRepositoty" que irá receber todos os métodos definidos na interface "IGeneroRepository" 
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }


        /// <summary>
        /// Intancia o objeto "_generoRepositoty" para que haja a referência aos métodos no repositório
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();

        } // Fim do método construtor 



        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Uma lista de gêneros e um status code</returns>
        /// http://localhost:5000/api/genero
        [HttpGet]

        public IActionResult Get()
        {
            // Cria uma lista nomeada "ListaGeneros" para receber os dados
            List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de gêneros no formato JSON
            return Ok(ListaGeneros);

        } // Fim do "Get"



       
        /// <summary>
        /// Busca um genero através do seu Id
        /// </summary>
        /// <param name="id">Id do genero que será buscado</param>
        /// <returns>Um genero buscado ou Not Found caso nenhum genero seja encontrado</returns>
        /// http://localhost:5000/api/genero/1
        [HttpGet("{Id}")]

        public IActionResult GetById(int id)
        {
            // Cria um objeto chamado "GeneroBuscado" que irá receber o genero buscado no banco de dados
            GeneroDomain GeneroBuscado = _generoRepository.BuscarPorId(id);

            // Verifica se nenhum genero foi encontrado 
            if (GeneroBuscado == null)
            {   
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem
                return NotFound("Nenhum genero encontrado!");
            }

            // Caso seja encontrado, retorna o genero buscado com um status code 200 - Ok
            return Ok(GeneroBuscado);

        } // Fim de GetById 


       
        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <returns >Retorna um status code 201 - Created </returns>
        /// http://localhost:5000/api/genero
        [HttpPost]

        public IActionResult Post(GeneroDomain NovoGenero)
        {
            // Faz a chamada para o método Cadastrar
            _generoRepository.Cadastrar(NovoGenero);

            // Retorna um Status Code 201 - Created
            return StatusCode(201);

        } // Fim do "Post"



        /// <summary>
        /// Atualiza um genero existente passando o seu Id pela Url da requisiçaõ
        /// </summary>
        /// <param name="id">Id do genero que será atualizado</param>
        /// <param name="GeneroAtualizado">Objeto GeneroAtualizado com as novas informações</param>
        /// <returns>Retorna um status code</returns>
        /// http://localhost/api/genero/1
        [HttpPut ("{Id}")] // Obs: Verbo Put atualiza todos os campos de uma determinada entidade, nesse caso (Generos)

        public IActionResult PutIdUrl(int id, GeneroDomain GeneroAtualizado)
        {
            // Cria um objeto generobuscado que irá receber o genêro que for buscado no banco de dados
            GeneroDomain generobuscado = _generoRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna Not Found com mensagem personalizada
            // Além de um booleano (bool) para apresentar que houve erro
            if (generobuscado == null)
            {
                return NotFound // Erro 404 - Não encontrado
                    (
                         new
                         {
                             mensagem = "Genero não encontrado!",
                             erro = true
                         }

                    ) ;
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para método AtualizarIdUrl
                _generoRepository.AtualizarIdUrl(id, GeneroAtualizado);

                // Retorna um status code 204 - NoContent
                return NoContent();
            }
            // Caso ocorra algum erro 
            catch (Exception CodigodoErro)
            {
                // Retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(CodigodoErro);
            }
        } // Fim de PutIdUrl



        /// <summary>
        /// Atualizando um genero existente passando o seu Id pelo corpo da requisição
        /// </summary>
        /// <param name="GeneroAtualizado">Objeto GeneroAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain GeneroAtualizado)
        {
            // Cria um objeto generobuscado que irá receber o genêro que for buscado no banco de dados
            GeneroDomain generobuscado = _generoRepository.BuscarPorId(GeneroAtualizado.IdGenero);

            // Verifica se algum genero for encontrado
            if (generobuscado == null)
            {
                try
                {
                    // Faz a chamada para o método AtualizarIdCorpo
                    _generoRepository.AtualizarIdCorpo(GeneroAtualizado);

                    // Retorna um status code - 204 -> NoContent -> Sem conteúdo
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception CodErro)
                {
                    // Retorna um status code - BadRequest com o código do erro
                    return BadRequest(CodErro);
                }
            }
            // Caso não seja encontrado, retorna o erro Not Found com mensagem personalizada em formato JSON
            return NotFound

            (
                new
                {
                    mensagem = "Gênero não encontrado!"
                }

            );
        } // Fim de PutIdBody



        /// <summary>
        /// Deleta um genêro existente
        /// </summary>
        /// <param name="id">id do genero que será deletado</param>
        /// <returns>Retorna um status code 204 - No Content</returns>
        ///  http://localhost:5000/api/genero/2
        [HttpDelete("{Id}")]

        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método Deletar
            _generoRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);

        } // Fim de delete

    } 
}
