using System.Collections.Generic;
using Common.Interfaces;
using Common.Models;
using Models.Encounters;
using Models.Utils;
using Models.Attributes;

namespace Models
{
    public class Controller : ViewModelBase
    {
        private static Controller _instance;
        public static Controller Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Controller();
                }
                return _instance;
            }
        }

        //Force Singleton pattern
        private Controller()
        {
            ReloadRuleSets(true);
        }

        private IRuleSet _currentRuleSet;
        public IRuleSet CurrentRuleSet
        {
            get { return _currentRuleSet; }
            set
            {
                Set(ref _currentRuleSet, value);
            }
        }

        private List<IRuleSet> _availableRuleSets;
        public List<IRuleSet> AvailableRuleSets
        {
            get { return _availableRuleSets; }
            set
            {
                Set(ref _availableRuleSets, value);
            }
        }




        private Encounter _currentEncounter;
        public Encounter CurrentEncounter
        {
            get { return _currentEncounter; }
            set
            {
                Set(ref _currentEncounter, value);
            }
        }



        public void ReloadRuleSets(bool forceReload = false)
        {
            AvailableRuleSets = RuleSetHelper.LoadRuleSets(forceReload);
        }
    }
}