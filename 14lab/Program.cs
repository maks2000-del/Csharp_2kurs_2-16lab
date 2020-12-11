using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;
using System.Xml.Linq;

namespace _14_lab_oop
{
    public class Print
    {
        public string name { get; set; }
        public string page { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {   
            //                                                          бинарная сериализация
            // объект для сериализации
            Print_addition p_ad = new Print_addition("aa", "bb");
            Console.WriteLine("Объект создан");

            // создаем объект BinaryFormatter
            BinaryFormatter binar_formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("p_add.dat", FileMode.OpenOrCreate))
            {
                binar_formatter.Serialize(fs, p_ad);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("p_add.dat", FileMode.OpenOrCreate))
            {
                Print_addition new_p_add_binary = (Print_addition)binar_formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {new_p_add_binary.Name} --- Тип: {new_p_add_binary.Type}");
            }
            Console.ReadLine();
            //                                                          соап сериализация
            // создаем объект SoapFormatter
            SoapFormatter soap_formatter = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {
                soap_formatter.Serialize(fs, p_ad);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {
                Print_addition new_p_add_soap = (Print_addition)soap_formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {new_p_add_soap.Name} --- Тип: {new_p_add_soap.Type}");
            }
            Console.ReadLine();
            //                                                          джишок сериализация

            // создаем DataContractJsonSerializer 
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Print_addition));

            // создаем поток (json файл) 
            using (FileStream fs = new FileStream("d://1.json", FileMode.OpenOrCreate))
            {
                // сериализация (сохранение объекта в поток) 
                formatter.WriteObject(fs, p_ad);
                Console.WriteLine("Объект сериализован");
            }

            // открываем поток (json файл) 
            using (FileStream fs = new FileStream("d://1.json", FileMode.OpenOrCreate))
            {
                // десериализация (создание объекта из потока) 
                Print_addition new_p_add_json = (Print_addition)formatter.ReadObject(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {new_p_add_json.Name} --- Тип: {new_p_add_json.Type}");
            }

            //                                                          хтмл сериализация
            Console.ReadLine();
            // передаем в конструктор тип класса
            XmlSerializer xml_formatter = new XmlSerializer(typeof(Print_addition));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                xml_formatter.Serialize(fs, p_ad);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                Print_addition new_p_add_xml = (Print_addition)xml_formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {new_p_add_xml.Name} --- Тип: {new_p_add_xml.Type}");
            }
            Console.ReadLine();
            //                                                            2 задание

            Print_addition p_add1 = new Print_addition("aa1", "bb");
            Print_addition p_add2 = new Print_addition("aa2", "bb");
            // массив для сериализации
            Print_addition[] p_adds = new Print_addition[] { p_add1, p_add2 };

            BinaryFormatter formatter_mas = new BinaryFormatter();

            using (FileStream fs = new FileStream("p_adds.dat", FileMode.OpenOrCreate))
            {
                // сериализуем весь массив people
                formatter_mas.Serialize(fs, p_adds);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("p_adds.dat", FileMode.OpenOrCreate))
            {
                Print_addition[] deserilize_p_adds = (Print_addition[])formatter_mas.Deserialize(fs);

                foreach (Print_addition p in deserilize_p_adds)
                {
                    Console.WriteLine($"Имя: {p.Name} --- Тип: {p.Type}");
                }
            }

            Console.ReadLine();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D://books.xml");
            XmlElement xRoot = xDoc.DocumentElement;
           
            XmlNodeList users = xRoot.SelectNodes("book");
            foreach (XmlNode n in users)
                Console.WriteLine(n.SelectSingleNode("@name").Value);
            XmlNodeList pages = xRoot.SelectNodes("//book/page");
            foreach (XmlNode n in pages)
                Console.WriteLine(n.InnerText);

            Console.ReadLine();

            XDocument xdoc = new XDocument(new XElement("books",
            new XElement("book",
            new XElement("name", "book1"),
            new XElement("page", "100")),
            new XElement("book",
            new XElement("name", "book1"),
            new XElement("page", "400")),
            new XElement("book",
            new XElement("name", "book3"),
            new XElement("page", "100"))));
            xdoc.Save("books.xml");
            XDocument xdocc = XDocument.Load("books.xml");
            var items = from xe in xdocc.Element("books").Elements("book")
                        where xe.Element("page").Value == "100"
                        select new Print
                        {
                            name = xe.Element("name").Value,
                            page = xe.Element("page").Value
                        };


            foreach (var item in items)
                Console.WriteLine($"{item.name} - {item.page}");
            Console.ReadLine();
        }
    }
}
