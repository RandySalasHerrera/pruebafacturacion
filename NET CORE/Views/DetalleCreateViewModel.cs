using System;

namespace NET_CORE.Views
{
    public class DetalleCreateViewModel
    {
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }

    public class DetalleUpdateViewModel : DetalleCreateViewModel
    {
        
    }

    

}