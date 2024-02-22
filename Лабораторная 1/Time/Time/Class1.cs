using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public class Time
    {
        private byte _hour;
        private byte _minutes;
        private byte _seconds;

        public byte hour
        {
            get { return _hour; }
            set
            {
                if (value > 24 || value < 0)
                {
                    throw new Exception("Неправильное значение для часов");
                }
                _hour = value;

            }
        }

        public byte minutes
        {
            get { return _minutes; }
            set
            {
                if (value > 59 || value < 0)
                {
                    throw new Exception("Неправильное значение для минут");
                }
                _minutes = value;
            }

        }

        public byte seconds
        {
            get { return _seconds; }
            set
            {
                if (value > 59 || value < 0)
                {
                    throw new Exception("Неправильное значение для секунд");
                }
                _seconds = value;
            }
        }

        public void changeTimeHours(int hour)//метод для изменения значения часа на заданное количенство единиц
        {
            int minutes = 0;
            int seconds = 0;
            if (hour > 100 || hour < -100)
            {
                throw new Exception("Неправильное значение для изменения времени");
            }
            int totalSeconds = this.hour * 3600 + this.minutes * 60 + this.seconds;
            totalSeconds += (3600 * ((hour % 24) + 24) + 60 * minutes + seconds);

            this.hour = (byte)((totalSeconds / 3600) % 24);
            this.minutes = (byte)((totalSeconds / 60) % 60);
            this.seconds = (byte)(totalSeconds % 60);
        }

        public void changeTimeMinutes(int minutes)//метод для изменения значения митнут на заданное количенство единиц
        {
            int hour = 0;
            int seconds = 0;
            if (minutes > 100 || minutes < -100)
            {
                throw new Exception("Неправильное значение для изменения времени");
            }
            int totalSeconds = this.hour * 3600 + this.minutes * 60 + this.seconds;
            totalSeconds += (3600 * ((hour % 24) + 24) + 60 * minutes + seconds);

            this.hour = (byte)((totalSeconds / 3600) % 24);
            this.minutes = (byte)((totalSeconds / 60) % 60);
            this.seconds = (byte)(totalSeconds % 60);
        }

        public void changeTimeSeconds(int seconds)//метод для изменения значения секунд на заданное количенство единиц
        {
            int hour = 0;
            int minutes = 0;
            if (seconds > 100 || seconds < -100)
            {
                throw new Exception("Неправильное значение для изменения времени");
            }
            int totalSeconds = this.hour * 3600 + this.minutes * 60 + this.seconds;
            totalSeconds += (3600 * ((hour % 24) + 24) + 60 * minutes + seconds);

            this.hour = (byte)((totalSeconds / 3600) % 24);
            this.minutes = (byte)((totalSeconds / 60) % 60);
            this.seconds = (byte)(totalSeconds % 60);
        }

        public void setTime(byte hour, byte minutes, byte seconds)//метод для задания значений времени
        {
            this.hour = hour;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public override string ToString()//метод для преобразования обьектов в строку 
        {
            return String.Format("Время {0}:{1}:{2}", hour, minutes, seconds);
        }


        public Time(byte hour, byte minutes, byte seconds)//конструктор с парметрами
        {
            this.hour = hour;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public Time() { }//конструктор по умолчанию
    }
}
