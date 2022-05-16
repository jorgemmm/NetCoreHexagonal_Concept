using System;
using System.Collections.Generic;
using System.Text;

using AppVenta.Dominio.Interfaces_CRUD;

namespace AppVenta.Dominio.Interfaces_CRUD.Repositories
{
    public interface IRepositoryBase<TEntidad, TEntidadID>
        : IAdd<TEntidad>, IGet<TEntidad, TEntidadID>, IEdit<TEntidad>, IDelete<TEntidadID>, ITransaction
    {

    }
}
