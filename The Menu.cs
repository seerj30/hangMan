using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Spânzurătoarea
{

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            Thread thr = new Thread(Go);
            thr.Start();

            button4.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button5.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button6.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        private delegate void moveBd(Button btn);

        void moveButtonR(Button btn)
        {
            int x = btn.Location.X;
            int y = btn.Location.Y;
            btn.Location = new Point(x + 1, y);
        }

        void moveButtonL(Button btn)
        {
            int x = btn.Location.X;
            int y = btn.Location.Y;
            btn.Location = new Point(x - 1, y);
        }

        void moveButtonU(Button btn)
        {
            int x = btn.Location.X;
            int y = btn.Location.Y;
            btn.Location = new Point(x, y - 1);
        }

        void moveButtonD(Button btn)
        {
            int x = btn.Location.X;
            int y = btn.Location.Y;
            btn.Location = new Point(x, y + 1);
        }
        private void Go()
        {
            Button b1 = button1, b2 = button4, b3 = button3, b4 = button5, b5 = button2, b6 = button6;
            if (b1.Location.X < b2.Location.X)
                while ((b1.Location.X + b1.Size.Width) < b2.Location.X + b2.Size.Width)
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new moveBd(moveButtonR), b1);
                        Thread.Sleep(1);
                    }
                }
            else
                while ((b1.Location.X + b1.Size.Width) > b2.Location.X + b2.Size.Width)
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new moveBd(moveButtonL), b1);
                        Thread.Sleep(1);
                    }
                }
            if (b1.Location.Y > b2.Location.Y)
                while ((b1.Location.Y + b1.Size.Width) > b2.Location.Y + b2.Size.Width)
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new moveBd(moveButtonU), b1);
                        Thread.Sleep(1);
                    }
                }
            else
                while ((b1.Location.Y + b1.Size.Width) < b2.Location.Y + b2.Size.Width)
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new moveBd(moveButtonD), b1);
                        Thread.Sleep(1);
                    }
                }
            if (b3.Location.X < b4.Location.X)
                while ((b3.Location.X + b3.Size.Width) < b4.Location.X + b4.Size.Width)
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new moveBd(moveButtonR), b3);
                        Thread.Sleep(1);
                    }
                }
            else
                while ((b3.Location.X + b3.Size.Width) > b4.Location.X + b4.Size.Width)
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new moveBd(moveButtonL), b3);
                        Thread.Sleep(1);
                    }
                }
            if (b3.Location.Y > b4.Location.Y)
                while ((b3.Location.Y + b3.Size.Width) > b4.Location.Y + b4.Size.Width)
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new moveBd(moveButtonU), b3);
                        Thread.Sleep(1);
                    }
                }
            else
                while ((b3.Location.Y + b3.Size.Width) < b4.Location.Y + b4.Size.Width)
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new moveBd(moveButtonD), b3);
                        Thread.Sleep(1);
                    }
                }
            if (b5.Location.X < b6.Location.X)
                while ((b5.Location.X + b5.Size.Width) < b6.Location.X + b6.Size.Width)
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new moveBd(moveButtonR), b5);
                        Thread.Sleep(1);
                    }
                }
            else
                while ((b5.Location.X + b5.Size.Width) > b6.Location.X + b6.Size.Width)
                {
                    if (this.InvokeRequired)
                    {
                        Invoke(new moveBd(moveButtonL), b5);
                        Thread.Sleep(1);
                    }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            variables.timer_1 = 60;
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            new player1().Show();
            this.Hide();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Black;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Black;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button7.Select();
        }

    }
}
