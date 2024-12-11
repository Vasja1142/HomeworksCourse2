using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PR_9
{
    public class Time
    {
        private int hours;
        private int minutes;
        public static int countTimes = 0;

        public int Hours
        {
            get => hours;
            set
            {
                if (value < 0)
                {
                    hours = 0;
                    
                }
            
                hours = value;
            }
        }
        public int Minutes
        {
            get=> minutes;
            set
            {
                if (value < 0)
                {
                    
                    minutes = 0;
                }
                else if (value < 60)
                {
                    minutes = value;
                }
                else
                {
                    hours += value / 60;
                    minutes = value % 60;
                }
            }
        }

        public Time(int h, int m)
        {
            Hours = h;
            Minutes = m;

            countTimes++;
        }

        public Time(int m)
        {
            Minutes = m;
            countTimes++;
        }

        public Time(Time time)
        {
            
            Hours = time.Hours;
            Minutes = time.Minutes;
            countTimes++;
        }

        
        public int GetAllMinutes()
        {
            return minutes + hours*60;
        }
        public bool IsNotNull()
        {
            return minutes + hours != 0;
        }
       
        public static Time operator --(Time a)
        {
            int m = a.Minutes;
            a.Minutes=(--m);
            return a;
        }

        public static Time operator ++(Time a)
        {
            int m = a.Minutes;
            a.Minutes = (++m);
            return a;
        }

        public static Time operator -(Time a, Time b)
        {
            int allMinutes=a.GetAllMinutes()-b.GetAllMinutes();
            return new Time(0, allMinutes);
        }

        public static bool operator >(Time a, Time b)
        {
            return a.GetAllMinutes() > b.GetAllMinutes();
        }
        public static bool operator <(Time a, Time b)
        {
            return a.GetAllMinutes() < b.GetAllMinutes();
        }



        public override string ToString()
        {
            if (Minutes < 10)
                return $"{Hours}:0{Minutes}";
            return $"{Hours}:{Minutes}";
        }

    }
}
