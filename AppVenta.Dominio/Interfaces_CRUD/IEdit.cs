using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces_CRUD
{
   
    public interface IEdit<TEntidad>
    {
        void Edit(TEntidad entidad);

    }
}
