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
       

        // Конструктор класса-коллекции (пришлось поменять местами возраст и курс)
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

//Переписал, чтобы числа сравнивались также как строки и все работает аналогично
        static int MyDelegat(Student st1, Student st2)        
        {
            if (st1.age == st2.age) return 0;
            else if (st1.age > st2.age) return 1;
            else return -1;
        }
        static void Main(string[] args)

        {

            Console.WriteLine("Халдон. Переделать программу Пример использования коллекций для решения следующих задач:\n" +
                "а) Подсчитать количество студентов учащихся на 5 и 6 курсах;\n" +
                "б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);\n" +
                " в) отсортировать список по возрасту студента;\n");
            Console.WriteLine("==================================================================");


            int courseFive = 0;
            int courseSix = 0;
            Dictionary<int, int> cousreFrequency = new Dictionary<int, int>();

            List<Student> list = new List<Student>();                
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
                    if (int.Parse(s[6]) == 5) courseFive++;
                    else if (int.Parse(s[6]) == 6) courseSix++;

                    if (int.Parse(s[5]) <= 20 && int.Parse(s[5]) >= 18)
                    {
                        if (cousreFrequency.ContainsKey(int.Parse(s[6])))
                            cousreFrequency[int.Parse(s[6])] += 1;
                        else
                            cousreFrequency.Add(int.Parse(s[6]), 1);
                    }

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
            Console.WriteLine("Students on the 5th course{0} and on the 6th course {1}", courseFive, courseSix);
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadLine();
        }
    }

}
