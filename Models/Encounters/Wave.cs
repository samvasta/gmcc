using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Common.Models;
using Models.Creatures;

namespace Models.Encounters
{
    public class Wave : ViewModelBase
    {
        private Encounter _encounter;
        [XmlIgnoreAttribute]
        public Encounter Encounter
        {
            get { return _encounter; }
            set
            {
                Set(ref _encounter, value);
            }
        }

        private int _index;
        public int Index
        {
            get { return _index; }
            set
            {
                Set(ref _index, value);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                Set(ref _name, value);
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

        private List<Creature> _creatures;
        public List<Creature> Creatures
        {
            get { return _creatures; }
            set
            {
                Set(ref _creatures, value);
            }
        }

        private string _startWaveCommand;
        /// <summary>
        /// A command that will be executed when the encounter enters this wave
        /// </summary>
        public string StartWaveCommand
        {
            get { return _startWaveCommand; }
            set
            {
                Set(ref _startWaveCommand, value);
            }
        }

        private string _endWaveCommand;
        /// <summary>
        /// A command that will be executed when the encounter exits this wave
        /// </summary>
        public string EndWaveCommand
        {
            get { return _endWaveCommand; }
            set
            {
                Set(ref _endWaveCommand, value);
            }
        }

    }
}