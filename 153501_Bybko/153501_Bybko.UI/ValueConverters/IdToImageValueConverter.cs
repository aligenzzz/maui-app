using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Globalization;
using System.Resources;

namespace _153501_Bybko.UI.ValueConverters
{
    internal class IdToImageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imagePath = $"i{value}i.png";

            string directoryPath = "/storage/emulated/0/Android/data/com.companyname.x_153501_bybko.ui/cache/Images/";

            //if (Directory.Exists(directoryPath))
            //{
            //    string[] files = Directory.GetFiles(directoryPath);
            //    string[] directories = Directory.GetDirectories(directoryPath);
            //}

            if (!File.Exists(Path.Combine(directoryPath, imagePath)))
                imagePath = "i0i.png";

            return imagePath;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
