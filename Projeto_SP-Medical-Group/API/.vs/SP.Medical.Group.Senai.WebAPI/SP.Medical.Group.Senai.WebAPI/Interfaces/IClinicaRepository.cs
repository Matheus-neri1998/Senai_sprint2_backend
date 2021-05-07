using SP.Medical.Group.Senai.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Interfaces
{
    /// <summary>
    /// Interface Clinica responsável repositório ClinicaRepository
    /// </summary>
    interface IClinicaRepository
    {
        List<Clinica> Listar();

        Clinica BuscarPorId(int id);

        void Cadastrar(Clinica NovaClinica);

        void Atualizar(int id, Clinica NovaClinica);

        void Deletar(int id);
    }
}
