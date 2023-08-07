using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : IdentifiableObject
    {
        private string[] _identifiers;
        private Location _destination;
        private Direction[] _egress;

        public Path(string[] ids, Location destination, Direction[] egress) : base(ids)
        {
            _identifiers = ids;
            _destination = destination;
            _egress = egress;
        }

        public Direction[] Egress 
        { 
            get { return _egress; } 
        }

        public string[] Identifiers
        {
            get { return _identifiers; }
        }

        public Location Destination
        {
            get { return _destination; }
        }

    }
}
