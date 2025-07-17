using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLoveMyTeacher
{
    public class File : Thing
    {
        private string _extention;
        private int _size;

        public File(string name, string extention, int size) : base(name)
        {
            _extention = extention;
            _size = size;
        }

        public override int Size()
        {
            return _size;
        }

        public override void Print()
        {
            Console.WriteLine($"File: '{_name}.{_extention}' Size: {_size} bytes");
        }
    }
}
