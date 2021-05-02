using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.inlock.webApi_.Domains
{
    public class JogoDomain
    {
        // Coluna IdJogo
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        // Coluna NomeJogo
        public string NomeJogo { get; set; }

        // Coluna Descricao
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        // Coluna DataLancamento
        public DateTime DataLancamento { get; set; }

        // Coluna Valor
        public double Valor { get; set; }

        [Required(ErrorMessage = "O Id do estúdio desenvolvedor é obrigatório")]
        // Coluna IdEstudio
        public int IdEstudio { get; set; }
    }
}
