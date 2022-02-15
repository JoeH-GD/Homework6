using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6

{
    //Новый делегат с двумя параметрами
    public delegate double Fun(double x, double a);

    class DelegateTable
    {
        //Я решил оставить параметр а неизменяемым, чтобы проще было проверить вычисления
        public static void Table(Fun F, double x, double a, double b)
        {
            Console.WriteLine("----- X ----- A ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000}", x,a, F(x,a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        // Функция, на которой требовалось протестировать делегат
        public static double MyFunc(double x, double a)
        {
            return a * Math.Pow(x, 2);
        }

        static void Main()
        {
            
            Console.WriteLine("Function a*x^2 table:");

            //Вызываем таблицу и передаем туда вновь созданный делегат
            //Вносим две переменные для вычислений и одну для количества итераций
            Table(new Fun(MyFunc), 2,3, 5);
          
            Console.WriteLine("Fuction a*sin(x) table:");
           
            Table(delegate (double x, double a) { return a * Math.Sin(x); }, 0,2, 3);

            Console.ReadLine();
        }
    }

}
