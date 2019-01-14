using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media.Imaging;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Engine.Parsers.Grammar;
using Models.Attributes;

namespace Models.Creatures
{
    public class Creature : ViewModelBase, ICreature
    {
        private CreatureProto _prototype;
        public CreatureProto Prototype
        {
            get { return _prototype; }
            set
            {
                Set(ref _prototype, value);
            }
        }

        public string EntityName
        {
            get { return Prototype.EntityName; }
            set { throw new InvalidOperationException("EntityName should never be set on a creature instance. Instead, prefer to set it on the prototype."); }
            }

        private string _individualName;
        public string IndividualName
        {
            get { return _individualName; }
            set
            {
                Set(ref _individualName, value);
            }
        }

        public IBitmap Icon { get { return Prototype.Icon; } }

        public IBitmap MapToken
        {
            get { return Prototype.MapToken; }
            set { throw new InvalidOperationException("MapToken should never be set on a creature instance. Instead, prefer to set it on the prototype."); }
            }

        public List<CreatureAction> CreatureActions { get { return Prototype.CreatureActions; } }

        private Dictionary<AbilityAttr, int> _abilityScores;
        /// <summary>
        /// Dictionary of {ability attribute definitions, values}
        /// </summary>
        public Dictionary<AbilityAttr, int> AbilityScores
        {
            get { return _abilityScores; }
            set
            {
                Set(ref _abilityScores, value);
            }
        }

        private Dictionary<AbilitySkillAttr, int> _abilitySkillScores;
        /// <summary>
        /// Dictionary of {ability skill attribute definitions, values}
        /// </summary>
        public Dictionary<AbilitySkillAttr, int> AbilitySkillScores
        {
            get { return _abilitySkillScores; }
            set
            {
                Set(ref _abilitySkillScores, value);
            }
        }

        private Dictionary<CounterAttr, CounterValue> _counterValues;
        /// <summary>
        /// Dictionary of {counter attribute definitions, values}
        /// </summary>
        public Dictionary<CounterAttr, CounterValue> CounterValues
        {
            get { return _counterValues; }
            set
            {
                Set(ref _counterValues, value);
            }
        }

        private Dictionary<OtherAttr, int> _otherScores;
        /// <summary>
        /// Dictionary of {other attribute definitions, values}
        /// </summary>
        public Dictionary<OtherAttr, int> OtherScores
        {
            get { return _otherScores; }
            set
            {
                Set(ref _otherScores, value);
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


        public Creature(CreatureProto prototype)
        {
            if(prototype == null)
            {
                throw new ArgumentNullException(nameof(prototype));
            }

            _prototype = prototype;
            throw new NotImplementedException();
        }








        public GrammarParseResult GetValue(string name)
        {
            CreatureAction action = Prototype.CreatureActions.SingleOrDefault(x => x.Name.Equals(name));
            if(action != null)
            {
                return Engine.Parsers.ParserHelper.Evaluate(action.ActionText, Controller.Instance.CurrentRuleSet);
            }

            //Assume it's an attribute if it's not an action
            GrammarParseResult result = new GrammarParseResult($"{IndividualName}'s ({Prototype.EntityName}) {name}");

            //Check Abilities
            AbilityAttr ability = AbilityScores.SingleOrDefault(x => x.Key.Name.Equals(name)).Key;
            if(ability != null)
            {
                result.Value = AbilityScores[ability];
                result.EvaluatedText = AbilityScores[ability].ToString();
                return result;
            }

            //Check Ability Skills
            AbilitySkillAttr abilityskill = AbilitySkillScores.SingleOrDefault(x => x.Key.Name.Equals(name)).Key;
            if(ability != null)
            {
                result.Value = AbilitySkillScores[abilityskill];
                result.EvaluatedText = AbilitySkillScores[abilityskill].ToString();
                return result;
            }

            //Check Counters
            CounterAttr counter = CounterValues.SingleOrDefault(x => x.Key.Name.Equals(name)).Key;
            if(ability != null)
            {
                result.Value = CounterValues[counter];
                result.EvaluatedText = CounterValues[counter].Value.ToString();
                return result;
            }

            //Check Other Attributes
            OtherAttr otherAttr = OtherScores.SingleOrDefault(x => x.Key.Name.Equals(name)).Key;
            if(ability != null)
            {
                result.Value = OtherScores[otherAttr];
                result.EvaluatedText = OtherScores[otherAttr].ToString();
                return result;
            }


            result.IsSuccessful = false;
            result.Value = 0;
            result.Output = $"Creatures of type \"{Prototype.EntityName}\" do not have an action or attribute with name \"{name}\"";
            return result;
        }

        public int GetAttributeValue(Common.Interfaces.ICreatureAttribute attribute)
        {
            if(attribute.AttributeKind == AttributeKind.Ability)
            {
                return AbilityScores[(AbilityAttr)attribute];
            }
            if(attribute.AttributeKind == AttributeKind.AbilitySkill)
            {
                return AbilitySkillScores[(AbilitySkillAttr)attribute];
            }
            if(attribute.AttributeKind == AttributeKind.Counter)
            {
                return CounterValues[(CounterAttr)attribute];
            }
            if(attribute.AttributeKind == AttributeKind.Other)
            {
                return OtherScores[(OtherAttr)attribute];
            }

            throw new ArgumentException($"No logic defined in {nameof(GetAttributeValue)} for this kind of attribute");
        }
    }
}