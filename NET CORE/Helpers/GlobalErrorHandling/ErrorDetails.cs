using Newtonsoft.Json;

namespace EPublico.Core.Helpers.GlobalErrorHandling
{
    public class ErrorDetails
    {
 
        public string message { get; set; }
        public  int code { get; set; }
        public  int number { get; set; }
        public  string action { get; set; } = "Cerrar";
        public  string CustomCss { get; set; } = "cm-error";


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class CustomObjectResult
    {

        public bool success { get; set; }
        public ErrorDetails data { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}