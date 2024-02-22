using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForArray
{
    public class IntArray
    {
        private int[] a;
        private int length;

        public int Length
        {
            get { return length; }
            set{
                length = value;
                a = new int[length];
            }
        }

        public int this[int i]
        {
            get { return a[i]; }
            set{ a[i] = value; }
        }

        public static IntArray RandomIntArray(int length, int a, int b)
        {
            IntArray intArray = new IntArray(length);
            Random random = new Random();
            for(int i = 0; i < length; i++)
            {
                intArray[i] = random.Next(a, b);
            }
            return intArray;
        }

        public static IntArray ArrayFromTextFile(string fileName)
        {
            IntArray intArray = new IntArray();
            try
            {
                StreamReader f = new StreamReader(fileName);
                LinkedList<int> list = new LinkedList<int>();
                string s;
                int i = 0;
                int len = 0;
                while ((s = f.ReadLine()) != null)
                {
                    list.AddLast(int.Parse(s));
                    len++;
                }
                intArray.Length = len;
                while (i < list.Count)
                {
                    intArray[i] = list.ElementAt(i);
                    i++;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return intArray;
        }

        public static void ArrayToTextFile(IntArray arr, string fileName)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fileName))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        streamWriter.WriteLine(arr[i]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int SumArray(IntArray arr)
        {
            int sum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        public static IntArray operator ++(IntArray arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]++;
            }
            return arr;
        }

        public static IntArray operator +(IntArray x, int y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] += y;
            }
            return x;
        }

        public static IntArray operator +(int x, IntArray y)
        {
            for (int i = 0; i < y.Length; i++)
            {
                y[i] += x;
            }
            return y;
        }

        public static IntArray operator +(IntArray x, IntArray y)
        {
            if (y.Length > x.Length)
            {
                for (int i = 0; i < y.Length; i++)
                {
                    y[i] += x[i];
                }
                return y;
            }
            else
            {
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] += y[i];
                }
                return x;
            }
        }

        public static IntArray operator --(IntArray arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i]--;
            }
            return arr;
        }

        public static IntArray operator -(IntArray x, int y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] -= y;
            }
            return x;
        }

        public static IntArray operator -(int x, IntArray y)
        {
            for (int i = 0; i < y.Length; i++)
            {
                y[i] -= x;
            }
            return y;
        }

        public static IntArray operator -(IntArray x, IntArray y)
        {
            if (y.Length > x.Length)
            {
                for (int i = 0; i < y.Length; i++)
                {
                    y[i] -= x[i];
                }
                return y;
            }
            else
            {
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] -= y[i];
                }
                return x;
            }
        }
    
        public static IntArray Method(IntArray A, IntArray B)
        {
            IntArray C = new IntArray(A.Length - 1);
            for (int i = 0; i < A.Length - 1; i++)
            {
                C[i] = A[i] * A[i + 1] + B[i] * B[i + 1];
            }
            return C;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Length; i++)
            {
                s += a[i] + " ";
            }
            return s;
        }

        public IntArray(){}

        public IntArray(int length)
        {
            this.Length = length;
        }

        public IntArray(params int[] arr)
        {
            this.a = arr;
        }

    }
}
