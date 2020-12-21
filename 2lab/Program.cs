using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//4 определяет правила написания кода для межъязыковой интеграции 
namespace _2_лаба_щарп_моб
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // 1a
            // int [][] myArr = new int [4][]
            //
            ////
            ///
            //////
            int aaaa = 1, bbbb = 2;
            change(ref aaaa, ref bbbb);
            Console.WriteLine(aaaa + bbbb + "deddddddd");
           
            Console.Write("Первое задание\nбулевый: ");
            bool num = Convert.ToBoolean(Console.ReadLine());
            Console.Write("один символ: ");
            char num_1 = Convert.ToChar(Console.ReadLine()); 
            Console.Write("дробь: ");
            float num_2 = (float)Convert.ToDouble(Console.ReadLine()); 
            Console.Write("целое: ");
            int num_3 = Convert.ToInt32(Console.ReadLine()); 
            Console.Write("u целое: ");
            uint num_6 = (uint)Convert.ToInt32(Console.ReadLine()); 
            Console.Write("байт 255: ");
            byte num_7 = (byte)Convert.ToInt32(Console.ReadLine()); 

            Console.WriteLine("{0}; {1}; {2}; {3}; {4}; {5}",num, num_1, num_2, num_3, num_6, num_7);
            
            Console.ReadKey();
            //1b//////////////
            
            int a = 10;
            long a1 = a;
            double a2 = a1;
            object a3 = a;
            float a4 = a;
            double a5 = a;

            int b = 20;
            uint b_1 = (uint)b;
            short b0 = (short)b;
            long b00 = (long)b;
            short b2 = 20;
            ushort b_2 = (ushort)b2;
            long b3 = 20;
            ulong b_3 = (ulong)b3;

            //1c///////////////
            int i =123;
            object o = i;
            i = 456;

            Console.WriteLine("значение = {0}", o);
            Console.WriteLine("упаковка = {0}", i);

            i = (int)o;

            Console.ReadKey();
            //1d/////////////
            var vi = 5;

            var vs = "Hello";

            var varr = new[] { 0, 1, 2 };
            Console.WriteLine("{0}; {1}; {2}, {3}, {4};", vi, vs, varr[0], varr[1], varr[2]);
            //1f//////////////
            var ih = 10;
            Console.WriteLine("значение 1: " + ih);

            ih = 11;
            Console.WriteLine("значение 2: " + ih);
            //ih = "string";
            Console.ReadKey();
            //1e///////////////
            int? ie = null;
            Nullable<int> ie_1 = 1;
            bool? ib = true;
            object obj = ib;
            ib = null;
            Console.WriteLine("{0}; {1}; {2}; {3};", ie, ie_1,  obj, ib);
            
            Console.ReadKey();
            ///////2a////////////////
            string s1 = "a", s2 = "b", s3 = "aa";
            Console.WriteLine(String.Compare(s1, s2));
            Console.WriteLine(String.Compare(s1, s1));
            Console.WriteLine(String.Compare(s3, s1));
            Console.ReadKey();
            //////2b////////////////
            string sb1 = "hello world", sb2 = " hello", sb3 = "red,green,white";
            Console.WriteLine(String.Concat(sb1, sb2));
            Console.WriteLine(String.Copy(sb1));
            Console.WriteLine("есть ли подстрока в строке: " + sb1.Contains("hell"));
            Console.WriteLine(sb1.Insert(3, "tttttttttt"));
            Console.WriteLine(sb1.Remove(0, 6));
            string[] colours = sb3.Split(',');
            Console.WriteLine("{0}\n{1}\n{2}", colours[0], colours[1], colours[2]);
            
            long number = 375337654321;
            Console.WriteLine($"{number:+### ## ### ## ##}");
            
            StringBuilder sb = new StringBuilder("asfevwvw");
            sb.Append("!");
            sb.Insert(1, "!");
            sb.Remove(3, 3);

            Console.ReadKey();
            
            ///////3a///////////
            int[,] double_arr= new int[4, 4];
            for (int iu = 0; iu < 4; iu++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double_arr[iu, j] = iu + j;
                    Console.Write(double_arr[iu, j] + " ");
                }
                Console.Write("\n");
            }
            Console.ReadKey();
            
            ///////3b//////////////
            
            int pos; string value; string[] arr_string = new string[4]{"max", "tommy", "jason", "morty" };

            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine(arr_string[j]);
            }
            Console.WriteLine("enter pos and value: ");
            pos = (int)Convert.ToInt32(Console.ReadLine ());
            value = Console.ReadLine();
            arr_string[pos] = value;
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine(arr_string[j]);
            }
            Console.ReadKey();
           
            ///////3c/////////////
            int[,] arr_3c = new int[5,5]; int p = 2;
            for (int ii = 0; ii < 3; ii++)
            {
                
                for (int j = 0; j < p; j++)
                {
                    Console.WriteLine($"enter pos and value{ii}{j}: ");
                    arr_3c[ii,j] = (int)Convert.ToInt32(Console.ReadLine());

                }
                p++;
                
            }
            p = 2;
            for (int iii = 0; iii < 3; iii++)
            {
                for (int j = 0; j < p; j++)
                {
                    Console.Write(arr_3c[iii,j] + " ");
                }
                p++;
                Console.Write("\n");
            }
            Console.ReadKey();
            
            //////3D///////////
            var stri = "ewfvqvq";
            var arraynew = new[] { 1, 10, 100, 1000 };
            Console.ReadKey();
             
            //////4a/////////
            
            (int , string, char, string, ulong) kort_1 = (a = 1, "qqq", 'w', "efc", 100);
            (int, string, char, string, ulong) kort_2 = (1, "qqq", 'w', "efc", 100);
            Console.WriteLine(kort_1);
            Console.WriteLine("{0},{1}", kort_1.Item1, kort_1.Item3);
            string k_str = kort_1.Item2;
            Console.WriteLine(k_str);
            Console.WriteLine(kort_1.CompareTo(kort_2));
            Console.ReadKey();
            
            int length = 3; string str_myf = "qwerty";

            Console.WriteLine(mfunc(length, str_myf));

            static (int, int, int, char) mfunc(int length, string str_myf) {
                
                
                int min = 1, max = 1, sum = 0; int[] arra = new int[3] { 1,2,3};
                for (int i = 0; i < 3; i++) {
                    if (arra[i] < min) min = arra[i];
                    if (arra[i] > max) max = arra[i];
                    sum += arra[i];
                }
                (int, int, int, char) kort_1 = (min, max, sum, str_myf[0]);

                return kort_1;
            }
            Console.ReadKey();
            
            fun1();fun2();
            static void fun1 () {
                int ch = 2147483647;
                ch = checked  (ch);
            }
            static void fun2 ()
            {
                int ch = 2147483647;
                ch = unchecked(ch);
            }

            Console.ReadKey();
            
        }
        private static void change(ref int aaaa, ref int bbbb)
        {
            int cccc = aaaa;
            aaaa = bbbb;
            bbbb = cccc;
        }
    }

}
