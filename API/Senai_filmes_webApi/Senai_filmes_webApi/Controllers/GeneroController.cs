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
    // ex: http://localhost:5000/api/generos
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
        [HttpGet]

        public IActionResult Get()
        {
            // Cria uma lista nomeada "ListaGeneros" para receber os dados
            List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de gêneros no formato JSON
            return Ok(ListaGeneros);
        }

    } 
}
