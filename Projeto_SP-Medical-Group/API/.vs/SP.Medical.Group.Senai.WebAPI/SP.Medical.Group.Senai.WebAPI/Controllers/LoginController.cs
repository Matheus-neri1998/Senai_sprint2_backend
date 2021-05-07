using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SP.Medical.Group.Senai.WebAPI.Domains;
using SP.Medical.Group.Senai.WebAPI.Interfaces;
using SP.Medical.Group.Senai.WebAPI.Repositories;
using SP.Medical.Group.Senai.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public LoginController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Logar(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _UsuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email e senha inválidos");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmg-chave-autentição"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "SP.Medical.Group.Senai.WebAPI",    // Emissor do token
                    audience: "SP.Medical.Group.Senai.WebAPI",  // Destinatário do token
                    claims: claims,                             // Dados definidos acima
                    expires: DateTime.Now.AddDays(2),           // Tempo de expiração
                    signingCredentials: creds                   // Credenciais do token
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });


                }
                catch (Exception erro)
                
            {

                return BadRequest(erro);
            }



            
        } // Fim de Logar

    }
}
