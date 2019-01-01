using System;
using Common.Interfaces;

namespace Common.Models
{
    public class CounterValue : ViewModelBase, IEquatable<CounterValue>, IDeepCloneable<CounterValue>
    {
        public int Minimum { get; }

        public int Maximum { get; }

        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                Set(ref _value, value);
            }
        }

        public CounterValue(int minimum, int maximum)
            : this(minimum, maximum, maximum)
        {
            //no need to do anything extra
        }

        public CounterValue(int minimum, int maximum, int value)
        {
            if(maximum <= minimum)
            {
                throw new ArgumentException("Maximum must be greater than minimum", nameof(maximum));
            }
            if(value < minimum || value > maximum)
            {
                throw new ArgumentException("value must be between minimum and maximum (inclusive)", nameof(value));
            }

            Maximum = maximum;
            Minimum = minimum;
            Value = value;
        }


        public static implicit operator int(CounterValue counterValue)
        {
            return counterValue.Value;
        }
        
        public static bool operator <(CounterValue x, CounterValue y)
        {
            return x.Value < y.Value;
        }
        public static bool operator >(CounterValue x, CounterValue y)
        {
            return x.Value > y.Value;
        }
        
        public static bool operator <=(CounterValue x, CounterValue y)
        {
            return x.Value <= y.Value;
        }
        
        public static bool operator >=(CounterValue x, CounterValue y)
        {
            return x.Value >= y.Value;
        }
        
        public static bool operator !=(CounterValue x, CounterValue y)
        {
            return !x.Equals(y);
        }
        
        public static bool operator ==(CounterValue x, CounterValue y)
        {
            return x.Equals(y);
        }

        public bool Equals(CounterValue other)
        {
            return this.Value == other.Value &&
                   this.Minimum == other.Minimum &&
                   this.Maximum == other.Maximum;
        }

        public CounterValue DeepClone()
        {
            return new CounterValue(Minimum, Maximum, Value);
        }
    }
}