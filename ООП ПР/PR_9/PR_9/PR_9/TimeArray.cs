using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_9
{
    
    internal class TimeArray
    {
        private Time[] times;
        internal TimeArray(Time[] times)
        {
            this.times = times;
        }
        internal TimeArray()
        {
            times = [];
        }
        internal TimeArray(int len)
        {
            times = new Time[len];
        }

        internal TimeArray(int min, int max, int len)
        {
            var rand = new Random();
            times = new Time[len];
            for (int i = 0; i < len; i++)
            {
                times[i] = new Time(rand.Next(min, max+1));
            }
        }

        public Time this[int index]
        {
            get
            {
                if (index < 0 || index >= times.Length)
                {
                    throw new ArgumentException();
                }
                return times[index];
            }
            set
            {
                if (index < 0 || index >= times.Length)
                {
                    throw new ArgumentException();
                }
                times[index] = value;
            }
        }
        public int Count
        {
            get { return times.Length; }
        }

        

        public override string ToString()
        {
            string str = "";
            int counter = 1;
            foreach (var time in times)
            {
                str += $"{counter++}-е значение времени: {time}\n";
            }
            return str; 
        }
    }
}
