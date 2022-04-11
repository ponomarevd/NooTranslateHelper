using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooTranslateHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd;


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                ofd = new OpenFileDialog();
                ofd.ShowDialog();
                Program.RealFileName = ofd.SafeFileName;
                Program.FileName = ofd.FileName.ToString();
                Program.FilePath = Path.GetFullPath(Program.FileName);

                string AllText = File.ReadAllText(Program.FilePath);

                if (!(!Regex.IsMatch(AllText, @"\p{IsCyrillic}")))
                {
                    MessageBox.Show("Please select file with english language!", "Error");
                    Program.FilePath = null;
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("File wasn't be chosen! Try again.", "Error");
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.FilePath.Contains(':') || Program.FilePath.Contains('\\'))
                {
                    Form2 form2 = new Form2();
                    Program.Context.MainForm = form2;
                    form2.Show();
                    Close();
                }  
            }
            catch (Exception)
            {
                MessageBox.Show("Please select file!", "Error");
            }
        }
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;
        }
    }
}
