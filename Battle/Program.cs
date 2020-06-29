using System;
using System.Collections.Generic;

namespace Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            Battle battle = new Battle();
            Console.WriteLine("Добро пожаловать в бойцовский клуб.");
            Console.WriteLine("-------------------------------------");
            battle.ShowInfo();
            Console.WriteLine("-------------------------------------");
            battle.WarriorsPick();

        }
    }

    class Battle
    {
        List<Warrior> warriors = new List<Warrior>
            {
            new NightElf ("Ночной Эльф", 100, 5, 6, 2),
            new Gnom("Гном", 100, 7, 15),
            new Knight ("Рыцарь", 100, 6, 13),
            new Vampire ("Вампир", 100, 4, 10),
            new Mage ("Маг", 100, 5, 12)
            };

        public void ShowInfo()
        {
            Console.WriteLine("Наши бойцы: ");
            int number = 1;
            foreach (var warrior in warriors)
            {
                Console.WriteLine($"{number}. {warrior.Name}");
                number++;
            }
        }

        public void WarriorsPick()
        {
            Warrior firstWarrior;
            Warrior secondWarrior;
            while (true)
            {
                Console.WriteLine("Выберите двух бойцов для проведения поединка. Введите класс.");
                while (true)
                {
                    Console.Write("Первый: ");
                    string userFirstWarrior = Console.ReadLine();
                    firstWarrior = warriors.Find(x => x.Name == userFirstWarrior);
                    if (firstWarrior == null)
                    {
                        Console.WriteLine("Ошибка. Повторите выбор!");
                    }
                    else
                    {
                        break;
                    }
                }
                while (true)
                {
                    Console.Write("Второй: ");
                    string userSecondWarrior = Console.ReadLine();
                    secondWarrior = warriors.Find(x => x.Name == userSecondWarrior);
                    if (secondWarrior == null)
                    {
                        Console.WriteLine("Ошибка. Повторите выбор!");
                    }
                    else
                    {
                        break;
                    }
                }
                break;
            }
            Fight(firstWarrior, secondWarrior);
        }

        public void Fight(Warrior firstWarrior, Warrior secondWarrior)
        {
            int round = 1;
            while (true)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Раунд {round}");
                Console.WriteLine("-----------------------------------------");
                firstWarrior.UseUltimate(round);
                secondWarrior.UseUltimate(round);
                firstWarrior.TakeDamage(secondWarrior.Damage);
                secondWarrior.TakeDamage(firstWarrior.Damage);
                if (firstWarrior.Health <= 0 || secondWarrior.Health <= 0)
                {
                    string winner;
                    if (firstWarrior.Health > 0)
                    {
                        winner = firstWarrior.Name;
                    }
                    else
                    {
                        winner = secondWarrior.Name;
                    }
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine($"Победил {winner}");
                    break;
                }
                round++;
                Console.ReadKey();
            }
        }
    }


    abstract class Warrior
    {
        public string Name { get; private set; }
        public int Damage { get; protected set; }
        public int Health { get; protected set; }
        protected int Armor;
        public Warrior(string name, int health, int armor, int damage)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public Warrior() { }
        public void TakeDamage(int damage)
        {
            if (Armor > damage)
            {
                Health = Health;
            }
            else
            {
                Health -= damage - Armor;
            }
            Console.WriteLine($"{Name} получил {damage} урона. Броня отразила {Armor} урона. Осталось {Health} НР");
        }


        public abstract void UseUltimate(int round);
    }

    class NightElf : Warrior
    {
        public int AttackSpeed { get; private set; }
        public NightElf(string name, int health, int armor, int damage, int attackSpeed) : base(name, health, armor, damage * attackSpeed)
        {
            AttackSpeed = attackSpeed;
        }
        public override void UseUltimate(int round)
        {
            if (round == 5)
            {
                Console.WriteLine($"{Name} использует уникальную способность. Скорость атаки увеличена на 1.");
                Damage /= AttackSpeed;
                AttackSpeed++;
                Damage *= AttackSpeed;

            }
            else if (round == 6)
            {
                Console.WriteLine($"Действие уникальной способности {Name} окончено. Скорость атаки уменьшена на 1.");
                Damage /= AttackSpeed;
                AttackSpeed--;
                Damage *= AttackSpeed;
            }
        }
    }

    class Gnom : Warrior
    {
        public Gnom(string name, int health, int armor, int damage) : base(name, health, armor, damage) { }
        public override void UseUltimate(int round)
        {
            if (round == 5)
            {
                Console.WriteLine($"{Name} использует уникальную способность. Броня увеличена на 5.");
                Armor += 5;
            }
            else if (round == 6)
            {
                Console.WriteLine($"Действие уникальной способности {Name} окончено. Броня уменьшена на 5.");
                Armor -= 5;
            }
        }
    }

    class Vampire : Warrior
    {
        public Vampire(string name, int health, int armor, int damage) : base(name, health, armor, damage)
        {
        }
        public override void UseUltimate(int round)
        {
            if (round == 5)
            {
                Console.WriteLine($"{Name} использует уникальную способность. Жизни увеличены на 20.");
                Health += 20;
            }
        }
    }

    class Knight : Warrior
    {
        public Knight(string name, int health, int armor, int damage) : base(name, health, armor, damage)
        {
        }
        public override void UseUltimate(int round)
        {
            if (round == 5)
            {
                Console.WriteLine($"{Name} использует уникальную способность. Урон увеличен вдвое.");
                Damage *= 2;
            }
            else if (round == 6)
            {
                Console.WriteLine($"Действие уникальной способности {Name} окончено. Урон понижен вдвое.");
                Damage /= 2;
            }
        }
    }

    class Mage : Warrior
    {
        public Mage(string name, int health, int armor, int damage) : base(name, health, armor, damage)
        {
        }
        public override void UseUltimate(int round)
        {
            if (round == 7)
            {
                Console.WriteLine($"{Name} использует уникальную способность. Урон увеличен на 10.");
                Damage += 10;
            }
            else if (round == 8)
            {
                Console.WriteLine($"{Name} использует уникальную способность. Урон уменьшен на 10.");
                Damage -= 10;
            }
        }
    }
}
