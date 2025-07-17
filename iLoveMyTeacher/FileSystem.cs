using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iLoveMyTeacher
{
    public class FileSystem
    {
        private List<Thing> _content = new List<Thing>();


        public FileSystem() 
        {
            
        }

        public void Add(Thing toAdd)
        {
            _content.Add(toAdd);
        }

        //public void AddFile(File toAdd)
        //{
        //    _files.Add(toAdd);
        //}

        public void PrintContent()
        {
            foreach (var content in _content)
            {
                content.Print();
            }
            //foreach (var file in _files)
            //{ file.Print(); }

        }
    }
}
