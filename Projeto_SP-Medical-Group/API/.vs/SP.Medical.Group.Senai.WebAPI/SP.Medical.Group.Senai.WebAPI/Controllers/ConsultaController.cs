using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP.Medical.Group.Senai.WebAPI.Domains;
using SP.Medical.Group.Senai.WebAPI.Interfaces;
using SP.Medical.Group.Senai.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Controllers
{
    [Produces("application/json")
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _ConsultaRepository { get; set; }

        public ConsultaController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_ConsultaRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim de Listar

        [HttpGet("{Id}")]

        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_ConsultaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim de BuscarPorId

        [HttpPost]

        public IActionResult Cadastrar(Consulta NovaConsulta)
        {
            try
            {
                _ConsultaRepository.Cadastrar(NovaConsulta);

                return StatusCode(201);        
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim de Cadastrar

        [HttpPut ("{Id}")]

        public IActionResult Atualizar(int id, Consulta ConsultaAtualizada)
        {
            try
            {
                _ConsultaRepository.Atualizar(id, ConsultaAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim de Atualizar

        [HttpDelete ("{Id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _ConsultaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        } // Fim de Deletar

        [HttpGet ("{Listar Minhas}")]

        public IActionResult GetMy()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(_ConsultaRepository.ListarMinhas(IdUsuario));
            }
            catch (Exception erro)
            {

                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado",
                    erro
                });
            }
        } // Fim de ListarMinhas

        [Authorize(Roles = "1")]
        [HttpPatch("{Id}")]

        public IActionResult AtualizarStatus(int id, string permissao)
        {
            try
            {
                _ConsultaRepository.AtualizarStatus(id, permissao);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(new
                {
                    mensagem = "Somente o administrador pode alterar a situação da consulta",
                    erro
                }) ;
            }
        } // Fim de AtualizarStatus

        [Authorize(Roles = "2")]
        [HttpPatch("{Descrição/Id}")]

        public IActionResult UpdateDescption(int id, Consulta NovoProntuario)
        {
            try
            {
                _ConsultaRepository.Prontuario(id, NovoProntuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(new
                {
                    mensagem = "Somente o médico pode alterar a descrição",
                    erro
                });
                
            }
        }
    }
}
