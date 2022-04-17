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
        List<string> TranslateList = new List<string>();
        string tempRight = null;
        string tempLeft = null;
        int k = 0;
        int count;
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

            count = readText.Length;
            labelCountForEnd.Text = count.ToString();

            pictureBoxLeft.Image = Image.FromFile("left_off.png");
            pictureBoxLeft.Enabled = false;

            pictureBoxRight.Image = Image.FromFile("right_off.png");
            pictureBoxRight.Enabled = false;
        }
        private void roundButtonNext_Click(object sender, EventArgs e)
        {
            if (textBoxTranslateText.Text.Trim() == String.Empty || textBoxTranslateText.Text == "Enter the translation...") 
            {
                textBoxTranslateText.Clear();
                MessageBox.Show("Please write the translation", "Error");
                return;
            }

            if (k == TranslateList.Count)
            {
                pictureBoxRight.Image = Image.FromFile("right_off.png");
                pictureBoxRight.Enabled = false;
            }
            count--;
            labelCountForEnd.Text = count.ToString();

            k++;                                                                                                              
            if (k >= readText.Length)                                      
            {
                labelCountForEnd.Text = "Good job!";
                MessageBox.Show("It's all!", "Good job");
                saveToolStripMenuItem_Click(sender, e);
                Application.Restart();                                    
            }
            else 
                StringWrap(readText[k], labelSubsText);                           

            TranslateList.Add(textBoxTranslateText.Text);

            textBoxTranslateText.Clear();                                               
        }
        private void loadSaveToolStripMenuItem_Click(object sender, EventArgs e) 
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

                TranslateList.Clear();
                TranslateList = File.ReadAllLines(TranslateFilePath).ToList();    
                for (int i = 0; i < TranslateList.Count; i++)                    
                {
                    if (TranslateList[i] == "")
                        TranslateList[i] = null;
                }
                TranslateList = TranslateList.Where(x => x != null).ToList();

                k = TranslateList.Count;
                StringWrap(readText[k], labelSubsText);                                        
            }
            catch (Exception)
            {
                MessageBox.Show("File wasn't be chosen!", "Error");
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] TranslatedTextOut = new string[TranslateList.Count];

            for (int i = 0; i < TranslateList.Count; i++)
                TranslatedTextOut[i] = TranslateList[i].ToString() + "\n";

            string NewFilePath = null;

            if (Program.FilePath.Contains(Program.RealFileName))
                NewFilePath = Program.FilePath.Replace(Program.RealFileName, $"Translate_{Program.RealFileName}");

            MessageBox.Show($"File will be saved to {NewFilePath}", "Save file");

            using (StreamWriter writer = new StreamWriter(NewFilePath))
            {
                foreach (string str in TranslatedTextOut)
                    writer.WriteLine(str);
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
        private void pictureBoxRight_Click(object sender, EventArgs e)
        { 
            if (textBoxTranslateText.Text.Trim() == String.Empty || textBoxTranslateText.Text == null)
                return;

            if (k == TranslateList.Count-2)
            {
                pictureBoxRight.Image = Image.FromFile("right_off.png");
                pictureBoxRight.Enabled = false;
                roundButtonNext.Enabled = true;
                roundButtonNext.Visible = true;
            }

            if (k < TranslateList.Count - 1)
            {
                k++;
                StringWrap(readText[k], labelSubsText);
                textBoxTranslateText.Text = TranslateList[k];
                if (tempRight != TranslateList[k - 1])
                    TranslateList[k - 1] = tempRight;
            }
            else
                return;  
        }
        private void pictureBoxLeft_Click(object sender, EventArgs e)
        {
            roundButtonNext.Visible = false;
            roundButtonNext.Enabled = false;
            pictureBoxRight.Image = Image.FromFile("right.png");
            pictureBoxRight.Enabled = true;

            if (k > 0)
            {
                k--;
                StringWrap(readText[k], labelSubsText);
                textBoxTranslateText.Text = TranslateList[k];
                if (tempLeft != TranslateList[k + 1])
                    TranslateList[k + 1] = tempLeft;
            }
            else
                return;
            if (k == 0)
            {
                pictureBoxLeft.Image = Image.FromFile("left_off.png");
                pictureBoxLeft.Enabled = false;
            }
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
            if (k == TranslateList.Count - 1)
            {
                pictureBoxRight.Image = Image.FromFile("right_off.png");
                pictureBoxRight.Enabled = false;
            }
            pictureBoxRight.Image = Image.FromFile("right_moved.png");
            tempRight = textBoxTranslateText.Text;
        }
        private void pictureBoxLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (TranslateList.Count == k)
                TranslateList.Add(null);

            pictureBoxLeft.Image = Image.FromFile("left_moved.png");
            tempLeft = textBoxTranslateText.Text;
        }
        private void textBoxTranslateText_TextChanged(object sender, EventArgs e)
        {
            if (textBoxTranslateText.Text.Trim() != string.Empty && k!=0)
            {
                pictureBoxLeft.Enabled = true;
                pictureBoxLeft.Image = Image.FromFile("left.png");
            }
            else
            {
                pictureBoxLeft.Image = Image.FromFile("left_off.png");
                pictureBoxLeft.Enabled = false;
            }   
        }

        //всякие мелочи и т.д. основная логика выше
        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelSubsText_Click(sender, e);
        }
        private void labelSubsText_Click(object sender, EventArgs e)
        {
            if (labelSubsText != null)
                Clipboard.SetText(labelSubsText.Text, TextDataFormat.UnicodeText);
        }
        private void textBoxTranslateText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                roundButtonNext_Click(sender, e);
                e.Handled = true;
            }
        }
        private void pictureBoxRight_MouseLeave(object sender, EventArgs e)
        {
            if (k == TranslateList.Count - 1)
            {
                pictureBoxRight.Image = Image.FromFile("right_off.png");
                pictureBoxRight.Enabled = false;
            }
            else
                pictureBoxRight.Image = Image.FromFile("right.png"); 
        }

        private void pictureBoxLeft_MouseLeave(object sender, EventArgs e)
        {
            if (k == 0) 
            {
                pictureBoxLeft.Image = Image.FromFile("left_off.png");
                pictureBoxLeft.Enabled=false;   
            }
            else
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

        private void roundButtonExit_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
            Application.Restart();
        }
        private void roundButtonShowFile_Click(object sender, EventArgs e)
        {
            Process txt = new Process();
            txt.StartInfo.FileName = "notepad.exe";
            txt.StartInfo.Arguments = $@"{Program.FilePath}";
            txt.Start();
        }

        private void saveBindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] TranslatedTextOut = new string[TranslateList.Count];

            for (int i = 0; i < TranslateList.Count; i++)
                TranslatedTextOut[i] = TranslateList[i].ToString() + "\n";

            string NewFilePath = null;

            if (Program.FilePath.Contains(Program.RealFileName))
                NewFilePath = Program.FilePath.Replace(Program.RealFileName, $"Translate_{Program.RealFileName}");

            using (StreamWriter writer = new StreamWriter(NewFilePath))
            {
                foreach (string str in TranslatedTextOut)
                    writer.WriteLine(str);
            }
        }
    }
}

//пофиксить сейв, согласовать с переключателями, пофиксить перелючатели
