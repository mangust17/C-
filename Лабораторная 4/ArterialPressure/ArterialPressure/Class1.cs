using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

namespace ArterialPressure
{
    public class ArterialPressureClass
    {
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public static string GetTextFromFile(string path)
        {
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = Encoding.Default.GetString(array);
                return textFromFile;
            }
        }
        public void SaveFile(string content)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(content);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка сохранения файла: {ex.Message}");
            }
        }


        public static bool IsValid(string text)
        {
            string[] arr = text.Split(new char[] { ' ' });
            for (int i = 0; i < arr.Length; i++)
            {
                int index = arr[i].IndexOf('/');
                if (index < 0) return false;
                string upper_str = arr[i].Substring(0, index);
                int upper_int;
                bool is_upper_valid = int.TryParse(upper_str, out upper_int);
                string down_str = arr[i].Substring((index + 1), arr[i].Length - index - 1);
                int down_int;
                bool is_down_valid = int.TryParse(down_str, out down_int);
                if ((!is_down_valid || !is_upper_valid) || (upper_int > 320 || down_int > 230) || (upper_int < 10 || down_int < 10)) return false;
            }
            return true;
        }

        public static int[] MinMax(string text)
        {
            string[] measurements = text.Split(new char[] { ' ' });
            int minUpper = int.MaxValue, maxUpper = int.MinValue;
            int minDown = int.MaxValue, maxDown = int.MinValue;

            if (!IsValid(text))
            {
                throw new Exception("Введенная строка не корректна");
            }

            foreach (string measurement in measurements)
            {
                string[] pressureValues = measurement.Split('/');
                if (pressureValues.Length == 2)
                {
                    if (int.TryParse(pressureValues[0], out int upperPressure) &&
                        int.TryParse(pressureValues[1], out int downPressure))
                    {
                        minUpper = Math.Min(minUpper, upperPressure);
                        maxUpper = Math.Max(maxUpper, upperPressure);
                        minDown = Math.Min(minDown, downPressure);
                        maxDown = Math.Max(maxDown, downPressure);
                    }
                }
            }
            return new int[] { minUpper, maxUpper, minDown, maxDown };
        }
        //110-130/60-80) 
        public static string CheckPressure(int[] pressureValues)
        {
            int minUpperPressure = pressureValues[0];
            int maxUpperPressure = pressureValues[1];
            int minDownPressure = pressureValues[2];
            int maxDownPressure = pressureValues[3];

            if(minUpperPressure == int.MaxValue || maxUpperPressure == int.MinValue || minDownPressure == int.MaxValue || maxDownPressure == int.MinValue)
            {
                return "Недостаточно данных для анализа";
            }

            string minUpperMessage = CheckPressureRange(minUpperPressure, 110, 130);
            string minDownMessage = CheckPressureRange(minDownPressure, 60, 80);
            string maxUpperMessage = CheckPressureRange(maxUpperPressure, 110, 130);
            string maxDownMessage = CheckPressureRange(maxDownPressure, 60, 80);

            return $"Минимальное верхнее давление: {minUpperPressure} ({minUpperMessage}), " +
                   $"Максимальное верхнее давление: {maxUpperPressure} ({maxUpperMessage}), " +
                   $"Минимальное нижнее давление: {minDownPressure} ({minDownMessage}), " +
                   $"Максимальное нижнее давление: {maxDownPressure} ({maxDownMessage})";
        }

        private static string CheckPressureRange(int pressure, int minRange, int maxRange)
        {
            if (pressure < minRange)
            {
                return "Ниже нормы";
            }
            else if (pressure > maxRange)
            {
                return "Выше нормы";
            }
            else
            {
                return "В норме";
            }
        }
        public void PrintToPrinter()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(PrintPage);
                pd.Print();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка печати на принтер: {ex.Message}");
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    Font printFont = new Font("Arial", 10);
                    float yPos = 0f;
                    int count = 0;
                    string line = null;

                    while (count < e.MarginBounds.Height / printFont.GetHeight(e.Graphics) &&
                        ((line = reader.ReadLine()) != null))
                    {
                        yPos = count * printFont.GetHeight(e.Graphics);
                        e.Graphics.DrawString(line, printFont, Brushes.Black, 0, yPos, new StringFormat());
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка печати страницы: {ex.Message}");
            }
        }

        public static string OpenFileAndGetContents(string filePath, out string status)
        {
            status = "Открытие документа";
            try
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding(1251)))
                {
                    string fileContents = sr.ReadToEnd();
                    status = string.Empty;
                    return fileContents;
                }
            }
            catch (Exception ex)
            {
                status = $"Ошибка чтения файла.\n{ex.ToString()}";
                return null;
            }
        }
    }
}
