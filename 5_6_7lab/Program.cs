using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace oop_lab_5_6
{
    interface IInterface1
    {
        void Method1();
    }
    interface IInterface2
    {
        void Method1();
    }
    
    public partial class Publishing_house : IInterface1, IInterface2
    {
        void IInterface1.Method1()
        {
            Console.WriteLine("IInterface1");
        }
        void IInterface2.Method1()
        {
            Console.WriteLine("IInterface2");
        }
        public string Name;

        public Publishing_house()
        {
            Console.WriteLine("был вызван конструкотр по умолчанию");
        }
        public Publishing_house(string Name)
        {
            this.Name = Name;
        
        }
        
        public virtual void Display()
        {
            Console.WriteLine(Name);
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Publishing_house person = (Publishing_house)obj;
            return (this.Name == person.Name);
        }
       
    }
    class Print_addition : Publishing_house 
    {
        public string Type;

        public Print_addition(string Type, string Name) : base (Name)
        {
            this.Type = Type;
        }
    }
    class Author : Print_addition
    {
        public string Author_Name;
        public float Popularity;

        public Author(string Author_Name, float Popularity, string Type, string Name) : base(Type, Name)
        {
           
            this.Popularity = Popularity;
            this.Author_Name = Author_Name;

        }
    }
    
    class Magazine : Author 
    {
        public string Magazine_Name;
        public int Num_of_pages;
        public int Cost;
       
        public Magazine(string Magazine_Name, int Num_of_pages, int Cost, string Author_Name,  float Popularity, string Type , string Name) : base (Author_Name, Popularity, Type, Name)
        {
            this.Magazine_Name = Magazine_Name;
            this.Num_of_pages = Num_of_pages;
            this.Cost = Cost;
           
        }
        public override void Display()
        {
            Console.WriteLine($"{Type} {Magazine_Name} с количеством страниц {Num_of_pages} ценой {Cost}\n автора {Author_Name} с популярностью {Popularity} издания {Name}.");
        }
        public override string ToString()
        {
            return $"{Type} {Magazine_Name} с количеством страниц {Num_of_pages} ценой {Cost}\n автора {Author_Name} с популярностью {Popularity} издания {Name}.";
        }
        

    }
     class Exercisebook : Author 
    {
        public string Exercisebook_Name;
        public int Num_of_pages;
        public int Cost;
        

        public Exercisebook(string Exercisebook_Name, int Num_of_pages, int Cost, string Author_Name, float Popularity, string Type, string Name) : base(Author_Name, Popularity, Type, Name)
        {
            this.Exercisebook_Name = Exercisebook_Name;
            this.Num_of_pages = Num_of_pages;
            this.Cost = Cost;
            
        }
        public override void Display()
        {
            Console.WriteLine($"{Type} {Exercisebook_Name} с количеством страниц {Num_of_pages} ценой {Cost}\n автора {Author_Name} с популярностью {Popularity} издания {Name}.");
        }
       
    }
    sealed class Book : Author 
    {
        public string Book_Name;
        public int Num_of_pages;
        public int Cost;
       
        public Book(string Book_Name, int Num_of_pages, int Cost, string Author_Name, float Popularity, string Type, string Name) : base(Author_Name, Popularity, Type, Name)
        {
            this.Book_Name = Book_Name;
            this.Num_of_pages = Num_of_pages;
            this.Cost = Cost;
           
        }
        public override void Display()
        {
            Console.WriteLine($"{Type} {Book_Name} с количеством страниц {Num_of_pages} ценой {Cost}\n автора {Author_Name} с популярностью {Popularity} издания {Name}.");
        }
        
    }
    abstract class SomeClass
    { 
    
    }
    class Printer
    {

        public void IAmPrinting(object someObj)
        {
            
            Console.WriteLine(someObj.GetType());
            Console.WriteLine(someObj.ToString());
        }
    }
    

    public class Library 
    {
        public int price;
        public bool added;
        public string book_type;
        public string book_name;
        public string info;
        public int year;
        public static int index = 0;
        public Library[] myLib { get; private set; } = new Library[20];
        
        public Library()
        { }
        public Library(string str)
        {
            this.info = str;
        }
        public Library(string book_type, string book_name, int price, int year, bool added = false)
        {

            this.book_type = book_type;
            this.book_name = book_name;
            this.price = price;
            this.year = year;
            
        }
        public void ToStr()
        {
            Console.WriteLine(this.info);
        }
        public void addtostorage(int index, string book_type, string book_name, int price, int year)
            {
            myLib[index] = new Library("noth", "noth", 0, 0);
            myLib[index].book_type = book_type;
            myLib[index].book_name = book_name;
            myLib[index].price = price;
            myLib[index].year = year;
            myLib[index].added = true;
            // index++;
        }
        
        public void show(int index)
        {
            Console.WriteLine($"\nindex:{index}\ntype:{myLib[index].book_type}\tname:{myLib[index].book_name}\tyear:{myLib[index].year}\tprice:{myLib[index].price}\tadded:{myLib[index].added}");
        }
        
        public void del(int index) {
            myLib[index] = new Library("empty", "empty", 0, 0);
        }
        int sum = 0;
        int sum_price;

        public void task_1(Library[] obj)
        {
            for (int i = 0; i < 2; i++)
            {
                if (obj[i].added == false)
                {
                    sum++;
                }
            }
            Console.WriteLine($"\nсуммарное кол-во учебников:\t{sum}");
        }
        public void task_2(Library[] obj)
        {
            for (int i = 0; i < 2; i++)
            {
                if (obj[i].added == false)
                {
                    sum_price += obj[i].price;
                }
            }
            Console.WriteLine($"\nсуммарная цена учебников:\t{sum_price}");
        }

    }
    class Lib_control : Library
    {
        int sum = 0;
        int sum_price;

        public void task_1(Library[] obj)
        {
            for (int i = 0; i < 2; i++)
            {
                if (obj[i].added == false)
                {
                    sum++;
                }
            }
            Console.WriteLine($"\nсуммарное кол-во учебников:\t{sum}");
        }
        public void task_2(Library[] obj)
        {
            for (int i = 0;i<2;i++) {
                if (obj[i].added == false)
                {
                    sum_price += obj[i].price;
                }
            }
            Console.WriteLine($"\nсуммарная цена учебников:\t{sum_price}");
        }
    }
    enum Days
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    struct book
    {
        public string name;
        public int age;

        public void DisplayInfo()
        {
            Console.WriteLine($"\nName: {name}  \tAge: {age}");
        }
    }
    class Person
    {
        public string Name { get; set; }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18)
                    throw new PersonException("Лицам до 18 регистрация запрещена", value);
                else
                    age = value;
            }
        }
        public void mesg(int n)
        {
           
            Debug.Assert(n == null, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            

            Debug.Assert(n <= 10, "aarrrrrrrrrrrrrrrraaaaaaaaaaaaaa");

            Console.WriteLine("its fine");
        }
    }

    class PersException : Exception
    {
        public PersException(string message)
            : base(message)
        { }
    }
    class PersonException : PersException
    {
        public int Value { get; }
        public PersonException(string message, int val)
            : base(message)
        {
            Value = val;
        }
    }
    public class Log
    {
        private static object sync = new object();
        public static void Write(Exception ex)
        {
            try
            {
                // Путь .\\Log
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog); // Создаем директорию, если нужно
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}.{2}()] {3}\r\n",
                DateTime.Now, ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message);
                lock (sync)
                {
                    File.AppendAllText(filename, fullText, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch
            {
                // Перехватываем все и ничего не делаем
            }
        }
        public void logW()
        {
            try
            {
                Console.WriteLine("log num is: ");
                int numlog = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("log num is " + numlog);
            }
            catch (Exception msg)
            {
                Write(msg);                      //запись в лог
                Console.WriteLine(msg.ToString()); //Вывод сообщения на экран, можно исключить              
                throw;
            }

        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            //переопределение метода иквалс
            Publishing_house person2 = new Publishing_house ("NY");
            Publishing_house person3 = new Publishing_house ("NY");
            bool p23 = person2.Equals(person3);
            Console.WriteLine(p23);
            //is as + работа с объектами по ссылке
            List<Publishing_house> PrAdd = new List<Publishing_house>();
            PrAdd.Add(new Print_addition("book", "qqqqq"));
            PrAdd.Add(new Print_addition("book", "wwwww"));
            PrAdd.Add(new Print_addition("book", "eeeee"));

            foreach (Publishing_house P_h in PrAdd)
            {
                if (P_h is Print_addition) 
                {
                    // is - исключение
                        Console.WriteLine(P_h.Name);
                    // as - null
                }
            }

            foreach (Publishing_house P_h in PrAdd)
            {
                if (P_h as Print_addition != null)
                {
                    // is - исключение
                    Console.WriteLine(P_h.Name);
                    // as - null
                }
            }
            //основа
            Print_addition book = new Print_addition("book", "NY print");
            book.Display();

            ((IInterface1)book).Method1();
            ((IInterface2)book).Method1();
            Author jkRowling = new Author("J K Rowling", 13.32f, "book", "NY print");
            Exercisebook engGrammar = new Exercisebook("English Grammar Book", 342, 100, "I I Kovisky", 4.913f, "exercisebook", "UK print house");
            Console.WriteLine(engGrammar.ToString());
            Magazine PB = new Magazine("Playboy", 69, 1000, "ph_maxcell", 10, "Magazine", "Rus_pechat'");
            PB.Display();
            Book HP = new Book("Harry Potter", 342, 100, "j k rowling", 9.99f, "book", "NY printt");
            HP.Display();

            Printer printer = new Printer();
            object[] mass_obj = new object[6];
            mass_obj[0] = book;
            mass_obj[1] = jkRowling;
            mass_obj[2] = engGrammar;
            mass_obj[3] = PB;
            mass_obj[4] = HP;
            mass_obj[5] = printer;
            for (int i = 0; i < 6; i++)
            {
                printer.IAmPrinting(mass_obj[i]);
            }
         
            Console.ReadKey();//.............................................................................
            //6 лаба........................................................... 
            Days day;
            day = Days.Thursday;
            Console.WriteLine("thursday is " + (int)day + " day of a week");
            book b1;
            b1.name = "cace";
            b1.age = 14;
            b1.DisplayInfo();
            // партиал для примера
            person2.Print();
            Library[] libContr = new Library[10];
            libContr[0] = new Library("book1", "A A Ak", 300, 1990);
            libContr[1] = new Library("book2", "A A Ak", 500, 1990);
            
            Library lib = new Library();

            lib.addtostorage(0, "book", "A A Ak", 300, 1990);
            lib.show(0);

            lib.addtostorage(1, "exercisebook", "B B Bk", 500, 2020);
            lib.show(1);
            lib.del(0);
            lib.show(0);
            Console.ReadKey();
            Lib_control libControl = new Lib_control();
            libControl.task_1(libContr);
            libControl.task_2(libContr);

            Console.WriteLine();
            Console.ReadKey();
            string path = @"D:\text.txt";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    Library test = new Library(line);
                    test.ToStr();
                }
               
            }
            var book_json = File.Exists("book_json.json") ? JsonConvert.DeserializeObject<Library>(File.ReadAllText("book_json.json")) : new Library
            {
                book_type = "qqqq",
                book_name = "wwwww",
                price = 100,
                year = 2000
            };
            book_json.price += 100;

            File.WriteAllText("book_json.json", JsonConvert.SerializeObject(book_json));
            Console.WriteLine(book_json.price);
                Console.ReadKey();
            ////////7lab
            Person pp = new Person { Name = "Tom", Age = 18 };
            pp.mesg(20);
            try
            {
                Person p = new Person { Name = "Tom", Age = 13 };
            }
                
            catch (PersonException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Value}");
            }
            try 
            {
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("num is " + num);
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("ArgumentOutOfRangeException");
            }
            catch(OutOfMemoryException)
            {
                Console.WriteLine("OutOfMemoryException");
            }
            catch(IndexOutOfRangeException) 
            {
                Console.WriteLine("IndexOutOfRangeException");
            }
            catch(FormatException)
            {
                Console.WriteLine("FormatException");
                
            }
            finally 
            {
                Console.WriteLine("it'll be written anyway");
            }
            int[] aa = null;
            Debug.Assert(aa != null, "Values array cannot be null");
            Log log = new Log();
            log.logW();
            Console.Read();
        }
    }
}
