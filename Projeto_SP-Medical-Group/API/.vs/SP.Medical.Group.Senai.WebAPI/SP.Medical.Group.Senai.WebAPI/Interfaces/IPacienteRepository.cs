using SP.Medical.Group.Senai.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo reposiório PacienteRepository
    /// </summary>
    interface IPacienteRepository
    {
        List<Paciente> Listar();

        Paciente BuscarPorId(int id);

        void Cadastrar(Paciente NovoPaciente);

        void Atualizar(int id, string status);

        void Deletar(int id);
    }
}
