using System;
using Avalonia.Media.Imaging;
using Models.Creatures;

namespace Models.RuleSet
{
    public interface IStatusEffect : INamedCreatureProperty
    {
         IBitmap Icon { get; }

         void ApplyTo(ICreature creature);

         void RemoveFrom(ICreature creature);
    }
}