namespace NoiseListDemo.WPF
{
    public class Stuff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public bool IsRealStuff { get; set; }

        public Stuff()
        {

        }

        public Stuff(int id, string name, float value, bool isReal)
        {
            Id = id;
            Name = name;
            Value = value;
            IsRealStuff = isReal;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Value} - {IsRealStuff}";
        }
    }
}