using ConsoleApp1;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            List<Character> heroes = new List<Character>();
            List<Character> enemies = new List<Character>();

            string mode = null;

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "hero":
                        mode = "hero";
                        break;
                    case "enemy":
                        mode = "enemy";
                        break;
                    default:
                        var data = input.Split();
                        if (data[0] == "knight")
                        {
                            var character = new Knight (int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), string.Join(' ', data.Skip(5)));
                            character.HealthPoints = character.Vitality * 4 + 15;
                            if (mode == "hero")
                            {
                                heroes.Add(character);
                            }
                            else if (mode == "enemy")
                            {
                                enemies.Add(character);
                            }
                        }

                        else if (data[0] == "thief")
                        {
                            var character = new Theif(int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), string.Join(' ', data.Skip(5)));
                            character.HealthPoints = character.Vitality * 4;
                            if (mode == "hero")
                            {
                                heroes.Add(character);
                            }
                            else if (mode == "enemy")
                            {
                                enemies.Add(character);
                            }
                        }

                        else if (data[0] == "mage")
                        {
                            var character = new Mage(int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), string.Join(' ', data.Skip(5)));
                            character.HealthPoints = character.Vitality * 4;
                            if (mode == "hero")
                            {
                                heroes.Add(character);
                            }
                            else if (mode == "enemy")
                            {
                                enemies.Add(character);
                            }
                        }



                        break;
                }
            }
            int countheroes = heroes.Count;
            int countenemies = enemies.Count;
            Console.WriteLine("Stay a while and listen, and I will tell you a story. A story of Dungeons and Dragons, of Orcs and Goblins, of Ghouls and Ghosts, of Kings and Quests, but most importantly -- of Heroes and NoobCo -- Well... A story of Heroes.");
            int i = 0; int j = 0;
            while (countheroes>i && countenemies>j)
            {
                bool flag = false;
                foreach (var hero in heroes)
                {
                    hero.figth(enemies[enemies.Count-j-1]);                    
                    if (enemies[enemies.Count - j - 1].HealthPoints <= 0) { j++; }
                    if (j == countenemies) { Console.WriteLine("heroes win"); flag = true;  break; }
                }
                if (flag) { break; }
                foreach (var enemy in enemies)
                {
                    enemy.figth(heroes[heroes.Count - i - 1]);
                    if (heroes[heroes.Count - i - 1].HealthPoints <= 0) { i++; }
                    if (i == countheroes) { Console.WriteLine("heroes lose"); break; }
                }


            }
            
           
        }
    }

    public class Character
    {
        public int Strength { get; set; } // сила
        public int Agility { get; set; } // ловкость
        public int Vitality { get; set; } // живучесть
        public int Intelligence { get; set; } // интеллект
        public string Name { get; set; }

        public Character(int strength, int agility, int vitality, int intelligence, string name)
        {
            Strength = strength;
            Agility = agility;
            Vitality = vitality;
            Intelligence = intelligence;
            Name = name;
        }

        public int HealthPoints { get; set; }
        public int MagicEnergy => Intelligence * 4;
        public virtual double Armor => Agility / 2.0;
        public double MagicArmor => Intelligence / 2.0;
        public virtual int damage => 0;

        public void figth(Character enem)
        {
            enem.HealthPoints -= this.damage;
            Console.WriteLine($"{this.Name} hit {enem.Name} with {this.damage} damage. {enem.Name} have {enem.HealthPoints} hp");
        }

    }

    public class Knight: Character
    {
        
        public Knight(int strength, int agility, int vitality, int intelligence, string name) : base(strength, agility, vitality, intelligence, name)
        {
            Strength = strength + 2;
            Agility = agility;
            Vitality = vitality;
            Intelligence = intelligence;
            Name = name;
        }

        public override double Armor => Agility / 2.0 + 2 ;
        public override int damage => 5;


    }

    public class Theif : Character
    {

        public Theif(int strength, int agility, int vitality, int intelligence, string name) : base(strength, agility, vitality, intelligence, name)
        {
            Strength = strength;
            Agility = agility + 3;
            Vitality = vitality;
            Intelligence = intelligence;
            Name = name;
        }

       
        public override int damage => 4;
    }

    public class Mage : Character
    {

        public Mage(int strength, int agility, int vitality, int intelligence, string name) : base(strength, agility, vitality, intelligence, name)
        {
            Strength = strength;
            Agility = agility;
            Vitality = vitality;
            Intelligence = intelligence+5;
            Name = name;
        }

        public override int damage => 15;

    }

}



