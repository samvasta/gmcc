using System;
using Common.Interfaces;
using Common.Models;

namespace Models.Creatures
{
    public class CreatureAction : ViewModelBase, INamedCreatureProperty
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

        //Creature actions should not have additional aliasesS
        public string[] Aliases { get; } = new string[0];

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                Set(ref _description, value);
            }
        }

        private string _actionText;
        public string ActionText
        {
            get { return _actionText; }
            set
            {
                Set(ref _actionText, value);
            }
        }
        
    }
}