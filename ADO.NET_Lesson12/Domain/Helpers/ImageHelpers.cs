using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ADO.NET_Lesson12.Domain.Helpers
{
    public class ImageHelpers
    {
        public static string GetImagePath(byte[] buffer, int counter)
        {
            ImageConverter ic = new ImageConverter();
            var data = ic.ConvertFrom(buffer);
            Image img = data as Image;
            if (img != null)
            {
                Bitmap bitmap1 = new Bitmap(img);
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ServerImages");
                Directory.CreateDirectory(path);
                var p = $@"{path}\image{counter}.png";
                if (!File.Exists(p))
                    bitmap1.Save(p);
                var imagepath = $@"{path}\image{counter}.png";
                return imagepath;
            }
            else
            {
                return String.Empty;
            }
        }
        public static byte[] GetBytesOfImage(string path)
        {
            var image = new Bitmap(path);
            ImageConverter imageconverter = new ImageConverter();
            var imagebytes = ((byte[])imageconverter.ConvertTo(image, typeof(byte[])));
            return imagebytes;
        }
    }
}
