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
    public partial class Form6 : Form
    {
        int numToAdd;
        int added = 0;
        List<string> organismsToAdd = new List<string>();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(n.Next(150));
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            numToAdd = Convert.ToInt32(textBox6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string properties;
            StringBuilder build = new StringBuilder();
            build.AppendFormat("{0},{1},{2},{3},{4},{5}",textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,col);
            properties = Convert.ToString(build);

            organismsToAdd.Add(properties);
            added += 1;

           // MessageBox.Show(properties);
            if (added == numToAdd)
            {
                Form5 f5 = new Form5(organismsToAdd);
                f5.Show();

                this.Close();
            }


        }

        private void siticoneShapes1_Click(object sender, EventArgs e)
        {
            
        }

         Random n = new Random();
        string col;
        private void button8_Click(object sender, EventArgs e)
        {
            int r = n.Next(255);
            int g = n.Next(255);
            int b = n.Next(255);

            col = Convert.ToString(r) + "," + Convert.ToString(g) + "," + Convert.ToString(b);
            //MessageBox.Show(r.ToString());
            //MessageBox.Show(Convert.ToString(r));
           // MessageBox.Show(Convert.ToString(Convert.ToInt32(Convert.ToString(r))));

            siticoneShapes1.FillColor = Color.FromArgb(r,g,b);
            //siticoneShapes1.BackColor = Color.FromArgb(r, g, b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(n.Next(5,21));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(n.Next(50));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(n.Next(150));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = Convert.ToString(n.Next(5,21));
        }
    }
}
