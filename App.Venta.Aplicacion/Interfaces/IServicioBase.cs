using System;
using System.Collections.Generic;
using System.Text;

using AppVenta.Dominio.Interfaces_CRUD;

namespace AppVenta.Aplicacion.Interfaces
{
    interface IServicioBase<TEntidad, TEntidadID>
        : IAdd<TEntidad>, IGet<TEntidad, TEntidadID>, IEdit<TEntidad>, IDelete<TEntidadID>
    {
    }
}
