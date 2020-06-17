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

    class NightElf : Warrior 
    {
        public NightElf(int health, int armor, int damage, int attackSpeed) : base(health, armor, damage*attackSpeed) { }

        public void Description ()
        {
            Console.WriteLine("С Ночными Эльфами шутки плохи, не успеешь моргнуть, как они наносят несколько молниеносных ударов...");
        }
    }

    class Gnome : Warrior
    {
        public Gnome(int health, int damage) : base(health,25, damage) { }
        public void Description()
        {
            Console.WriteLine("Гномы славятся своей броней. Не каждое оружие может его пробить.");
        }

    }
    class Kamikaze : Warrior
    {
        public Kamikaze(int health, int armor, int damage) : base(health, armor, 500) { }
        public void Description()
        {
            Console.WriteLine("Бойцы Камикадзе идут до конца... в прямом смысле...");
        }
    }
    class Mage : Warrior
    {
        public Mage(int health, int armor, int damage) : base(health, armor, damage) { }
        public void Description()
        {
            Console.WriteLine("Черная, белая магия, да им все равно чем тебя убивать...");
        }
    }
    class Werewolf : Warrior
    {
        public Werewolf(int health, int armor, int damage) : base(health, armor, damage) { }
        public void Description()
        {
            Console.WriteLine("С ними невозможно драться ночью... Они приобретают образ человекоподного зверя с толстой кожей и очень острыми когтями");
        }
    }

}
