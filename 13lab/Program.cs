using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_13_lab
{
    class Program
    {
        static void Main(string[] args)
        {

            //                                                  1 таскич
            Console.WriteLine("==========1part==========");
            DMVLog.write("DMVlogfile.txt", "aaaaaaaa");
            DMVLog.readFind("DMVlogfile.txt", "aaaaaaaa");
            DMVLog.Find("DMVlogfile.txt", "25.11.2020");
            Console.ReadKey();
            //                                                  2 таскич
            /*
            Console.WriteLine("==========2part==========");
            DMVDiskInfo.freespace("C");
            DMVDiskInfo.forEach();
            DMVDiskInfo.fileSystem();
            Console.ReadKey();
            //                                                  3 таскич
            Console.WriteLine("==========3part==========");
            DMVFileInfo.fullPath(@"D:\1.txt");
            Console.ReadKey();
            Console.WriteLine("==========4part==========");
            DMVDirInfo.dirInfo(@"D:\кинцо");
            Console.ReadKey();
            Console.WriteLine("==========5part==========");
            DMVFileManager.tusk_1();
            DMVFileManager.tusk_2(@"D:\SomeDir", ".exe");
            Console.ReadKey();
            */
        }
    }

}
