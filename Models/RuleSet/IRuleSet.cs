using System;
using System.Collections.Generic;
using Models.Attributes;
using Models.Creatures;

namespace Models.RuleSet
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