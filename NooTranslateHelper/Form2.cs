using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NooTranslateHelper
{
    public partial class Form2 : Form
    {
        public StreamWriter Writer;                                         //инициализируем объект Writer, для дальнейшей записи в файлы
        string[] readText;                                                  //массив для текста из англ. субтитров
        int k = 0;                                                          //счетчик для добавления в label строки из субтитров по нажатию кнопки
        public Form2()
        {
            InitializeComponent();
        }
        async void WriteToFile(string path)                                 //метод для записи переведенной строки в файл с переводом
        {
            Writer = new StreamWriter(path, true);
            await Writer.WriteLineAsync($"{textBox1.Text}\n");
            Writer.Close();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)   //при клике на textbox очищаем его и делаем цвет черным
        {                                                                   //т.к. изначально текст серый и есть поясняющая надпись
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;
        }
        private void roundButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == String.Empty || textBox1.Text == "Enter the translation...") //проверка на пустоту строки и дефолтной надписи
            {
                textBox1.Clear();
                MessageBox.Show("Please write the translation", "Error");
                return;
            }

            k++;                                                            //инкрементим счетчик                                                               
            if (k >= readText.Length)                                       //если счетчик равен количеству строк в массиве
            {
                MessageBox.Show("It's all!", "Good job");                   //то выводим MessageBox
                Application.Restart();                                      //и рестартим
            }
            else 
            {
                label1.Text = readText[k];                                  //иначе присваем в текст label строку из англ. субтитров
            }

            string NewFilePath = null;                                      //объявляем переменную в которой будет путь к файлу с переводом
            if (Program.FilePath.Contains(Program.RealFileName))            //если путь к файлу с переводом содержит свое же имя
            {
                NewFilePath = Program.FilePath.Replace(Program.RealFileName, $"Translate_{Program.RealFileName}"); //то путь к файлу с переводом будет таким же но с добавлением Translate_
            }

            WriteToFile(NewFilePath);                                       //используем метод записи в файл с переводом

            textBox1.Clear();                                               //очищаем textbox
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) //обработка нажатия Enter по textbox
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                roundButton1_Click(sender, e);
                e.Handled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            readText = File.ReadAllLines(Program.FilePath);                //записываем в массив каждую строку из файла с англ. субтитрами
            label1.Text = readText[0];                                     //и по дефолту в label выводим самую первую строчку из файла с англ. субтитрами
            for (int i = 1; i < readText.Length; i++)                   
            {
                if (readText[i] == "")                                     //пробегаемся циклом и присваеваем null туда где есть пустая строка между строками
                {
                    readText[i] = null;                                     
                }
            }
            readText = readText.Where(x => x != null).ToArray();           //перезаписываем массив удаляя из него все пустые строки 
        }                                                                  //P.S. для того чтобы потом когда мы выводим строку в label, не было пустого значения

        private void label1_Click(object sender, EventArgs e)              //копирование строки по нажатию на label для удобного переноса в переводчик в дальнейшем
        {
            if (label1 != null)
            {
                Clipboard.SetText(label1.Text, TextDataFormat.UnicodeText);
            }
        }
        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e) //копирование строки по нажатию на ContextStripMenu "Copy" у label'а 
        {
            label1_Click(sender, e);    
        }

        private void savePointToolStripMenuItem_Click(object sender, EventArgs e) //что-то вроде сейва данных, загружаем уже насколько-то 
        {                                                                         //переведенный текст и процесс перевода начинается с той строчки 
            try                                                                   //на которой в прошлый раз был сделан выход из программы
            {                   
                OpenFileDialog ofd = new OpenFileDialog();                           
                ofd.ShowDialog();                                                 //открываем окошко с выбором файла                           
                string TranslateFilePath = ofd.FileName;                          //получаем путь к файлу
                string AllText = File.ReadAllText(TranslateFilePath);             //получаем весь текст для проверки на язык

                if (!Regex.IsMatch(AllText, @"\p{IsCyrillic}")                    //проверяем на язык (должен быть русский)
                    || (!TranslateFilePath.Contains(Program.RealFileName)         //проверяем на не содержание файла с переводом, имени оригинального файла, чтобы не открыть левый файл
                    || AllText == null))                                          //проверяем на null содержимое файла
                {
                    MessageBox.Show("Please select correct file", "Error");       //если хоть одно из условий выполняется выводим ошибку
                    TranslateFilePath = null;                                     //присваеваем в путь к файлу null чтобы программа дальше не выполнялась
                    return;
                }

                string[] translateText = File.ReadAllLines(TranslateFilePath);    //записываем в массив строки из открытого файла с переводом
                for (int i = 0; i < translateText.Length; i++)                    //удаляем из массива пустые строки между строками, содержащими перевод
                {
                    if (translateText[i] == "")
                    {
                        translateText[i] = null;
                    }
                }
                translateText = translateText.Where(x => x != null).ToArray();

                k = translateText.Length;                                         //присваеваем в k индекс последнего элемента из файла с переводом
                label1.Text = readText[k];                                        //и в label строку из файла с англ. субтитрами под этим же индексом
            }
            catch (Exception)
            {
                MessageBox.Show("File wasn't be chosen!", "Error");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Program.CountOfClickOnGoogleTranslate++;
            Form3 form3 = new Form3();
            if (Program.CountOfClickOnGoogleTranslate > 1)
            {
                MessageBox.Show("Google Translate is already opened!", "Error");
                Program.CountOfClickOnGoogleTranslate--;
                return;
            }
            else    
                form3.Show();
        }
    }
}
