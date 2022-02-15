using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Homework6
{
    class Class2
    {

        public delegate double MyDelegate(double x);


    #region functions
        //Функция, возвращающая значение типа double
        public static double Function(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double Function2(double x)
        {
            return Math.Sin(x);
        }


        public static double Function3(double x)
        {
            return ((Math.Pow(x, 2) - 50 )/360);
        }

        public static double Function4(double x)
        {
            return ((Math.Sqrt(x) + 12 * x) / 100);
        }
        #endregion

        #region streamfunctions
        //функция записи результата вычислений в файл
        public static void SaveFunc(string fileName, MyDelegate F, double a, double b, double h)
        {
            //создаем новый поток, который создает файл и записывает в него информацию
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            //вызываем класс для записи значений в файл
            BinaryWriter bw = new BinaryWriter(fs);

            double x = a;


            while (x <= b)
            {

                //записываем результат функции в файл
                bw.Write(F(x));

                //меняем значение x 
                x += h;
            }


            bw.Close();
            fs.Close();
        }

        //функция поиска минимума
        public static double Load(string fileName)
        {
            //открываем поток на чтение
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            BinaryReader bw = new BinaryReader(fs);

            //созаем переменную минимума и присваеиваем ей максимальное значение
            double min = double.MaxValue;
            double d;
            //Проходимся циклом по файлу и ищем там минимум (не забываем делить размер файла на размер типа переменной) 
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }

        #endregion 
        static void Main(string[] args)
        {

            MyDelegate[] delegateArray = new MyDelegate[4]
         {
            Function, Function2, Function3, Function4
         };
            Console.WriteLine("Enter the number from 0 to 3 to coose function");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose the minimum for x");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose the maximum for x");
            int xMax = int.Parse(Console.ReadLine());

            #region menu
            switch (number) {

                case 0:
            SaveFunc("data.bin", delegateArray[number], x, xMax, 2);
                    break;

                case 1:
            SaveFunc("data.bin", delegateArray[number], x, xMax, 2);
                    break;
                case 2:
            SaveFunc("data.bin", delegateArray[number], x, xMax, 2);
                    break;
                case 3:
            SaveFunc("data.bin", delegateArray[number], x, xMax, 2);
                    break;
                default:
                    Console.WriteLine("Invalid number!"); 
                    break;
        }
            #endregion 

            //находим минимум и сразу пишем его в консоль
            Console.WriteLine(Load("data.bin"));
            Console.ReadKey();
        }



    }
}




