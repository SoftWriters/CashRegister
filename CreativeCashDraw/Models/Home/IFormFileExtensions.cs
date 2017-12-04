using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;

namespace CreativeCashDraw.Models.Home
{
    /// <summary>
    /// This static class is to provide quick common utility methods
    /// </summary>
    public static class IFormFileExtensions
    {
        public static async Task<MemoryStream> GetFileStream(this IFormFile file)
        {
            MemoryStream filestream = new MemoryStream();
            await file.CopyToAsync(filestream);
            return filestream;
        }
    }
}
