using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace oop_12_lab
{
    class Program
    {
        public static class Reflector
        {
            public static void Name(string cl)
            {
                Console.WriteLine("Имя сборки(класса):");

                Type type = Type.GetType(cl);
                Console.WriteLine(type.ToString());
                SaveRead.Save("save.txt", $"\n{type}");

                Console.WriteLine();
            }
            public static void Fields(string cl)
            {
                Console.WriteLine("Поля в классе:");

                Type type = Type.GetType(cl);
                foreach (FieldInfo fi in type.GetFields())
                {
                    Console.WriteLine(fi.Name);
                    SaveRead.Save("save.txt", $"\n{fi.Name}");
                }

                Console.WriteLine();
            }
            public static void Methods(string cl)
            {
                Console.WriteLine("Методы в классе:");

                Type type = Type.GetType(cl);
                foreach (MethodInfo fi in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    Console.WriteLine(fi.Name);
                    SaveRead.Save("save.txt", $"\n{fi.Name}");
                }

                Console.WriteLine();
            }
            public static void Constr(string cl)
            {
                Console.WriteLine("Публичные конструкторы в классе:");

                Type type = Type.GetType(cl);
                foreach (ConstructorInfo fi in type.GetConstructors())
                {
                    Console.WriteLine(fi);
                    SaveRead.Save("save.txt", $"\n{fi}");
                }

                Console.WriteLine();
            }
            public static void Interf(string cl)
            {
                Console.WriteLine("Интерфейсы в классе:");

                Type type = Type.GetType(cl);
                foreach (Type fi in type.GetInterfaces())
                {
                    Console.WriteLine(fi.Name);
                    SaveRead.Save("save.txt", $"\n{fi.Name}");
                }

                Console.WriteLine();
            }
            public static void Interfuck(string cl, string q)
            {
                Console.WriteLine($"Методы с заданным параметром({q}) в классе:");

                Type type = Type.GetType(cl);
                foreach (MethodInfo fi in type.GetMethods())
                {
                    string b = fi.ToString();
                    string a = q;
                    bool c = b.Contains(a);
                    if (c == true)
                    Console.WriteLine(b);
                    SaveRead.Save("save.txt", $"\n{b}");
                }
            }


            public static object[] GeneratorParam(string NameClass, string NameMet)//генератор значений для каждого типа(почти)
            {
                Type type = Type.GetType(NameClass);
                Console.WriteLine(type.Name);

                MethodInfo[] Met = type.GetMethods();

                int index = 0;
                string[] nameT = new string[16];

                foreach (var m in Met)
                {
                    ParameterInfo[] pars = m.GetParameters();
                    if (m.Name == NameMet)
                    {

                        Console.WriteLine($"\nМетод: {m.Name}\nПараметры: ");
                        foreach (var p in pars)
                        {
                            nameT[index] = Convert.ToString(p.ParameterType);
                            Console.WriteLine($"{p.Name}, тип параметра: {nameT[index]}\n");
                            index++;
                        }
                    }
                }

                Console.WriteLine("Colvo param: {0}", index);
                object[] param = new object[index];

                for (int i = 0; nameT[i] != null; i++)
                {
                    switch (nameT[i])
                    {
                        case "System.Int32": param[i] = 100; break;
                        case "System.String": param[i] = "cho kak"; break;
                        default: break;
                    }
                }
                return param;
            }

            public static void Invoke2(object Ob, string NameMet, object[] Pars)
            {
                MethodInfo obMethod = Ob.GetType().GetMethod(NameMet);
                object magicValue = obMethod.Invoke(Ob, Pars);
                Console.WriteLine("Class.metod() вернет: {0}", magicValue);
            }

            public static void Invoke(string NameClass, string NameMet)//1 вариант Invoke(чтение данных из файла)
            {
                int sp;
                Type type = Type.GetType(NameClass);
                Console.WriteLine(type.Name);

                ConstructorInfo Constructor = type.GetConstructor(Type.EmptyTypes);
                object ClassObject = Constructor.Invoke(new object[] { });

                //Вызываем метод из этого класса
                string a = SaveRead.Read("read.txt");

                string[] wordsParam = a.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                object[] Params = new object[wordsParam.Length];

                for (int i = 0; i < wordsParam.Length; i++)
                {
                    Console.WriteLine(wordsParam[i]);
                    if (int.TryParse(wordsParam[i], out sp))
                    {
                        Console.WriteLine($"Получаем {sp.GetType()}");
                        Params[i] = sp;
                    }
                    else { Console.WriteLine($"Получаем {wordsParam[i].GetType()}"); Params[i] = wordsParam[i]; }
                }
                //Вызываем метод из этого класса
                MethodInfo magicMethod = type.GetMethod(NameMet);
                object magicValue = magicMethod.Invoke(ClassObject, Params);

                Console.WriteLine("Class.metod() вернет: {0}", magicValue);

            }


            public static Object Create(Type cl)
            {
                Console.WriteLine("объект создан");
                return Activator.CreateInstance(cl);
            }
        }
        static void Main(string[] args)
        {
            //                                               1part

            Reflector.Name("oop_12_lab.Book");
            Reflector.Fields("oop_12_lab.Book");
            Reflector.Methods("oop_12_lab.Book");
            Reflector.Constr("oop_12_lab.Book");
            Reflector.Interf("oop_12_lab.Book");
            Reflector.Interfuck("oop_12_lab.Book", "(Int32)");


            //                                               1part Invoke

            Console.WriteLine("\nInvoke1\n");

            Reflector.Invoke("oop_12_lab.Class", "metod");

            Class cl = new Class();

            object[] Pars = Reflector.GeneratorParam("oop_12_lab.Class", "metod");
            Console.WriteLine("\nInvoke2\n");

            Reflector.Invoke2(cl, "metod", Pars);

            //                                               2part Create

            var ob1 = Reflector.Create(typeof(Book));
            Console.WriteLine(ob1);

            Console.ReadKey();
        }
    }
}
