using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Lab_4_zavd_3
{
    class DateComparer : IComparer<Collection>
    {
        public int Compare(Collection p1, Collection p2)
        {
            if (p1.dateOfRecording > p2.dateOfRecording)
                return 1;
            else if (p1.dateOfRecording < p2.dateOfRecording)
                return -1;
            else
                return 0;
        }
    }
    class Collection : IComparable<Collection>
    {
        private int Number;
        private string NameOfAlbum;
        private double SizeOfDisk;
        private string TypeOfDisk;
        private DateTime DateOfRecording;
        public Collection()
        {
            Number = 0120332;
            NameOfAlbum = "Autumn";
            SizeOfDisk = 12.6;
            TypeOfDisk = "CD-ROM";
            DateOfRecording = new DateTime(2003, 05, 04);
        }
        public Collection(string s)
        {
            s = System.Text.RegularExpressions.Regex.Replace(s, @"\s+", " ");
            string[] str = s.Split(' ');
            NameOfAlbum = str[1];
            if (str[0].Length == 7)
            {
                Number = int.Parse(str[0]);
            }
            else throw new Exception("Введено неправильний номер. Кiлькiсть цифр має дорiвнювати семи!");

            if (str[2].Contains(',')) SizeOfDisk = double.Parse(str[2]);
            else if (str[2].Contains('.')) throw new System.FormatException();
            TypeOfDisk = str[3];
            string[] data = str[4].Split('.');
            int day = int.Parse(data[0]);
            int month = int.Parse(data[1]);
            int year = int.Parse(data[2]);
            DateOfRecording = new DateTime(year, month, day);
            

        }
        public int CompareTo(Collection p)
        {
            return this.DateOfRecording.CompareTo(p.DateOfRecording);
        } 
        public static void AddInFile(string s)
        {
            s = System.Text.RegularExpressions.Regex.Replace(s, @"\s+", " ");
            string[] str = s.Split(' ');
            if (str[2].Contains('.')) throw new System.FormatException();
            if (str[0].Length == 7)
            {
                StreamWriter file = new StreamWriter("D:/ООП/Lab_4/Lab_4_zavd_3/Lab_4_zavd_3/BazaDiskov.txt", true);
                file.Write($"{str[0],-10} {str[1],15} {str[2],15} {str[3],15} {str[4],15}");
                file.Write(Environment.NewLine);
                file.Close();
            }
            else throw new Exception("Введено неправильний номер. Кiлькiсть цифр має дорiвнювати семи!");
        }

        public int number
        {
            get { return Number; }
            set {
                if (value.ToString().Length == 7)
                {
                    Number = value;
                }
                else throw new Exception("Введено неправильний номер. Кiлькiсть цифр має дорiвнювати семи!");
            }
        }
        
        public string nameOfAlbum {
            get { return NameOfAlbum; }
            set { NameOfAlbum = value; }
        }
        public double sizeOfDisk
        {
            get { return SizeOfDisk; }
            set { SizeOfDisk = value; }
        }
        public string typeOfDisk
        {
            get { return TypeOfDisk; }
            set { TypeOfDisk = value; }
        }
        public DateTime dateOfRecording
        {
            get { return DateOfRecording; }
            set { DateOfRecording = value; }
        }

    }
    class Program
    {
        public static void RemoveRecords(int n)
        {
            List<string> quotelist = File.ReadAllLines("D:/ООП/Lab_4/Lab_4_zavd_3/Lab_4_zavd_3/BazaDiskov.txt").ToList();
            quotelist.RemoveAt(n - 1);
            File.WriteAllLines("D:/ООП/Lab_4/Lab_4_zavd_3/Lab_4_zavd_3/BazaDiskov.txt", quotelist.ToArray());
        }
        public static void Search(Collection[] d, string name)
        {
            for (int i = 0; i < d.Length; i++)
            {
                if (d[i].nameOfAlbum == name) Console.WriteLine($"{d[i].number,-10} {d[i].nameOfAlbum,15} {d[i].sizeOfDisk,15} {d[i].typeOfDisk,15} {d[i].dateOfRecording.ToShortDateString(),15}");
            }
        }
        public static Collection[] UpdateBasa()
        {
            int k = 0, i = 0;
            StreamReader file = new StreamReader("D:/ООП/Lab_4/Lab_4_zavd_3/Lab_4_zavd_3/BazaDiskov.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                k++;
            }
            file.BaseStream.Position = 0;
            Collection[] basa = new Collection[k];
            try
            {

                while ((line = file.ReadLine()) != null)
                {
                    basa[i] = new Collection(line);
                    k++;
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e.Message);
            }
            file.Close();
            return basa;

        }
        public static void Edit(Collection[] d)
        {
            askLine:
            Console.Write("Введіть номер рядка, в якому хочете щось змінити: ");
            int k = (int.Parse(Console.ReadLine())) - 1;
            if (k > d.Length)
            {
                Console.WriteLine("Такого рядка не iснує. Спробуйте iнший");
                goto askLine;
            }
            Console.WriteLine("Введіть номер поля, яке хочете змінити. Наприклад: number(1), nameOfAlbum(2), sizeOfDisk(3), typeOfDisk(4), dateOfRecording(5)");
            int pole = int.Parse(Console.ReadLine());
            retry:
            Console.Write("Введіть нове значення: ");
            string val = Console.ReadLine();
            try
            {
                switch (pole)
                {
                    case 1: d[k].number = int.Parse(val); break;
                    case 2: d[k].nameOfAlbum = val; break;
                    case 3: d[k].sizeOfDisk = double.Parse(val); break;
                    case 4: d[k].typeOfDisk = val; break;
                    case 5:
                        string[] data = val.Split('.');
                        int day = int.Parse(data[0]);
                        int month = int.Parse(data[1]);
                        int year = int.Parse(data[2]);
                        d[k].dateOfRecording = new DateTime(year, month, day);
                        break;
                    default: Console.WriteLine("Поля з таким номером не існує!"); break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка: " + e);
                goto retry;
            }
        }
        public static void Sorting(Collection[] d)
        {
            Array.Sort(d, new DateComparer());
        }

        public static void UpdateFile(Collection[] d){
            StreamWriter file = new StreamWriter("D:/ООП/Lab_4/Lab_4_zavd_3/Lab_4_zavd_3/BazaDiskov.txt");
            for (int i = 0; i < d.Length; i++)
            {
                file.Write($"{d[i].number, -10} {d[i].nameOfAlbum, 15} {d[i].sizeOfDisk,15} {d[i].typeOfDisk,15} {d[i].dateOfRecording.ToShortDateString(),15}");
                file.Write(Environment.NewLine);
            }
            file.Close();
        }

        public static void ShowFile()
        {
            StreamReader file = new StreamReader("D:/ООП/Lab_4/Lab_4_zavd_3/Lab_4_zavd_3/BazaDiskov.txt");
            string show = file.ReadToEnd();
            if (show.Length == 0)
            {
                Console.WriteLine("Упс, файл пустий.");
            }
            else Console.WriteLine(show);
            file.Close();
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Меню прогами:\na - Додавання записiв;\ne - Редагування записiв;\nf - Знищення записiв;\ns - Виведення iнформацiї з файла на екран;\nn - Пошук потрiбної iнформацiї за полем 'Назва альбому';\nc - Сортування за датою.;\nq - Щоб вийти з програми.");
            char check;
            int n;
            string name;
            do
            {
            userCheck:
                Console.Write("\nВведiть команду: ");
                try
                {
                    check = char.Parse(Console.ReadLine());
                }catch (System.FormatException)
                {
                    Console.WriteLine("Неправильна команда. Спробуйте ще раз.");
                    goto userCheck;
                }
                Collection[] disk = UpdateBasa();
                if (check == 'a')
                {
                    AddZapis:
                    Console.WriteLine("Введiть новий запис до бази даних за принципом:\nНоменклатурний номер     Назва альбому      Розмiр диску(Мб)      тип диску       дата(ДД.ММ.РРРР)");
                    try
                    {
                        Collection.AddInFile(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Неправильний формат розміру диску. Слід вживати ',' замість '.'.\nСпробуйте ще раз.");
                        goto AddZapis;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Помилка: " + e.Message);
                        goto AddZapis;
                    }
                }
                else if (check == 'e')
                {
                    Edit(disk);
                    UpdateFile(disk);
                }
                else if (check == 'f')
                {
                    Console.Write("Введiть номер рядка який хочете видалити: ");
                    n = int.Parse(Console.ReadLine());
                    RemoveRecords(n);
                    disk = UpdateBasa();
                }
                else if (check == 's')
                {
                    Console.WriteLine("Вмiст файлу:");
                    ShowFile();
                }
                else if (check == 'n')
                {
                    Console.Write("Введiть назву альбому: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Ось що вдалося знайти за вашим запитом: ");
                    Search(disk, name);
                }
                else if (check == 'c')
                {
                    Sorting(disk);
                    UpdateFile(disk);
                    Console.WriteLine("База успiшно вiдсортована за датою.");
                }
                else
                {
                    if (check == 'q') Console.WriteLine("Програма завершена.");
                    else Console.WriteLine("На жаль, такої команди немає, спробуйте iншу.");
                }
            } while (check != 'q');
        }
    }
}
