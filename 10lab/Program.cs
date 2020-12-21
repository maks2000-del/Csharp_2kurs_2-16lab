using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace oop_10_lab
{
    interface ISet<T>
    {
        T Id { get; }
    }

    class Computer<T> : ISet<T>
    {
        T id;
        public Computer(T id)
        {
            this.id = id;
        }
        public T Id { get { return id; } }
        public void del()
        {
            this.id = default(T);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Computer<int> pc1 = new Computer<int>(6789);
            Console.WriteLine(pc1.Id);
            pc1.del();
            Console.WriteLine(pc1.Id);
            Computer<string> pc2 = new Computer<string>("12345");
            Console.WriteLine(pc2.Id);

            Console.ReadKey();

            HashSet<int> evenNumbers = new HashSet<int>();
            LinkedList<int> myAL = new LinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                evenNumbers.Add(i * 2);

                myAL.AddLast((i * 2) + 1);
            }

            Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
            DisplaySet(evenNumbers);

            Console.Write("oddNumbers contains {0} elements: ", myAL.Count);
            DisplayList(myAL);

            myAL.RemoveLast();

            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            Console.WriteLine("numbers UnionWith oddNumbers...");
            numbers.UnionWith(myAL);

            Console.Write("numbers contains {0} elements: ", numbers.Count);
            DisplaySet(numbers);

            void DisplaySet(HashSet<int> collection)
            {
                Console.Write("{");
                foreach (int i in collection)
                {
                    Console.Write(" {0}", i);
                }
                Console.WriteLine(" }");
            }
            void DisplayList(LinkedList<int> collection)
            {
                Console.Write("{");
                foreach (int i in collection)
                {
                    Console.Write(" {0}", i);
                }
                Console.WriteLine(" }");
            }

            Console.ReadKey();

            ObservableCollection<User> users = new ObservableCollection<User>
            {
                new User { Name = "Bill"},
                new User { Name = "Tom"},
                new User { Name = "Alice"}
            };

            users.CollectionChanged += Users_CollectionChanged;

            users.Add(new User { Name = "Bob" });
            users.RemoveAt(1);
            users[0] = new User { Name = "Anders" };

            foreach (User user in users)
            {
                Console.WriteLine(user.Name);
            }

            Console.Read();
        }

        public static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // добавление
                    User newUser = e.NewItems[0] as User;
                    Console.WriteLine($"Добавлен новый объект: {newUser.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // удаление
                    User oldUser = e.OldItems[0] as User;
                    Console.WriteLine($"Удален объект: {oldUser.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace: // замена
                    User replacedUser = e.OldItems[0] as User;
                    User replacingUser = e.NewItems[0] as User;
                    Console.WriteLine($"Объект {replacedUser.Name} заменен объектом {replacingUser.Name}");
                    break;
            }
        }
    }

    class User
    {
        public string Name { get; set; }
    }
}

