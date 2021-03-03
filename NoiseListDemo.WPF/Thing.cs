using System;
using System.Collections.Generic;
using System.Text;

namespace NoiseListDemo.WPF
{
    public class Thing
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Thing()
        {

        }

        public Thing(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"A Thing: {Id} | {Name}";
        }
    }
}
