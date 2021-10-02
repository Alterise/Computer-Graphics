using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
	public partial class Form1 : Form
	{
		private struct Sun
		{
			public int x, y;
			public float radius;

			public Brush brush;

			public void draw(Graphics gr)
			{
				gr.FillEllipse(brush, x - radius, y - radius, radius * 2, radius * 2);
			}
		}

		private Sun sun;

		private struct Planet
		{
			public int x1, y1, x2, y2;
			public float radius;

			public float orbitRadius;
			public double speedMultiplier;

			public Brush brush;

			public void draw(Graphics gr)
			{
				gr.FillEllipse(brush, x2 - radius, y2 - radius, radius * 2, radius * 2);
			}

			public void drawOrbit(Graphics gr, Pen orbitPen)
			{
				gr.DrawEllipse(orbitPen, x1 - orbitRadius, y1 - orbitRadius,
						   orbitRadius * 2, orbitRadius * 2);
			}

			public void recalculateCoordinates(double t)
			{
				x2 = x1 + (int)(orbitRadius * Math.Cos(t * speedMultiplier));
				y2 = y1 + (int)(orbitRadius * Math.Sin(t * speedMultiplier));
			}
		}

		private Planet mercury, venus, earth, mars, jupiter, saturn, uranus, neptune;

		private double angle;
		private double angular_velocity;

		private Pen orbitPen;

		private void timer1_Tick(Object sender, EventArgs e)
		{
			angle += angular_velocity;
			mercury.recalculateCoordinates(angle);
			venus.recalculateCoordinates(angle);
			earth.recalculateCoordinates(angle);
			mars.recalculateCoordinates(angle);
			jupiter.recalculateCoordinates(angle);
			saturn.recalculateCoordinates(angle);
			uranus.recalculateCoordinates(angle);
			neptune.recalculateCoordinates(angle);
			pictureBox1.Invalidate();
		}

		private void button1_Click(Object sender, EventArgs e)
		{
			timer1.Enabled = true;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			timer1.Enabled = false;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			angular_velocity = 0.005;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			angular_velocity = 0.01;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			angular_velocity = 0.025;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			angular_velocity = 0.05;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			angular_velocity = 0.25;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			angular_velocity = 0.5;
		}

		private void pictureBox1_Paint(Object sender,
		PaintEventArgs e)
		{
			Graphics  gr = e.Graphics;

			sun.draw(gr);

			mercury.drawOrbit(gr, orbitPen);
			venus.drawOrbit(gr, orbitPen);
			earth.drawOrbit(gr, orbitPen);
			mars.drawOrbit(gr, orbitPen);
			jupiter.drawOrbit(gr, orbitPen);
			saturn.drawOrbit(gr, orbitPen);
			uranus.drawOrbit(gr, orbitPen);
			neptune.drawOrbit(gr, orbitPen);

			mercury.draw(gr);
			venus.draw(gr);
			earth.draw(gr);
			mars.draw(gr);
			jupiter.draw(gr);
			saturn.draw(gr);
			uranus.draw(gr);
			neptune.draw(gr);
		}

		private void MyForm_Load(Object sender, EventArgs e)
		{
			sun = new Sun
			{
				x = pictureBox1.Width / 2,
				y = pictureBox1.Height / 2,
				radius = 40,
				brush = new SolidBrush(Color.Yellow)
			};

			mercury = new Planet
			{
				x1 = pictureBox1.Width / 2,
				y1 = pictureBox1.Height / 2,
				x2 = pictureBox1.Width / 2,
				y2 = pictureBox1.Height / 2,
				radius = 5,
				orbitRadius = 60,
				brush = new SolidBrush(Color.Chocolate),
				speedMultiplier = 5
			};

			venus = new Planet
			{
				x1 = pictureBox1.Width / 2,
				y1 = pictureBox1.Height / 2,
				x2 = pictureBox1.Width / 2,
				y2 = pictureBox1.Height / 2,
				radius = 7,
				orbitRadius = 80,
				brush = new SolidBrush(Color.DarkOrange),
				speedMultiplier = 2
			};

			earth = new Planet
			{
				x1 = pictureBox1.Width / 2,
				y1 = pictureBox1.Height / 2,
				x2 = pictureBox1.Width / 2,
				y2 = pictureBox1.Height / 2,
				radius = 8,
				orbitRadius = 100,
				brush = new SolidBrush(Color.DodgerBlue),
				speedMultiplier = 1
			};

			mars = new Planet
			{
				x1 = pictureBox1.Width / 2,
				y1 = pictureBox1.Height / 2,
				x2 = pictureBox1.Width / 2,
				y2 = pictureBox1.Height / 2,
				radius = 6,
				orbitRadius = 120,
				brush = new SolidBrush(Color.Red),
				speedMultiplier = 0.5
			};

			jupiter = new Planet
			{
				x1 = pictureBox1.Width / 2,
				y1 = pictureBox1.Height / 2,
				x2 = pictureBox1.Width / 2,
				y2 = pictureBox1.Height / 2,
				radius = 20,
				orbitRadius = 150,
				brush = new SolidBrush(Color.Orange),
				speedMultiplier = 0.08
			};

			saturn = new Planet
			{
				x1 = pictureBox1.Width / 2,
				y1 = pictureBox1.Height / 2,
				x2 = pictureBox1.Width / 2,
				y2 = pictureBox1.Height / 2,
				radius = 15,
				orbitRadius = 190,
				brush = new SolidBrush(Color.Goldenrod),
				speedMultiplier = 0.015
			};

			uranus = new Planet
			{
				x1 = pictureBox1.Width / 2,
				y1 = pictureBox1.Height / 2,
				x2 = pictureBox1.Width / 2,
				y2 = pictureBox1.Height / 2,
				radius = 12,
				orbitRadius = 225,
				brush = new SolidBrush(Color.Blue),
				speedMultiplier = 0.005
			};

			neptune = new Planet
			{
				x1 = pictureBox1.Width / 2,
				y1 = pictureBox1.Height / 2,
				x2 = pictureBox1.Width / 2,
				y2 = pictureBox1.Height / 2,
				radius = 12,
				orbitRadius = 250,
				brush = new SolidBrush(Color.DarkBlue),
				speedMultiplier = 0.0025
			};

			angle = 0;
			angular_velocity = 0.005;
			mercury.recalculateCoordinates(angle);
			venus.recalculateCoordinates(angle);
			earth.recalculateCoordinates(angle);
			mars.recalculateCoordinates(angle);
			jupiter.recalculateCoordinates(angle);
			saturn.recalculateCoordinates(angle);
			uranus.recalculateCoordinates(angle);
			neptune.recalculateCoordinates(angle);

			orbitPen = new Pen(Color.Gray, 0.5F);


		}
		public Form1()
		{
			InitializeComponent();
		}

	}
}
