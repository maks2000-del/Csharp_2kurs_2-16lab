using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.IO;

namespace oop_4lab
{
    class Program
    {
        public class Owner
        {
            public int ID;
            public string name;
            public string nameOrganiz;
            public Owner(int id, string nm, string nO)
            {
                ID = id;
                name = nm;
                nameOrganiz = nO;
            }
        }
        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            
            public T Data { get; set; }
            public Node<T> Next { get; set; }
        }

        public class LinkedList<T> : IEnumerable<T>
        {
            
            public class Date
            {
                public string date;

                public Date(string dt)
                {
                    date = dt;
                }
            }

            public Owner owner = new Owner(123, "Max", "Shakalsky");
            public Date dt = new Date("05092001");

            static Node<T> head; 
            static Node<T> tail; 
            
            int count; 
            public LinkedList() { }
            public string name;
            public LinkedList(string name)
            {
                this.name = name;

            }
            // добавление элемента
            public void Add(T data)
            {
                Node<T> node = new Node<T>(data);

                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;

                count++;
            }
            public void Add(T data, int n)
            {
                Node<T> node = new Node<T>(data);
                node.Next = head;
                head = node;
                if (count == 0)
                    tail = head;
                count++;
            }
           
            public bool Remove(T data)
            {
                Node<T> current = head;
                Node<T> previous = null;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        
                        if (previous != null)
                        {
                            previous.Next = current.Next;

                            if (current.Next == null)
                                tail = previous;
                        }
                        else
                        {
                            head = head.Next;
                            if (head == null)
                                tail = null;
                        }
                        count--;
                        return true;
                    }

                    previous = current;
                    current = current.Next;
                }
                return false;
            }

            
            
            // реализация интерфейса IEnumerable
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }
            
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
           
           //////////////////////////////////////////////////////////////////!!!
           
            public override string ToString()
            {
                Node<T> current = head;
                Console.WriteLine(current.Data);
                return " ";
            }
           
            /////////////////////////////////////////////////////////////////////
            public static class StaticOperation
        {
            public static string Compare<T>(T data) where T : IComparable<T>
            {
                    return " ";
            }

                public static string Contains(T data)
                {
                    Node<T> current = head;
                    while (current != null)
                    {
                        if (current.Data.Equals(data))
                            return "yes";
                        current = current.Next;
                    }
                    return "nope";
                }

                public static string Remove()
            {
                    tail = null;
                    return "done";
            }
           
        }

        }
        /// /8
        public interface ISort<T>
        where T : struct
        {
            void ReWrite();
            void Add(T i, int pos);
            void Remove(int pos);
        }

        
        class MyObj<T> : ISort<T> where T : struct
        {
            public int longOb { get; set; }
            T[] myarr;

            public MyObj(int i)
            {
                longOb = i;
            }

            public MyObj(int i, T[] arr)
            {
                longOb = i;
                myarr = new T[i];
                for (int j = 0; j < arr.Length; j++)
                    myarr[j] = arr[j];
            }

            public void ReWrite()
            {
                Console.WriteLine("Тип: {0}", typeof(T));
                Console.WriteLine("Массив объектов: ");
                foreach (T t in myarr)
                    Console.Write("{0}\t", t);
                Console.WriteLine("\n");
            }
            public void Add(T i, int pos) {
                myarr[pos] = i;
            }
            public void Remove(int pos) {
                myarr[pos] = myarr[pos+1];
            }

            public void write_to_file()
            {
                
                    string writePath = @"D:\8tt.txt";

                        using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                        {
                    foreach (T t in myarr)
                        sw.WriteLine(t);
                        }

                       

            }

        }

        static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            LinkedList<string>[] db_arr = new LinkedList<string>[5];
            // добавление элементов
            db_arr[0] = new LinkedList<string>("Tom");
            db_arr[1] = new LinkedList<string>("Tommy");
            
            linkedList.Add("Tom");
            linkedList.Add("Alice");
            linkedList.Add("Bob");
            linkedList.Add("Sam");
            linkedList.Add("Pider", 1);
            

            string D, F, C; int i = 2;
            while (i != 0){
            Console.WriteLine("Please select the task");
            Console.WriteLine("1. Does the list contains name Tom.");
            Console.WriteLine("2. Delete last word.");
                Console.Write(":");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                       
                        F = LinkedList<string>.StaticOperation.Contains("Tom");
                        Console.WriteLine("The longast word is: {0:F2}", F);
                        break;

                    case "2":

                        D = LinkedList<string>.StaticOperation.Remove();
                        Console.WriteLine("Delete last word: {0:F2}", D);
                        break;

                    case "3":

                        C = LinkedList<string>.StaticOperation.Compare("Tom");
                        Console.WriteLine("Delete last word: {0:F2}", C);
                        break;

                    default:
                        Console.WriteLine("Please select a convertor.");
                        break;
                }
                i--;
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            // выводим элементы

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            
            linkedList.Remove("Alice");

            Console.ReadKey();

            //обработка
            try
            {
                byte[] MyArrByte = new byte[5] { 4, 5, 18, 56, 8 };
                MyObj<byte> ByteConst = new MyObj<byte>(MyArrByte.Length, MyArrByte);
                ByteConst.ReWrite();
                ByteConst.Add(5, 0);
                ByteConst.ReWrite();
            }

            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("эоементов больше чем зарезервировано под массив");
            }
            finally
            {
                Console.WriteLine("Тупа блок финалу который всегда ы ^-^");
            }
            float[] MyArrFloat = new float[8] { 12.0f, 1f, 3.4f, 2.8f, -334.7f, -2f, 7.89f, 0 };
            MyObj<float> FloatConst = new MyObj<float>(MyArrFloat.Length, MyArrFloat);
            FloatConst.ReWrite();
            FloatConst.Remove(6);
            FloatConst.ReWrite();
            FloatConst.write_to_file();
                Console.ReadLine();
        }
    }
}
