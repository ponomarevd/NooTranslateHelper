using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Drawing;

namespace NooTranslateHelper
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Thread thread;
        int f;
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.CountOfClickOnGoogleTranslate--;
        }
        public string TranslateText(string firstLng, string secondLng, string input)
        {
            string url = String.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", firstLng, secondLng, Uri.EscapeUriString(input));
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;
            var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);
            var translationItems = jsonData[0];
            string translation = "";
            foreach (object item in translationItems)
            {
                IEnumerable translationLineObject = item as IEnumerable;
                IEnumerator translationLineString = translationLineObject.GetEnumerator();
                translationLineString.MoveNext();
                translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
            }
            if (translation.Length > 1) { translation = translation.Substring(1); };
            return translation; 
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == string.Empty)
                {
                    textBox2.Text = string.Empty;
                    pictureBox2.Visible = false;
                    pictureBox2.Enabled = false;
                }
                else
                {
                    pictureBox2.Visible = true;
                    pictureBox2.Enabled = true;
                    if (f % 2 != 0)
                    {
                        thread = new Thread(() =>
                        {
                            string result = TranslateText("ru", "en", textBox1.Text);
                            textBox2.Text = result;
                        });
                        thread.Start();
                    }
                    else
                    {
                        thread = new Thread(() =>
                        {
                            string result = TranslateText("en", "ru", textBox1.Text);
                            textBox2.Text = result;
                        });
                        thread.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error");
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Image.FromFile("clearTranslate_moved.png");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile("clearTranslate.png");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox2.BringToFront();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            f++;
            if (f % 2 != 0)
            {
                label1.Text = "Russian";
                label2.Text = "English";
            }
            else
            {
                label1.Text = "English";
                label2.Text = "Russian";
            }
            textBox1.Clear();
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Image.FromFile("change language_moved.png");
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("change language.png");
        }
    }
}
