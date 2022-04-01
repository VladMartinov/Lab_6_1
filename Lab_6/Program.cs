using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Table
{
    public enum ItemType
    {
        З, Б
    }
    public enum Actions
    {
        ADD, DELETE, UPDATE
    }
    public class OOP
    {


        public struct Item
        {
            public string name;
            public string ItemType;
            public int ploh;
            public int harvest;

            public Item(string name, string ItemType, int ploh, int harvest)
            {
                this.name = name;
                this.ItemType = ItemType;
                this.ploh = ploh;
                this.harvest = harvest;
            }
            
            public void Print()
            {
                Console.WriteLine($"|{this.name,-24}|{this.ItemType,-12}|{this.ploh,-20}|{this.harvest,-15}|");
            }
        }

        private static void Main()
        {
            List<Item> list = new List<Item>();
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\SomeDir3");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
           if (!File.Exists(@"C:\SomeDir3\lab.dat"))
            {
                FileStream fstream = new FileStream(@"C:\SomeDir3\lab.dat", FileMode.CreateNew);
            }
            else
            {
                int Numeration = 0;
                string[] lines = File.ReadAllLines(@"C:\SomeDir3\lab.dat");
                foreach (string s in lines)
                {
         

                    if (Numeration % 2 == 0)
                    {
                        using (BinaryReader reader = new BinaryReader(File.Open(@"C:\SomeDir3\lab.dat", FileMode.Open)))
                        {

                            string name = reader.ReadString();
                            string ItemType = reader.ReadString();
                            int ploh = reader.ReadInt32();
                            int harvest = reader.ReadInt32();
                            Item value = new Item(name, ItemType, ploh, harvest);
                            list.Add(value);
                        }
                    }
                    else
                    {
                        using (StreamReader sr = new StreamReader(@"C:\SomeDir3\lab.dat"))
                        {
                            string[] Lines = s.Split();
                            string name = Lines[0];
                            string ItemType = Lines[1];
                            int ploh = int.Parse(Lines[2]);
                            int harvest = int.Parse(Lines[3]);
                            Item value = new Item(name, ItemType, ploh, harvest);
                            list.Add(value);
                        }
                    }
                    Numeration++;
                }
                
            }
               
            ArrayList log = new ArrayList();
            DateTime[] log2 = new DateTime[50];
            TimeSpan[] log6 = new TimeSpan[50];
            ArrayList ToSearch2 = new ArrayList();
         
            List<int> logSecSimple = new List<int>();
            List<int> logMaxSimple = new List<int>();
            bool flag;
            var kk = 0;
            bool flag1 = true;
            string[] ListFilter = {"1-Слово начинается с заглваной", "2-Слово заканчивается заглавной", "3-Слово начинается с маленькой буквой", "4-Слово заканчивается маленькой буквой", "5-Слово начинается с цифры","6-Слово заканчивается цифрой",
                    "7-Начинается цифрой,заканчивается заглвной", "8-Заканчивается цифрой,начинается с заглвной","9-Начинается цифрой,заканчивается маленькой", "10-Заканчивается цифрой,начинается с маленькой",
            "11-Начинается с заглавной, заканчивается с маленькой", "12-Начинается с маленькой, заканчивается заглавной", "13-Имеются знаки", "14-Начинаются и заканчиваются с загланой",
            "15-Начинаются и заканчиваются с маленькой", "16-Начинаются и заканчиваются с цифры","17-Число больше указанного","18-Число меньше указанного","19-Число равное указанному"};
            while (flag1)
            {
                Console.WriteLine("1 – Просмотр таблицы");
                Console.WriteLine("2 – Добавить запись");
                Console.WriteLine("3 – Удалить запись");
                Console.WriteLine("4 – Обновить запись");
                Console.WriteLine("5 – Поиск записей");
                Console.WriteLine("6 – Просмотреть лог");
                Console.WriteLine("7 - Выход");
                flag = true;
                int Num1 = int.Parse(Console.ReadLine());
                switch (Num1)
                {
                    case 1:
                        {
                            Console.WriteLine(new string('-', 76));
                            Console.WriteLine($"{"|Сельско хозяйственные культуры",-75}|");
                            Console.WriteLine(new string('-', 76));
                            Console.WriteLine($"{"|Наименование",-25}|{"Тип ",-12}|{"Площадь",-20}|{"Урожайность",-15}|");
                            Console.WriteLine(new string('-', 76));
                            foreach (Item item in list)
                            {

                                item.Print();
                                Console.WriteLine(new string('-', 76));
                            }
                            Console.WriteLine($"{"|Перечисляемый тип: Z - зерновые, B - бобовые",-75}|");
                            Console.WriteLine(new string('-', 76));
                            break;
                        }
                    case 2:
                        {
                            while (flag)
                            {
                                Console.WriteLine("Введите данные:");
                                //
                                Console.WriteLine("Наименование:");
                                string name = Console.ReadLine();
                                if (log.Count >= 50)
                                {
                                    log.RemoveAt(0);
                                }
                                log.Add(DateTime.Now.ToString("HH:mm:ss") + " - Добавлена запись  " + $"“{name}”");

                                log2[kk] = DateTime.Now;
                                kk++;

                                Console.WriteLine("Тип растения (З-Зерновой, Б-Бобовые");
                                string ItemType = Console.ReadLine();
                                if (log.Count >= 50)
                                {
                                    log.RemoveAt(0);
                                }
                                log.Add(DateTime.Now.ToString("HH:mm:ss") + " - Добавлена запись  " + $"“{ItemType}”");
                                log2[kk] = DateTime.Now;
                                kk++;

                                Console.WriteLine("Площадь посева (га)");
                                int ploh = Int32.Parse(Console.ReadLine());
                                if (log.Count >= 50)
                                {
                                    log.RemoveAt(0);
                                }
                                log.Add(DateTime.Now.ToString("HH:mm:ss") + " - Добавлена запись  " + $"“{ploh}”");
                                log2[kk] = DateTime.Now;
                                kk++;

                                Console.WriteLine("Урожайность (ц/га)");
                                int harvest = Int32.Parse(Console.ReadLine());
                                if (log.Count >= 50)
                                {
                                    log.RemoveAt(0);
                                }
                                log.Add(DateTime.Now.ToString("HH:mm:ss") + " - Добавлена запись  " + $"“{harvest}”");
                                log2[kk] = DateTime.Now;
                                kk++;

                                Item value = new Item(name, ItemType, ploh, harvest);
                                list.Add(value);
                                while (true)
                                {
                                    Console.WriteLine("Добавить строку?\nда - продолжить\nнет - вывод таблицы");
                                    string input = Console.ReadLine();
                                    if (input == "да" || input == "нет")
                                    {
                                        if (input == "нет")
                                        {
                                            flag = false;
                                            break;
                                        }
                                        break;
                                    }
                                    else Console.WriteLine("Ошибка ввода. Попробуйте еще раз.");
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Номер строки которую нужно удалить:");
                            int NumLine = int.Parse(Console.ReadLine());
                            if (log.Count >= 50)
                            {
                                log.RemoveAt(0);
                            }

                            log.Add(DateTime.Now.ToString("HH:mm:ss") + " - Удалена запись под названием " + $"“{list[NumLine-1].name}”");
                            log2[kk] = DateTime.Now;
                            kk++;

                            list.RemoveAt(NumLine-1);
                            

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Номер строки которую нужно обновить:");
                            int NumLine = int.Parse(Console.ReadLine());
                            list.RemoveAt(NumLine - 1);
                            ToSearch2.RemoveAt(NumLine - 1);
                            Console.WriteLine("Введите данные:");

                            Console.WriteLine("Наименование:");
                            string name = Console.ReadLine();
                            if (log.Count >= 50)
                            {
                                log.RemoveAt(0);
                            }
                            log.Add(DateTime.Now.ToString("HH:mm:ss") + $" - В строке под номером {NumLine} проихошли обновления " + $"“{name}”");
                            log2[kk] = DateTime.Now;
                            kk++;

                            Console.WriteLine("Тип растения (З-Зерновой, Б-Бобовые");
                            string ItemType = Console.ReadLine();
                            if (log.Count >= 50)
                            {
                                log.RemoveAt(0);
                            }
                            log.Add(DateTime.Now.ToString("HH:mm:ss") + $" - В строке под номером {NumLine} проихошли обновления " + $"“{ItemType}”");
                            log2[kk] = DateTime.Now;
                            kk++;

                            Console.WriteLine("Площадь посева (га)");
                            int ploh = Int32.Parse(Console.ReadLine());
                            if (log.Count >= 50)
                            {
                                log.RemoveAt(0);
                            }
                            log.Add(DateTime.Now.ToString("HH:mm:ss") + $" - В строке под номером {NumLine} проихошли обновления " + $"“{ploh}”");
                            log2[kk] = DateTime.Now;
                            kk++;

                            Console.WriteLine("Урожайность (ц/га)");
                            int harvest = Int32.Parse(Console.ReadLine());
                            if (log.Count >= 50)
                            {
                                log.RemoveAt(0);
                            }
                            log.Add(DateTime.Now.ToString("HH:mm:ss") + $" - В строке под номером {NumLine} проихошли обновления " + $"“{harvest}”");
                            log2[kk] = DateTime.Now;
                            kk++;

                            Item value = new Item(name, ItemType, ploh, harvest);
                            list.Insert(NumLine - 1, value);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Хотите вывести список филтров?(да или нет)");
                            String Answer = Console.ReadLine();

                            if (Answer == "да")
                            {
                                foreach (string Line in ListFilter)
                                {
                                    Console.WriteLine(Line);
                                }
                            }
                            Console.WriteLine("Введите номер фильтра:");
                            int Object = int.Parse(Console.ReadLine());
                            switch (Object)
                            {                               
                                case 17:
                                    {
                                        int NumSe = int.Parse(Console.ReadLine());
                                        foreach (string g in ToSearch2)
                                        {
                                            string[] Search = g.Split(' ');
                                            int NumFirst = int.Parse(Search[0]);
                                            int NumSecond = int.Parse(Search[1]);
                                            if (NumFirst > NumSe)
                                            {
                                                Console.WriteLine(NumFirst);
                                            }
                                            if (NumSecond > NumSe)
                                            {
                                                Console.WriteLine(NumSecond);
                                            }

                                        }
                                        break;
                                    }
                                case 18:
                                    {
                                        int NumSe = int.Parse(Console.ReadLine());
                                        foreach (string g in ToSearch2)
                                        {
                                            string[] Search = g.Split(' ');
                                            int NumFirst = int.Parse(Search[0]);
                                            int NumSecond = int.Parse(Search[1]);
                                            if (NumFirst < NumSe)
                                            {
                                                Console.WriteLine(NumFirst);
                                            }
                                            if (NumSecond < NumSe)
                                            {
                                                Console.WriteLine(NumSecond);
                                            }

                                        }
                                        break;
                                    }
                                case 19:
                                    {
                                        int NumSe = int.Parse(Console.ReadLine());
                                        foreach (string g in ToSearch2)
                                        {
                                            string[] Search = g.Split(' ');
                                            int NumFirst = int.Parse(Search[0]);
                                            int NumSecond = int.Parse(Search[1]);
                                            if (NumFirst == NumSe)
                                            {
                                                Console.WriteLine(NumFirst);
                                            }
                                            if (NumSecond == NumSe)
                                            {
                                                Console.WriteLine(NumSecond);
                                            }
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case 6:
                        {
                            int Numeration = 0;

                            foreach (string Line in log)
                            {
                                Console.WriteLine(Line);
                            }
                            foreach (int G in logSecSimple)
                            {
                                if (Numeration > 0)
                                {
                                    logMaxSimple.Add(logSecSimple[Numeration] - logSecSimple[Numeration - 1]);
                                }
                                Numeration++;
                            }

                            for (int i = 1; i < log2.Length; i++)
                            {
                                log6[i] = log2[i] - log2[i - 1];
                            }
                            Regex regex = new Regex(@"[^\d{2}:\d{2}:\d{2}].*");
                            string LogMax = log6.Max().ToString();
                            Console.WriteLine(regex.Replace(LogMax, "") + " – Самый долгий период бездействия пользователя");
                            break;
                        }
                    case 7:
                        {
                            int Numeration = 0;
                            using (FileStream fstream = new FileStream(@"C:\SomeDir3\lab.dat", FileMode.Create))
                            {

                            }
                            foreach (Item item in list)
                            {
                                if (Numeration % 2 == 0)
                                {
                                    using (BinaryWriter writer = new BinaryWriter(File.Open(@"C:\SomeDir3\lab.dat", FileMode.Append)))
                                    {
                                
                                        writer.Write(item.name);
                                        writer.Write(item.ItemType);
                                        writer.Write(item.ploh);
                                        writer.Write(item.harvest);
                                    }

                                }
                                else
                                {

                                    using (StreamWriter f = new StreamWriter(@"C:\SomeDir3\lab.dat", true))
                                    {
                                        f.WriteLine($"\n{item.name} {item.ItemType} {item.ploh} {item.harvest}");
                                    }
                                    

                                }
                                Numeration++;
                            }
                            Process.GetCurrentProcess().Kill();
                            break;
                        }
                    
                }
            }

        }
    }
}
