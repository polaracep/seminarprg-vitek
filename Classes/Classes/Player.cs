using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Player
    {
        public string name; 
        public int health;
        private int damage;
        public int playerLevel;
        Random rng;
        public Player(string name, int health, int damage, int playerLevel, Random rng)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.playerLevel = playerLevel;
            this.rng = rng;
        }

        public void SetDamage(int value)
        {
            damage = value;
            if (value <= 0) 
            { 
                damage = 1;            
            }
        }
        public int GetDamage()
        {
            return damage;
        }
        public int Attack()
        {
            return rng.Next(damage /2, damage * 2);
        }
        public bool IsAlive()
        {
            return health > 0;
        }
        public string ShowState()
        {
            return "player" + name + "player health: " + health + player 
        }
            
    }
}
