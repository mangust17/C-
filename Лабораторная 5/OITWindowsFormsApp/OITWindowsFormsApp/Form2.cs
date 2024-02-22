using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using OIT_LIB;
using System.Text;

namespace OITWindowsFormsApp
{
    public partial class Form2 : Form
    {
        private string data;

        public Form2(string data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                List<Student> students = OIT.display(data);
                if (students.Count == 0)
                {
                    MessageBox.Show("Записи не найдены", "Ошибка");
                    return;
                }
                dataGridView1.RowCount = students.Count;
                dataGridView1.ColumnCount = 5;
                for (int i = 0; i < students.Count; i++)
                {
                    Student student = students[i];
                    dataGridView1.Rows[i].Cells[0].Value = i;
                    dataGridView1.Rows[i].Cells[1].Value = student.Group;

                    string str = "";
                    char[] bytes = Encoding.UTF8.GetString(student.fioByte).ToCharArray();
                    foreach (char c in bytes) { str += c; }

                    dataGridView1.Rows[i].Cells[2].Value = str;
                    dataGridView1.Rows[i].Cells[3].Value = student.BirthdayYear;
                    dataGridView1.Rows[i].Cells[4].Value = student.PhoneNumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void UpdateDataGridView()
        {
            dataGridView1.DataSource = null;
        }

        private void FilterData()
        {
            int selectedIndex = comboBox1.SelectedIndex;
            List<Student> students = new List<Student>();
            bool exit = false;
            switch (selectedIndex)
            {
                case 0:
                    students = OIT.getStudentsByGroup(data, Convert.ToUInt16(textBox4.Text));
                    break;
                case 1:
                    students = OIT.getStudentsByFIO(data, textBox4.Text);
                    break;
                case 3:
                    students = OIT.getStudentsByPhoneNumber(data, Convert.ToUInt64(textBox4.Text));
                    break;
                case 2:
                    students = OIT.getStudentsByBirthdayYear(data, Convert.ToUInt16(textBox4.Text));
                    // MessageBox.Show("Значение не может быть преобразовано в число", "Ошибка");
                    break;

            }
            if (exit) { return; }
            if (students.Count == 0)
            {
                MessageBox.Show("Записи не найдены", "Ошибка");
                return;
            }
            dataGridView1.RowCount = students.Count;
            dataGridView1.ColumnCount = 5;
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];
                dataGridView1.Rows[i].Cells[0].Value = i;
                dataGridView1.Rows[i].Cells[1].Value = student.Group;

                string str = "";
                char[] bytes = Encoding.UTF8.GetString(student.fioByte).ToCharArray();
                foreach (char c in bytes) { str += c; }

                dataGridView1.Rows[i].Cells[2].Value = str;
                dataGridView1.Rows[i].Cells[3].Value = student.BirthdayYear;
                dataGridView1.Rows[i].Cells[4].Value = student.PhoneNumber;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(data))
            {
                FilterData();
            }
            else
            {
                MessageBox.Show("Файл не найден.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<Student> students = OIT.display(data);
                if (students.Count == 0)
                {
                    MessageBox.Show("Записи не найдены", "Ошибка");
                    return;
                }
                dataGridView1.RowCount = students.Count;
                dataGridView1.ColumnCount = 5;
                for (int i = 0; i < students.Count; i++)
                {
                    Student student = students[i];
                    dataGridView1.Rows[i].Cells[0].Value = i;
                    dataGridView1.Rows[i].Cells[1].Value = student.Group;

                    string str = "";
                    char[] bytes = Encoding.UTF8.GetString(student.fioByte).ToCharArray();
                    foreach (char c in bytes) { str += c; }

                    dataGridView1.Rows[i].Cells[2].Value = str;
                    dataGridView1.Rows[i].Cells[3].Value = student.BirthdayYear;
                    dataGridView1.Rows[i].Cells[4].Value = student.PhoneNumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }
    }
}
