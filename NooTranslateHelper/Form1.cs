using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using System.Net;

namespace NooTranslateHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd;                                                 //инициализируем объект класса OpenFileDialog, для дальнейшей загрузки файла
        /*private void GetSubs(string url)
        {
            string urlDownload = $"https://savesubs.com/process?url={url}";
            HttpClient client = new HttpClient();
            string result = client.GetStringAsync(urlDownload).Result;
        }*/
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                ofd = new OpenFileDialog(); 
                ofd.ShowDialog();                                           //открываем окошко с выбором файла по клику на PictureBox

                Program.RealFileName = ofd.SafeFileName;                    //получаем имя файла

                Program.FilePath = ofd.FileName;                            //получаем путь к файлу

                string AllText = File.ReadAllText(Program.FilePath);        //записываем весь текст файла в переменную для проверки на язык

                if (!(!Regex.IsMatch(AllText, @"\p{IsCyrillic}")))          //проверка на язык
                {
                    MessageBox.Show("Please select file with english language!", "Error"); //если язык русский, то просим загрузить английский
                    Program.FilePath = null;                                               //присваем null чтобы при повторном нажатии нас не пустило на 2 форму
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("File wasn't be chosen! Try again.", "Error");
                return;
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            //GetSubs("www.youtube.com/watch?v=cbGB__V8MNk&ab_channel=Computerphile");
            try
            {
                if (Program.FilePath != null && Program.FilePath != string.Empty)  //если с путем к файлу все норм то идем дальше
                {
                    Form2 form2 = new Form2();
                    Program.Context.MainForm = form2;
                    form2.Show();                                               //открываем вторую форму
                    Close();
                }
                else
                    return;
            }
            catch (Exception)
            {
                MessageBox.Show("Please select file!", "Error");
                return;
            }
        }
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e) //обработка загрузки файла через MenuStrip
        {
            pictureBox1_Click(sender, e);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            pictureBox1.Image = Image.FromFile("document-download-outline_moved.png");
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("document-download-outline.png");
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox1.Text.Contains("Paste URL here"))
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Contains("http")) || !(textBox1.Text.Contains("youtube")))
            {
                this.ActiveControl = pictureBox1;
                textBox1.Text = "Paste URL here...";
                textBox1.ForeColor = Color.Gray;
            }
        }
    }
}
