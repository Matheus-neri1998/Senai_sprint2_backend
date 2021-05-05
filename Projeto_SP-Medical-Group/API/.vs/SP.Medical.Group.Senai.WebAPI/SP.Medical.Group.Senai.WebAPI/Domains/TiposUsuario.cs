using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SP.Medical.Group.Senai.WebAPI.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) de TiposUsuarios
    /// </summary>
    public partial class TiposUsuario
    {
        public TiposUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }

        // Define que o campo é obrigatório
        [Required(ErrorMessage ="O tipo de usuário é obrigatório")]
        public string TipoUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
