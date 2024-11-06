using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ImageDisplayApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        // Endpoint to get an image by filename
        [HttpGet("{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", imageName);

            if (System.IO.File.Exists(imagePath))
            {
                var imageFile = System.IO.File.ReadAllBytes(imagePath);
                return File(imageFile, "image/jpeg");  // Set the appropriate MIME type for the image
            }

            return NotFound();
        }
    }
}
