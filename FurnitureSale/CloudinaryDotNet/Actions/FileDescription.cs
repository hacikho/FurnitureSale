using System.Web;

namespace CloudinaryDotNet.Actions
{
    internal class FileDescription : CloudinaryDotNet.FileDescription
    {
        private HttpPostedFileBase productImage;

        public FileDescription(string filePath) : base(filePath)
        {
        }

        
    }
}