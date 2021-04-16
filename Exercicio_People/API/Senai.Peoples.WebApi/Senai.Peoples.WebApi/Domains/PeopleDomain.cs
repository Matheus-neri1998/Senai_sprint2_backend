using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Senai.Peoples.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (Tabela) Funcionarios
    /// </summary>
    public class PeopleDomain
    {
        
        public int IdFuncionario { get; set; }
        public string nome { get; set; }

        [Required(ErrorMessage = "O sobrenome do funcionário é obrigatório!")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "O sobrenome do funcionário deve conter de 5 a 10 caracteres.")]
        public string sobrenome { get; set; }

        // DataType não valida campo, apenas especifica o tipo do campo
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
