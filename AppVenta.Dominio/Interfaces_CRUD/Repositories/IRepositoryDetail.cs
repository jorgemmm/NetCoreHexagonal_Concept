using System;
using System.Collections.Generic;
using System.Text;
using AppVenta.Dominio.Interfaces_CRUD;
namespace AppVenta.Dominio.Interfaces_CRUD.Repositories
{
    public interface IRepositoryDetail<TEntidad, TMovimientoID>
    : IAdd<TEntidad>, ITransaction
    {
    }
}
