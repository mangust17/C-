// код программы
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time;

namespace Lab1
{
    internal class Program
    {

        static void inputInfo(out byte hour, out byte minutes, out byte seconds)//Метод для ввода пользовательских значений
        {
            while (true)
            {
                try
                {
                    Console.Write("hour = ");
                    hour = byte.Parse(Console.ReadLine());
                    if (hour > 24 || hour < 0)
                    {
                        throw new Exception("Неправильное значение для часов");
                    }
                    Console.Write("minutes = ");
                    minutes = byte.Parse(Console.ReadLine());
                    if (minutes > 59 || minutes < 0)
                    {
                        throw new Exception("Неправильное значение для минут");
                    }
                    Console.Write("seconds = ");
                    seconds = byte.Parse(Console.ReadLine());
                    if (seconds > 59 || seconds < 0)
                    {
                        throw new Exception("Неправильное значение для секунд");
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        

        static void Main(string[] args)
        {
            try
            {
                byte hour, minutes, seconds;
                sbyte hour_, minutes_, seconds_;
                inputInfo(out hour, out minutes, out seconds);
                Time.Time time_1 = new Time.Time(hour, minutes, seconds);//тест кейс для проверки конструктора с параметрами
                Console.WriteLine(time_1.ToString());

                Console.Write("hour = ");
                hour = Byte.Parse(Console.ReadLine());
                time_1.hour = hour;
                Console.WriteLine(time_1.ToString());//проверка установки значения часа

                Console.Write("minutes = ");
                minutes = Byte.Parse(Console.ReadLine());
                time_1.minutes = minutes;
                Console.WriteLine(time_1.ToString());//проверка установки значения минуты

                Console.Write("seconds = ");
                seconds = Byte.Parse(Console.ReadLine());
                time_1.seconds = seconds;
                Console.WriteLine(time_1.ToString());//проверка установки значения секунды
            
                Console.Write("hour = ");
                hour_ = SByte.Parse(Console.ReadLine());
                time_1.changeTimeHours(hour_);
                Console.WriteLine(time_1.ToString());

                Console.Write("minutes = ");
                minutes_ = SByte.Parse(Console.ReadLine());
                time_1.changeTimeMinutes(minutes_);
                Console.WriteLine(time_1.ToString());//проверка изменения значения на заданное количество минут

                Console.Write("seconds = ");
                seconds_ = SByte.Parse(Console.ReadLine());
                time_1.changeTimeSeconds(seconds_);
                Console.WriteLine(time_1.ToString());//проверка изменения значения на заданное количество секунд

                Console.Write("hour = ");
                hour_ = SByte.Parse(Console.ReadLine());
                time_1.changeTimeHours(hour_);
                Console.WriteLine(time_1.ToString());//проверка изменения значения на заданное количество часов

                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}