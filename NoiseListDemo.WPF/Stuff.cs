namespace NoiseListDemo.WPF
{
    public class Stuff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public bool IsRealStuff { get; set; }
        public Thing TheThing { get; set; }

        public Stuff()
        {

        }

        public Stuff(int id, string name, float value, bool isReal, Thing theThing)
        {
            Id = id;
            Name = name;
            Value = value;
            IsRealStuff = isReal;
            TheThing = theThing;
        }

        public override string ToString()
        {
            return $"Stuff: {Id} | {Name} | {Value} | {IsRealStuff} | {TheThing}";
        }
    }
}