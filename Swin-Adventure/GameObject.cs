using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private readonly string _description;
        private readonly string _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get { return _name; }
        }

        public string ShortDescription
        {
            get { return $"{_name} ({FirstId})"; }
        }

        public virtual string FullDescription
        {
            get { return _description; }
        }
    }
}
