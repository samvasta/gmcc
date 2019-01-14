using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IRuleSet
    {
         string Name { get; }

         string Description { get; }

        List<ICreatureAttribute> AllCreatureAttributes { get; }

         bool IsDead(ICreature creature);

         void RollAttribute(ICreatureAttribute attr, int advantage = 0);

         
    }
}