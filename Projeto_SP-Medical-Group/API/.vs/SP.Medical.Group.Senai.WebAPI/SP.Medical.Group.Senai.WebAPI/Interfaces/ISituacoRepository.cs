using SP.Medical.Group.Senai.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Medical.Group.Senai.WebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório SituacoRepository
    /// </summary>
    interface ISituacoRepository
    {
        /// <summary>
        /// Lista as situações
        /// </summary>
        /// <returns>Uma lista das situações</returns>
        List<Situaco> Listar();

        /// <summary>
        /// Atualiza uma situação
        /// </summary>
        /// <param name="id">Id de alguma situação que será atualizada</param>
        /// <param name="NovaSituaco">Objeto NovaSituaco com as novas informações</param>
        void Atualizar(int id, Situaco NovaSituaco);
    }
}
