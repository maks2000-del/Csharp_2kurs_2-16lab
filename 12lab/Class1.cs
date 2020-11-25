using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_12_lab
{
    public class Class
    {
        private int Value;

        public Class()
        {
            Value = 9;
        }

        public int metod(int a, string c)
        {
            Console.WriteLine("строка metod {0}", c);
            Console.WriteLine("строка metod {0}", a);
            return  Value * 10;
        }
    }
    interface aa
    { 
    }
    class Book : aa 
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
        }
        public void aa(int a)
        {
            a++;
        }
        public void nothing__just(int a)
        {
            a*=10;
            Console.WriteLine(a);
        }
    }
}
