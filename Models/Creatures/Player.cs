using System.Collections.Generic;
using Avalonia.Media.Imaging;
using Common.Interfaces;
using Common.Models;
using Models.Utils;
using Models.RuleSet;
using Models.Attributes;

namespace Models.Creatures
{
    public class Player : ViewModelBase, ICreature
    {
        private string _entityName;
        public string EntityName
        {
            get { return _entityName; }
            set
            {
                Set(ref _entityName, value);
            }
        }

        public IBitmap Icon { get { return IconHelper.GetIcon("face.png"); } }

        private IBitmap _mapToken;
        public IBitmap MapToken
        {
            get { return _mapToken; }
            set
            {
                Set(ref _mapToken, value);
            }
        }

        private List<IStatusEffect> _statusEffects;
        public List<IStatusEffect> StatusEffects
        {
            get { return _statusEffects; }
            set
            {
                Set(ref _statusEffects, value);
            }
        }
    }
}