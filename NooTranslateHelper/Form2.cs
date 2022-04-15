using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;

namespace NooTranslateHelper
{
    public partial class Form2 : Form
    {
        string[] readText;                                                  //массив для текста из англ. субтитров
        int k = 0;                                                          //счетчик для добавления в label строки из субтитров по нажатию кнопки
        List<string> TranslateArray = new List<string>();
        public Form2()
        {
            InitializeComponent();
        }
        /*private static string[] GetTranslationFile()
        {
            try
            {
                string NewFilePath = null;
                if (Program.FilePath.Contains(Program.RealFileName))
                {
                    NewFilePath = Program.FilePath.Replace(Program.RealFileName, $"Translate_{Program.RealFileName}");
                }
                string[] TranslateText;
                TranslateText = File.ReadAllLines(NewFilePath);
                for (int i = 0; i < TranslateText.Length; i++)
                {
                    if (TranslateText[i] == "")
                    {
                        TranslateText[i] = null;
                    }
                }
                TranslateText = TranslateText.Where(x => x != null).ToArray();
                return TranslateText;
            }
            catch (Exception)
            {
                MessageBox.Show("File wasn't be created");
                return null;
            }
        }*/
        private void StringWrap(string text, Label output)
        {
            if (text.Length > 43)
            {
                int LengthOfConversation = text.Length;
                string FirstString = text.Substring(0, (LengthOfConversation / 2));
                string LastString = null;
                if (text.Contains(FirstString))
                {
                    LastString = text.Replace(FirstString, "");
                }
                output.Text = $"{FirstString}-\n{LastString}";
            }
            else
                output.Text = readText[k];
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
                StringWrap(readText[k], label1);                            //иначе присваем в текст label строку из англ. субтитров
            }

            TranslateArray.Add(textBox1.Text + "\n");

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

            StringWrap(readText[0], label1);

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

                TranslateArray.Clear();
                TranslateArray = File.ReadAllLines(TranslateFilePath).ToList();    //записываем в массив строки из открытого файла с переводом
                for (int i = 0; i < TranslateArray.Count; i++)                    //удаляем из массива пустые строки между строками, содержащими перевод
                {
                    if (TranslateArray[i] == "")
                    {
                        TranslateArray[i] = null;
                    }
                }
                TranslateArray = TranslateArray.Where(x => x != null).ToList();

                k = TranslateArray.Count;                                         //присваеваем в k индекс последнего элемента из файла с переводом
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

        private void roundButton2_Click(object sender, EventArgs e)
        {
            Process txt = new Process();
            txt.StartInfo.FileName = "notepad.exe";
            txt.StartInfo.Arguments = $@"{Program.FilePath}";
            txt.Start();
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("Enter the translation"))
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
                textBox1.Focus();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NewFilePath = null;                                      //объявляем переменную в которой будет путь к файлу с переводом
            if (Program.FilePath.Contains(Program.RealFileName))            //если путь к файлу с переводом содержит свое же имя
            {
                NewFilePath = Program.FilePath.Replace(Program.RealFileName, $"Translate_{Program.RealFileName}"); //то путь к файлу с переводом будет таким же но с добавлением Translate_
            }
            MessageBox.Show($"File will be saved to {NewFilePath}", "Save file");

            using (StreamWriter writer = new StreamWriter(NewFilePath))
            {
                foreach (string str in TranslateArray)
                {
                    writer.WriteLine(str);
                }
            }
        }

        private void pictureBoxRight_Click(object sender, EventArgs e)
        {
            if (k < TranslateArray.Count - 1)
            {
                k++;
                StringWrap(readText[k], label1);
                textBox1.Text = TranslateArray[k];
            }
            else
            {
                return;
            }
        }
        private void pictureBoxLeft_Click(object sender, EventArgs e)
        {
            if (k > 0)
            {
                k--;
                StringWrap(readText[k], label1);
                textBox1.Text = TranslateArray[k];
            }
            else
            {
                MessageBox.Show("It's a first conversation", "Error");
            }
        }
    }
}
