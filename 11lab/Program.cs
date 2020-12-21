using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_11_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ar_str = new string[] {"June_", "July_", "May", "December_", "January_", "September", "October", "August_", "November", "February_", "March", "April" };

            Console.WriteLine("ordered by length: ");

            var selectedTeams = from t in ar_str // определяем каждый объект из teams как t
                                where t.Length == 5 // фильтрация
                                orderby t  // упорядочиваем
                                select t; // Проецирует значения выборк

            foreach (string s in selectedTeams)
                Console.WriteLine(s);

            Console.WriteLine("ordered: ");

            string[] sorted = ar_str.OrderBy(a => a).ToArray();

            foreach (string s in sorted)
                Console.Write(" "+s);
            Console.WriteLine("");
            Console.WriteLine("ordered by 'u' letter: ");

            selectedTeams = from t in ar_str 
                            where t.Length >= 4
                            where t.ToLower().Contains("u") 
                            orderby t
                            select t;
           
            foreach (string s in selectedTeams)
                Console.WriteLine(s);

            Console.WriteLine("ordered by summer & winteriscomming: ");

            var mounth = from t in ar_str where t.EndsWith("_") select t;

            foreach (string s in mounth)
                Console.WriteLine(s);

            Console.ReadKey();

            List<Book> my_lib = new List<Book>();

            my_lib.Add(new Book(1, "aaa", "bb", "c", 210, 100, 1990, true));
            my_lib.Add(new Book(2, "qqq", "bb", "c", 100, 300, 1990, false));
            my_lib.Add(new Book(3, "www", "bbb", "c", 990, 1000, 1990, false));
            my_lib.Add(new Book(4, "aaa", "bb", "c", 1400, 500, 2000, false));
            my_lib.Add(new Book(5, "aa1", "bb", "c", 300, 100, 2010, false));
            my_lib.Add(new Book(6, "aa2", "bb", "c", 230, 200, 2002, true));
            my_lib.Add(new Book(7, "aa3", "bb", "c", 250, 7000, 1991, false));
            my_lib.Add(new Book(8, "aa4", "bb", "c", 2330, 100, 1990, true));

            List<Book_type> teams = new List<Book_type>()
                {
                new Book_type { type = false, material ="none" },
                new Book_type { type = true, material ="paper" }
                };

            Console.WriteLine("ordered by amount of pages: ");

            var selectedBook = from book in my_lib
                                where book.amount_of_pages < 110
                                select book;

            foreach (Book book in selectedBook)
                Console.WriteLine($"{book.book_name} - {book.amount_of_pages}");

            Console.WriteLine("ordered by author & year: ");

            selectedBook = from book in my_lib
                           where book.year == 1990 && book.author_name == "bb"
                           select book;

            foreach (Book book in selectedBook)
                Console.WriteLine($"{book.book_name} {book.author_name} - {book.year}");

            Console.WriteLine("ordered by year: ");

            selectedBook = from book in my_lib
                           where book.year >= 2000
                           select book;

            foreach (Book book in selectedBook)
                Console.WriteLine($"{book.book_name} - {book.year}");

            Console.WriteLine("ordered by price: ");

            selectedBook = from book in my_lib
                           orderby book.price
                           select book;

            foreach (Book book in selectedBook)
                Console.WriteLine($"{book.book_name} - {book.price}");

            Console.WriteLine("first 5 selected py amount if pages: ");

            selectedBook = from book in my_lib
                           where book.amount_of_pages > 200
                           orderby book.price
                           select book;

            int i = 5;


                foreach (Book book in selectedBook) {
                
                    Console.WriteLine($"{book.book_name} - {book.price}");
                   i--;
                if (i==0) break;
             
            }

            Console.WriteLine("ordered by 5 dif types: ");

            selectedBook = from book in my_lib

                           where book.price < 5000
                           
                           orderby book.price
                            
                           select book;

            foreach (Book book in selectedBook.Skip(2).Reverse().Distinct())
                Console.WriteLine($"{book.book_name} - {book.price}");

            Console.WriteLine("joining 2 Lists: ");

            var result = from tp1 in my_lib
                         join tp2 in teams on tp1.type equals tp2.type
                         select new { book_name = tp1.book_name, type = tp1.type, material = tp2.material };

            foreach (var item in result)
                Console.WriteLine($"{item.book_name} - {item.type} ({item.material})");

            Console.ReadKey();
        }
    }
}
