using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryForArray;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "data.txt";
            IntArray arr = new IntArray();
            try
            {
                Console.Write("Введите длину массива: ");
                int len = int.Parse(Console.ReadLine());
                arr.Length = len;
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write("Введите число " + i + ": ");
                    arr[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine(arr);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: неверное значение для длины массива");
            }

            IntArray randomArr = IntArray.RandomIntArray(arr.Length, 0, 10);
            Console.Write("Случайный массив: ");
            Console.WriteLine(randomArr);

            IntArray.ArrayToTextFile(randomArr, "test.txt");
            Console.WriteLine("Метод ArrayToTextFile выполнен." + '\n');

            int sum = IntArray.SumArray(arr);
            Console.WriteLine("Сумма элементов массива: " + sum);

            IntArray arr2 = IntArray.ArrayFromTextFile(fileName);
            Console.WriteLine(arr2);

            Console.WriteLine("Проверка инкремента");
            Console.WriteLine(arr);
            arr++;
            Console.WriteLine(arr);

            Console.WriteLine("Проверка сложения массива со скаляром");
            Console.WriteLine(arr);
            arr += 10;
            Console.WriteLine(arr);

            Console.WriteLine("Проверка сложения скаляра с массивом");
            Console.WriteLine(arr);
            arr = 10 + arr;
            Console.WriteLine(arr);

            Console.WriteLine("Проверка сложения массивов");
            IntArray arr3 = IntArray.RandomIntArray(3, 0, 10);
            Console.WriteLine("Массив 1: " + arr);
            Console.WriteLine("Массив 2: " + arr3);
            arr += arr3;
            Console.WriteLine(arr);

            try
            {
                Console.WriteLine("Проверка выброса исключения при сложении массивов");
                arr3 = IntArray.RandomIntArray(30, 0, 10);
                Console.WriteLine("Массив 1: " + arr);
                Console.WriteLine("Массив 2: " + arr3);
                arr += arr3;
                Console.WriteLine(arr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Проверка вычетания скаляра из массива");
            Console.WriteLine(arr);
            arr -= 10;
            Console.WriteLine(arr);

            Console.WriteLine("Проверка вычетания массива из скаляра");
            Console.WriteLine(arr);
            arr = 10 - arr;
            Console.WriteLine(arr);

            Console.WriteLine("Проверка вачетания массивов");
            arr3 = IntArray.RandomIntArray(3, 0, 10);
            Console.WriteLine("Массив 1: " + arr);
            Console.WriteLine("Массив 2: " + arr3);
            arr -= arr3;
            Console.WriteLine(arr);

            try 
            {
                Console.WriteLine("Проверка выброса исключения при вычетании массивов");
                arr3 = IntArray.RandomIntArray(30, 0, 10);
                Console.WriteLine("Массив 1: " + arr);
                Console.WriteLine("Массив 2: " + arr3);
                arr -= arr3;
                Console.WriteLine(arr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
