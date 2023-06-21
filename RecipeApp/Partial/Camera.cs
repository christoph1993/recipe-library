using RecipeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public partial class Camera : IRecipeCamera
    {
        public async Task<byte[]> TakePhoto()
        {
            FileResult image = await MediaPicker.Default.CapturePhotoAsync();
            using var ms = new MemoryStream();
            (await image.OpenReadAsync()).CopyTo(ms);
            return ms.ToArray();
        }
    }
}
