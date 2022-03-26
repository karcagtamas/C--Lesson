using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students
{
    public enum Color
    {
        Red,
        Green,
        Blue
    }

    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public bool Boy { get; set; }
        public Color Color { get; set; }
    }

    public static class ColorConvert
    {
        public static Color FromString(string color)
        {
            switch (color)
            {
                case "Red": return Color.Red;
                case "Green": return Color.Green;
                case "Blue": return Color.Blue;
                default: return Color.Red;
            }
        }
    }
}
