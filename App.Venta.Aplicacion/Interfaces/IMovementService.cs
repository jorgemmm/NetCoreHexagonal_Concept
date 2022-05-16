using System;
using System.Collections.Generic;
using System.Text;


using AppVenta.Dominio.Interfaces_CRUD;

namespace App.Venta.Aplicacion.Interfaces
{
    public interface IMovementService<TEntidad, TEntidadID>
    : IAdd<TEntidad>, IGet<TEntidad, TEntidadID>
    {
        void Anular(TEntidadID entidadId);
    }
}
