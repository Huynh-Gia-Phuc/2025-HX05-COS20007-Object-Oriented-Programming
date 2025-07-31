namespace Swin_Adventure
{
    public class Direction
    {
        public string Name { get; }

        public Direction(string name)
        {
            Name = name.ToLower();
        }
    }
} 