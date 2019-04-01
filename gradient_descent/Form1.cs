using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradient_descent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double origin_slope;
        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series[1].Points.Clear();
            double x = Convert.ToDouble(textBox1.Text);
            Draw_model();
            origin_slope = Count_slope(x, x-0.1, find_y_in_model(x), find_y_in_model(x-0.1));
            GD(x, x-0.1, find_y_in_model(x), find_y_in_model(x-0.1), origin_slope, 0);
            
        }
        public void Draw_model()
        {
            double y = 0 ;
            
            for (double x=0;x<=10;x=x+0.01)
            {
                y = find_y_in_model(x);
                this.chart1.Series[0].Points.AddXY(x, y);
            }
        }
        public double find_y_in_model(double x)
        {
            const double e = 2.71828182846;
            double y = 0;
            y = 1 - x * Math.Pow(e, -x);
            return y;
        }
        public void GD(double current_x, double last_x, double current_y, double last_y,double slope,int num)
        {
            if (slope == 0 || num == 30000 || find_dx(current_x, last_x, current_y, last_y)==0)
            {

            }
            else
            {
                this.chart1.Series[1].Points.AddXY(current_x, current_y);
                num++;
                double dx = find_dx(current_x, last_x, current_y, last_y);
                double next_x = current_x+dx;
                GD(next_x, current_x, find_y_in_model(next_x), find_y_in_model(current_x),Count_slope(next_x, current_x, find_y_in_model(next_x), find_y_in_model(current_x)),num);

            }
        }
        public double find_dx(double current_x, double last_x, double current_y, double last_y)
        {
            double slope = Count_slope(current_x, last_x, current_y, last_y);
            double dx = 0;
            dx = -0.2 * slope;
            return dx;
        }
        public double Count_slope(double current_x,double last_x,double current_y,double last_y)
        {
            double slope;
            slope = (current_y - last_y) / (current_x - last_x);
            return slope;
        }
    }
}
