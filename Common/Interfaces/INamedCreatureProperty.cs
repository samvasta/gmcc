namespace Common.Interfaces
{
    public interface INamedCreatureProperty
    {
         string Name { get; }
         string[] Aliases { get; }
         string Description { get; }
    }
}