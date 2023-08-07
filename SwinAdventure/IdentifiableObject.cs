using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents) 
        {
            _identifiers = new List<string>(idents);
        }

        public bool AreYou(string id)
        { 
            if (_identifiers.Contains(id.ToLower())) 
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public string FirstId 
        { 
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return "";
                } 
                    
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

    }
}
