using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces_CRUD
{
   
    public interface IDelete<TEntidad>
    {
        void Delete(TEntidad entidad);

    }
}
