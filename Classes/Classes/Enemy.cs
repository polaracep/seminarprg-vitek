using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Enemy
    {
        internal Enemy(int value)
        {
                public string name;
        public int health;
        public int damage;
        public int level;

        public Enemy(string name, int health, int damage, int level)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.level = level;

        }
        public void Hurt(int incomingDamage)
        {
            if (health <= 0)
            {
                Console.WriteLine("this enemy is already dead");
            }
            health -= incomingDamage;
            Console.WriteLine("Player");
        }
    
    }
}
