using ClassLibraryForArray;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int n = 0;
        Random r = new Random();
        IntArray A = new IntArray();
        IntArray B = new IntArray();
        IntArray C = new IntArray();
        bool isA = false;
        public Form1()
        {
            InitializeComponent();
            setInvisible();
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView2.CellValueChanged += DataGridView2_CellValueChanged;
            dataGridView3.Enabled = false;

            setInvisible();
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
            numericUpDown1.Visible = true;
            groupBox1.Visible = true;
            groupBox3.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton5.Visible = true;
            radioButton6.Visible = true;
            numericUpDown3.Visible = true;
            numericUpDown5.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
        }
        private bool IsInt(string value)
        {
            return int.TryParse(value, out _);
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton1.Checked)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (IsInt(cell.Value?.ToString()) && cell.Value?.ToString()[0] != '0')

                    A[e.ColumnIndex] = int.Parse(cell.Value.ToString());
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }

        private void DataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e) //
        {
            if (radioButton1.Checked)
            {
                DataGridViewCell cell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (IsInt(cell.Value?.ToString()))
                    B[e.ColumnIndex] = int.Parse(cell.Value.ToString());
                else
                {
                    dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }

        private void массивАToolStripMenuItem_Click(object sender, EventArgs e) //меню ToolStrip для мааасива А и отображаемые в нем элементы
        {
            setInvisible();
            dataGridView1.Visible = true;
            dataGridView1.Enabled = true;
            numericUpDown1.Visible = true;
            groupBox1.Visible = true;
            groupBox3.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton5.Visible = true;
            radioButton6.Visible = true;
            numericUpDown3.Visible = true;
            numericUpDown5.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
        }

        private void массивБToolStripMenuItem_Click(object sender, EventArgs e) //меню ToolStrip для массива Б и отображаемые в нем элементы
        {
            setInvisible();
            dataGridView2.Visible = true;
            dataGridView2.Enabled = true;
            numericUpDown2.Visible = true;
            groupBox1.Visible = true;
            groupBox3.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton5.Visible = true;
            radioButton6.Visible = true;
            numericUpDown4.Visible = true;
            numericUpDown6.Visible = true;
            textBox2.Visible = true;
            button2.Visible = true;
            label7.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
        }

        private void setInvisible() // метод для включения режима неотображения для пользователя
        {
            dataGridView1.Visible = false;
            dataGridView1.Enabled = false;
            int n = Convert.ToInt32(numericUpDown1.Value);
            dataGridView1.SetBounds(12, 217, 100 * n + n, 60);
            dataGridView2.Visible = false;
            dataGridView2.Enabled = false;
            n = Convert.ToInt32(numericUpDown2.Value);
            dataGridView2.SetBounds(12, 217, 100 * n + n, 60);
            dataGridView3.Visible = false;
            dataGridView3.SetBounds(12, 217, 100 * C.Length + C.Length, 60);
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            numericUpDown3.Visible = false;
            numericUpDown4.Visible = false;
            numericUpDown5.Visible = false;
            numericUpDown6.Visible = false;
            groupBox1.Visible = false; 
            groupBox3.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            numericUpDown7.Visible = false;
            numericUpDown8.Visible = false;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) //заполнение массивов А при изменении его длины
        {
            int n = Convert.ToInt32(numericUpDown1.Value);
            dataGridView1.ColumnCount = n;
            dataGridView1.SetBounds(12, 217, 100 * n + n, 60);
            A.Length = n;
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Name = i.ToString();
                if (radioButton1.Checked)
                {
                    A[i] = 0;
                    dataGridView1.Rows[0].Cells[i].Value = A[i];
                }
                else
                {
                    A[i] = (r.Next((int)numericUpDown3.Value, (int)numericUpDown5.Value));
                    dataGridView1.Rows[0].Cells[i].Value = A[i];
                }
            }
        }

        public void updateGrids() // метод для обновления значения DataGridView из массивов
        {
            for (int i = 0; i < A.Length; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = A[i];
            }
            for (int i = 0; i < B.Length; i++)
            {
                dataGridView2.Rows[0].Cells[i].Value = B[i];
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) //заполнение массивов Б при изменении его длины
        {
            int n = Convert.ToInt32(numericUpDown2.Value);
            dataGridView2.ColumnCount = n;
            dataGridView2.SetBounds(12, 217, 100 * n + n, 60);
            B.Length = n;
            for (int i = 0; i < n; i++)
            {
                dataGridView2.Columns[i].Name = i.ToString();
                if (radioButton1.Checked)
                {
                    B[i] = 0;
                    dataGridView2.Rows[0].Cells[i].Value = B[i];
                }
                else
                {
                    B[i] = (r.Next((int) numericUpDown4.Value, (int)numericUpDown6.Value));
                    dataGridView2.Rows[0].Cells[i].Value = B[i];
                }
            }
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e) //ограничение для задания случайных чисел
        {
            if(Convert.ToInt32(numericUpDown4.Value) > Convert.ToInt32(numericUpDown6.Value))
            {
                numericUpDown6.Value = numericUpDown4.Value;
            }
        }

        private void button2_Click(object sender, EventArgs e) //работа с файлами
        {
            if (radioButton6.Checked)
            {
                try
                {
                    IntArray.ArrayToTextFile(B, textBox2.Text + ".txt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при записи в файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (radioButton5.Checked)
            {
                try
                {
                    B = IntArray.ArrayFromTextFile(textBox2.Text + ".txt");
                    dataGridView2.RowCount = 1;
                    dataGridView2.ColumnCount = A.Length;
                    int n = B.Length;
                    dataGridView2.SetBounds(12, 217, 100 * n + n, 60);
                    for (int i = 0; i < B.Length; i++)
                    {
                        dataGridView2.Columns[i].Name = i.ToString();
                        dataGridView2.Rows[0].Cells[i].Value = B[i];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении из файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //работа с файлами
        {
            if (radioButton6.Checked)
            {
                try
                {
                    IntArray.ArrayToTextFile(A, textBox1.Text + ".txt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при записи в файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (radioButton5.Checked)
            {
                try
                {
                    A = IntArray.ArrayFromTextFile(textBox1.Text + ".txt");
                    dataGridView1.RowCount = 1;
                    dataGridView1.ColumnCount = A.Length;
                    int n = A.Length;
                    dataGridView1.SetBounds(12, 217, 100 * n + n, 60);
                    for (int i = 0; i < A.Length; i++)
                    {
                        dataGridView1.Columns[i].Name = i.ToString();
                        dataGridView1.Rows[0].Cells[i].Value = A[i];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении из файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e) //нижняя граница случайного числа
        {
            if (Convert.ToInt32(numericUpDown4.Value) > Convert.ToInt32(numericUpDown6.Value))
            {
                numericUpDown4.Value = numericUpDown6.Value;
            }
        }

        private void массивАToolStripMenuItem1_Click(object sender, EventArgs e)//открытие вкладки для массива А
        {
            setInvisible();
            isA = true;
            dataGridView1.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            numericUpDown7.Visible = true;
            numericUpDown8.Visible = true;
            label3.Visible = true;
        }

        private void массивБToolStripMenuItem1_Click(object sender, EventArgs e) //открытие вкладки для массива Б
        {
            setInvisible();
            isA = false;
            dataGridView2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            numericUpDown7.Visible = true;
            numericUpDown8.Visible = true;
            label3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e) //инкримент массивов
        {
            if(isA)
            {
                A++;
            }
            else
            {
                B++;
            }
            updateGrids();
        }

        private void button4_Click(object sender, EventArgs e) //декримент массивов
        {
            if (isA)
            {
                A--;
            }
            else
            {
                B--;
            }
            updateGrids();
        }

        private void button5_Click(object sender, EventArgs e) // сложение массива со скаляром
        {
            if (isA)
            {
                A += Convert.ToInt32(numericUpDown8.Value);
            }
            else
            {
                B += Convert.ToInt32(numericUpDown8.Value);
            }
            updateGrids();
        }

        private void button6_Click(object sender, EventArgs e) // вывод информации по массиву(сумма элементов, размер и количество элементов кратных заданному числу
        {
            IntArray N;
            if (isA)
            {
                N = A;
            }
            else
            {
                N = B;
            }

            int sum = 0, count = N.Length, crat = 0, num = Convert.ToInt32(numericUpDown7.Value);
            if(num == 0)
            {
                label3.Text = "Числа нельзя проверить на кратность нулю";
                return;
            }
            for (int i = 0; i < N.Length; i++)
            {
                sum += N[i]; ;
                if (N[i] % num == 0)
                    crat++;
            }
            label3.Text = "Сумма элементов массива = " + sum + " , количество элементов = " + count + " , количество элементов кратных " + num + " = " + crat;
        }

        private void действиеНадОбоимиМассивамиToolStripMenuItem_Click(object sender, EventArgs e) //открытие вкладки для действий с обоими массивами
        {
            setInvisible();
            dataGridView1.Visible = true;
            int n = Convert.ToInt32(numericUpDown1.Value);
            dataGridView1.SetBounds(12, 148, 100 * n + n, 60);
            dataGridView2.Visible = true;
            n = Convert.ToInt32(numericUpDown2.Value);
            dataGridView2.SetBounds(12, 210, 100 * n + n, 60);
            dataGridView3.Visible = true;
            dataGridView3.SetBounds(12, 280, 100 * C.Length + C.Length, 60);
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e) // индивидуальное задание
        {
            if (A.Length != 0 && B.Length != 0)
            {
                C = IntArray.Method(A, B);
                dataGridView3.RowCount = 1;
                dataGridView3.ColumnCount = C.Length;
                int n = C.Length;
                dataGridView3.SetBounds(12, 280, 100 * n + n, 60);
                for (int i = 0; i < C.Length; i++)
                {
                    dataGridView3.Columns[i].Name = i.ToString();
                    dataGridView3.Rows[0].Cells[i].Value = C[i];
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)  // сложение массивов
        {
            
            dataGridView3.RowCount = 1;
            dataGridView3.ColumnCount = A.Length;
            int n = A.Length;
            C.Length = Math.Max(A.Length, B.Length);
            dataGridView3.SetBounds(12, 280, 100 * n + n, 60);
            for (int i = 0; i < C.Length; i++)
            {
                if(A.Length > i)
                    C[i] += A[i];
                if (B.Length > i)
                    C[i] += B[i];
                dataGridView3.Columns[i].Name = i.ToString();
                dataGridView3.Rows[0].Cells[i].Value = C[i];
            }
            
        }

        private void button8_Click(object sender, EventArgs e) //вычитание массивов
        {
            dataGridView3.RowCount = 1;
            dataGridView3.ColumnCount = A.Length;
            int n = A.Length;
            C.Length = Math.Max(A.Length, B.Length);
            dataGridView3.SetBounds(12, 280, 100 * n + n, 60);
            for (int i = 0; i < C.Length; i++)
            {
                if (A.Length > i)
                    C[i] = A[i];
                if (B.Length > i)
                    C[i] -= B[i];
                dataGridView3.Columns[i].Name = i.ToString();
                dataGridView3.Rows[0].Cells[i].Value = C[i];
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e) // нижняя граница для случайного числа
        {
            if (Convert.ToInt32(numericUpDown3.Value) > Convert.ToInt32(numericUpDown5.Value))
            {
                numericUpDown3.Value = numericUpDown5.Value;
            }
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)// верхняя граница случайного числа
        {
            if (Convert.ToInt32(numericUpDown3.Value) > Convert.ToInt32(numericUpDown5.Value))
            {
                numericUpDown5.Value = numericUpDown3.Value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
