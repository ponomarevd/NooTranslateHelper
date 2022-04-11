using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace NooTranslateHelper
{
    public partial class Form2 : Form
    {
        public StreamWriter Writer;
        string[] readText;
        int k = 0;
        public Form2()
        {
            InitializeComponent();
        }
        async void WriteToFile(string path)
        {
            Writer = new StreamWriter(path, true);
            await Writer.WriteLineAsync($"{textBox1.Text}\n");
            Writer.Close();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;
        }
        private void roundButton1_Click(object sender, EventArgs e)
        {
            k++;
            if (k >= readText.Length)
            {
                MessageBox.Show("It's all!", "Good job");
                Application.Restart();
            }
            else 
            {
                label1.Text = readText[k];
            }
                

            if (textBox1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please write the translation", "Error");
                return;
            }

            string NewFilePath = null;
            if (Program.FilePath.Contains(Program.RealFileName))
            {
                NewFilePath = Program.FilePath.Replace(Program.RealFileName, $"Translate_{Program.RealFileName}");
            }

            WriteToFile(NewFilePath);

            textBox1.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                roundButton1_Click(sender, e);
                e.Handled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            readText = File.ReadAllLines(Program.FilePath);
            label1.Text = readText[0];
            for (int i = 1; i < readText.Length; i++)
            {
                if (readText[i] == "")
                {
                    readText[i] = null;
                }
            }
            readText = readText.Where(x => x != null).ToArray();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (label1 != null)
            {
                Clipboard.SetText(label1.Text, TextDataFormat.UnicodeText);
            }
        }
        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1_Click(sender, e);    
        }

        private void savePointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                string TranslateFilePath = ofd.FileName;
                string AllText = File.ReadAllText(TranslateFilePath);

                if (!Regex.IsMatch(AllText, @"\p{IsCyrillic}"))
                {
                    MessageBox.Show("Please select file with russian language!", "Error");
                    TranslateFilePath = null;
                    return;
                }

                string[] translateText = File.ReadAllLines(TranslateFilePath);
                for (int i = 0; i < translateText.Length; i++)
                {
                    if (translateText[i] == "")
                    {
                        translateText[i] = null;
                    }
                }
                translateText = translateText.Where(x => x != null).ToArray();

                k = translateText.Length;
                label1.Text = readText[k];
            }
            catch (Exception)
            {
                MessageBox.Show("File wasn't be chosen!", "Error");
            }
        }
    }
}
