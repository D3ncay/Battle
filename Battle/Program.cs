using System;

namespace Battle
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Warrior
    {
        public int Health { get; private set; }
        public int Armor { get; private set; }
        public int Damage { get; private set; }
        public Warrior(int health, int armor, int damage)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
        }
        public void TakeDamage()
        {
            Health -= Damage + Armor;
        }
    }

    class NightElf : Warrior ()
    {

    }

}
