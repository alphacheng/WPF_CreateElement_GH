using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace CreateElement
{
    class ImageUtil
    {
        public static BitmapImage GetBitmapImage(string ResourceName)
        {
            System.Drawing.Bitmap bitmap = GetDimensionBitmap(ResourceName);

            BitmapImage bitmapImage = new BitmapImage();

            if (bitmap != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                    memory.Position = 0;                    
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();

                    return bitmapImage;
                }
            }
            else
            {
                return null;
            }
            
            
            
        }

        private static System.Drawing.Bitmap GetDimensionBitmap(string ImageName)
        {
            System.Drawing.Bitmap _bitmap = (System.Drawing.Bitmap)My.Resources.ShapeDimensions.ResourceManager.GetObject(ImageName);

            return _bitmap;
        }
    }
}
