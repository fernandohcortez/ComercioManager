using Helpers;
using System.Drawing;

namespace CM.UI.Desktop.Helpers
{
    public static class FileDialogBoxHelper
    {
        public static byte[] OpenDialogForImage()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = "png",
                Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"
            };

            var result = dlg.ShowDialog();

            if (result != true)
                return null;

            var filename = dlg.FileName;

            var foto = Image.FromFile(filename);

            return ImageHelper.ImageToByteArray(foto);
        }
    }
}
