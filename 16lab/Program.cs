using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public partial class Programm
{
    const int capacity = 100;
    const int density = 1000;
    const int weight = 6000;

    public static int GetWeight() => capacity * density;
    public static int GetDensity() => weight / capacity;
    public static int GetCapacity() => weight / density;
    public static async void Task3_4Async()
    {//. Создайте три задачи с возвратом результата и используйте их для
     //выполнения четвертой задачи.Например, расчет по формуле.
        Task<int> task1 = Task.Factory.StartNew(GetWeight); //вызывваем все три задачи в отдельных (асинхронных)задачах
        Task<int> task2 = Task.Factory.StartNew(GetDensity);
        Task<int> task3 = Task.Factory.StartNew(GetCapacity);
        //await значит выполнение асинхронной операции
        //4. Создайте задачу продолжения (continuation task) в двух вариантах:
        // C ContinueWith -планировка на основе завершения множества
        //предшествующих задач

        await task1.ContinueWith(firstTask => Console.WriteLine($"First task result: {firstTask.Result}")); //выводим на консоль результат после того как задача task1 завершила свою работу
        await task2.ContinueWith(secondTask => Console.WriteLine($"Second task result: {secondTask.Result}"));
        await task3.ContinueWith(thirdTask => Console.WriteLine($"Third task result: {thirdTask.Result}"));

        task3.ContinueWith(thirdTask => Console.WriteLine($"Third task result with GetAwaiter(): {thirdTask.Result}")).GetAwaiter();
        task2.ContinueWith(secondTask => Console.WriteLine($"Second task result with GetAwaiter().GetResult(): {secondTask.Result}")).GetAwaiter().GetResult();
        //getresult прекращает ожидание завершение асинхронной задачи
        Console.WriteLine("================================================\n");
    }
    public static void Main()
    {
        Console.WriteLine("\n ============================================= 4 three tasks ============================================\n");
        Task3_4Async();

        //первое задание ввод
        int k = 0, n = 0;
        Console.Write("num: ");
        n = int.Parse(Console.ReadLine());
        //

        int ms = 0;
        Task asyncT = new Task(async () =>
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(300);
                ms++;
                Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t 8 async и await\n");
            }
        }
        );
        asyncT.Start();

        Console.WriteLine("\n ============================================= 1 Task TPL ============================================\n");
        
        bool[] Simple = new bool[n];

        Task task1 = new Task(() =>
        {
            Simple = Simple.Select(y => Simple[k++] = y = true).ToArray();
            EratosfenArray(ref Simple);
            for (int i = 0; i < Simple.Length; i++)
                if (Simple[i]) Console.Write($" {i}");
        });

        Console.WriteLine($"\n Идентификатор задачи: {task1.Id}\nСтатус задачи на данный момент: {task1.Status}");
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        task1.Start();

        Console.WriteLine($"\n Идентификатор задачи: {task1.Id}\nСтатус задачи на данный момент: {task1.Status}");
        Console.WriteLine($"\n Идентификатор задачи: {task1.Id}\nСтатус задачи на данный момент: {task1.Status}");

        task1.Wait();
        stopWatch.Stop();

        Console.WriteLine($"\n Идентификатор задачи: {task1.Id}\nСтатус задачи на данный момент: {task1.Status}");
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value.
        string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime: " + elapsedTime);

        Console.WriteLine("\n ============================================= 2 CancellationToken ============================================\n");

        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token = tokenSource.Token;
        // используем  токен в двух задачах 
        bool[] Simple1 = new bool[n];
        k = 0;
        Task task2 = new Task(() =>
        {
            Simple1 = Simple1.Select(y => Simple1[k++] = y = true).ToArray();
            EratosfenArray(ref Simple1);
            for (int i = 0; i < Simple1.Length; i++)
            {
                if (tokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("\nОперация прервана токеном");
                    return;
                }
                if (Simple1[i]) Console.Write($" {i}");
            }
        }, token);

        Console.WriteLine($"\n Идентификатор задачи: {task2.Id}\nСтатус задачи на данный момент: {task2.Status}");

        task2.Start();

        Console.WriteLine($"\n Идентификатор задачи: {task2.Id}\nСтатус задачи на данный момент: {task2.Status}");
        Console.WriteLine($"\n Идентификатор задачи: {task2.Id}\nСтатус задачи на данный момент: {task2.Status}");

        Task Stope = new Task(() => {
            Task.Delay(2500); //асинхронный, срабатывает с началом работы программы
            tokenSource.Cancel();
        });
        Stope.Start();

        task2.Wait();
        Stope.Wait();
        Console.WriteLine($"\n Идентификатор задачи: {task2.Id}\nСтатус задачи на данный момент: {task2.Status}");

        Console.WriteLine("\n ============================================= 5 Parallel ============================================\n");

        Stopwatch stopWatch1 = new Stopwatch();
        Stopwatch stopWatch2 = new Stopwatch();
        Stopwatch stopWatch3 = new Stopwatch();
        Stopwatch stopWatch4 = new Stopwatch();

        //Создание объекта для генерации чисел
        Random rnd1 = new Random();
        Random rnd2 = new Random();
        int[] mass1 = new int[100];
        int[] mass2 = new int[100];

        int j = 0;
        Console.WriteLine("\n\t\t\t\t Заполняем массив с помощью Parallel.For\n");

        stopWatch1.Start();
        Parallel.For(1, 99, (int i, ParallelLoopState pd) =>
        {
            mass1[++j] = rnd1.Next(-1000, 100000);
            Console.WriteLine($" {j}: {mass1[j]}");
        });
        stopWatch1.Stop();

        Console.WriteLine("\n\t\t\t\t Заполняем массив с помощью for\n");
        stopWatch2.Start();
        for (int i = 0; i < 99; i++)
        {
            mass2[i] = rnd2.Next(-1000, 100000);
            Console.WriteLine($" {i}: {mass2[i]}");
        }
        stopWatch2.Stop();

        ts = stopWatch1.Elapsed;
        // Format and display the TimeSpan value.
        string elapsedTime1 = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime: " + elapsedTime1);

        ts = stopWatch2.Elapsed;
        // Format and display the TimeSpan value.
        elapsedTime1 = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
           ts.Hours, ts.Minutes, ts.Seconds,
           ts.Milliseconds / 10);
        Console.WriteLine("RunTime: " + elapsedTime1);

        Console.WriteLine("\n\t\t\t\tМассивы заполнены");
        stopWatch3.Start();
        ParallelLoopResult listFact = Parallel.ForEach(mass1, NegativeValue);//перебор в foreach
        stopWatch3.Stop();

        stopWatch4.Start();
        foreach (var elem in mass2)
            NegativeValue(elem);
        stopWatch4.Stop();

        ts = stopWatch3.Elapsed;
        // Format and display the TimeSpan value.
        elapsedTime1 = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime: " + elapsedTime1);

        ts = stopWatch4.Elapsed;
        // Format and display the TimeSpan value.
        elapsedTime1 = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime: " + elapsedTime1);

        Console.WriteLine("\n ============================================= 6 Parallel.Invoke()  ============================================\n");

        Parallel.Invoke(
       () =>
       {
           EratosfenArray(ref Simple);
           for (int i = 0; i < Simple1.Length; i++)
               if (Simple1[i]) Console.Write($" {i}");
       },
       () => {
           for (int i = 0; i < 20; i++)
           {
              Console.WriteLine($"\n\t\t\t\tВыполняется задача {Task.CurrentId}\n\n");
               Thread.Sleep(10);
           }
       });
        Console.WriteLine("\n ============================================= 7 BlockingCollection ============================================\n");
        
        BlockingCollection<int> sklad = new BlockingCollection<int>();
        int x = 0, t = 0;
        for (int producer = 0; producer < 5; producer++)
        {
            t = rnd1.Next(0, 100);
            Task.Factory.StartNew(() => {
                Task.Delay(t);
                x++;
                for (int ii = 0; ii < 3; ii++)
                {
                    x++;
                    // Thread.Sleep(100); 
                    int id = x;
                    sklad.Add(id);
                    Console.WriteLine($"\nПоставщиком  завезена техника с артикулом: {id}");
                }
            });
        }
        for (int con = 0; con < 10; con++)
        {
            Task consumer = Task.Factory.StartNew(() =>
            {
                int w;
                //     foreach (var item in sklad.GetConsumingEnumerable())
                while (!sklad.IsCompleted)
                {
                    if (sklad.TryTake(out w))
                        Console.WriteLine($"\nПокупателем куплена техника с артикулом: {w}");
                }
            });
        }
        asyncT.Wait();
        Console.WriteLine(ms);
        Console.ReadKey();
        Console.ReadKey();
    }
   
}