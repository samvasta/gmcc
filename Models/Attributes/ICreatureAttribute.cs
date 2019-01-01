using Common.Enums;
using Models.RuleSet;

namespace Models.Attributes
{
    public interface ICreatureAttribute : INamedCreatureProperty
    {
        AttributeKind AttributeKind { get; }
        string ValueFunction { get; }
    }
}