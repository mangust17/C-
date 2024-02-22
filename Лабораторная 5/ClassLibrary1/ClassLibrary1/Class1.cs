using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace OIT_LIB
{
    [Serializable]
    public class Student
    {
        private ushort group;
        public ushort Group
        {
            get { return group; }
            set { group = value; }
        }

        [NonSerialized]
        private string fio;
        public string FIO
        {
            get { return fio; }
            set
            {
                fio = value;
                while (fio.Length < 60)
                {
                    fio += " ";
                }
                if (fio.Length > 60) fio.Remove(60, fio.Length);
                fioByte = Encoding.Unicode.GetBytes(fio);
            }
        }

        private ushort birthdayYear { get; set; }
        public ushort BirthdayYear
        {
            get { return birthdayYear; }
            set
            {
                birthdayYear = value;
            }
        }

        private ulong phoneNumber;
        public ulong PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public Student() { }

        public Student(ushort group, string fio, ushort year, ulong phoneNum)
        {
            Group = group;
            FIO = fio;
            BirthdayYear = year;
            PhoneNumber = phoneNum;
            fioByte = Encoding.Unicode.GetBytes(FIO);
        }

        public byte[] fioByte;
    }

    public class OIT
    {

        public static void appendObject(string filename, Student student) //Метод для добавления обьекта в бинарный файл
        {
            if (getPosition(filename, student.FIO) != -1)
            {
                throw new Exception("Запись с таким ключевым полем уже существует");
            }

            FileStream fa = new FileStream(filename, FileMode.Append);
            BinaryFormatter bw = new BinaryFormatter();

            bw.Serialize(fa, student);
            fa.Close();
        }

        public static int getPosition(string filename, string fio)//Метод для нахождения позиции объекта в бинарном файле по его ключевому полю
        {
            byte[] fioByte;
            while (fio.Length < 60)
            {
                fio += " ";
            }
            if (fio.Length > 60) fio.Remove(60, fio.Length);
            fioByte = Encoding.Unicode.GetBytes(fio);

            int num = 0;
            try
            {
                while (true)
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        fs.Seek(num * 332, SeekOrigin.Begin);
                        Student student = (Student)bf.Deserialize(fs);

                        if (Enumerable.SequenceEqual(student.fioByte, fioByte))
                        {
                            return num;
                        }
                    }
                    num++;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }


        public static void changeData(string filename, long num, Student st)//Метод для замены объектов в бинарном файле на другой.
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open)) { }
            num = num < 0 ? 0 : num;
            if (getPosition(filename, st.FIO) != -1)
            {
                throw new Exception("Запись с таким ключевым полем уже существует");
            }
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    fs.Seek(num * 332, SeekOrigin.Begin);
                    Student student = (Student)bf.Deserialize(fs);

                    student.Group = st.Group;
                    student.FIO = st.FIO;
                    student.BirthdayYear = st.BirthdayYear;
                    student.PhoneNumber = st.PhoneNumber;
                    student.fioByte = st.fioByte;

                    fs.Seek(num * 332, SeekOrigin.Begin);

                    bf.Serialize(fs, student);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void createFile(string fileName) //Метод для создания файла
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate);
            stream.Close();
        }

        public static List<Student> display(string fileName)//Метод для получения всех объектов  в файле
        {
            List<Student> students = new List<Student>();
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    while (fs.Position < fs.Length)
                    {
                        Student student = (Student)formatter.Deserialize(fs);
                        students.Add(student);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return students;
        }

        public static List<Student> getStudentsByGroup(string filename, ushort group)// Метод для отбора студентов по группе
        {
            List<Student> students = display(filename);
            List<Student> result = new List<Student>();
            foreach (Student student in students)
            {
                if (student.Group == group)
                {
                    result.Add(student);
                }
            }
            return result;
        }

        public static List<Student> getStudentsByFIO(string filename, string fio)//Метод для отбора студентов по ФИО
        {
            List<Student> students = display(filename);
            List<Student> result = new List<Student>();

            byte[] fioByte;
            while (fio.Length < 60)
            {
                fio += " ";
            }
            if (fio.Length > 60) fio.Remove(60, fio.Length);
            fioByte = Encoding.Unicode.GetBytes(fio);


            foreach (Student student in students)
            {
                if (Enumerable.SequenceEqual(student.fioByte, fioByte))
                {
                    result.Add(student);
                }
            }
            return result;
        }

        public static List<Student> getStudentsByBirthdayYear(string filename, ushort year)//Метод для отбора студентов по году рождения
        {
            List<Student> students = display(filename);
            List<Student> result = new List<Student>();
            foreach (Student student in students)
            {
                if (student.BirthdayYear == year)
                {
                    result.Add(student);
                }
            }
            return result;
        }

        public static List<Student> getStudentsByPhoneNumber(string filename, ulong phoneNumber)//Метод для отбора студентов по номеру телефона
        {
            List<Student> students = display(filename);
            List<Student> result = new List<Student>();
            foreach (Student student in students)
            {
                if (student.PhoneNumber == phoneNumber)
                {
                    result.Add(student);
                }
            }
            return result;
        }
    }
}

