using Common.Enums;

namespace Common.Interfaces
{
    public interface ICreatureAttribute : INamedCreatureProperty
    {
        AttributeKind AttributeKind { get; }
        string ValueFunction { get; }
    }
}