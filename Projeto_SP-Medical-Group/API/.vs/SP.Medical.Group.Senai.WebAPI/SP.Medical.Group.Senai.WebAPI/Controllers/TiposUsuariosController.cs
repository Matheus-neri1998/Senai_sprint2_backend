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
    public class TiposUsuariosController : ControllerBase
    {
        private ITiposUsuarioRepository _TiposUsuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _TiposUsuarioRepository = new TiposUsuarioRepository();
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_TiposUsuarioRepository.Listar());

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
                return Ok(_TiposUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim de BuscarPorId

        [HttpPost]

        public IActionResult Cadastrar(TiposUsuario TipoUsuario)
        {
            try
            {
                _TiposUsuarioRepository.Cadastrar(TipoUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim de Cadastrar

        [HttpPut("{Id}")]

        public IActionResult Update(int id, TiposUsuario NovoTipousuario)
        {
            try
            {
                _TiposUsuarioRepository.Atualizar(id, NovoTipousuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim de Atualizar

        [HttpDelete("{Id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _TiposUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim de Deletar

    }
}
