using System;
using Common.Enums;
using Common.Interfaces;

namespace Models.Attributes
{
    public class AbilityAttr : CreatureAttributeBase
    {
        public override AttributeKind AttributeKind { get { return AttributeKind.Ability; } }
    }
}