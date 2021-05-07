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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _ClinicaRepository { get; set; }

        public ClinicaController()
        {
            _ClinicaRepository = new ClinicaRepository();
        }

        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                return Ok(_ClinicaRepository.Listar());

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
                return Ok(_ClinicaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim de BuscarPorId

        [HttpPost]

        public IActionResult Cadastrar(Clinica NovaClinica)
        {
            try
            {
                _ClinicaRepository.Cadastrar(NovaClinica);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim de Cadastrar

        [HttpPut("{Id}")]

        public IActionResult Update(int id, Clinica NovaClinica)
        {
            try
            {
                _ClinicaRepository.Atualizar(id, NovaClinica);

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
                _ClinicaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        } // Fim de Deletar
    }
}
