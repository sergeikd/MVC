using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Oxagile.Internal.MVC.BL.Interfaces
{
    public interface IImageService
    {
        Task<Bitmap> ResizeImageAsync(string fileName, int width, int height);
        string GetImageFileName(string name, string surname, string fileName);
        void DeleteOldImage(string fileName);
        void ManagePhoto(Stream file, string oldFileName, string newFileName);
    }
}
