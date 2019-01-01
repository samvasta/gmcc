using System;
using System.Collections.Generic;

using Models.RuleSet;
using Common.Interfaces;

namespace Models.Creatures
{
    public interface ICreature : IEntity
    {
        List<IStatusEffect> StatusEffects { get; }
    }
}