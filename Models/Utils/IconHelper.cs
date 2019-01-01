using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Avalonia.Media.Imaging;

namespace Models.Utils
{
    public static class IconHelper
    {
        private static readonly Dictionary<string, IBitmap> _cachedIcons = new Dictionary<string, IBitmap>();

        public static IBitmap GetIcon(string iconName)
        {
            if(_cachedIcons.ContainsKey(iconName))
            {
                return _cachedIcons[iconName];
            }


            Assembly ass = Assembly.GetAssembly(typeof(IconHelper));
            var resourceStream = ass.GetManifestResourceStream($"EmbeddedResource.Resources.Icons.{iconName}");
            Bitmap icon =  new Bitmap(resourceStream);
            _cachedIcons[iconName] = icon;

            return icon;
        }
    }
}