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
        string[] readText;                                                                                              
        List<string> TranslateArray = new List<string>();
        //bool IsTextWasChanged = false;
        string temp = null;
        int k = 0;
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
        private void roundButtonNext_Click(object sender, EventArgs e)
        {
            if (textBoxTranslateText.Text.Trim() == String.Empty || textBoxTranslateText.Text == "Enter the translation...") 
            {
                textBoxTranslateText.Clear();
                MessageBox.Show("Please write the translation", "Error");
                return;
            }

            k++;                                                                                                              
            if (k >= readText.Length)                                      
            {
                MessageBox.Show("It's all!", "Good job");                  
                Application.Restart();                                    
            }
            else 
                StringWrap(readText[k], labelSubsText);                           

            TranslateArray.Add(textBoxTranslateText.Text + "\n");

            textBoxTranslateText.Clear();                                               
        }

        private void textBoxTranslateText_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                roundButtonNext_Click(sender, e);
                e.Handled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            readText = File.ReadAllLines(Program.FilePath);               

            StringWrap(readText[0], labelSubsText);

            for (int i = 1; i < readText.Length; i++)                   
            {
                if (readText[i] == "")                                     
                    readText[i] = null;                                     
            }
            readText = readText.Where(x => x != null).ToArray();           
        }                                                                  

        private void labelSubsText_Click(object sender, EventArgs e)              
        {
            if (labelSubsText != null)
                Clipboard.SetText(labelSubsText.Text, TextDataFormat.UnicodeText);
        }
        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            labelSubsText_Click(sender, e);    
        }

        private void savePointToolStripMenuItem_Click(object sender, EventArgs e) 
        {                                                                         
            try                                                                   
            {
                OpenFileDialog ofd = new OpenFileDialog();                           
                ofd.ShowDialog();                                                    
                string TranslateFilePath = ofd.FileName;                         
                string AllText = File.ReadAllText(TranslateFilePath);           

                if (!Regex.IsMatch(AllText, @"\p{IsCyrillic}")                    
                    || (!TranslateFilePath.Contains(Program.RealFileName)         
                    || AllText == null))                                          
                {
                    MessageBox.Show("Please select correct file", "Error");       
                    TranslateFilePath = null;                                     
                    return;
                }

                TranslateArray.Clear();
                TranslateArray = File.ReadAllLines(TranslateFilePath).ToList();    
                for (int i = 0; i < TranslateArray.Count; i++)                    
                {
                    if (TranslateArray[i] == "")
                        TranslateArray[i] = null;
                }
                TranslateArray = TranslateArray.Where(x => x != null).ToList();

                k = TranslateArray.Count;                                         
                labelSubsText.Text = readText[k];                                        
            }
            catch (Exception)
            {
                MessageBox.Show("File wasn't be chosen!", "Error");
            }
        }

        private void pictureBoxGoogleTranslate_Click(object sender, EventArgs e)
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

        private void roundButtonShowFile_Click(object sender, EventArgs e)
        {
            Process txt = new Process();
            txt.StartInfo.FileName = "notepad.exe";
            txt.StartInfo.Arguments = $@"{Program.FilePath}";
            txt.Start();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NewFilePath = null;      
            
            if (Program.FilePath.Contains(Program.RealFileName))          
                NewFilePath = Program.FilePath.Replace(Program.RealFileName, $"Translate_{Program.RealFileName}"); 

            MessageBox.Show($"File will be saved to {NewFilePath}", "Save file");

            using (StreamWriter writer = new StreamWriter(NewFilePath))
            {
                foreach (string str in TranslateArray)
                    writer.WriteLine(str);
            }
        }

        private void pictureBoxRight_Click(object sender, EventArgs e)
        {
            if (k < TranslateArray.Count-1)
            {
                k++;
                StringWrap(readText[k], labelSubsText);
                textBoxTranslateText.Text = TranslateArray[k];
                if (temp != TranslateArray[k-1])
                {
                    TranslateArray[k-1] = temp;
                }
            }
            else
                return;
        }
        private void pictureBoxLeft_Click(object sender, EventArgs e)
        {
            if (k > 0)
            {
                k--;
                StringWrap(readText[k], labelSubsText);
                textBoxTranslateText.Text = TranslateArray[k];
            }
            else
                MessageBox.Show("It's a first conversation", "Error");
        }

        private void textBoxTranslateText_TextChanged(object sender, EventArgs e)
        {
            //IsTextWasChanged = true;
        }
        private void textBoxTranslateText_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBoxTranslateText.Text.Contains("Enter the translation"))
            {
                textBoxTranslateText.Clear();
                textBoxTranslateText.ForeColor = Color.Black;
                textBoxTranslateText.Focus();
            }
        }

        private void pictureBoxRight_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxRight.Image = Image.FromFile("right_moved.png");
            temp = textBoxTranslateText.Text;
            if (temp.Contains("\n"))
                temp = temp.Replace("\n", "") + "\n";
        }
        private void pictureBoxLeft_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxLeft.Image = Image.FromFile("left_moved.png");
            temp = textBoxTranslateText.Text;
            if (temp.Contains("\n"))
                temp = temp.Replace("\n", "") + "\n";
        }

        private void pictureBoxRight_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxRight.Image = Image.FromFile("right.png"); 
        }

        private void pictureBoxLeft_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxLeft.Image = Image.FromFile("left.png");
        }

        private void pictureBoxGoogleTranslate_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxGoogleTranslate.Image = Image.FromFile("Translate_logo_moved.png");
        }

        private void pictureBoxGoogleTranslate_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxGoogleTranslate.Image = Image.FromFile("Translate_logo.max-500x500.png");
        }

        private void roundButton1_Click(object sender, EventArgs e) //пофиксить
        {
            if (TranslateArray != null && TranslateArray[0].Trim() != String.Empty)
            {
                saveToolStripMenuItem_Click(sender, e);
                Application.Restart();
            }
            else
                Application.Restart();
        }
    }
}
