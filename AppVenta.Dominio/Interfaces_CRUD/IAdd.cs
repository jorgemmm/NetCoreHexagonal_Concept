using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces_CRUD
{
    public interface IAdd<TEntidad>    {

        TEntidad Add(TEntidad entity);      

    }
}
