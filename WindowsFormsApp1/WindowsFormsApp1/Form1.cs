using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		SqlConnection con;
		SqlDataAdapter da;
		SqlCommand cmd;
		DataSet ds;
		public Form1()
		{
			InitializeComponent();
		}

		public void GetList()
		{
			con = new SqlConnection(@"Data Source= .\SQLEXPRESS; Initial Catalog=Base1; Integrated Security=True");
			da = new SqlDataAdapter("SELECT Таблица1.IdCat, Таблица1.IdProd, *" +
"FROM Таблица1" +
"GROUP BY Таблица1.IdCat, Таблица1.IdProd", con) ;
			ds = new DataSet();
			con.Open();
			da.Fill(ds, "Tabel1");
			//dataGridView1.DataSource = ds.Tables["Tabel1"];//Таблица для заполнения
			con.Close();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			double S;
			if ((textBox1.Text=="" & textBox2.Text=="" & textBox3.Text=="") ^ (textBox1.Text != "" & textBox2.Text == "" & textBox3.Text == ""))
			{
				label8.Text = "ВВЕДИТЕ минимум 2 стороны";
			}
			else
			{
				if (textBox1.Text != "" & textBox2.Text != ""& textBox2.Text == "")
				{
					if (textBox1.Text == textBox2.Text)
					{
						label8.Text = "Площадь квадрата = ";
						S = double.Parse(textBox1.Text) * 2;
						textBox4.Text = S.ToString();
					}
					else
					{
						label8.Text = "Площадь прямоугольника = ";
						S = double.Parse(textBox1.Text) * double.Parse(textBox2.Text);
						textBox4.Text = S.ToString();
					}
				}
				else 
				{
					if (double.Parse(textBox3.Text) * double.Parse(textBox3.Text) == double.Parse(textBox1.Text) * double.Parse(textBox1.Text) + double.Parse(textBox2.Text) * double.Parse(textBox2.Text))
					{
						label8.Text = "Площадь прямоугольного треугольника = ";
						S = (double.Parse(textBox1.Text) * double.Parse(textBox2.Text))/2;
						textBox4.Text = S.ToString();
					}
					else
					{
						double H, p;
						p = (double.Parse(textBox1.Text) + double.Parse(textBox2.Text) + double.Parse(textBox3.Text)) / 2;
						label8.Text = "Площадь треугольника = ";
						S = Math.Sqrt(p*(p-double.Parse(textBox1.Text))* (p - double.Parse(textBox2.Text))* (p - double.Parse(textBox3.Text)));
						textBox4.Text = S.ToString();
					}
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			double S;
			S = Math.PI * (double.Parse(textBox7.Text) * double.Parse(textBox7.Text));
			textBox5.Text = S.ToString();
		}
	}
}
