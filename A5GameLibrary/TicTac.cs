using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTac
    {
        static void Main(string[] args)
        {
            
            Player p = new Player();
            p.Token = 'X';
            Player p2 = new Player();
            p2.Token = 'O';

            Console.WriteLine("Please enter your name: ");
            p.Initialize(new ConsoleWrapper());
            Console.WriteLine("Please enter your name: ");
            p2.Initialize(new ConsoleWrapper());
            Console.WriteLine(p.Greet());
            Game.IGame mygame = new Game.Game();
            mygame.AddPlayer(p);
            mygame.AddPlayer(p2);
            mygame.RunGame();
        }
        
        
    }
    

}
