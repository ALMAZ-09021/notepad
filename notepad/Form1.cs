using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace notepad
{
    public partial class Блокнот : Form
    {
        public Блокнот()
        {
            InitializeComponent();//инициализация элементов и форматов файлов
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            fontDialog1.ShowColor = true;
        }
        bool isSaved = true;//вводим переменную,проверяющую сохранен ли файл
        private void richTextBox1_TextChanged(object sender, EventArgs e)//проверяем изменение сохраненного текста
        {
            isSaved =false;
        } 
        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();//прекращает работу блокнота,перед этим проверив сохранена ли информация
        }

        private void выбратьВсеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();//выбирает весь текст,находящийся в блокноте
        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();//вставляет скопированный текст
        }

        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();//вырезает выделенную часть
        }

        private void изменитьШрифтцветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)//если передумали изменять цвет/шрифт,то возвращает к исходному тексту
                return;
            // изменяется шрифт
            richTextBox1.SelectionFont = fontDialog1.Font;
            // изменяется цвет
            richTextBox1.ForeColor = fontDialog1.Color;
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();//создает объект новой формы
            newForm.Show();//отображает Form2 на экране
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();//копирует выделенный текст
        }

        private void создатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {   
            if (!isSaved)
            {
                DialogResult res = MessageBox.Show("Сохранить?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                {
                      //закрываем сообщение
                }
                else if (res == DialogResult.Yes)
                {
                    SaveFileDialog safety = new SaveFileDialog();
                    safety.FileName = "Безымянный";
                    safety.Filter = "Текстовый файл|*.txt";
                    isSaved = true;
                    if (safety.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.Clear();
                    }
                }
                else//очищаем форму от текста
                {
                    richTextBox1.Clear();
                }
            }
        }

        private void Блокнот_FormClosing(object sender, FormClosingEventArgs e)
        {
             e.Cancel = false;
             if (!isSaved)
             {
                 DialogResult res = MessageBox.Show("Сохранить?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                 if (res == DialogResult.Cancel)//закрываем сообщение
                 {
                    e.Cancel = true;
                 }
                 else if (res == DialogResult.Yes)
                 {
                     SaveFileDialog text = new SaveFileDialog();
                     text.FileName = "Безымянный";
                     text.Filter = "Текстовый файл|*.txt";
                     
                     if (text.ShowDialog() == DialogResult.OK)
                     {
                         File.WriteAllText(text.FileName, richTextBox1.Text);
                     }
                     else//закрываем сообщение
                     {
                        e.Cancel = true;
                     }
                 }       
             }
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
            isSaved = true;
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                DialogResult res = MessageBox.Show("Сохранить?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                {
                    return;
                }
                else if (res == DialogResult.Yes)
                {
                    SaveFileDialog safety = new SaveFileDialog();
                    safety.FileName = "Безымянный";
                    safety.Filter = "Текстовый файл|*.txt";
                    isSaved = true;

                    if (safety.ShowDialog() == DialogResult.OK)
                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                            return;
                        // получаем выбранный файл
                        string filename = openFileDialog1.FileName;
                        // читаем файл в строку
                        string fileText = System.IO.File.ReadAllText(filename);
                        richTextBox1.Text = fileText;
                        MessageBox.Show("Файл открыт");
                        isSaved = false;
                    }
                }
                else
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    // получаем выбранный файл
                    string filename = openFileDialog1.FileName;
                    // читаем файл в строку
                    string fileText = System.IO.File.ReadAllText(filename);//копируем текст из исходного файла и вставляем в форму
                    richTextBox1.Text = fileText;
                    MessageBox.Show("Файл открыт");
                    isSaved = false;
                }
            }
        }
    }

}
