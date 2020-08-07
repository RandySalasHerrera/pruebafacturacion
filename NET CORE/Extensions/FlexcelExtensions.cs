using System.IO;
using System.Threading.Tasks;
using FlexCel.XlsAdapter;
using Microsoft.AspNetCore.Mvc;

public static class FexcelExtensions
{
    public static FileContentResult getFileStreamResult(this XlsFile file, string filename, string ContentType)
    {

        MemoryStream ms = new MemoryStream();

        // MemoryStream ms = new MemoryStream();
        file.Save(ms);
        ms.Position = 0;

        return getFileContentFromMS(ms, filename, ContentType);
    }

    public static FileContentResult getFileContentFromMS(this MemoryStream ms, string filename, string ContentType)
    {
        if(ms == null){
            return null;
        }

        ms.Position = 0;
        FileContentResult fs = new FileContentResult(ms.ToArray(), ContentType);
        fs.FileDownloadName = filename;
        
        return fs;
    }
}