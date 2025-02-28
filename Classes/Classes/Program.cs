using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            Player player = new Player("digga", 100, 17, 1);
            int enemieskilled = 0;
            Random rng = new Random();
            /*player.playerName = "digga";
            player.playerLevel = 1;
            player.SetDamage(11);
            player.health = 44;*/
            Console.WriteLine(player.health + "\n" + player.GetDamage());
            Console.ReadLine();

            while (player.IsAlive())
            {
                Enemy enemy = new Enemy("test" + (enemieskilled + 1),
                    20 + enemieskilled * rng.Next(5, 10),
                    5 + enemieskilled * rng.Next(1,3),enemieskilled + 1);
            }
                

        }
    }
}
