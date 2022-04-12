using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NooTranslateHelper
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.CountOfClickOnGoogleTranslate--;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string text = textBox1.Text;
        }
    }
}
