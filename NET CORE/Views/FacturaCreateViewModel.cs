using System;

namespace NET_CORE.Views
{
    public class FacturaCreateViewModel
    {
        public int ClienteId { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class FacturaUpdateViewModel : FacturaCreateViewModel
    {
        
    }

    

}