using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_filmes_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) Filmes
    /// </summary>
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        public string Titulo { get; set; }

        public int? IdGenero { get; set; }
    }
}
