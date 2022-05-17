using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces_CRUD
{
    interface IGet
    {
    }

    public interface IGet<TEntidad, TEntidadID>
    {
        List<TEntidad> Get(); //List de entidades

        TEntidad GetbyId(TEntidadID entityId);

    }
}
