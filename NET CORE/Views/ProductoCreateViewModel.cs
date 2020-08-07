using System;

namespace NET_CORE.Views
{
    public class ProductoCreateViewModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class ProductoUpdateViewModel : ProductoCreateViewModel
    {
        
    }

    

}