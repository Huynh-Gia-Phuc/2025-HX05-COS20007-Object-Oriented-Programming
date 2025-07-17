using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockTask
{
    public class Counter
    {
        private long _count;
        private string _name;

        public Counter(string name) 
        {
            _name = name;
            _count = 0;
        }

        public void Increment() 
        {
            _count += 1;
        }

        public void Reset()
        {
            _count = 0;
        }

        public string Name
        {
            get 
            { 
                return _name;
            }
            set 
            { 
                _name = value;
            }
        }

        public long Ticks 
        {
            get
            {
                return _count;
            }
        }

        public long ResetByDefault
        {
            set
            {
                _count = 2147483647358;
            }
        }


    }
}
