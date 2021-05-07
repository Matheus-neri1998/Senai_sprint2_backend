using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP.Medical.Group.Senai.WebAPI.Domains;
using SP.Medical.Group.Senai.WebAPI.Interfaces;
using SP.Medical.Group.Senai.WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_UsuarioRepository.Listar());
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
                return Ok(_UsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim do método BuscarPorId

        [HttpPost]
        public IActionResult Cadastrar(Usuario NovoUsuario)
        {
            try
            {
                _UsuarioRepository.Cadastrar(NovoUsuario);

                return StatusCode(201); 
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim do método Cadastrar

        [HttpPut("{Id}")]

        public IActionResult Update(int id, Usuario Usuario)
        {
            try
            {
                _UsuarioRepository.Atualizar(id, Usuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim do método Atualizar

        [HttpDelete("{Id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _UsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim dp método Deletar

        }
    
    
    }
