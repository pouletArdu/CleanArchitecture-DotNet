namespace Formation.Data.Common
{
    public class DataAttribute : Attribute
    {
        public DataAttribute(string name, int position)
        {
            Name = name;
            Position = position;
        }

        public string Name { get; }
        public int Position { get; }
    }
}
