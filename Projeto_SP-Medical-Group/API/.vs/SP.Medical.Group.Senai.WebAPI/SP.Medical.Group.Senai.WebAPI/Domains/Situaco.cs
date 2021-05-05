using System;
using System.Collections.Generic;

#nullable disable

namespace SP.Medical.Group.Senai.WebAPI.Domains
{
    public partial class Situaco
    {
        public Situaco()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }
        public string Situacao { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
        public object IdSituacaoNavigation { get; internal set; }
        public object ConsultaNavigation { get; internal set; }
        public object SituacaoNavigation { get; internal set; }
    }
}
