using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PracticeBug
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
        }

        int health, repnum, speed, FFL;
        Color colour;
        Size size;



        public void GetInfo(Size Size, int Health, int Repnum, int Speed, Color Colour, int foodfind, int minX, int maxX)
        {
            Controls.Clear();
            health = Health;
            repnum = Repnum;
            speed = Speed;  
            colour = Colour;
            size = Size;

            Siticone.Desktop.UI.WinForms.SiticoneShapes showObj = new Siticone.Desktop.UI.WinForms.SiticoneShapes();

            showObj.PolygonSides = 6;
            showObj.FillColor = colour;
            showObj.Size = new Size(200, 200);
            showObj.Show();
            Controls.Add(showObj);


            TextBox healthTB = new TextBox();
            healthTB.Location = new Point(showObj.Location.X + 250, showObj.Location.Y );
            healthTB.Text = "initial health: " + health.ToString();
            healthTB.Size = new Size(300,20);
            Controls.Add(healthTB);

            TextBox reptb = new TextBox();
            reptb.Location = new Point(showObj.Location.X + 250, showObj.Location.Y + 50);
            reptb.Text = "Reproduction number: " + repnum.ToString();
            reptb.Size = new Size(300, 20);
            Controls.Add(reptb);

            TextBox speedtb = new TextBox();
            speedtb.Location = new Point(showObj.Location.X + 250, showObj.Location.Y + 100);
            speedtb.Text = "speed: " + speed.ToString();
            speedtb.Size = new Size(300, 20);
            Controls.Add(speedtb);

            TextBox ffltb = new TextBox();
            ffltb.Location = new Point(showObj.Location.X + 250, showObj.Location.Y + 150);
            ffltb.Text = "Food Find Level: " + FFL.ToString();
            ffltb.Size = new Size(300, 20);
            Controls.Add(ffltb);

            //TextBox sizes = new TextBox();
            //ffltb.Location = new Point(showObj.Location.X + 250, showObj.Location.Y + 200);
            //ffltb.Text = "bounds: " + maxX.ToString() + " , " + minX.ToString();
            //ffltb.Size = new Size(300, 20);
            //Controls.Add(sizes);


            Button b = new Button();
            b.Location = new Point(b.Location.X + 75, showObj.Location.Y + 200);
            b.Size = new Size(300, 75);
            b.Text = "Save to System";
            Controls.Add(b);
            b.Click += B_Click;

        }
        
        private void B_Click(object sender, EventArgs e)
        {
            string txt = File.ReadAllText("U:/Organisms.txt");

            StreamWriter writer = new StreamWriter("U:/Organisms.txt");
            if (txt.Length > 0)
            {
                writer.WriteLine(txt);
            }
            
            writer.WriteLine("{0},{1},{2},{3},{4},{5}", size.Width, colour, FFL, health, speed, repnum);
            writer.Close();


        }
    }
}
