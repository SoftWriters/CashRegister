using System.Collections.Generic;

namespace CreativeCashDraw.Models.Home
{
    /// <summary>
    /// This class is to store output data which is rendered in the presentation layer.
    /// </summary>
    public class FileOutputModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
        public bool InvalidFile { get; set; }
        public List<CheckoutModel> CheckoutModel { get; set; }
    }
    
}
