using Senai_filmes_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_filmes_webApi.Interfaces
{
    public interface IFilmeRepository
    {
        // TipoRetorno NomeMetodo (TipoParametro NomeParametro)

        List<FilmeDomain> ListarTodos(); // Método Read

        FilmeDomain BuscarPorId(int id); // Método Read

        void Cadastrar(FilmeDomain NovoFilme); // Método Create

        void AtualizarIdCorpo(FilmeDomain movie); // Método Update

        void AtualizarIdUrl(int id, FilmeDomain movie); // Método Update

        void DeletarFilme(int id); // Método Delete




    }
}
