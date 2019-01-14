using System;
using Avalonia.Media.Imaging;

namespace Common.Interfaces
{
    public interface IStatusEffect : INamedCreatureProperty
    {
         IBitmap Icon { get; }

         void ApplyTo(ICreature creature);

         void RemoveFrom(ICreature creature);
    }
}