using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_filmes_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) Generos
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        public string Nome { get; set; }
    }
}
