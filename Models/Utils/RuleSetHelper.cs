using System;
using System.Linq;
using System.Collections.Generic;
using Common.Interfaces;
using System.IO;
using System.Reflection;

namespace Models.Utils
{
    public static class RuleSetHelper
    {
        private static List<IRuleSet> _cachedRuleSets = null;
        public static readonly string RULE_SET_PATH = Environment.CurrentDirectory + @"\RuleSets";

        public static List<IRuleSet> LoadRuleSets(bool forceReload = false)
        {
            if(forceReload)
            {
                _cachedRuleSets?.Clear();
                _cachedRuleSets = null;
            }

            if(_cachedRuleSets != null)
            {
                return _cachedRuleSets;
            }

            _cachedRuleSets = new List<IRuleSet>();

            if(!Directory.Exists(RULE_SET_PATH))
            {
                Directory.CreateDirectory(RULE_SET_PATH);
            }
            
            string[] dllFileNames = Directory.GetFiles(RULE_SET_PATH, "*.dll");

            Type iRuleSetType = typeof(IRuleSet);

            foreach(string dllFile in dllFileNames)
            {
                Assembly assembly = Assembly.LoadFile(dllFile);

                try
                {
                    Type[] types = assembly.GetTypes();

                    foreach(Type t in types)
                    {
                        if(iRuleSetType.IsAssignableFrom(t))
                        {
                            IRuleSet ruleSet = (IRuleSet)Activator.CreateInstance(t);
                            _cachedRuleSets.Add(ruleSet);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"WARNING! Failed to load rule set at \"{dllFile}\"");
                }
            }

            return _cachedRuleSets;
        }

        
    }
}