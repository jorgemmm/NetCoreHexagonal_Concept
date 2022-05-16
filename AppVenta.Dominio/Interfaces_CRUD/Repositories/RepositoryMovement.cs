using System;
using System.Collections.Generic;
using System.Text;


using AppVenta.Dominio.Interfaces_CRUD;

namespace AppVenta.Dominio.Interfaces_CRUD.Repositories
{
    public interface IRepositoryMovement<TEntidad, TEntidadID>
    : IAdd<TEntidad>, IGet<TEntidad, TEntidadID>, ITransaction
    {
        void Anular(TEntidadID entidadId);
    }
}
