using System;
using System.Collections.Generic;
using System.Text;

namespace AppVenta.Dominio.Interfaces_CRUD
{
    //Operaciones de persistencia
    public interface ITransaction
    {
        void SaveAllChanges();
    }
}
