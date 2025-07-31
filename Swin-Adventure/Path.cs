using System.Collections.Generic;

namespace Swin_Adventure
{
    public class Path : IdentifiableObject
    {
        public Location Destination { get; }
        public Direction Direction { get; }

        public Path(List<string> identifiers, Direction direction, Location destination)
            : base(identifiers.ToArray())
        {
            Direction = direction;
            Destination = destination;
        }
    }
} 