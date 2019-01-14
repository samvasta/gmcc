using System;
using System.Collections.Generic;
using Common.Interfaces;

namespace EngineTest.Grammar
{
    public class TestRuleSet : IRuleSet
    {
        public string Name => "Test Rule Set";

        public string Description => "Rule Set for unit tests";

        private List<ICreatureAttribute> _allCreatureAttributes;
        public List<ICreatureAttribute> AllCreatureAttributes 
        {
            get { return _allCreatureAttributes; }
        }

        private ICreatureAttribute _healthAttr;


        public bool IsDead(ICreature creature)
        {
            return creature.GetAttributeValue(_healthAttr) <= 0;
        }

        public void RollAttribute(ICreatureAttribute attr, int advantage = 0)
        {
            throw new NotImplementedException();
        }
    }
}