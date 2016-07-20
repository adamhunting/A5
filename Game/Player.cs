using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player
    {
        public char Token { get; set; }
        public string Name { get; set; }

        public string Greet()
        {
            //Console.WriteLine("Hello " + Name);
            return ("Hello " + Name);
        }

        public void Initialize(IStringGetter s)
        {
            
            string input = s.GetInput(); //returns a string
            Name = input;
        }
    }
}
