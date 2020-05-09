using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Lab_4_zavd_1
{
    public class Student
    {
        private string name;
        private string LastName;
        private string Group;
        private int Year;
        private string Adress;
        private string Passport;
        private int Age;
        private int Telephon;
        private int Rating;

        public Student()
        {
            name = "Vlad";
            LastName = "Hrozovskyi";
            Group = "IK-11";
            Year = 2019;
            Adress = "Luksha 4";
            Passport = "RK023456334";
            Age = 17;
            Telephon = 0674944612;
            Rating = 88;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string lastName
        {
            get { return LastName; }
            set { LastName = value; }
        }
        public string group
        {
            get { return Group; }
            set { Group = value; }
        }
        public int year
        {
            get { return Year; }
            set { Year = value; }
        }
        public string adress
        {
            get { return Adress; }
            set { Adress = value; }
        }
        public string passport
        {
            get { return Passport; }
            set { Passport = value; }
        }
        public int age
        {
            get { return Age; }
            set { Age = value; }
        }
        public int telephon
        {
            get { return Telephon; }
            set { Telephon = value; }
        }
        public int rating
        {
            get { return Rating; }
            set { Rating = value; }
        }
        public static string StudentRating(int R)
        {
            string res;
            if (R >= 90) res = "Вiтаємо вiдмiнника!";
            else if (R >= 75) res = "Можна вчитися краще!";
            else res = "Варто бiльше уваги придiляти навчанню!";
            return res;
        } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            string sms = Student.StudentRating(s.rating);
            Console.WriteLine("Якщо рейтинг "+s.rating + " - " +sms);
            s.rating = 91;
            sms = Student.StudentRating(s.rating);
            Console.WriteLine("Якщо рейтинг " + s.rating + " - " + sms);
            s.rating = 55;
            sms = Student.StudentRating(s.rating);
            Console.WriteLine("Якщо рейтинг " + s.rating + " - " + sms);
            Console.WriteLine("Спробуйте заповнити данi про себе");
            Console.Write("Name: ");
            s.Name = Console.ReadLine();
            Console.Write("Lastname: ");
            s.lastName = Console.ReadLine();
            Console.Write("Group: ");
            s.group = Console.ReadLine();
            Console.Write("Year: ");
            s.year = int.Parse(Console.ReadLine());
            Console.Write("Adress: ");
            s.adress = Console.ReadLine();
            Console.Write("Passport: ");
            s.passport = Console.ReadLine();
            Console.Write("Age: ");
            s.age = int.Parse(Console.ReadLine());
            Console.Write("Telephon: ");
            s.telephon = int.Parse(Console.ReadLine());
            Console.Write("Rating: ");
            s.rating = int.Parse(Console.ReadLine());
            
            Console.WriteLine(Student.StudentRating(s.rating));
        }
    }
}
