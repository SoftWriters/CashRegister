using Microsoft.AspNetCore.Http;

namespace CreativeCashDraw.Models.Home
{
    /// <summary>
    /// This class is a model to get file input info.
    /// </summary>
    public class FileInputModel
    {
        public IFormFile FileToUpload { get; set; }
    }
}
