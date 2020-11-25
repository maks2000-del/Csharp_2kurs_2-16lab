using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_12_lab
{
    static class SaveRead
    {
        public static string Read(string patch)
        {
            string str = null;
            string writePath = @"D:\lab\2 курс 1 семестр\стп моб сис\oop_12_lab\";
            try
            {
                writePath += patch;
                using (StreamReader sr = new StreamReader(writePath, Encoding.GetEncoding(1251)))
                {
                    str = sr.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return str;
        }

        public static void Save(string patch, string inf)
        {
            string writePath = @"D:\lab\2 курс 1 семестр\стп моб сис\oop_12_lab\";
            try
            {
                writePath += patch;
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))//если записи пропадают, поменять на false
                {
                    sw.Write(inf);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Save(string patch, string inf, string comment)
        {
            string writePath = @"D:\lab\2 курс 1 семестр\стп моб сис\oop_12_lab\";
            try
            {
                writePath += patch;
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))//если записи пропадают, поменять на false
                {
                    sw.Write($"\n{comment}\n");
                    sw.Write($"\n{inf}\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
