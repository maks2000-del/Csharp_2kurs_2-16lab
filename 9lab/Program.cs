using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_laba_oop
{
    class Game
    {
        public string Name { get; private set; }
        private string Type;
        private float Health;

        public delegate void HeroHandler(string message);
        public event HeroHandler Notify;
        
        public Game(string Name, string Type, int Health)
        {
            this.Name = Name;
            this.Type = Type;
            this.Health = Health;
        }

        public void damage(float health)
        {

            //Console.WriteLine($"Hero {Name} / {Health} HP get damaged. Damage {health}");

            if (Health > health) {
                if (Type == "magician")
                {
                    Health -= health;
                    Notify?.Invoke($"Hero {Name} has {Health} HP.");
                }
                if (Type == "knight")
                {
                    Health -= health / 2;
                    Notify?.Invoke($"Hero {Name} has {Health} HP.");
                }
            }
            
        }

        public void health(float health)
        {

           // Console.WriteLine($"Hero {Name} / {Health} HP get healed. Heal {health}");

            if (Type == "magician")
            {
                Health += health*2;
                Notify?.Invoke($"Hero {Name} has {Health} HP.");
            }
            if (Type == "knight")
            {
                Health += health;
                Notify?.Invoke($"Hero {Name} has {Health} HP.");
            }
        }

    }

    class My_str
    {
        public Action<string> op;
        public string my_str;


        public My_str(string my_str)
        {
            this.my_str = my_str;
        }
        public void process_1()
        {
            Console.WriteLine($"spaces in my string: {my_str}");
            foreach (Char ch in my_str)
            {
                if (ch == ' ')
                {
                op?.Invoke($"space");
                }
            }
        }
        public void process_2()
        {
            op?.Invoke($"Transitiom to upper case \n {my_str.ToUpper()}");
        }
        public void process_3()
        {
            my_str = my_str.Insert(my_str.Length, "!");
            op?.Invoke($"!!!!!!!!!!!!!!!!!\n{my_str}");
        }
        public void process_4()
        {
            my_str = my_str.Replace("   ", " ");
            op?.Invoke($"Removing double spaces:\n{my_str}");
        }
        public void process_5()
        {
            Console.WriteLine("Every word on a new line");  
            string[] words = my_str.Split(new char[] { ' ' });

            foreach (string s in words)
            {
                op?.Invoke($"\n{s}");
            }
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            Game creature_1 = new Game("Warlock", "magician", 100);
            Game creature_2 = new Game("Dragon knight", "knight", 130);
            creature_1.Notify += DisplayMessage;
            creature_2.Notify += DisplayRedMessage;
            creature_1.damage(10);
            creature_2.damage(10);
            creature_1.health(10);
            creature_2.health(10);
            creature_2.health(10);

            Console.ReadKey();

            My_str str = new My_str("qecfibe qiefbq qei bqie eqiiqeei   qeiyf qeiy ");
            str.op += DisplayMessage;

            str.process_1();
            str.process_2();
            str.process_3();
            str.process_4();
            str.process_5();

            Console.ReadKey();

        }
           
            private static void DisplayMessage(string message)
            {
                Console.WriteLine(message);
            }
            private static void DisplayRedMessage(String message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
            
                Console.ResetColor();
            }
    }
}
