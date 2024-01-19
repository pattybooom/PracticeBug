using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Siticone.Desktop.UI.Native.WinApi;


namespace PracticeBug
{

    public partial class Form1 : Form
    {

        Random n = new Random();
        Form2 frm2 = new Form2();
        List<string> organismsToAdd;
        bool isAllopatric;
        public Form1(List<string> organis = null, bool allopatric = false)
        {
            InitializeComponent();
            organismsToAdd = organis;
            isAllopatric = allopatric;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitSim(); //initialises the simuation
            KeyPress += Form1_KeyPress;
            MouseClick += Form1_MouseClick;

            frm2.Show();
            frm3.f3.Show();

            frm3.f3.DesktopLocation = new Point(20, 600);
            frm2.DesktopLocation = new Point(20, 20);

            this.FormClosing += Form1_FormClosing;



        }



        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Siticone.Desktop.UI.WinForms.SiticoneShapes block = new Siticone.Desktop.UI.WinForms.SiticoneShapes();
            block.PolygonSides = 4;
            block.FillColor = Color.Gray;
            block.BackColor = Color.Gray;
            block.BorderColor = Color.Gray;
            block.Size = new Size(100, 100);
            block.Location = e.Location;
            block.Tag = "block";
            Controls.Add(block);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForms();
        }

        private void CloseForms()
        {
            frm2.Close();
            frm3.f3.Close();
        }



        List<Organism> myOrganisms = new List<Organism>();

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {



        }

        private void InitSim()
        {
            Timer gameTimer = new Timer();
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = 200;
            gameTimer.Enabled = true;


            for (int i = 0; i < 50; i++) //will add 50 new food on initialisation of the simulator
            {
                Food food = new Food();
                foodnum.num += 1;
                Controls.Add(food.InitFood(new Point(n.Next(1000), n.Next(1000)), Color.LightGreen));
            }

            
            if (!isAllopatric)
            {
                if (organismsToAdd != null)
                {
                    foreach (string x in organismsToAdd)
                    {
                        // MessageBox.Show(x);
                        string[] properties = new string[8];
                        properties = x.Split(',');
                        int size = Convert.ToInt32(properties[0]);
                        int foodFindLev = Convert.ToInt32(properties[1]);
                        int HP = Convert.ToInt32(properties[2]);
                        int speed = Convert.ToInt32(properties[3]);
                        int repNum = Convert.ToInt32(properties[4]);
                        Color col = Color.FromArgb(Convert.ToInt32(properties[5]), Convert.ToInt32(properties[6]), Convert.ToInt32(properties[7]));


                        Hexabug o = new Hexabug(this, new Point(n.Next(1000), n.Next(1000)), new Size(size, size), col, foodFindLev, HP, speed, repNum, false, 1);
                        Controls.Add(o.InitOrganismObj());
                        o.SetBounds(0, 1000, 0, 1000);
                        organismnum.num += 1;

                    }

                } else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int s = n.Next(50);
                        Hexabug o = new Hexabug(this, new Point(n.Next(1000), n.Next(1000)), new Size(s, s), Color.FromArgb(n.Next(255), n.Next(255), n.Next(255)), n.Next(3, 15), n.Next(60, 180), n.Next(10, 50), n.Next(5, 15), false, 1);
                        o.SetBounds(0, 1000, 0, 1000);
                        n.Next(0, 1000);
                        Controls.Add(o.InitOrganismObj());
                        organismnum.num += 1;
                    }
                }
            }
            else

            {
                if (organismsToAdd != null)
                {
                    foreach (string x in organismsToAdd)
                    {
                        // MessageBox.Show(x);
                        string[] properties = new string[8];
                        properties = x.Split(',');
                        int size = Convert.ToInt32(properties[0]);
                        int foodFindLev = Convert.ToInt32(properties[1]);
                        int HP = Convert.ToInt32(properties[2]);
                        int speed = Convert.ToInt32(properties[3]);
                        int repNum = Convert.ToInt32(properties[4]);
                        Color col = Color.FromArgb(Convert.ToInt32(properties[5]), Convert.ToInt32(properties[6]), Convert.ToInt32(properties[7]));


                        Hexabug o = new Hexabug(this, new Point(n.Next(500), n.Next(1000)), new Size(size, size), col, foodFindLev, HP, speed, repNum, false, 1);
                        Controls.Add(o.InitOrganismObj());
                        o.SetBounds(0, 500, 0, 1000);
                        organismnum.num += 1;

                        Hexabug o1 = new Hexabug(this, new Point(n.Next(500, 100), n.Next(1000)), new Size(size, size), col, foodFindLev, HP, speed, repNum, false, 1);
                        Controls.Add(o.InitOrganismObj());
                        o.SetBounds(500, 1000, 0, 1000);
                        organismnum.num += 1;

                    }
                }
                else
                {



                    Siticone.Desktop.UI.WinForms.SiticoneShapes midPoint = new Siticone.Desktop.UI.WinForms.SiticoneShapes();
                    midPoint.Size = new Size(10, 1000);
                    midPoint.Location = new Point(498, 0);
                    midPoint.PolygonSides = 4;
                    midPoint.Rotate = 180;
                    Controls.Add((midPoint));

                    for (int i = 0; i < 10; i++)
                    {
                        if (i % 2 == 0)
                        {
                            int s = n.Next(50);
                            Color c = Color.FromArgb(n.Next(255), n.Next(255), n.Next(255));
                            int foodFind = n.Next(3, 15);
                            int HP = n.Next(60, 180);
                            int speed = n.Next(10, 50);
                            int repnum = n.Next(2, 5);

                            Hexabug o = new Hexabug(this, new Point(n.Next(500), n.Next(1000)), new Size(s, s), c, foodFind, HP, speed, repnum, false, 1);
                            o.SetBounds(0, 500, 0, 1000);
                            Controls.Add(o.InitOrganismObj());


                            organismnum.num += 1;


                            //c = Color.FromArgb(n.Next(255), n.Next(255), n.Next(255));
                            Hexabug o1 = new Hexabug(this, new Point(n.Next(500, 1000), n.Next(1000)), new Size(s, s), c, foodFind, HP, speed, repnum, false, 1);

                            o1.SetBounds(500, 1000, 0, 1000);
                            Controls.Add(o1.InitOrganismObj());
                            organismnum.num += 1;
                        }
                    }
                }

            }
        }
   
            private void GameTimer_Tick(object sender, EventArgs e)
            {

                Food food = new Food();
                foodnum.num += 1;
                Controls.Add(food.InitFood(new Point(n.Next(1000), n.Next(1000)), Color.LightGreen)); //new food is added (5 every second)

                if (n.Next(200) == 0) //1 in 100 chance of virus spawning every fifth of a second
                {
                    Virus v = new Virus();
                    Controls.Add(v.InitOrganismObj());
                }

            }

        }

        static class foodnum
        {
            public static int num = 0;
        }

        static class organismnum
        {
            public static int num = 0;
        }

        static class frm3
        {
            public static Form3 f3 = new Form3();
        }

        public class Food
        {
            public Siticone.Desktop.UI.WinForms.SiticoneShapes InitFood(Point location, Color colour)
            {
                Siticone.Desktop.UI.WinForms.SiticoneShapes foodObj = new Siticone.Desktop.UI.WinForms.SiticoneShapes();
                foodObj.Location = location;
                foodObj.FillColor = colour;
                foodObj.PolygonSides = 1000;
                foodObj.Size = new Size(7, 7);
                foodObj.BorderColor = Color.Transparent;
                foodObj.Tag = "food";
                return foodObj;
            }
        }


        public class Organism //parent class of all organisms  
        {
            protected Random n = new Random();
            protected Siticone.Desktop.UI.WinForms.SiticoneShapes organismObj = new Siticone.Desktop.UI.WinForms.SiticoneShapes();
            protected Point p = new Point(0, 0);

            public virtual Siticone.Desktop.UI.WinForms.SiticoneShapes InitOrganismObj()
            {
                return organismObj;
            }

            protected virtual Point GetNewPoint()
            {
                return new Point(n.Next(1000), n.Next(1000));
            }

            protected virtual void Move(Point point)
            {
                if (organismObj.Location.X < point.X)
                {
                    organismObj.Location = new Point(organismObj.Location.X + 2, organismObj.Location.Y);
                }
                else
                {
                    organismObj.Location = new Point(organismObj.Location.X - 2, organismObj.Location.Y);
                }

                if (organismObj.Location.Y < point.Y)
                {
                    organismObj.Location = new Point(organismObj.Location.X, organismObj.Location.Y + 2);
                }
                else
                {
                    organismObj.Location = new Point(organismObj.Location.X, organismObj.Location.Y - 2);
                }

                double dist = Math.Sqrt((organismObj.Location.X - point.X) ^ 2 + (point.Y - organismObj.Location.Y) ^ 2);

                if (dist < 5)
                {
                    p = GetNewPoint();
                }

            }

        }




        public class Virus : Organism
        {
            public Virus()
            {
                Timer tim = new Timer();
                tim.Tick += Tim_Tick;
                tim.Interval = 1;
                tim.Enabled = true;
            }

            public override Siticone.Desktop.UI.WinForms.SiticoneShapes InitOrganismObj()
            {
                organismObj.PolygonSides = 3;
                organismObj.BackColor = Color.Red;
                organismObj.BorderColor = Color.Blue;
                organismObj.Size = new Size(10, 10);
                organismObj.Location = new Point(10, 10);
                organismObj.Tag = "Virus";
                return organismObj;
            }

            private void Tim_Tick(object sender, EventArgs e)
            {
                Move(p);
            }
        }


        public class Hexabug : Organism
        {
            private Form forms;

            private int foodLev;
            private int health, initHealth;
            private int foodcollected = 0;
            private int speed = 1;
            private int repnum = 5;
            private int virusRes = 1;
            private int minX, minY, maxX, maxY;
            Timer HealthDeacrease = new Timer();
            Timer tim = new Timer();
            Timer viralTim = new Timer();

            private bool alive = true;
            private bool hasVirus = false;



            // Siticone.Desktop.UI.WinForms.SiticoneShapes bugObj = new Siticone.Desktop.UI.WinForms.SiticoneShapes();



            public Hexabug(Form form, Point location, Size size, Color colour, int foodFindLevel, int HP, int organismSpeed, int repnumb, bool hasVir, int virusRes)
            {
                forms = form;
                health = HP;
                initHealth = HP;
                foodLev = foodFindLevel;
                speed = organismSpeed;
                repnum = repnumb;
                hasVirus = hasVir;
                tim.Interval = speed;



                organismObj.FillColor = colour;
                organismObj.PolygonSides = 6;
                organismObj.Location = location;
                organismObj.Size = size;
                organismObj.BorderColor = Color.Transparent;
                organismObj.BackColor = Color.Transparent;
                organismObj.UseTransparentBackground = true;

                tim.Interval = speed;
                tim.Tick += Tim_Tick;
                tim.Enabled = true;


                HealthDeacrease.Tick += HealthDeacrease_Tick;
                HealthDeacrease.Interval = 1000;
                HealthDeacrease.Enabled = true;
            }

            public void SetBounds(int xMin, int xMax, int yMin, int yMax)
            {
                minX = xMin;
                minY = yMin;
                maxX = xMax;
                maxY = yMax;
            }
            protected override Point GetNewPoint()
            {
                return new Point(n.Next(minX, maxX), n.Next(1000));
            }

            public override Siticone.Desktop.UI.WinForms.SiticoneShapes InitOrganismObj()
            {
                p = GetNewPoint();
                organismObj.MouseEnter += BugObj_MouseEnter;

                if (hasVirus == true)
                {
                    SetInfect(true);
                }
                return organismObj;
            }

            public bool getAliveState()
            {
                return alive;
            }

            private void HealthDeacrease_Tick(object sender, EventArgs e)
            {

                if (HealthDeacrease.Interval > 10) //will speed up the rate at which health of the organism decreases over time 
                {
                    HealthDeacrease.Interval -= 10;
                }

                if (health == 0)
                {
                    organismObj.Dispose();
                    this.organismObj = null;
                    organismnum.num -= 1;
                    alive = false;
                }
                health -= 1;
            }


            private void BugObj_MouseEnter(object sender, EventArgs e)
            {
                frm3.f3.GetInfo(organismObj.Size, initHealth, repnum, speed, organismObj.FillColor, foodLev, maxX, minX); //when mouse hovers ofer the organism it will show details of it in form 3
            }

            private void Tim_Tick(object sender, EventArgs e)
            {
                if (organismObj != null)
                {


                    // for (int i = 0; i < n.Next(6); i++)
                    // {
                    Move(p);
                    Move(p);
                    CheckIfIntesect();
                    //}
                    Reproduce(repnum);
                }
            }

            private void Reproduce(int repNum)
            {

                if (foodcollected == repNum)
                {
                    foodcollected = 0;

                    Size si = new Size();
                    int rand;

                    if (n.Next(2) == 1)
                    {
                        rand = n.Next(5);
                        si = new Size(organismObj.Size.Width + rand, organismObj.Size.Height + rand);
                    }
                    else
                    {
                        rand = n.Next(5);
                        if (organismObj.Size.Height > rand)
                        {
                            si = new Size(organismObj.Size.Width - rand, organismObj.Size.Height - rand);
                        }


                    }

                    int f = foodLev;
                    if (n.Next(2) == 1)
                    {
                        rand = n.Next(3);
                        f = foodLev + rand;
                    }
                    else
                    {
                        rand = n.Next(3);
                        if (foodLev > rand)
                            f = foodLev - rand;
                    }

                    int h = initHealth;
                    if (n.Next(2) == 1)
                    {
                        rand = n.Next(10);
                        h = initHealth + rand;
                    }
                    else
                    {
                        if (initHealth > 10)
                        {
                            rand = n.Next(10);
                            h = initHealth - rand;
                        }

                    }

                    int sp = speed;
                    if (n.Next(2) == 1)
                    {
                        rand = n.Next(10);
                        sp = speed + rand;
                    }
                    else
                    {
                        rand = n.Next(10);
                        if (speed > rand)
                        {
                            sp = speed - rand;
                        }



                    }




                    int r = repnum;
                    if (n.Next(2) == 1)
                    {
                        rand = n.Next(2);
                        r = repnum + rand;
                    }
                    else
                    {
                        rand = n.Next(2);
                        if (rand > repnum)
                        {
                            r = repnum - rand;
                        }

                    }

                    Color c = organismObj.FillColor;
                    if (n.Next(100) == 0)
                    {
                        c = Color.FromArgb(n.Next(255), n.Next(255), n.Next(255));
                    }


                    int v = virusRes;
                    if (n.Next(2) == 1)
                    {
                        rand = n.Next(2);
                        v = virusRes + rand;
                    }
                    else
                    {
                        rand = n.Next(2);
                        if (rand > virusRes)
                        {
                            r = virusRes - rand;
                        }
                    }

                    Hexabug o = new Hexabug(forms, organismObj.Location, si, c, f, h, sp, r, hasVirus, v);
                    o.SetBounds(minX, maxX, minY, maxY);
                    forms.Controls.Add(o.InitOrganismObj());
                    organismnum.num += 1;
                }
            }



            public void SetInfect(bool set)
            {
                if (set)
                {
                    viralTim.Tick += ViralTim_Tick;
                    viralTim.Interval = 1000;
                    viralTim.Enabled = true;


                    hasVirus = true;
                    organismObj.BorderColor = Color.Red;
                    speed *= 2;
                    tim.Interval = speed;
                } else
                {
                    viralTim.Enabled = false;

                    hasVirus = false;

                    if (alive)
                    {
                        organismObj.BorderColor = Color.Transparent;
                        speed /= 2;
                        tim.Interval = speed;

                    }
                }
            }

            int count = 0;
            private void ViralTim_Tick(object sender, EventArgs e)
            {


                count += 1;
                if (count == virusRes * 10)
                {
                    SetInfect(false);
                    count = 0;
                }

            }

            private void CheckIfIntesect()
            {

                foreach (Siticone.Desktop.UI.WinForms.SiticoneShapes x in forms.Controls)
                {
                    if (x.Bounds.IntersectsWith(organismObj.Bounds))
                    {
                        if ((string)x.Tag == "food")
                        {
                            x.Dispose();
                            foodnum.num -= 1;
                            foodcollected += 1;
                            health += 2;
                        }
                        else if ((string)x.Tag == "Virus")
                        {
                            x.Dispose();
                            SetInfect(true);
                            hasVirus = true;
                        }


                    }
                }
            }

            private Siticone.Desktop.UI.WinForms.SiticoneShapes FindClosestFood()
            {
                int foodNum = 0;
                double minDist = 100000;
                double dist = 0;
                Siticone.Desktop.UI.WinForms.SiticoneShapes closestFood = null;

                foreach (Siticone.Desktop.UI.WinForms.SiticoneShapes food in forms.Controls)
                {
                    if ((string)food.Tag == "food")
                    {
                        foodNum += 1;
                        dist = Math.Sqrt(Math.Pow((food.Location.X - organismObj.Location.X), 2) + Math.Pow((-food.Location.Y + organismObj.Location.Y), 2));
                        if (dist < minDist)
                        {
                            minDist = dist;
                            closestFood = food;

                        }
                    }

                }

                if (closestFood.Location.X > maxX || closestFood.Location.X < minX)
                {
                    p = GetNewPoint();
                }


                return closestFood;

            }
            bool moveEnabled = true;

            protected override void Move(Point point)
            {
                if (moveEnabled)
                {
                    Siticone.Desktop.UI.WinForms.SiticoneShapes closestFood = FindClosestFood();

                    if (organismObj.Location.X < point.X)
                    {
                        organismObj.Location = new Point(organismObj.Location.X + 2, organismObj.Location.Y);
                    }
                    else
                    {
                        organismObj.Location = new Point(organismObj.Location.X - 2, organismObj.Location.Y);
                    }

                    if (organismObj.Location.Y < point.Y)
                    {
                        organismObj.Location = new Point(organismObj.Location.X, organismObj.Location.Y + 2);
                    }
                    else
                    {
                        organismObj.Location = new Point(organismObj.Location.X, organismObj.Location.Y - 2);
                    }

                    double dist;
                    dist = Math.Sqrt((organismObj.Location.X - point.X) ^ 2 + (point.Y - organismObj.Location.Y) ^ 2);

                    if (dist < 5)
                    {
                        int ran = n.Next(foodLev);
                        if (ran == 0)
                        {
                            p = FindClosestFood().Location;
                        }
                        else
                        {
                            p = GetNewPoint();
                        }
                    }
                }
            }
        }
    } 


