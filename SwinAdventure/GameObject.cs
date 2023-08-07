﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _description = desc;
            _name = name;
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
            get
            {
                return $"{_name}, {_description}.";
            }
        }

    }
}
