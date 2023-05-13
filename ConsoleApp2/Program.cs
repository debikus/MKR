using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


class Program
{
    static void Main(string[] args)
    {

        SortedList<Record, string> records = new SortedList<Record, string>();

        records.Add(new Record("Чеков", "38067155232", "Галицька 133"), "Замітка 1");
        records.Add(new Record("Власов", "38067152589", "Стрийська 9"), "Замітка 2");
        records.Add(new Record("Чернецький", "38093255241", "Наукова 5"), "Замітка 3");
        records.Add(new Record("Максвел", "38093719273", "Княгинi Ольги 91"), "Замітка 4");

        Console.WriteLine("Всi записи:");
        foreach (var item in records)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        records.Remove(records.Keys[0]);
        Console.WriteLine("\nЗаписи пiсля видалення першого:");
        foreach (var item in records)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fs = new FileStream("records.dat", FileMode.Create))
        {
            formatter.Serialize(fs, records);
        }
        using (FileStream fs = new FileStream("records.dat", FileMode.Open))
        {
            SortedList<Record, string> deserializedRecords = (SortedList<Record, string>)formatter.Deserialize(fs);

            Console.WriteLine("\nЗаписи пiсля десерiалiзацiї:");
            foreach (var item in deserializedRecords)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}