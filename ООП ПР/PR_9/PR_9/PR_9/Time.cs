using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_9
{
    public class Time
    {
        private int hours;
        private int minutes;

        public Time(int h, int m)
        {
            if (m < 0)
            {
                h += (m / 60) - 1;
                m = 60 + (m % 60);
            }
            else if (m > 59)
            {
                h += m / 60;
                m = m % 60;
            }
            if (h < 0)
            {
                h = 0;
                m = 0;
            }
            hours = h;
            minutes = m;
        }

        public Time(int m)
        {
            Time t = new Time(0, m);
            hours = t.GetHours();
            minutes = t.GetMinutes();
        }

        public Time(Time time)
        {
            hours = time.GetHours();
            minutes = time.GetMinutes();
        }

        public int GetHours() => hours;
        public int GetMinutes() => minutes;

        private void SetHours(int h) {
            if (h < 0)
            {
                hours = 0;
            }
            else
            {
                hours = h;
            }
        }
        public int GetAllMinutes()
        {
            return minutes + hours*60;
        }
        public bool IsNotNull()
        {
            return minutes + hours != 0;
        }
        private void SetMinutes(int m)
        {
            Time t = new Time(hours, m);
            minutes = t.GetMinutes();
            hours = t.GetHours();
        }
        public static Time operator --(Time a)
        {
            int m = a.GetMinutes();
            a.SetMinutes(--m);
            return a;
        }

        public static Time operator ++(Time a)
        {
            int m = a.GetMinutes();
            a.SetMinutes(++m);
            return a;
        }

        public static Time operator -(Time a, Time b)
        {
            int h = a.GetHours() - b.GetHours();
            int m = a.GetMinutes() - b.GetMinutes();
            return new Time(h, m);
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
            if (minutes < 10)
                return $"{hours}:0{minutes}";
            return $"{hours}:{minutes}";
        }

    }
}
