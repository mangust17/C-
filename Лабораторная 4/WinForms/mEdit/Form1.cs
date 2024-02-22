using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ArterialPressure;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        // имя файла
        private string fn = string.Empty;        
        private bool docChanged = false; // true - в текст внесены изменения
        string status="";
        ArterialPressureClass AP = new ArterialPressureClass();

        public Form1()  //конструктор формы
        {
            InitializeComponent();

            textBox1.ScrollBars = ScrollBars.Vertical;  //только вертикальная прокрутка
            textBox1.Text = string.Empty;               //очистить текст

            this.Text = "NkEdit - Новый документ";      //заголовок формы

            // отобразить панель инструментов
            toolStrip1.Visible = true;
            ParamToolStripMenuItem.Checked = true;  //установить галочку на данном пункте меню (Панель инструментов)

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "текст|*.txt";
            openFileDialog1.Title = "Открыть документ";
            openFileDialog1.Multiselect = false;

            // настройка компонента saveDialog1
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "текст|*.txt";
            saveFileDialog1.Title = "Сохранить документ";
        }

        private int SaveDocument()
        {
            status = "Сохранение документа";
            statusStrip1.Items[2].Text = "Состояние: " + status;

            int result = 0;
    
            if (fn == string.Empty)
            {
                 // отобразить диалог Сохранить
                 if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                 {
                      // отобразить имя файла в заголовке окна
                      fn = saveFileDialog1.FileName;
                      this.Text = fn;
                 }
                 else result = -1;

            }

            // сохранить файл
            if (fn != string.Empty)
            {
                 try
                 {
                     // получим информацию о файле fn
                     System.IO.FileInfo fi =
                            new System.IO.FileInfo(fn);

                     // поток для записи (перезаписываем файл)
                     
                     System.IO.StreamWriter sw = fi.CreateText();

                     // записываем данные
                     sw.Write(textBox1.Text);

                     // закрываем поток
                     sw.Close();
                     result = 0;
                 }
                 catch (Exception exc)
                 {
                     MessageBox.Show(exc.ToString(), "NkEdit",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                 }
            }

            statusStrip1.Items[2].Text = "Состояние: ";
            return result;
        }
        
        // выбор в меню Файл команды Создать
        private void FileCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status = "Создание документа";
            statusStrip1.Items[2].Text = "Состояние: " + status;

            if (docChanged)
            {
                DialogResult dr;
                dr = MessageBox.Show("Сохранить изменения ?", "NkEdit",
                                      MessageBoxButtons.YesNoCancel,
                                      MessageBoxIcon.Warning);
                switch (dr)
                {
                    case DialogResult.Yes:
                        
                        if (SaveDocument() == 0)
                        {
                            textBox1.Clear();
                            docChanged = false;
                        }
                        break;
                    case DialogResult.No:
                        textBox1.Clear();
                        docChanged = false;
                        break;
                    case DialogResult.Cancel:                        
                        break;
                }
            }

            statusStrip1.Items[2].Text = "Состояние: ";
        }

        private void FileOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status = "Открытие документа";
            statusStrip1.Items[2].Text = "Состояние: " + status;

            openFileDialog1.FileName = string.Empty;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fn = openFileDialog1.FileName;
                AP.Path = fn;

                this.Text = fn;

                string fileContents = ArterialPressureClass.OpenFileAndGetContents(fn, out status);

                if (fileContents != null)
                {
                    textBox1.Text = fileContents;
                    textBox1.SelectionStart = textBox1.TextLength;
                }
                else
                {
                    MessageBox.Show("Не удалось открыть файл.", "MEdit",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

            statusStrip1.Items[2].Text = "Состояние: " + status;

        }


        // выбор в меню Файл команды Сохранить
        private void FileSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ArterialPressureClass.IsValid(textBox1.Text))
            {
                try {
                    AP.SaveFile(textBox1.Text);
                }
                catch(Exception ex) {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();

                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    DialogResult result = saveFileDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        AP.Path = filePath;
                        if (ArterialPressureClass.IsValid(textBox1.Text))
                            AP.SaveFile(textBox1.Text);
                        else
                            MessageBox.Show("Сохраняемые данные не корректны, в файле должны находиться только записи об артериальном виде через пробел (120/90 110/80)");
                    }
                }
            }
            else
                MessageBox.Show("Сохраняемые данные не корректны, в файле должны находиться только записи об артериальном виде через пробел (120/90 110/80)");
        }

        // выбор в меню Файл команды Выход
        private void FileExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // выбор в меню Параметры команды Панель инструментов
        private void ParamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // отобразить/скрыть панель инструментов
            toolStrip1.Visible = ! toolStrip1.Visible;
            ParamToolStripMenuItem.Checked = ! ParamToolStripMenuItem.Checked;
        }

        // выбор в меню Параметры команды Шрифт
        private void ParamFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status = "Выбор шрифта";
            statusStrip1.Items[2].Text = "Состояние: " + status;

            fontDialog1.Font = textBox1.Font;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }

            statusStrip1.Items[2].Text = "Состояние: ";
        }

        //обработка события TextChanged
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            docChanged = true;
            int len = textBox1.Text.Length; // кол-во символов в поле редактирования 

            statusStrip1.Items[0].Text = "Число знаков: " + len.ToString("D");
            int lines = textBox1.Lines.Length;            
            statusStrip1.Items[1].Text = "Число строк: " + lines.ToString("D");
            status = "Редактирование документа";
            statusStrip1.Items[2].Text = "Состояние: " + status;    
        }

        // пользователь сделал щелчок на кнопке "Закрыть окно"
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (docChanged )
            {
                DialogResult dr;
                dr = MessageBox.Show("Сохранить изменения?", "NkEdit",
                                      MessageBoxButtons.YesNoCancel,
                                      MessageBoxIcon.Warning);
                switch ( dr )
                {
                    case DialogResult.Yes :
                        status = "Сохранение документа";
                        if ( SaveDocument() != 0)
                            // пользователь отменил операцию сохранения файла 
                            e.Cancel = true; // отменить закрытие окна программы 
                         break;
                    case DialogResult.No: ;
                         break;
                    case DialogResult.Cancel:
                         // отменить закрытие окна программы  
                         e.Cancel = true;
                         break; 
                }
            }
        }

        // выбор в меню Справка команды О программе
        private void оПрограммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status = "Справка о программе";
            statusStrip1.Items[2].Text = "Состояние: " + status;

            Form2 about = new Form2();
            about.ShowDialog();
            statusStrip1.Items[2].Text = "Состояние: ";
        }

        // выбор в меню Файл команды Печать
        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status = "Печать документа";
            statusStrip1.Items[2].Text = "Состояние: " + status;

            try
            {
                AP.PrintToPrinter();
            } catch {
                MessageBox.Show("Пожалуйста сначала откройте файл");
            }


            statusStrip1.Items[2].Text = "Состояние: ";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(ArterialPressureClass.CheckPressure(ArterialPressureClass.MinMax(textBox1.Text)));
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                AP.Path = filePath;
                if (ArterialPressureClass.IsValid(textBox1.Text))
                    AP.SaveFile(textBox1.Text);
                else
                    MessageBox.Show("Сохраняемые данные не корректны, в файле должны находиться только записи об артериальном виде через пробел (120/90 110/80)");
            }
        }

        private void ParamToolStripToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
