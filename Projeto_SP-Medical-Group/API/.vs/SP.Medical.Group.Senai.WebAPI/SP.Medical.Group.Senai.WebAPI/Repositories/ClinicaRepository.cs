using SP.Medical.Group.Senai.WebAPI.Context;
using SP.Medical.Group.Senai.WebAPI.Domains;
using SP.Medical.Group.Senai.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {

        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Atualizar(int id, Clinica NovaClinica)
        {
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            if (NovaClinica.Cnpj != null)
            {
                clinicaBuscada.Cnpj = NovaClinica.Cnpj;
            }

            if (NovaClinica.Endereco != null)
            {
                clinicaBuscada.Endereco = NovaClinica.Endereco;
            }

            if (NovaClinica.NomeFantasia != null)
            {
                clinicaBuscada.NomeFantasia = NovaClinica.NomeFantasia;
            }

            if (NovaClinica.RazaoSocial != null)
            {
                clinicaBuscada.RazaoSocial = NovaClinica.RazaoSocial;
            }

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.Find(id);
        }

        public void Cadastrar(Clinica NovaClinica)
        {
            ctx.Clinicas.Add(NovaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clinicas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
