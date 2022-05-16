using System;
using System.Collections.Generic;
using System.Text;

using AppVenta.Dominio.Interfaces_CRUD;

namespace AppVenta.Dominio.Interfaces_CRUD.Repositorios
{
    public interface IRepositorioBase<TEntidad, TEntidadID>
        : IAdd<TEntidad>, IGet<TEntidad, TEntidadID>, IEdit<TEntidad>, IDelete<TEntidad>, ITransaction
    {

    }
}
