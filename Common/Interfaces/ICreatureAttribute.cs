using Common.Enums;

namespace Common.Interfaces
{
    public interface ICreatureAttribute
    {
        string Name { get; set; }
        AttributeKind AttributeKind { get; set; }
        string ValueFunction { get; set; }
    }
}