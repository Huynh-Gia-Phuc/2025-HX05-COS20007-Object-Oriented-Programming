using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLoveMyTeacher
{
    public class Folder : Thing
    {
        private List<Thing> _content = new List<Thing>();

        public Folder(string name) : base(name)
        {
        }

        public void Add(Thing toAdd)
        {
            _content.Add(toAdd);
        }

        public override int Size()
        {
            int sum = 0;
            foreach (var item in _content)
            {
                sum += item.Size();
            }
            return sum;
        }

        public override void Print()
        {
            if (_content.Count > 0)
            {
                Console.WriteLine($"The Folder: {_name} contains {_content.Count} files totalling {Size()} bytes");
                foreach (var item in _content)
                    item.Print();
            }
            else
            {
                Console.WriteLine($"The Folder: '{_name}' is empty!");
            }
        }
    }
}
