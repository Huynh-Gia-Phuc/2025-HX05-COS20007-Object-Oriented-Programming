using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cl
{
    public class Clock
    {
        Counter hour = new Counter("Hour");
        Counter min = new Counter("Min");
        Counter sec = new Counter("Sec");
        string Id = "SWS01358";
        bool is12Hr;

        public Clock()
        {
            // Determine 12-hour or 24-hour format based on last digit of Id
            char lastChar = Id[Id.Length - 1];
            if (char.IsDigit(lastChar) && (lastChar - '0') <= 5)
            {
                is12Hr = true;
            }
            else
            {
                is12Hr = false;
            }
            hour = new Counter("Hour");
            min = new Counter("Minute");
            sec = new Counter("Second");
        }

        public void ClockTick()
        {
            sec.Increment();
            if (sec.Ticks >= 60)
            {
                sec.Reset();
                min.Increment();
                if (min.Ticks >= 60)
                {
                    min.Reset();
                    hour.Increment();
                    if (hour.Ticks >= (is12Hr ? 12 : 24))
                    {
                        hour.Reset();
                    }
                }
            }
        }

        public void SetTime(int h, int m, int s)
        {
            for (long i = 0; i < h; i++) hour.Increment();
            for (long i = 0; i < m; i++) min.Increment();
            for (long i = 0; i < s; i++) sec.Increment();
        }

        public void Reset()
        {
            hour.Reset();
            min.Reset();
            sec.Reset();
        }

        public override string ToString()
        {
            return $"{hour.Ticks:D2}:{min.Ticks:D2}:{sec.Ticks:D2}";
        }
    }
}
