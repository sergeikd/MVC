using System;
using System.Web.Mvc;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using Oxagile.Internal.MVC.BL.Interfaces;
using Oxagile.Internal.MVC.Infrastructure.Interfaces;

namespace Oxagile.Internal.MVC.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IConfigService _configService;

        #region Constructor
        public ImageController(IImageService imageService, IConfigService configService)
        {
            if (imageService == null)
            {
                throw new ArgumentNullException(nameof(imageService));
            }
                
            if (configService == null)
            {
                throw new ArgumentNullException(nameof(configService));
            }
                
            _imageService = imageService;
            _configService = configService;
        }
        #endregion

        public async Task ResizePhoto(string fileName)
        {
            var newImage = await _imageService.ResizeImageAsync(fileName, _configService.IcoWidth, _configService.IcoHeight);
            newImage.Save(ControllerContext.HttpContext.Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}