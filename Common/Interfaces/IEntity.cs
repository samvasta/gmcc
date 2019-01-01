using Avalonia.Media.Imaging;

namespace Common.Interfaces
{
    public interface IEntity
    {
         string EntityName { get; set; }

         IBitmap Icon { get; }

         IBitmap MapToken { get; set; }
    }
}