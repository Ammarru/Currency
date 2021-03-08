using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int days = 1;
        const double k = 0.03;
        bool clicked = false;
		 double rub = 1000d;
		double dollars = 0d;
		double price;
		private void btStart_Click(object sender, EventArgs e)
        {

			if (!clicked)
			{
				Random random = new Random();
				price = (double)edPrice.Value;
				chart1.Series[0].Points.AddXY(0, price);
				days++;
				price = price * (1 + k * (random.NextDouble() - 0.5));
				chart1.Series[0].Points.AddXY(days, price);
				clicked = true;
			}
			else
			{

				Random random = new Random();
				price = (double)edPrice.Value;
				days++;
				price = price * (1 + k * (random.NextDouble() - 0.5));
				chart1.Series[0].Points.AddXY(days, price);
			}
            
        }

		private void button1_Click(object sender, EventArgs e)
		{
			if (rub < price)
			{
				MessageBox.Show("Not EnoughMoney");
			}
			else
			{
				dollars++;
				label4.Text = $"{dollars} $";
				rub -= price;
				label3.Text = $"{rub} rub";
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (dollars <= 0)
			{
				MessageBox.Show("Not Enough Dollars!");
			}
			else
			{
				dollars--;
				label4.Text = $"{dollars} $";
				rub += price;
				label3.Text = $"{rub} rub";
			}
		}
	}
}
