using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Oxagile.Internal.MVC.BL.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace Oxagile.Internal.MVC.BL.Services
{
    public class ImageService : IImageService
    {
        private readonly string _imagesFolderPath;
        public ImageService(string imagesFolderPath)
        {
            _imagesFolderPath = imagesFolderPath;
        }
        public async Task<Bitmap> ResizeImageAsync(string fileName, int width, int height)
        {
            return await Task.Run(() => ResizeImage(fileName, width, height));
        }
        private Bitmap ResizeImage(string fileName, int width, int height)
        {
            var filePath = GetFilePath(fileName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            using (var file = Image.FromFile(filePath))
            {
                destImage.SetResolution(file.HorizontalResolution, file.VerticalResolution);
                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(file, destRect, 0, 0, file.Width, file.Height, GraphicsUnit.Pixel,
                            wrapMode);
                    }
                }                
            }
            return destImage;
        }

        public string GetImageFileName(string name, string surname, string fileName)
        {
            var fileExtPos = fileName.LastIndexOf(".", StringComparison.Ordinal);
            var fileExtension = fileName.Substring(fileExtPos, fileName.Length - fileExtPos);
            var newFileName = name + surname;
            var filePath = GetFilePath(newFileName) + fileExtension;
            if (File.Exists(filePath))
            {
                var success = false;
                var copyNum = 1;
                while (!success)
                {
                    newFileName = name + surname + "("+ copyNum + ")";
                    if (File.Exists(GetFilePath(newFileName) + fileExtension))
                    {
                        var copyNumCurrent = Convert.ToInt16(newFileName.Substring(newFileName.LastIndexOf("(", StringComparison.Ordinal) + 1, 
                            newFileName.LastIndexOf(")", StringComparison.Ordinal) - newFileName.LastIndexOf("(", StringComparison.Ordinal) -1));
                        copyNum = copyNumCurrent + 1;
                        continue;
                    }
                    success = true;
                }
            }
            return newFileName + fileExtension;
        }

        public void ManagePhoto(Stream file, string oldFileName, string newFileName)
        {
            var filePath = GetFilePath(newFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            if (oldFileName != null && oldFileName != newFileName)
                DeleteOldImage(oldFileName);
        }

        public void DeleteOldImage(string fileName)
        {
            var filePath = GetFilePath(fileName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }
            File.Delete(filePath);
        }

        private string GetFilePath(string fileName)
        {
            return AppDomain.CurrentDomain.BaseDirectory + _imagesFolderPath.Replace("~/", "").TrimStart().Replace("/", @"\") + fileName;
        }
    }
}
