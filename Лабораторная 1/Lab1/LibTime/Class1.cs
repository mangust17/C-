using System;

namespace LibTime
{

    class Time
    {
        private byte _hour;
        private byte _minutes;
        private byte _seconds;

        public byte hour
        {
            get { return _hour; }
            set
            {
                try
                {
                    if (value > 24 || value < 0)
                    {
                        throw new Exception("Неправильный формат времени");
                    }
                    _hour = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public byte minutes
        {
            get { return _minutes; }
            set
            {
                try
                {
                    if (value > 59 || value < 0)
                    {
                        throw new Exception("Неправильный формат времени");
                    }
                    _minutes = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public byte seconds
        {
            get { return _seconds; }
            set
            {
                try
                {
                    if (value > 59 || value < 0)
                    {
                        throw new Exception("Неправильный формат времени");
                    }
                    _seconds = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void setTime(byte hour, byte minutes, byte seconds)
        {
            this.hour = hour;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public Time(byte hour, byte minutes, byte seconds)
        {
            this.hour = hour;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        public Time() { }
    }


}
