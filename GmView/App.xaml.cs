using Avalonia;
using Avalonia.Markup.Xaml;

namespace GmView
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}