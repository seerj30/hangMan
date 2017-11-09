using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Spânzurătoarea
{
    public partial class Form5 : Form
    {
        public static int sc1 = variables.sc1;
        public static int sc2 = variables.sc2;
        public static int r = variables.r;
        public Form5()
        {
            InitializeComponent();
            checkBox1.Enabled = false;
            label1.Visible = false;
            textBox2.ForeColor = SystemColors.GrayText;
            textBox2.Text = "Introduceți cuvântul dorit";
            MessageBox.Show("Cuvântul poate avea maxim 20 de litere !", "Atenție !",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Select();
            this.textBox2.Enter += new EventHandler(textBox2_Enter);
            this.textBox2.Leave += new EventHandler(textBox2_Leave);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Introduceți cuvântul dorit")
            {
                textBox2.Text = "";
                textBox2.ForeColor = SystemColors.WindowText;
            }
            textBox2.PasswordChar = '\u25CF';
            textBox2.MaxLength = 20;
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                textBox2.Text = "Introduceți cuvântul dorit";
                textBox2.ForeColor = SystemColors.GrayText;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Introduceți cuvântul dorit" || textBox2.Text == "")
                MessageBox.Show("Vă rugăm introduceți un cuvânt !", "",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    File.WriteAllText("WORD.rtf", textBox2.Text.ToUpper());
                    StreamWriter file = new StreamWriter("word-mp.txt");
                    for (i = 0; i < textBox2.Text.Length; i++)
                        file.WriteLine(textBox2.Text[i].ToString().ToUpper());
                    file.Close();
                }
                variables.timer_2 = 60;
                this.Hide();
                Form f = new Form4();
                f.Show();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.UseSystemPasswordChar = true;
            else
                textBox2.UseSystemPasswordChar = false;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "Introduceți cuvântul dorit" && textBox2.Text.Length > 0)
                checkBox1.Enabled = true;
            else
                checkBox1.Enabled = false;
            if (checkBox1.Enabled == false)
                checkBox1.Checked = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new player2().Show();
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
