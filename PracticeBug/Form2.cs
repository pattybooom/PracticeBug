
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        System.Windows.Forms.DataVisualization.Charting.Chart chart = new System.Windows.Forms.DataVisualization.Charting.Chart();

        private void Form2_Load(object sender, EventArgs e)
        {
            Timer tim = new Timer();
            tim.Interval = 1000;
            tim.Tick += Tim_Tick;
            tim.Enabled = true;

            chart.Size = new Size(450, 450);
            chart.Series.Add("food");
            chart.ChartAreas.Add("foodAreas");
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chart.Series.Add("totalOrganisms");
            chart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Controls.Add(chart);

        }
        int index = -1;
        int length = 60;
        
        private void Tim_Tick(object sender, EventArgs e)
        {
            index += 1;
            if (index == 999)
            {
                index = 0;
                chart.Series[0].Points.Clear();
                chart.Series[1].Points.Clear();
            }

            if (foodnum.num > length - 10)
            {
                length += 20;
            }
            
            double[] x = new double[length];
            double[] y = new double[length];
            double[] y1 = new double[length];

            Random r = new Random();
            double amp = r.Next(0, length);


            chart.Series[0].Points.AddXY(index, foodnum.num);
            chart.Series[1].Points.AddXY(index, organismnum.num);
            

            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = length;
        }
    }
}
