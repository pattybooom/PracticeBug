using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeBug
{
    public partial class Form5 : Form
    {
        List<string> Parameters;
        public Form5(List<string> parameters = null)
        {
            InitializeComponent();
            Parameters = parameters;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Close();


        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(Parameters,allopatric);
            f1.Show();
            this.Close();

        }

        bool allopatric = false;
        private void button3_Click(object sender, EventArgs e)
        {
            allopatric = !allopatric;
        }
    }
}
