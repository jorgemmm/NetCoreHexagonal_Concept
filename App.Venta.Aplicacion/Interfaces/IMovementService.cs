using System;
using System.Collections.Generic;
using System.Text;


using AppVenta.Dominio.Interfaces_CRUD;

namespace AppVenta.Aplicacion.Interfaces
{
    public interface IMovementService<TEntidad, TEntidadID>
    : IAdd<TEntidad>, IGet<TEntidad, TEntidadID>
    {
        //Cancel 
        void Refound(TEntidadID entidadId);
    }
}
