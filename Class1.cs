using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Homework6
{
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public string department;
        public int course;
        public int age;
        public int group;
        public string city;
       

        // Конструктор класса-коллекции 
        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }

      
    }
    class Program
    {


        static int MyDelegat(Student st1, Student st2)        
        {
            if (st1.age == st2.age) return 0;
            else if (st1.age > st2.age) return 1;
            else return -1;
        }
        static void Main(string[] args)
        {
            int lastCourses =0;
            List<Student> list = new List<Student>();                             // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (int.Parse(s[6]) >= 5) lastCourses++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort((MyDelegat));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Студентов на 5 и 6 курсах:{0}", lastCourses);
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadLine();
        }
    }

}
