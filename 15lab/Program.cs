using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Security.Permissions;
using System.Threading;
using System.IO;

namespace _15_lab_oop
{
    class Program
    {
        static object locker = new object();
        static void Main(string[] args)
        {
            
            foreach (Process process in Process.GetProcesses())
            {
                // выводим id и имя процесса
                Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}");
            }
            Console.ReadKey();
            Process proc = Process.GetProcessesByName("devenv")[0];
            ProcessThreadCollection processThreads = proc.Threads;

            foreach (ProcessThread thread in processThreads)
            {
                Console.WriteLine($"ThreadId: {thread.Id} StartTime: {thread.StartTime}");
            }

            Console.ReadKey();
            
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine($"SetupInformation: {domain.SetupInformation}");
            Console.WriteLine();
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);

            MakeNewDomain();

            
            int n = Convert.ToInt32(Console.ReadLine());
            
            Thread second = new Thread(new ThreadStart(Count));
            
            second.Start();
            second.Suspend();
            
            Console.ReadKey();
            second.Resume();
            Thread tt = Thread.CurrentThread;
          
            for (int i = 1; i < n; i+=2)
            {
                Console.Write("поток(0):");
                Console.WriteLine(i);
                Thread.Sleep(300);
            }
            
            tt.Name = "поток(0)";
            Console.WriteLine($"Имя потока: {tt.Name}");
            tt.Priority = ThreadPriority.AboveNormal;
            Console.WriteLine($"Приоритет потока: {tt.Priority}");
            Console.ReadKey();
            
            
           
                for (int i = 0; i < 2; i++)
                {
                    Thread myThread = new Thread(Count2);
                    myThread.Name = "Поток " + i.ToString();
                    myThread.Start();
                }

            Console.ReadKey();
            TimerCallback tm = new TimerCallback(Countt);
            Timer timer = new Timer(tm, null, 0, 1000);
            Console.ReadKey();
        }
        public static void Count2()
        {
            lock (locker)
            {
                if (Thread.CurrentThread.Name == "Поток 1")
                {
                    for (int i = 0; i < 10; i += 2)
                    {
                        Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, i);
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    for (int i = 1; i < 10; i += 2)
                    {

                        Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, i);
                        Thread.Sleep(100);
                    }
                }
            }
        }
        public static void Count()
        {
            for (int i = 0; i < 10; i+=2)
            {
                Console.Write("поток(1): ");
                Console.WriteLine(i);
                Thread.Sleep(400);
            }
            Thread t = Thread.CurrentThread;
            t.Name = "поток(1)";
            Console.WriteLine($"Имя потока: {t.Name}");
            Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
            Console.WriteLine($"Приоритет потока: {t.Priority}");
            Console.WriteLine($"Статус потока: {t.ThreadState}");
           
        }
        static int GetRandom()
        {
            //Создание объекта для генерации чисел (с указанием начального значения)
            Random rnd = new Random();

            //Получить случайное число 
            int value = rnd.Next(0,3);

            return value;
        }
        public static void Countt(object obj)
        {
            string[] strmas = new string[3];
            strmas[0] = "It's time to stop";
            strmas[1] = "Just stope";
            strmas[2] = "Please";

            Console.WriteLine(strmas[GetRandom()]);
        }
        static void MakeNewDomain()
        {
            // новый домен приложения
            AppDomain newD = AppDomain.CreateDomain("NewDomain");
            string longName = "system, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            Assembly assem = Assembly.Load(longName);
            Console.WriteLine("имя сборки: " + assem.FullName);
            InfoDomainApp(newD);
            // Уничтожение домена приложения
            AppDomain.Unload(newD);
        }

        static void InfoDomainApp(AppDomain defaultD)
        {
            Console.WriteLine("*** Информация о домене приложения ***\n");
            Console.WriteLine("Имя: {0}\nID: {1}\nПо умолчанию? {2}\nПуть: {3}\n",
                defaultD.FriendlyName, defaultD.Id, defaultD.IsDefaultAppDomain(), defaultD.BaseDirectory);

        }
    }
}
