using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.IO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

/// <summary>
/// Controller responsável pelos endpoints (URLs) de Usuário
/// </summary>
namespace senai.inlock.webApi_.Controllers
{
    // Define que o tipo de resposta da requisição será no formato json
    [Produces("application/json")]

    // Define que a rota da requisição da API será no formato: dominio/api/nomecontrolador
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }
       

        /// <summary>
        /// Intancia o objeto _usuarioRepository para que haja os métodos no repositório
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Faz a autenticação do usuário
        /// </summary>
        /// <param name="login">Objeto com os dados de email e senha</param>
        /// <returns>Um status code e, em caso de sucesso os dados do usuário buscado</returns>
        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain UsuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            // Caso não encontre um usuário com email e senha
            if (UsuarioBuscado == null)
            {
                // Retorna NotFound (Não encontrado) com uma mensagem
                return NotFound("Email e Senha inválidos");
            }
            // Caso encontre, prossegue para criação do token

            // Define os dados que serão fornecidos no token - Payload
            var claims = new[]
            {                           // Tipo da Claim | Valor da Claim
                new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdTipoUsuario.ToString()),
                new Claim(ClaimTypes.Role, UsuarioBuscado.Senha ),
                new Claim("Claim personalizada", "Valor teste")
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Inlock-chave-autentição"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Define a composição do token
            var token = new JwtSecurityToken(
                issuer: "Inlock.webApi",             // Emissor do token
                audience: "Inlock.webApi",           // Destinatório do token
                claims: claims,                      // Dados definidos acima, a partir da linha 59
                expires: DateTime.Now.AddHours(2),   // Tempo de expiração
                signingCredentials: creds            // Credenciais do token
            );

            // Retorna um status code 200 - Ok com o token criado 
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            }) ;

        } // Fim de Login
        
          
    } // Fim de UsuarioController
}
