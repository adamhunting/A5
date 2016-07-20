using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ConsoleWrapper  : IStringGetterPutter
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void PutString(string output)
        {
             Console.Write(output);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }

    public interface IStringGetter
    {
        string GetInput();
    }

    public interface IStringPutter
    {
        void PutString(string output);
        
    }

    public interface IStringGetterPutter : IStringGetter, IStringPutter, IClear
    { }

    public interface IClear
    {
        void Clear();
    }
}
