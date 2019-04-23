using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
    public partial class Main_Form : Form
    {
        
        Universe space;
        Star sun;
        ScreenConverter sc;
        Graphics g;
        Bitmap bmp;
        Color cl = Color.Red;

        public Main_Form()
        {
            InitializeComponent();
            sc = new ScreenConverter(pictureBox.Width, pictureBox.Height);
            sun = new Star("Солнце", 75, new Orbit(0, 0), new PointF(500, 250), 0.001, cl);
            space = new Universe();
            space.Space.Add(sun);
        }
        private void timerDraw_Tick(object sender, EventArgs e)
        {

            pictureBox.Invalidate();
        }
        private float dt = DateTime.Now.Millisecond;
        private float delta;
        private void timerUpd_Tick(object sender, EventArgs e)
        {
            delta = 5 * 0.01f;
            dt += delta;
            space.UpdateAll(dt);
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

            foreach (SpaceObj p in space.Space)
            {
                listBox.Items.Add(p);
            }
        }
        private bool check;
        private Point begin_location;
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                check = true;
                begin_location = e.Location;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (check)
            {
                sc.Move(e.Location, begin_location);
                begin_location = e.Location;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            check = false;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            g = Graphics.FromImage(bmp);
            space.DrawAll(g, sc);
            e.Graphics.DrawImage(bmp, 0, 0);
            g.Dispose();
            bmp.Dispose();
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            double v = (int)numericUpDown_V.Value * 0.01;
            Planet p = new Planet(textBox_Name.Text, (int)numericUpDown_R.Value, new Orbit(Convert.ToInt16(textBox_W.Text), Convert.ToInt16(textBox_H.Text)), new PointF(Convert.ToInt16(textBox_X.Text), Convert.ToInt16(textBox_Y.Text)), v,cl);

            space.Space.Add(p);
            listBox.Items.Add(p);
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            space.Space.Remove((SpaceObj)listBox.SelectedItem);
            listBox.Items.Remove(listBox.SelectedItem);
        }

        private void Color_button_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            Color_button.BackColor = colorDialog.Color;
            cl = colorDialog.Color;
        }
    } 
}
