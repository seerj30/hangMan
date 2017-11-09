using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spânzurătoarea
{
    public partial class player2 : Form
    {
        public player2()
        {
            InitializeComponent();
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            label1.Select();
            textBox2.ForeColor = SystemColors.GrayText;
            textBox2.Text = "Introduceți numele jucătorului 2";

            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void player2_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            this.textBox2.Enter += new EventHandler(textBox2_Enter);
            this.textBox2.Leave += new EventHandler(textBox2_Leave);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Introduceți numele jucătorului 2")
            {
                textBox2.Text = "";
                textBox2.ForeColor = SystemColors.WindowText;
            }
            textBox2.MaxLength = 12;
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                textBox2.Text = "Introduceți numele jucătorului 2";
                textBox2.ForeColor = SystemColors.GrayText;
            }
        }

        private void player2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "" || textBox2.Text == "Introduceți numele jucătorului 2")
                MessageBox.Show("Vă rugăm să vă introduceți numele !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                variables.j2_name = textBox2.Text;
                this.Hide();
                new Form5().Show();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(this, new EventArgs());
            if (e.KeyCode == Keys.Escape)
                button2_Click(this, new EventArgs());
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new player1().Show();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
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

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Black;
        }
    }
}
