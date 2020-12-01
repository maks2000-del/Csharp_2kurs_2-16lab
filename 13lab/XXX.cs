using System;
using System.IO.Compression;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace oop_13_lab
{
    //                                                             //1//
    class DMVLog
    {
        private static int num_operations = 3;
        public static void write(string path, string strToWrite)
        {
            Info("DMVlogfile.txt", $"{strToWrite}");
        }

        public static void readFind(string path, string strToFind)
        {
            string writePath = @"D:\lab\2 курс 1 семестр\стп моб сис\oop_13_lab\";
            writePath += path;

            using (StreamReader sr = new StreamReader(writePath, System.Text.Encoding.Default))
            {
                string line; int i = 0;
                while ((line = sr.ReadLine()) != null)
                {

                    bool c = line.Contains(strToFind);
                    if (c) i++;

                }
                Console.WriteLine($"Найдено {i} повторений");

            }
            Info("DMVlogfile.txt", "");

        }
        public static void Find(string path, string time)
        {
            string writePath = @"D:\lab\2 курс 1 семестр\стп моб сис\oop_13_lab\";
            writePath += path;

            using (StreamReader sr = new StreamReader(writePath, System.Text.Encoding.Default))
            {
                string line, prevLine; int i = 0;
                
                while ((line = sr.ReadLine()) != null)
                {
                    
                    bool c = line.Contains(time);
                    if (c)
                    {
                        prevLine = sr.ReadLine();
                        Console.WriteLine(line + prevLine);
                    }
                    
                }
                Console.WriteLine($"Найдено {i} повторений");

            }

        }


        public static void Info(string path, string inf, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            num_operations++;
            //директория
            string writePath = @"D:\lab\2 курс 1 семестр\стп моб сис\oop_13_lab\";
            //время
            DateTime date1 = DateTime.Now;
            date1 = date1.ToLocalTime();
            //названиие файлса
            string infPaarth = path;
            //вызвавший метод
            Console.WriteLine("member name: " + memberName);

            try
            {
                writePath += path;
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    if (String.IsNullOrEmpty(inf))
                        sw.WriteLine($"Path: {writePath}\nName: {path}\nMethod: {memberName}\nTime: {date1}\n----------------------------");
                    else
                        sw.WriteLine($"Path: {writePath}\nName: {path}\nMethod: {memberName}\nTime: {date1}\nText: {inf}\n----------------------------");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("количество записей в файле{0}", num_operations);
        }
    }
        //                                                             //2//
        class DMVDiskInfo
        {
            public static void freespace(string Disk)
            {
                
                Disk = Disk.ToUpper();

                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo a in drives)
                {
                    if (a.Name.Contains(Disk))
                        Console.WriteLine($"Свободное пространство на диске {Disk}: {a.TotalFreeSpace} bytes\n");
                }
        }

            public static void fileSystem()
            {

            DriveInfo[] drives = DriveInfo.GetDrives();
            
                foreach (DriveInfo drive in drives)
                {
                string driv = drive.ToString();
                string[] dirs = Directory.GetDirectories(driv);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }

                }

            }

            public static void forEach()
            {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }

            }
        }
        //                                                             //3//

    class DMVFileInfo
    {
        public static void fullPath(string fileName)
        {
            
            FileInfo fileInf = new FileInfo(fileName);
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Полный путь: {0}", fileInf.FullName);
                Console.WriteLine("Расширение: {0}", fileInf.Extension);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0} байт", fileInf.Length);
                //Path известно, как выглядят различные форматы путевых имен в разных операционных системах
                Console.WriteLine(Path.Combine(@"D:\", "1.txt"));
            }
        }
         
    }


    class DMVDirInfo
    {
        public static void dirInfo(string dirName)
        {
            int fileNum = 0;
            int dirNum = 0;
            string[] files = Directory.GetFiles(dirName);
            foreach (string s in files)
            {
                fileNum++;
            }
            Console.WriteLine("Кол-во файлов: {0}", fileNum);
            string[] dirs = Directory.GetDirectories(dirName);
            foreach (string s in dirs)
            {
                dirNum++;
            }
            Console.WriteLine("Кол-во поддиректорий: {0}", dirNum);
            Console.WriteLine("Директория родителя: {0}", Directory.GetParent(dirName));

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            Console.WriteLine("Время создания: {0}", dirInfo.CreationTime);

        }

        
    }

    class DMVFileManager
    {
        public static void tusk_1()
        {
            string ffpath = @"D:\SomeDir\dirinfo.txt";

            string path = @"D:\SomeDir";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string path2 = @"D:\SomeDir2";
            DirectoryInfo dirInfo2 = new DirectoryInfo(path2);
            if (!dirInfo2.Exists)
            {
                dirInfo2.Create();
            }

            

            string fpath = @"D:\SomeDir\xxxdirinfo.txt";
            FileInfo fileInf = new FileInfo(fpath);
            if (!fileInf.Exists)
            {
                fileInf.Create();
            }

            using (StreamWriter sw = new StreamWriter(fpath, true, System.Text.Encoding.Default))
            { 
                sw.WriteLine("o)-_-)0");
                sw.Close();
            }
        
            
            string fffpath = @"D:\dirinfo.txt";
            FileInfo fileInff = new FileInfo(ffpath);
            if (!fileInff.Exists)
            {
                fileInff.Create();
            }
            if (fileInff.Exists)
            {
                fileInff.CopyTo(fffpath, true);
            }
            if (fileInff.Exists)
            {
                fileInff.Delete();
            }

        }
        public static void tusk_2(string path, string type)
        {

            //к SomeDir отказано в досутпе а При попытке переместить каталог в уже существующий каталог произойдет IOException 
            string sourceDirectory = @"D:\SomeDir2";
            string destinationDirectory = @"D:\SomeDir3";

            try
            {
                Directory.Move(sourceDirectory, destinationDirectory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            /////



            
            int fileNum = 0;
            string[] files = Directory.GetFiles(path);
            foreach (string s in files)
            {
                fileNum++;
                string newPath = $@"D:\SomeDir2\{fileNum}.txt";
                FileInfo a = new FileInfo(s);
                string g = a.ToString();
                bool c = g.Contains(path);
                if(c)
                a.CopyTo(newPath);
            }
            Console.WriteLine("Кол-во файлов: {0}", fileNum);

            string sourceFile = "D://test/1.txt"; // исходный файл
            string compressedFile = "D://test/1.gz"; // сжатый файл
            string targetFile = "D://newtest/1_new.txt"; // восстановленный файл

            // создание сжатого файла
            Compress(sourceFile, compressedFile);
            // чтение из сжатого файла
            Decompress(compressedFile, targetFile);

            Console.ReadLine();
        }

        public static void Compress(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
        }

        public static void Decompress(string compressedFile, string targetFile)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }



    }





}
