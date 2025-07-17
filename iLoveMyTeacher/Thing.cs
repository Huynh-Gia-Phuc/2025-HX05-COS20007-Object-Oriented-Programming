using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace iLoveMyTeacher
{
    public abstract class Thing
    {
        protected string _name;
        
        public Thing(string name)
        {
            _name = name;
        }

        public abstract int Size();

        public abstract void Print();
        
        public string Name { get { return _name; } }
    }
}
