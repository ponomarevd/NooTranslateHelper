﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace NooTranslateHelper
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Thread thread;
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.CountOfClickOnGoogleTranslate--;
            thread.Abort();
        }
        public string TranslateText(string input)
        {
            string url = String.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", "en", "ru", Uri.EscapeUriString(input));
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
                    textBox2.Text = string.Empty;
                else
                {
                    thread = new Thread(() => 
                    {
                        string result = TranslateText(textBox1.Text);
                        textBox2.Text = result;
                    });
                    thread.Start(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}", "Error");
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.LShiftKey)
            {
                textBox1.Clear();
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                textBox1.Clear();
                e.Handled = true;
            }
        }
    }
}
