using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Spânzurătoarea
{
    public partial class Form4 : Form
    {
        int ok;
        double time1 = 0, time2 = 0, time3 = 0, time4 = 0, time5 = 0, time6 = 0, time7 = 0, time8 = 0, time9 = 0, time10 = 0;
        int i, amount = 0;
        string copyCurrent = "";
        string current = "", current1 = "";
        string[] words = new string[50];
        public bool rr = false;

        //meniu
        private void meniu_Click(object sender, EventArgs e)
        {
            systemTimer.Stop();
            this.Hide();
            new Form2().Show();
            variables.sc1 = 0;
            variables.sc2 = 0;
            variables.timer_2 = 60;
        }
        //iesire-meniu
        private void iesire_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Ești sigur că vrei să părăsești jocul ?", "Ieșire", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                Application.Exit();
        }

        public Form4()
        {
            InitializeComponent();
            //elimin marginile butoanelor
            cmdA.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdĂ.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdÂ.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdB.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdC.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdD.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdE.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdF.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdG.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdH.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdI.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdÎ.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdJ.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdK.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdL.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdM.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdN.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdO.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdP.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdQ.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdR.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdS.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdȘ.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdT.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdȚ.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdU.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdV.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdW.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdX.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdY.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            cmdZ.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            //

            string nume1_1 = String.Empty ;
            string nume1_2 = String.Empty;
            string nume2_1 = String.Empty;
            string nume2_2 = String.Empty;
            nume1_1 = variables.j1_name.Substring(0, 1).ToUpper();
            nume1_2 = variables.j1_name.Remove(0, 1);
            nume1_2 = nume1_2.ToLower();
            nume2_1 = variables.j2_name.Substring(0, 1).ToUpper();
            nume2_2 = variables.j2_name.Remove(0, 1);
            nume2_2 = nume2_2.ToLower();

            string nume1 = nume1_1 + nume1_2;
            string nume2 = nume2_1 + nume2_2;

            variables.j1_name = nume1;
            variables.j2_name = nume2;

            label2.Text = nume1 + ": " + variables.sc1.ToString();
            label3.Text = nume2 + ": " + variables.sc2.ToString();
            variables.r++;
            systemTimer.Start();
            timer_hp.Start();
            panel1.Visible = true;
            pictureBox5.Visible = false;
            panel1.Parent = pictureBox2;
            panel1.BackColor = Color.Transparent;

        }

        // generare cuvant random si _ pe label in fucntie de lungimea cuvantului
        private void setupWordChoice()
        {
            amount = 0;
            copyCurrent = "";
            current = File.ReadAllText("WORD.rtf");
            current1 = File.ReadAllText("WORD.rtf");
            for (i = 0; i < current.Length; i++)
                copyCurrent += "_";
            displayCopy();
        }

        //spatiu intre litere pe label
        private void displayCopy()
        {
            lblShowWord.Text = "";
            for (i = 0; i < copyCurrent.Length; i++)
            {
                lblShowWord.Text += copyCurrent.Substring(i, 1);
                lblShowWord.Text += " ";
            }
        }

        //resetare la space (1)
        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            rr = false;
            if (e.KeyCode == Keys.Space)
            {
                rr = true;
            }
        }
        //(2)
        private void Form4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rr == true && copyCurrent.Equals(current))
                reset();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //verific daca litera aleasa este in cuvant
        private void guessClick(object sender, EventArgs e)
        {
            label4.Focus();
            Button choice = sender as Button;
            choice.Enabled = false;
            if (current.Contains(choice.Text))
            {
                char[] temp = copyCurrent.ToCharArray();
                char[] find = current.ToCharArray();
                char guessChar = choice.Text.ElementAt(0);
                for (i = 0; i < find.Length; i++)
                    if (find[i] == guessChar)
                    {
                        temp[i] = guessChar;
                        string tempFile = Path.GetTempFileName();
                        using (var sr = new StreamReader("word-mp.txt"))
                        using (var sw = new StreamWriter(tempFile))
                        {
                            string line1;

                            while ((line1 = sr.ReadLine()) != null)
                            {
                                if (Convert.ToChar(line1) != guessChar)
                                    sw.WriteLine(line1);
                            }
                        }

                        File.Delete("word-mp.txt");
                        File.Move(tempFile, "word-mp.txt");
                    }
                copyCurrent = new string(temp);
                displayCopy();
            }
            else
            {
                amount++;
                panel1.Enabled = false;
                if (amount == 1)
                {
                    timer_head.Start();
                    ok = 0;
                    pictureBox3.Image = Image.FromFile("Head.gif");
                }
                else
                if (amount == 2)
                {
                   timer_el.Start();
                   ok = 0;
                   pictureBox3.Image = Image.FromFile("Eye_left.gif");
                }
                else
                if (amount == 3)
                {
                   timer_er.Start();
                   ok = 0;
                   pictureBox3.Image = Image.FromFile("Eye_right.gif");
                }
                else
                if (amount == 4)
                {
                   timer_m.Start();
                   ok = 0;
                   pictureBox3.Image = Image.FromFile("Mouth.gif");
                }
                else
                if (amount == 5)
                {
                   timer_b.Start();
                   ok = 0;
                   pictureBox3.Image = Image.FromFile("Body.gif");
                }
                else
                if (amount == 6)
                {
                   timer_al.Start();
                   ok = 0;
                   pictureBox3.Image = Image.FromFile("Arm_left.gif");
                }
                else
                if (amount == 7)
                {
                   timer_ar.Start();
                   ok = 0;
                   pictureBox3.Image = Image.FromFile("Arm_right.gif");
                }
                else
                if (amount == 8)
                {
                   timer_ll.Start();
                   ok = 0;
                   pictureBox3.Image = Image.FromFile("Leg_left.gif");
                }
                else
                if (amount == 9)
                {
                   timer_lr.Start();
                   ok = 0;
                   pictureBox3.Image = Image.FromFile("Leg_right.gif");
                }
            }
            if (amount == 9)
            {
                systemTimer.Stop();
                variables.timer_2 = 0;
                for (i = 0; i < current1.Length; i += 2)
                    current1 = current1.Insert(i, " ");
                lblShowWord.Text = "";
                lblShowWord.Text = current1;
                if (variables.r % 2 == 1)
                    variables.sc1++;
                else
                    variables.sc2++;
                label2.Text = variables.j1_name + ": " + variables.sc1.ToString();
                label3.Text = variables.j2_name + ": " + variables.sc2.ToString();
            }
            if (copyCurrent.Equals(current))
            {
                systemTimer.Stop();
                variables.timer_2 = 0;
                pictureBox5.Visible = true;
                if (variables.r % 2 == 1)
                    variables.sc2++;
                else
                    variables.sc1++;
                label2.Text = variables.j1_name + ": " + variables.sc1.ToString();
                label3.Text = variables.j2_name + ": " + variables.sc2.ToString();
            }
        }

        //intializare
        private void Form4_Load(object sender, EventArgs e)
        {
            setupWordChoice();
            lblShowWord.Parent = pictureBox2;
            lblShowWord.BackColor = Color.Transparent;
            min.Parent = pictureBox2;
            min.BackColor = Color.Transparent;
            sec.Parent = pictureBox2;
            sec.BackColor = Color.Transparent;
            pct.Parent = pictureBox2;
            pct.BackColor = Color.Transparent;
            var pos = this.PointToScreen(label2.Location);
            pos = pictureBox1.PointToClient(pos);
            label2.Parent = pictureBox1;
            label2.Location = pos;
            label2.BackColor = Color.Transparent;
            pictureBox2.Controls.Add(pictureBox1);
            pictureBox1.BackColor = Color.Transparent;
            var pos2 = this.PointToScreen(label3.Location);
            pos2 = pictureBox4.PointToClient(pos2);
            label3.Parent = pictureBox4;
            label3.Location = pos2;
            label3.BackColor = Color.Transparent;
            pictureBox2.Controls.Add(pictureBox4);
            pictureBox4.BackColor = Color.Transparent;
            pictureBox3.Controls.Add(pictureBox5);
            pictureBox5.BackColor = Color.Transparent;
            MenuStrip1.Parent = pictureBox2;
            MenuStrip1.BackColor = Color.Transparent;
            pictureBox2.Controls.Add(pbTime);
            pbTime.BackColor = Color.Transparent;
            pictureBox2.Controls.Add(pictureBox3);
            pictureBox3.BackColor = Color.Transparent;
            panel1.Enabled = false;
            this.panel1.BackgroundImage = null;
        }

        //resetare
        private void reset()
        {
            cmdA.Enabled = true;
            cmdĂ.Enabled = true;
            cmdÂ.Enabled = true;
            cmdB.Enabled = true;
            cmdC.Enabled = true;
            cmdD.Enabled = true;
            cmdE.Enabled = true;
            cmdF.Enabled = true;
            cmdG.Enabled = true;
            cmdH.Enabled = true;
            cmdI.Enabled = true;
            cmdÎ.Enabled = true;
            cmdJ.Enabled = true;
            cmdK.Enabled = true;
            cmdL.Enabled = true;
            cmdM.Enabled = true;
            cmdN.Enabled = true;
            cmdO.Enabled = true;
            cmdP.Enabled = true;
            cmdQ.Enabled = true;
            cmdR.Enabled = true;
            cmdS.Enabled = true;
            cmdȘ.Enabled = true;
            cmdT.Enabled = true;
            cmdȚ.Enabled = true;
            cmdU.Enabled = true;
            cmdV.Enabled = true;
            cmdW.Enabled = true;
            cmdX.Enabled = true;
            cmdY.Enabled = true;
            cmdZ.Enabled = true;
            amount = 0;
            pictureBox3.Image = null;
            pictureBox2.Invalidate();
            pictureBox3.Image = Image.FromFile("HP.gif");
            timer_hp.Stop();
            systemTimer.Stop();
            setupWordChoice();
            panel1.Enabled = false;
            this.Hide();
            Form f = new Form5();
            f.Show();
        }

        //timer_joc
        private void systemTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            variables.timer_2--;
            if (variables.timer_2 >= 0)
            {
                if (ok == 1 && amount != 9 && copyCurrent!=current)
                {
                    min.Text = (variables.timer_2 / 60).ToString();
                    if (variables.timer_2 % 60 < 10)
                        sec.Text = ("0" + variables.timer_2 % 60).ToString();
                    else
                        sec.Text = (variables.timer_2 % 60).ToString();
                }
                if (variables.timer_2 <= 5)
                    MenuStrip1.Enabled = false;

                if (variables.timer_2 == 0)
                {
                    systemTimer.Stop();
                    sec.ForeColor = Color.Red;
                    pct.ForeColor = Color.Red;
                    min.ForeColor = Color.Red;
                    for (i = 0; i < current1.Length; i += 2)
                        current1 = current1.Insert(i, " ");
                    lblShowWord.Text = "";
                    lblShowWord.Text = current1;
                    sec.Text = "00";
                    if (variables.r % 2 == 1)
                        variables.sc1++;
                    else
                        variables.sc2++;
                    label2.Text = variables.j1_name + ": " + variables.sc1.ToString();
                    label3.Text = variables.j2_name + ": " + variables.sc2.ToString();
                    systemTimer.Stop();
                    MessageBox.Show("Timpul a expirat !","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    Form f = new Form5();
                    f.Show();
                }
            }
            
        }
        //timer_hangpost
        private void timer_hp_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time1++;
            if (time1 == 26)
            {
                pictureBox3.Image = Image.FromFile("HP.png");
                timer_hp.Stop();
                variables.timer_2 = variables.timer_2 + 10;
                ok = 1;
                time1 = 0;
                panel1.Enabled = true;
            }
        }
        //timer_head
        private void timer_head_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time2++;
            if (time2 == 12)
            {
                pictureBox3.Image = Image.FromFile("Head.png");
                timer_head.Stop();
                variables.timer_2 = variables.timer_2 + 5;
                ok = 1;
                time2 = 0;
                panel1.Enabled = true;
            }
        }
        //timer_eye_left
        private void timer_el_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time3++;
            if (time3 == 5)
            {
                pictureBox3.Image = Image.FromFile("Eye_left.png");
                timer_el.Stop();
                variables.timer_2 = variables.timer_2 + 2;
                ok = 1;
                time3 = 0;
                panel1.Enabled = true;
            }
        }
        //timer_eye_right
        private void timer_er_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time4++;
            if (time4 == 5)
            {
                pictureBox3.Image = Image.FromFile("Eye_right.png");
                timer_er.Stop();
                variables.timer_2 = variables.timer_2 + 2;
                ok = 1;
                time4 = 0;
                panel1.Enabled = true;
            }
        }
        //timer_mouth
        private void timer_m_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time5++;
            if (time5 == 8)
            {
                pictureBox3.Image = Image.FromFile("Mouth.png");
                timer_m.Stop();
                variables.timer_2 = variables.timer_2 + 1;
                ok = 1;
                time5 = 0;
                panel1.Enabled = true;
            }
        }
        //timer_body
        private void timer_b_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time6++;
            if (time6 == 18)
            {
                pictureBox3.Image = Image.FromFile("Body.png");
                timer_b.Stop();
                variables.timer_2 = variables.timer_2 + 4;
                ok = 1;
                time6 = 0;
                panel1.Enabled = true;
            }
        }
        //timer_arm_left
        private void timer_al_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time7++;
            if (time7 == 9)
            {
                pictureBox3.Image = Image.FromFile("Arm_left.png");
                timer_al.Stop();
                variables.timer_2 = variables.timer_2 + 2;
                ok = 1;
                time7 = 0;
                panel1.Enabled = true;
            }
        }
        //timer_arm_right
        private void timer_ar_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time8++;
            if (time8 == 9)
            {
                pictureBox3.Image = Image.FromFile("Arm_right.png");
                timer_ar.Stop();
                variables.timer_2 = variables.timer_2 + 2;
                ok = 1;
                time8 = 0;
                panel1.Enabled = true;
            }
        }
        //timer_leg_left
        private void timer_ll_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time9++;
            if (time9 == 5)
            {
                pictureBox3.Image = Image.FromFile("Leg_left.png");
                timer_ll.Stop();
                variables.timer_2 = variables.timer_2 + 2;
                ok = 1;
                time9 = 0;
                panel1.Enabled = true;
            }
        }
        //timer_leg_right
        private void timer_lr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time10++;
            if (time10 == 5)
            {
                pictureBox3.Image = Image.FromFile("Leg_right.png");
                timer_lr.Stop();
                variables.timer_2 = variables.timer_2 + 2;
                ok = 1;
                time10 = 0;
                panel1.Enabled = true;
                if (amount == 9)
                {
                    systemTimer.Stop();
                    variables.timer_2 = 0;
                    MessageBox.Show("Ai pierdut !","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    Form f = new Form5();
                    f.Show();
                }
            }
        }

        private void cmdA_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdĂ_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdÂ_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdB_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdC_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdD_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdE_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdF_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdG_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdH_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdI_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdÎ_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdJ_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdK_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdL_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdM_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdN_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdO_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdP_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdQ_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdR_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdS_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdȘ_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdT_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdȚ_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdU_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdV_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdW_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdX_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdY_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdZ_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void cmdA_MouseHover(object sender, EventArgs e)
        {
            cmdA.ForeColor = Color.White;
        }

        private void cmdA_MouseLeave(object sender, EventArgs e)
        {
            cmdA.ForeColor = Color.Black;
        }

        private void cmdĂ_MouseHover(object sender, EventArgs e)
        {
            cmdĂ.ForeColor = Color.White;
        }

        private void cmdĂ_MouseLeave(object sender, EventArgs e)
        {
            cmdĂ.ForeColor = Color.Black;
        }

        private void cmdÂ_MouseHover(object sender, EventArgs e)
        {
            cmdÂ.ForeColor = Color.White;
        }

        private void cmdÂ_MouseLeave(object sender, EventArgs e)
        {
            cmdÂ.ForeColor = Color.Black;
        }

        private void cmdB_MouseHover(object sender, EventArgs e)
        {
            cmdB.ForeColor = Color.White;
        }

        private void cmdB_MouseLeave(object sender, EventArgs e)
        {
            cmdB.ForeColor = Color.Black;
        }

        private void cmdC_MouseHover(object sender, EventArgs e)
        {
            cmdC.ForeColor = Color.White;
        }

        private void cmdC_MouseLeave(object sender, EventArgs e)
        {
            cmdC.ForeColor = Color.Black;
        }

        private void cmdD_MouseHover(object sender, EventArgs e)
        {
            cmdD.ForeColor = Color.White;
        }

        private void cmdD_MouseLeave(object sender, EventArgs e)
        {
            cmdD.ForeColor = Color.Black;
        }

        private void cmdE_MouseHover(object sender, EventArgs e)
        {
            cmdE.ForeColor = Color.White;
        }

        private void cmdE_MouseLeave(object sender, EventArgs e)
        {
            cmdE.ForeColor = Color.Black;
        }

        private void cmdF_MouseHover(object sender, EventArgs e)
        {
            cmdF.ForeColor = Color.White;
        }

        private void cmdF_MouseLeave(object sender, EventArgs e)
        {
            cmdF.ForeColor = Color.Black;
        }

        private void cmdG_MouseHover(object sender, EventArgs e)
        {
            cmdG.ForeColor = Color.White;
        }

        private void cmdG_MouseLeave(object sender, EventArgs e)
        {
            cmdG.ForeColor = Color.Black;
        }

        private void cmdH_MouseHover(object sender, EventArgs e)
        {
            cmdH.ForeColor = Color.White;
        }

        private void cmdH_MouseLeave(object sender, EventArgs e)
        {
            cmdH.ForeColor = Color.Black;
        }

        private void cmdI_MouseHover(object sender, EventArgs e)
        {
            cmdI.ForeColor = Color.White;
        }

        private void cmdI_MouseLeave(object sender, EventArgs e)
        {
            cmdI.ForeColor = Color.Black;
        }

        private void cmdÎ_MouseHover(object sender, EventArgs e)
        {
            cmdÎ.ForeColor = Color.White;
        }

        private void cmdÎ_MouseLeave(object sender, EventArgs e)
        {
            cmdÎ.ForeColor = Color.Black;
        }

        private void cmdJ_MouseHover(object sender, EventArgs e)
        {
            cmdJ.ForeColor = Color.White;
        }

        private void cmdJ_MouseLeave(object sender, EventArgs e)
        {
            cmdJ.ForeColor = Color.Black;
        }

        private void cmdK_MouseHover(object sender, EventArgs e)
        {
            cmdK.ForeColor = Color.White;
        }

        private void cmdK_MouseLeave(object sender, EventArgs e)
        {
            cmdK.ForeColor = Color.Black;
        }

        private void cmdL_MouseHover(object sender, EventArgs e)
        {
            cmdL.ForeColor = Color.White;
        }

        private void cmdL_MouseLeave(object sender, EventArgs e)
        {
            cmdL.ForeColor = Color.Black;
        }

        private void cmdM_MouseHover(object sender, EventArgs e)
        {
            cmdM.ForeColor = Color.White;
        }

        private void cmdM_MouseLeave(object sender, EventArgs e)
        {
            cmdM.ForeColor = Color.Black;
        }

        private void cmdN_MouseHover(object sender, EventArgs e)
        {
            cmdN.ForeColor = Color.White;
        }

        private void cmdN_MouseLeave(object sender, EventArgs e)
        {
            cmdN.ForeColor = Color.Black;
        }

        private void cmdO_MouseHover(object sender, EventArgs e)
        {
            cmdO.ForeColor = Color.White;
        }

        private void cmdO_MouseLeave(object sender, EventArgs e)
        {
            cmdO.ForeColor = Color.Black;
        }

        private void cmdP_MouseHover(object sender, EventArgs e)
        {
            cmdP.ForeColor = Color.White;
        }

        private void cmdP_MouseLeave(object sender, EventArgs e)
        {
            cmdP.ForeColor = Color.Black;
        }

        private void cmdQ_MouseHover(object sender, EventArgs e)
        {
            cmdQ.ForeColor = Color.White;
        }

        private void cmdQ_MouseLeave(object sender, EventArgs e)
        {
            cmdQ.ForeColor = Color.Black;
        }

        private void cmdR_MouseHover(object sender, EventArgs e)
        {
            cmdR.ForeColor = Color.White;
        }

        private void cmdR_MouseLeave(object sender, EventArgs e)
        {
            cmdR.ForeColor = Color.Black;
        }

        private void cmdS_MouseHover(object sender, EventArgs e)
        {
            cmdS.ForeColor = Color.White;
        }

        private void cmdS_MouseLeave(object sender, EventArgs e)
        {
            cmdS.ForeColor = Color.Black;
        }

        private void cmdȘ_MouseHover(object sender, EventArgs e)
        {
            cmdȘ.ForeColor = Color.White;
        }

        private void cmdȘ_MouseLeave(object sender, EventArgs e)
        {
            cmdȘ.ForeColor = Color.Black;
        }

        private void cmdT_MouseHover(object sender, EventArgs e)
        {
            cmdT.ForeColor = Color.White;
        }

        private void cmdT_MouseLeave(object sender, EventArgs e)
        {
            cmdT.ForeColor = Color.Black;
        }

        private void cmdȚ_MouseHover(object sender, EventArgs e)
        {
            cmdȚ.ForeColor = Color.White;
        }

        private void cmdȚ_MouseLeave(object sender, EventArgs e)
        {
            cmdȚ.ForeColor = Color.Black;
        }

        private void cmdU_MouseHover(object sender, EventArgs e)
        {
            cmdU.ForeColor = Color.White;
        }

        private void cmdU_MouseLeave(object sender, EventArgs e)
        {
            cmdU.ForeColor = Color.Black;
        }

        private void cmdV_MouseHover(object sender, EventArgs e)
        {
            cmdV.ForeColor = Color.White;
        }

        private void cmdV_MouseLeave(object sender, EventArgs e)
        {
            cmdV.ForeColor = Color.Black;
        }

        private void cmdW_MouseHover(object sender, EventArgs e)
        {
            cmdW.ForeColor = Color.White;
        }

        private void cmdW_MouseLeave(object sender, EventArgs e)
        {
            cmdW.ForeColor = Color.Black;
        }

        private void cmdX_MouseHover(object sender, EventArgs e)
        {
            cmdX.ForeColor = Color.White;
        }

        private void cmdX_MouseLeave(object sender, EventArgs e)
        {
            cmdX.ForeColor = Color.Black;
        }

        private void cmdY_MouseHover(object sender, EventArgs e)
        {
            cmdY.ForeColor = Color.White;
        }

        private void cmdY_MouseLeave(object sender, EventArgs e)
        {
            cmdY.ForeColor = Color.Black;
        }

        private void cmdZ_MouseHover(object sender, EventArgs e)
        {
            cmdZ.ForeColor = Color.White;
        }

        private void cmdZ_MouseLeave(object sender, EventArgs e)
        {
            cmdZ.ForeColor = Color.Black;
        }
    }
}
