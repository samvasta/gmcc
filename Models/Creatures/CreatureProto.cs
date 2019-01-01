using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Media.Imaging;
using Common.Interfaces;
using Common.Models;
using Engine.Parsers.Grammar;
using Models.Attributes;
using Models.Utils;

namespace Models.Creatures
{
    public class CreatureProto : ViewModelBase, IEntity
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

        public IBitmap Icon { get { return IconHelper.GetIcon("skull.png"); } }

        private IBitmap _mapToken;
        public IBitmap MapToken
        {
            get { return _mapToken; }
            set
            {
                Set(ref _mapToken, value);
            }
        }

        private List<CreatureAction> _creatureActions;
        /// <summary>
        /// List of all actions available to creatures based on this prototype
        /// </summary>
        public List<CreatureAction> CreatureActions
        {
            get { return _creatureActions; }
            set
            {
                Set(ref _creatureActions, value);
            }
        }

        private Dictionary<AbilityAttr, int> _abilityScores;
        /// <summary>
        /// Dictionary of {ability attribute definitions, default values}
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
        /// Dictionary of {ability skill attribute definitions, default values}
        /// </summary>
        public Dictionary<AbilitySkillAttr, int> AbilitySkillScores
        {
            get { return _abilitySkillScores; }
            set
            {
                Set(ref _abilitySkillScores, value);
            }
        }

        private Dictionary<CounterAttr, CounterValue> _defaultCounterValues;
        /// <summary>
        /// Dictionary of {counter attribute definitions, default values}
        /// </summary>
        public Dictionary<CounterAttr, CounterValue> DefaultCounterValues
        {
            get { return _defaultCounterValues; }
            set
            {
                Set(ref _defaultCounterValues, value);
            }
        }

        private Dictionary<OtherAttr, int> _otherScores;
        /// <summary>
        /// Dictionary of {other attribute definitions, default values}
        /// </summary>
        public Dictionary<OtherAttr, int> OtherScores
        {
            get { return _otherScores; }
            set
            {
                Set(ref _otherScores, value);
            }
        }





        public GrammarParseResult GetValue(string name)
        {
            CreatureAction action = CreatureActions.SingleOrDefault(x => x.Name.Equals(name));
            if(action != null)
            {
                return Engine.Parsers.ParserHelper.Evaluate(action.ActionText);
            }

            GrammarParseResult result = new GrammarParseResult($"{EntityName}'s default {name}");

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
            CounterAttr counter = DefaultCounterValues.SingleOrDefault(x => x.Key.Name.Equals(name)).Key;
            if(ability != null)
            {
                result.Value = DefaultCounterValues[counter];
                result.EvaluatedText = DefaultCounterValues[counter].Value.ToString();
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
            result.Output = $"Creatures of type \"{EntityName}\" do not have an action or attribute with name \"{name}\"";
            return result;
        }
    }
}