using System;
using System.Collections.Generic;

#nullable disable

namespace SP.Medical.Group.Senai.WebAPI.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int? IdMedico { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdSituacao { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Horario { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situaco IdSituacaoNavigation { get; set; }
        public object DataConsultaNavigation { get; internal set; }
        public object HorarioNavigation { get; internal set; }
        public object DescricaoNavigation { get; internal set; }
        public object IdConsultaNavigation { get; internal set; }
    }
}
