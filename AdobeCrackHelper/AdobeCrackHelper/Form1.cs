using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdobeCrackHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBrowse64_Click(object sender, EventArgs e)
        {
            textBoxFile64.GetFilePath();
        }

        private void buttonBrowse32_Click(object sender, EventArgs e)
        {
            textBoxFile32.GetFilePath();
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBoxFile32.Text) && File.Exists(textBoxFile64.Text))
            {
                CrackHelper.Replace(textBoxFile32.Text, textBoxFile64.Text);
            }
        }
    }
}
