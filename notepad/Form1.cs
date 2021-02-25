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
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            fontDialog1.ShowColor = true;
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool UpdateInForm = false;
        private void richtextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateInForm = true;
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный нами файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в выбранный файл файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // прочитываем выбранный файл
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;

        }

        private void выбратьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }





        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // прочитываем выбранный файл
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный нами файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в выбранный файл файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength != 0)
            {
                DialogResult res = MessageBox.Show("Сохранить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    SaveFileDialog ttt = new SaveFileDialog();
                    ttt.FileName = "Безымянный";
                    ttt.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

                    if (ttt.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(ttt.FileName, richTextBox1.Text);
                    }
                }
                if (res == DialogResult.No)
                {
                    this.Close();
                }
            }
            if (richTextBox1.TextLength == 0)
            {
                this.Close();
            }
        }

        private void выбратьВсеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void изменитьШрифтцветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // изменяется шрифт
            richTextBox1.SelectionFont = fontDialog1.Font;
            // изменяется цвет
            richTextBox1.ForeColor = fontDialog1.Color;
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void создатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength != 0)
            {
                DialogResult res = MessageBox.Show("Сохранить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    SaveFileDialog ttt = new SaveFileDialog();
                    ttt.FileName = "Безымянный";
                    ttt.Filter = "Текстовый файл|*.txt";

                    if (ttt.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(ttt.FileName, richTextBox1.Text);
                    }
                }
                else
                {
                    richTextBox1.Clear();
                }
            }

        }

        private void Блокнот_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.TextLength != 0)
            {
                DialogResult res = MessageBox.Show("Сохранить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    SaveFileDialog ttt = new SaveFileDialog();
                    ttt.FileName = "Безымянный";
                    ttt.Filter = "Текстовый файл|*.txt";

                    if (ttt.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(ttt.FileName, richTextBox1.Text);
                    }
                    else
                    {
                        Close();
                    }
                }
                
            }
        }

    }

}
