using System;

using AppVentas.Infraestructura.Datos.Contextos;



namespace AppVentas.Infraestructura.Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando Bsse de datos si no existe");

            SaleContext db = new SaleContext();

            db.Database.EnsureCreated();
            Console.WriteLine(" Base de datos creada ");

            Console.ReadKey();
        }
    }
}
