using Common.Enums;
using Common.Interfaces;
using Common.Models;

namespace Models.Attributes
{
    public abstract class CreatureAttributeBase : ViewModelBase, ICreatureAttribute
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                Set(ref _name, value);
            }
        }

        private string[] _aliases;
        public string[] Aliases
        {
            get { return _aliases; }
            set
            {
                Set(ref _aliases, value);
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                Set(ref _description, value);
            }
        }

        public abstract AttributeKind AttributeKind { get; }

        private string _valueFunction;
        public string ValueFunction
        {
            get { return _valueFunction; }
            set
            {
                Set(ref _valueFunction, value);
            }
        }

    }
}