using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//1полиморфизм наследование множественное наследование инкапсуляция 4 void Finalize() and object MemberwiseClone 32!2 1!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
namespace _3_лаба_ооп
{
    class Book
    {
        
        public static int count = 0;
        const int year = 1990;
        //
        public int ID { get; private set; }
        public string book_name;
        public string author_name;
        public string print_name;
        public int amount_of_pages;
        public int price;
        public bool type;
        //



        //private Book();
        static Book()
        {
            Console.WriteLine(" создан статический конструктор");   
        }
       
     
        public Book(){
            ID = 33;
            book_name ="3 boys";
            author_name ="tolsti";
            print_name="t.print";
            
            amount_of_pages=364;
            price=14;
            type=true;

            count++;
            Print();
            }

        public Book(int ID, string book_name, string author_name, string print_name, int amount_of_pages, int price, bool type)
        {
            this.ID = ID;
            this.book_name = book_name;
            this.author_name = author_name;
            this.print_name = print_name;
            this.amount_of_pages = amount_of_pages;
            this.price = price;
            this.type = type;

            count++;
            Print();
        }
        public Book(string book_name, int ID, string author_name = "grver wef", string print_name= "wrfrwgf wrfrw", int amount_of_pages = 30, int price = 12, bool type = false)
        {
            this.ID = ID;
            this.book_name = book_name;
            this.author_name = author_name;
            this.print_name = print_name;

            this.amount_of_pages = amount_of_pages;
            this.price = price;
            this.type = type;

            count++;
            Print();
        }
        public void Print()
    {
        Console.WriteLine("id: " + ID);
        Console.WriteLine("название книги: " + book_name);
        Console.WriteLine("автор: " + author_name);
        Console.WriteLine("издательство: " + print_name);
            Console.WriteLine("год издания: " + year);
            Console.WriteLine("кол-во страниц: " + amount_of_pages);
            Console.WriteLine("цена: " + price);
            Console.WriteLine("твёрдый переплёт: " + type);
            Console.WriteLine("порядковый новер книги: " + count);

        }
       
    }
    public partial class Person
    {
        partial void DoSomethingElse();

        public void DoSomething()
        {
            Console.WriteLine("Start");
            DoSomethingElse();
            Console.WriteLine("Finish");
        }
    }

    public partial class Person
    {
        partial void DoSomethingElse()
        {
            Console.WriteLine("I am reading a book");
        }
    }

    class MainClass 
    {
        public static void Main(string[] args)
        {
            Book book1 = new Book();  
            Console.WriteLine();
            Book book2 = new Book(124, "harry potter", "j k rowling", "eng.print", 3470, 43, true);
            Book book3 = new Book("par po umolch", 1488);
             Book[] myArr = new Book[5];
            myArr[0] = book1;
            myArr[1] = book2;
            myArr[2] = book3;
           

            

              int num = (int)Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 3; i ++) {
                
                if (myArr[i].price < num)
                Console.WriteLine(myArr[i].book_name);
            }
            int num2 = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 3; i++)
            {
                if (myArr[i].amount_of_pages > num2)
                    Console.WriteLine(myArr[i].book_name);
            }

            Console.WriteLine("\n\nBook1.ToString() = " + book1.ToString());
            Console.WriteLine("Book2.Equals(Airplane1) = " + book2.Equals(book1));
            Console.WriteLine("Book3.GetHashCode() = " + book3.GetHashCode());

            Console.WriteLine("Book1.ID = " + book1.ID + "\n\n");
            Console.WriteLine(book1.GetType());

            int price_for_print;
            full_price( ref book1.amount_of_pages,ref book1.price, out price_for_print);
            Console.WriteLine("Цена печати книги: " + price_for_print);


            var book6 = new
            {
                ID = 54,
                book_name = "3 boys",
                author_name = "tolsti",
                print_name = "t.print",
                amount_of_pages = 364,
                price = 14,
                type = true,

            };

            Person tom = new Person();
            tom.DoSomething();
            Console.WriteLine("\nid:{0}\nназвание:{1}\nавтор:{2}\nтипография:{3}\nкол-во страниц:{4}\nцена:{5}\nпереплёт:{6}\n", book6.ID, book6.book_name, book6.author_name, book6.print_name, book6.amount_of_pages, book6.price, book6.type);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        static void full_price(ref int amount_of_pages, ref int price, out int price_for_print)
        {
            price_for_print = amount_of_pages * price;
        }

    }
}