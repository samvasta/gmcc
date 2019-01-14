using System;
using System.Collections.Generic;

using Common.Interfaces;
using Common.Models;

namespace Common.Interfaces
{
    public interface ICreature : IEntity
    {
        List<IStatusEffect> StatusEffects { get; }

        int GetAttributeValue(ICreatureAttribute attribute);
    }
}