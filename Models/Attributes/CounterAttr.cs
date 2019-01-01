using System;
using Common.Enums;
using Common.Interfaces;

namespace Models.Attributes
{
    public class CounterAttr : CreatureAttributeBase
    {
        public override AttributeKind AttributeKind { get { return AttributeKind.Counter; } }
    }
}