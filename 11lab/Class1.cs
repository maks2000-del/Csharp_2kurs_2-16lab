using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_11_lab
{
    class Book_type
    {
        public bool type { get; set; }
        public string material { get; set; }
    }
    class Book
    {

        public static int count = 0;
        public int year;
        //
        public int ID { get; private set; }
        public string book_name;
        public string author_name;
        public string print_name;
        public int amount_of_pages;
        public int price;
        public bool type;
       

        public Book()
        {
            ID = 33;
            book_name = "3 boys";
            author_name = "tolsti";
            print_name = "t.print";

            amount_of_pages = 364;
            price = 14;
            type = true;

            count++;
            Print();
        }

        public Book(int ID, string book_name, string author_name, string print_name, int amount_of_pages, int price, int year, bool type)
        {
            this.ID = ID;
            this.book_name = book_name;
            this.author_name = author_name;
            this.print_name = print_name;
            this.amount_of_pages = amount_of_pages;
            this.price = price;
            this.year = year;
            this.type = type;

            count++;
            //Print();
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
}
