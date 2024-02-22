using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OIT_LIB;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OITWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьФормуПросмотраДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OIT.createFile(textBox4.Text);

                ushort age;
                ulong someValue;

                if (ushort.TryParse(textBox1.Text, out age) && ulong.TryParse(textBox3.Text, out someValue))
                {
                    Student student = new Student(age, textBox2.Text, (ushort)Convert.ToInt32(numericUpDown1.Value), someValue);
                    OIT.appendObject(textBox4.Text, student);
                }
                else
                {
                    MessageBox.Show("Некорректный ввод данных", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                OIT.createFile(textBox4.Text);

                ushort age;
                ulong someValue;

                if (ushort.TryParse(textBox1.Text, out age) && ulong.TryParse(textBox3.Text, out someValue))
                {
                    Student student = new Student(age, textBox2.Text, (ushort)Convert.ToInt32(numericUpDown1.Value), someValue);
                    OIT.appendObject(textBox4.Text, student);
                }
                else
                {
                    MessageBox.Show("Некорректный ввод данных", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ushort age;
                ulong someValue;
                Student student;
                if (ushort.TryParse(textBox1.Text, out age) && ulong.TryParse(textBox3.Text, out someValue))
                {
                    student = new Student(age, textBox2.Text, (ushort)Convert.ToInt32(numericUpDown1.Value), someValue);
                    string filename = textBox4.Text;
                    OIT.changeData(filename, Convert.ToInt32(numericUpDown2.Value), student);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 newForm = new Form2(textBox4.Text);

                newForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void изменитьОбъектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ushort age;
                ulong someValue;
                Student student;
                if (ushort.TryParse(textBox1.Text, out age) && ulong.TryParse(textBox3.Text, out someValue))
                {
                    student = new Student(age, textBox2.Text, (ushort)Convert.ToInt32(numericUpDown1.Value), someValue);
                    string filename = textBox4.Text;
                    OIT.changeData(filename, Convert.ToInt32(numericUpDown2.Value), student);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void открытьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
                Form2 newForm = new Form2(textBox4.Text);

                newForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
