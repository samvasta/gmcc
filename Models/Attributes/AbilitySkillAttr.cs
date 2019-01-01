using System;
using Common.Enums;
using Common.Interfaces;

namespace Models.Attributes
{
    public class AbilitySkillAttr : CreatureAttributeBase
    {
        public override AttributeKind AttributeKind { get { return AttributeKind.AbilitySkill; } }
    }
}