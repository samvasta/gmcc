using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Common.Models;
using Models.Creatures;

namespace Models.Encounters
{
    public class Encounter : ViewModelBase
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
        [XmlIgnoreAttribute]
        public List<Creature> Creatures
        {
            get { return _creatures; }
            set
            {
                Set(ref _creatures, value);
            }
        }


        private List<Wave> _waves;
        public List<Wave> Waves
        {
            get { return _waves; }
            set
            {
                Set(ref _waves, value);
            }
        }

        private Wave _activeWave;
        [XmlIgnoreAttribute]
        public Wave ActiveWave
        {
            get { return _activeWave; }
            set
            {
                Set(ref _activeWave, value);
            }
        }





        public void NextWave()
        {
            throw new NotImplementedException();
        }

    }
}