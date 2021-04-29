using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class UsuarioDomain
    {
        // Coluna IdUsuario
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o seu email")]
        public string Email { get; set; } // Coluna Email

        [Required(ErrorMessage = "Informe a sua senha")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha´precisa ter no mínimo 3 e no máximo 20 caracteres")]
        public string Senha { get; set; } // Coluna Senha

        public int IdTipoUsuario { get; set; } // Coluna IdTipoUsuario

    }
}
