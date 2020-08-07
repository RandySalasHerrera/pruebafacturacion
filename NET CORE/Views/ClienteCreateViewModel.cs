using System;

namespace NET_CORE.Views
{
    public class ClienteCreateViewModel
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int Edad { get; set; }
    }

    public class ClienteUpdateViewModel : ClienteCreateViewModel
    {
        
    }

    

}