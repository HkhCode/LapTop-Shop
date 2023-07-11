using System.Globalization;

namespace Laptop_shop.Utilities
{
    public static class ImageAndBytesHandler
    {
        public static string ByteArrayToImage(byte[] bytes)
        {
            string base64Data = Convert.ToBase64String(bytes);
            string dataUrl = string.Format("data:image/png;base64;{0}" , base64Data);
            return dataUrl;
        }
        public static byte[] ImageToByteArray(string path)
        {
            byte[] byteData = System.IO.File.ReadAllBytes(path);
            return byteData;
        }
    }
}
