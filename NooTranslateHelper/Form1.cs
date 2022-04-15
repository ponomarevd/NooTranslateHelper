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

        private void GetSubs(string url)
        {
            string urlDownload = $"https://savesubs.com/process?url={url}";
            HttpClient client = new HttpClient();
            string result = client.GetStringAsync(urlDownload).Result;
        }

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
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            GetSubs("www.youtube.com/watch?v=cbGB__V8MNk&ab_channel=Computerphile"); // передаем в метод label.Text
            try
            {
                if (Program.FilePath != null)                                //если с путем к файлу все норм то идем дальше
                {
                    Form2 form2 = new Form2();                                         
                    Program.Context.MainForm = form2;
                    form2.Show();                                            //открываем вторую форму
                    Close();
                }  
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select file!", "Error");
            }
        }
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e) //обработка загрузки файла через MenuStrip
        {
            pictureBox1_Click(sender, e);
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)     //при клике на textbox очищаем его и делаем цвет черным
        {                                                                     //т.к. изначально текст серый и есть поясняющая надпись
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;
        }
    }
}
