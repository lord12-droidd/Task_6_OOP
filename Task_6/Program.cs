using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Program
    {
        private static int CheckedSize(int value, string meaning)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Введіть кількість {meaning}: ");
                    value = Convert.ToInt32(Console.ReadLine());
                    if (value >= 1)
                    {
                        return value;

                    }
                    else
                    {
                        Console.WriteLine($"Кількість {meaning} повинна бути більша ніж 0");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                }

            }
        }

        private static int[,] FillingWritting(int[,] arr)
        {
            Console.WriteLine();
            Random rand = new Random();
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                {
                    arr[i, j] = rand.Next(1,41);
                    Console.Write($"{arr[i, j]} \t");
                }
                Console.WriteLine();
            }
            return arr;
        }

        private static void SearchValue(int[,] arr)
        {
            Console.WriteLine();
            bool present = false;
            Console.WriteLine("Введіть шуканий елемент: ");
            while (true)
            {
                try
                {
                    int searched = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
                    {
                        for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
                        {
                            if (arr[i, j] == searched)
                            {
                                present = true;
                                Console.WriteLine($"{arr[i, j]}: рядок {i+1} стовпець {j+1}");
                            }
                        }
                    }
                    if (!present)
                    {
                        Console.WriteLine($"Такого елементу немає в масиві");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ви ввели некоректне значення!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ви ввели недопустиме для пошуку значення!");
                }
            
            }
        }

        private static void ColumnMin(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(1); ++i)
            {
                //int tempmin = int.MaxValue;
                int tempmin = arr[0, i];
                int posj = 0;
                for (int j = 0; j < arr.GetLength(0); ++j)
                {
                    if (arr[j, i] < tempmin)
                    {
                        tempmin = arr[j, i];
                        posj = j;
                    }
                }
                Console.WriteLine($"В стовпці номер {i + 1} найменший: {tempmin}, Стовпець: {i+1} , Рядок: {posj+1}");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            int m = 0;
            int n = 0;
            int[,] massive = new int[CheckedSize(m,"рядків"), CheckedSize(n,"стовпців")];
            massive = FillingWritting(massive);
            SearchValue(massive);
            ColumnMin(massive);
            Console.ReadKey();
        }
    }
}
