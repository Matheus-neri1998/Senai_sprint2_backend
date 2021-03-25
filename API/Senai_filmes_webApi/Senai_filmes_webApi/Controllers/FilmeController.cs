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
/// Essa classe é um Controller responsável pelos endpoints referente à Filme
/// </summary>
namespace Senai_filmes_webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato json
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/filme
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FilmeController : ControllerBase
    {
        /// <summary>
        /// Objeto _FilmeRepostory que irá receber todos os métodos definidos na interface IFilmeRepository
        /// </summary>
        private IFilmeRepository _FilmeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto "_FilmeRepository" para que haja a referência aos métodos no repositório
        /// </summary>
        public FilmeController()
        {
            _FilmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os filmes 
        /// </summary>
        /// <returns>Uma lista de filmes e um status code</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            // Cria uma lista nomeada "ListaFilmes" para receber os dados 
            List<FilmeDomain> ListaFilmes = _FilmeRepository.ListarTodos();

            // Retorna um status code 200 (Ok) com a lista de filmes no formato JSON
            return Ok(ListaFilmes);

        } // Fim de listar



        /// <summary>
        /// Busca um filme através do seu Id
        /// </summary>
        /// <param name="id">Id do filme que será buscado</param>
        /// <returns>Um genero buscado ou Not Found caso nenhum genero seja encontrado</returns>
        /// http://localhost:5000/api/filme/1
        [HttpGet("{Id}")]

        public IActionResult GetById(int id)
        {
            // Cria um objeto chamado "FilmeBuscado" que irá receber o genero buscado no banco de dados
            FilmeDomain FilmeBuscado = _FilmeRepository.BuscarPorId(id);

            // Verifica se nenhum filme foi encontrado 
            if (FilmeBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem
                return NotFound("Nenhum genero encontrado!");
            }

            // Caso seja encontrado, retorna o filme buscado com um status code 200 - Ok
            return Ok(FilmeBuscado);

        } // Fim de GetById 



        [HttpPost]

        public IActionResult Post(FilmeDomain NovoFilme)
        {
            // Objeto usado para fazer a chamada do método Cadastrar
            _FilmeRepository.Cadastrar(NovoFilme);

            // Retorna um Status code 201 - Created
            return StatusCode(201);

        } // Fim de Post/Método Cadastrar


        /// <summary>
        /// Atualiza um filme existente passando o seu Id pela Url da requisiçaõ
        /// </summary>
        /// <param name="id">Id do filme que será atualizado</param>
        /// <param name="FilmeAtualizado">Objeto FilmeAtualizado com as novas informações</param>
        /// <returns>Retorna um status code</returns>
        /// http://localhost/api/filme/1
        [HttpPut("{Id}")] // Obs: Verbo Put atualiza todos os campos de uma determinada entidade, nesse caso (Filme)

        public IActionResult PutIdUrl(int id, FilmeDomain FilmeAtualizado)
        {
            // Cria um objeto filmebuscado que irá receber o filme que for buscado no banco de dados
            FilmeDomain filmebuscado = _FilmeRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna Not Found com mensagem personalizada
            // Além de um booleano (bool) para apresentar que houve erro
            if (filmebuscado == null)
            {
                return NotFound // Erro 404 - Não encontrado
                    (
                         new
                         {
                             mensagem = "Genero não encontrado!",
                             erro = true
                         }

                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para método AtualizarIdUrl
                _FilmeRepository.AtualizarIdUrl(id, FilmeAtualizado);

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
        /// Atualizando um filme existente passando o seu Id pelo corpo da requisição
        /// </summary>
        /// <param name="FilmeAtualizado">Objeto FilmeAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(FilmeDomain FilmeAtualizado)
        {
            // Cria um objeto Filmebuscado que irá receber o filme que for buscado no banco de dados
            FilmeDomain Filmebuscado = _FilmeRepository.BuscarPorId(FilmeAtualizado.IdFilme);

            // Verifica se algum filme for encontrado
            if (Filmebuscado == null)
            {
                try
                {
                    // Faz a chamada para o método AtualizarIdCorpo
                    _FilmeRepository.AtualizarIdCorpo(FilmeAtualizado);

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


        [HttpDelete("{ID}")]

        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método DeletarFilme
            _FilmeRepository.DeletarFilme(id);

            // Retorna um Status code 204 - No Content
            return StatusCode(204);
        }

    }
}
