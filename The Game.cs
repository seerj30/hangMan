using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;


namespace Spânzurătoarea
{
    public partial class Form1 : Form
    {
        int nr, win=0, ok;
        double time1 = 0, time2 = 0, time3 = 0, time4 = 0, time5 = 0, time6 = 0, time7 = 0, time8 = 0, time9 = 0, time10 = 0;
        int i, wordsnumber = 0, guessIndex, amount = 0, coins = 0;
        string copyCurrent = "";
        string current = "", current1 = "";
        string[] words = new string[2000];
        Button[] cmd = new Button[35];
        public bool rr = false;
        public int[] ap= new int[2000];


        //variabile
        public Form1()
        {
            InitializeComponent();
            systemTimer.Start();
            timer_hp.Start();
            panel1.Visible = true;
            btn_buy.Enabled = false;
            pictureBox5.Visible = false;
            //elimin marginile butoanelor
            btn_buy.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
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
            cmd[1] = cmdA;
            cmd[1].Text = "A";
            cmd[2] = cmdĂ;
            cmd[2].Text = "Ă";
            cmd[3] = cmdÂ;
            cmd[3].Text = "Â";
            cmd[4] = cmdB;
            cmd[4].Text = "B";
            cmd[5] = cmdC;
            cmd[5].Text = "C";
            cmd[6] = cmdD;
            cmd[6].Text = "D";
            cmd[7] = cmdE;
            cmd[7].Text = "E";
            cmd[8] = cmdF;
            cmd[8].Text = "F";
            cmd[9] = cmdG;
            cmd[9].Text = "G";
            cmd[10] = cmdH;
            cmd[10].Text = "H";
            cmd[11] = cmdI;
            cmd[11].Text = "I";
            cmd[12] = cmdÎ;
            cmd[12].Text = "Î";
            cmd[13] = cmdJ;
            cmd[13].Text = "J";
            cmd[14] = cmdK;
            cmd[14].Text = "K";
            cmd[15] = cmdL;
            cmd[15].Text = "L";
            cmd[16] = cmdM;
            cmd[16].Text = "M";
            cmd[17] = cmdN;
            cmd[17].Text = "N";
            cmd[18] = cmdO;
            cmd[18].Text = "O";
            cmd[19] = cmdP;
            cmd[19].Text = "P";
            cmd[20] = cmdQ;
            cmd[20].Text = "Q";
            cmd[21] = cmdR;
            cmd[21].Text = "R";
            cmd[22] = cmdS;
            cmd[22].Text = "S";
            cmd[23] = cmdȘ;
            cmd[23].Text = "Ș";
            cmd[24] = cmdT;
            cmd[24].Text = "T";
            cmd[25] = cmdȚ;
            cmd[25].Text = "Ț";
            cmd[26] = cmdU;
            cmd[26].Text = "U";
            cmd[27] = cmdV;
            cmd[27].Text = "V";
            cmd[28] = cmdW;
            cmd[28].Text = "W";
            cmd[29] = cmdX;
            cmd[29].Text = "X";
            cmd[30] = cmdY;
            cmd[30].Text = "Y";
            cmd[31] = cmdZ;
            cmd[31].Text = "Z";
        }

        //citire cuvinte din fisier, numararea lor si punerea in vector
        private void loadwords()
        {
            i = 0;
            string s;
            using (StreamReader f = new StreamReader(Path.GetFullPath("cuvinte.rtf")))
            {
                while ((s = f.ReadLine()) != null)
                {
                    i++;
                    words[i] = s;
                }
            }
            wordsnumber = i;
        }

        // generare cuvant random si _ pe label in fucntie de lungimea cuvantului
        private void setupWordChoice()
        {
            if (coins < 3)
                btn_buy.Enabled = false;

            amount = 0;
            copyCurrent = "";
            guessIndex = (new Random()).Next(wordsnumber);
            //ma asigur ca nu generez acelasi cuvant de mai multe ori
            do
            {
                guessIndex = (new Random()).Next(wordsnumber);
            } while (ap[guessIndex] == 1);
            ap[guessIndex] = 1;
            //
            current = words[guessIndex];
            current1 = words[guessIndex];
            StreamWriter file = new StreamWriter("letters.txt"); //fisierul cu literele cuvantului
            for (i = 0; i < words[guessIndex].Length; i++)
                file.WriteLine(words[guessIndex][i]); //pun literele din cuvant pe cate o linie a fisierului
            file.Close();
            for (i = 0; i < current.Length; i++)
                copyCurrent += "_";
            displayCopy();
        }

        //pun literele si spatiu intre ele pe label
        private void displayCopy()
        {
            if (coins < 3)
                btn_buy.Enabled = false;

            lblShowWord.Text = "";
            for (i = 0; i < copyCurrent.Length; i++)
            {
                lblShowWord.Text += copyCurrent.Substring(i, 1); //litera
                lblShowWord.Text += " "; //spatiu
            }
        }

        //cumpar litera random din cuvant si dezactivez butonul cu litera respectiva
        private void btn_buy_Click(object sender, EventArgs e)
        {
            if (coins < 3)
                btn_buy.Enabled = false;

            if (coins >= 3)
            {
                coins -= 3;
                coinslbl.Text = "MONEDE: " + coins.ToString();
                var fileName = "letters.txt";
                var file = File.ReadLines(fileName).ToList();
                int skip, j;
                int count = file.Count();
                Random r = new Random();
                skip = r.Next(0, count);
                string line = file.Skip(skip).First(); 
                char[] temp = copyCurrent.ToCharArray();
                char[] find = current.ToCharArray();
                for (i = 0; i < copyCurrent.Length; i++)
                {
                    if (find[i] == line[0])
                    {
                        temp[i] = line[0];
                        nr++;
                        for (j = 1; j <= 43; j++)
                        {
                            if (cmd[j].Text[0] == line[0])
                                break;
                        }
                        if (cmd[j] == cmdA)
                            cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdÂ)
                            cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdÂ)
                            cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdB)
                            cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdC)
                            cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdD)
                            cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdE)
                            cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdF)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdG)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdH)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdI)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdÎ)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdJ)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdK)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdL)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdM)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdN)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdO)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdP)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdQ)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdR)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdS)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdȘ)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdT)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdȚ)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdU)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdV)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdW)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdX)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdY)
                           cmd[j].Enabled = false;
                        else
                        if (cmd[j] == cmdZ)
                           cmd[j].Enabled = false;

                        string tempFile = Path.GetTempFileName();
                        using (var sr = new StreamReader("letters.txt"))
                        using (var sw = new StreamWriter(tempFile))
                        {
                            string line1;

                            while ((line1 = sr.ReadLine()) != null)
                            {
                                if (line1 != line)
                                    sw.WriteLine(line1);
                            }
                        }

                        File.Delete("letters.txt");
                        File.Move(tempFile, "letters.txt");
                    }
                }
                copyCurrent = new string(temp);
                displayCopy();
                if (copyCurrent.Length == nr)
                {
                    systemTimer.Stop();
                    pictureBox5.Visible = true;
                    panel1.Focus();
                }
            }
        }
        private void btn_buy_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        //verific daca litera aleasa este in cuvant
        private void guessClick(object sender, EventArgs e)
        {
            if (coins < 3)
                btn_buy.Enabled = false;

            label3.Focus();
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
                        nr++;
                        string tempFile = Path.GetTempFileName();
                        using (var sr = new StreamReader("letters.txt"))
                        using (var sw = new StreamWriter(tempFile))
                        {
                            string line1;

                            while ((line1 = sr.ReadLine()) != null)
                            {
                                if (Convert.ToChar(line1) != guessChar)
                                    sw.WriteLine(line1);
                            }
                        }

                        File.Delete("letters.txt");
                        File.Move(tempFile, "letters.txt");
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
                    btn_buy.Enabled = false;//
                    timer_head.Start();
                    ok=0;
                    pictureBox3.Image = Image.FromFile("Head.gif");
                }
                else
                if (amount == 2)
                {
                    btn_buy.Enabled = false;//
                    timer_el.Start();
                    ok=0;
                    pictureBox3.Image = Image.FromFile("Eye_left.gif");
                }
                else
                if (amount == 3)
                {
                    btn_buy.Enabled = false;//
                    timer_er.Start();
                    ok=0;
                    pictureBox3.Image = Image.FromFile("Eye_right.gif");
                }
                else
                if (amount == 4)
                {
                    btn_buy.Enabled = false;//
                    timer_m.Start();
                    ok=0;
                    pictureBox3.Image = Image.FromFile("Mouth.gif");
                }
                else
                if (amount == 5)
                {
                    btn_buy.Enabled = false;//
                    timer_b.Start();
                    ok=0;
                    pictureBox3.Image = Image.FromFile("Body.gif");
                }
                else
                if (amount == 6)
                {
                     btn_buy.Enabled = false;//
                     timer_al.Start();
                     ok=0;
                     pictureBox3.Image = Image.FromFile("Arm_left.gif");
                }
                else
                if (amount == 7)
                {
                     btn_buy.Enabled = false;//
                     timer_ar.Start();
                     ok=0;
                     pictureBox3.Image = Image.FromFile("Arm_right.gif");
                }
                else
                if (amount == 8)
                {
                     btn_buy.Enabled = false;//
                     timer_ll.Start();
                     ok=0;
                     pictureBox3.Image = Image.FromFile("Leg_left.gif");
                }
                else
                if (amount == 9)
                {
                     btn_buy.Enabled = false;//
                     timer_lr.Start();
                     ok=0;
                     pictureBox3.Image = Image.FromFile("Leg_right.gif");
                }
            }
            if (amount == 9)
            {
                btn_buy.Enabled = false;//
                systemTimer.Stop();
                for (i = 0; i < current1.Length; i += 2)
                    current1 = current1.Insert(i, " ");
                lblShowWord.Text = "";
                lblShowWord.Text = current1;
            }
            if (copyCurrent.Equals(current))
            {
                systemTimer.Stop();
                coins++;
                win++;
                coinslbl.Text = "MONEDE: " + coins.ToString();
                label2.Text =  "Victorii: " + win.ToString();
                pictureBox5.Visible = true;
                btn_buy.Enabled = false;
            }
        }

        //initializare
        private void Form1_Load(object sender, EventArgs e)
        {
            loadwords();
            setupWordChoice();
            min.Parent = pictureBox2;
            min.BackColor = Color.Transparent;
            pct.Parent = pictureBox2;
            pct.BackColor = Color.Transparent;
            sec.Parent = pictureBox2;
            sec.BackColor = Color.Transparent;
            lblShowWord.Parent = pictureBox2;
            lblShowWord.BackColor = Color.Transparent;
            coinslbl.Parent = pictureBox2;
            coinslbl.BackColor = Color.Transparent;
            pictureBox2.Controls.Add(pictureBox1);
            pictureBox1.BackColor = Color.Transparent;
            MenuStrip1.Parent = pictureBox2;
            MenuStrip1.BackColor = Color.Transparent;
            pictureBox2.Controls.Add(pbTime);
            pbTime.BackColor = Color.Transparent;
            pictureBox2.Controls.Add(pictureBox3);
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Controls.Add(pictureBox4);
            pictureBox4.BackColor = Color.Transparent;
            label2.Parent = pictureBox3;
            label2.BackColor = Color.Transparent;
            panel1.Enabled = false;
            panel1.Parent = pictureBox2;
            panel1.BackColor = Color.Transparent;
            pictureBox3.Controls.Add(pictureBox5);
            pictureBox5.BackColor = Color.Transparent;
            btn_buy.Parent = pictureBox3;
        }

        //iesire-meniu
        private void iesire_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Ești sigur că vrei să părăsești jocul ?", "Ieșire", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                Application.Exit();
        }

        //functie resetare
        private void reset()
        {
            systemTimer.Start();
            loadwords();
            min.Text = "1";
            sec.Text = "00";
            setupWordChoice();
            int i;
            for (i = 1; i <= 31; i++)
                cmd[i].Enabled = true;
            amount = 0;
            ok = 0;
            pictureBox3.Image = null;
            pictureBox2.Invalidate();
            variables.timer_1 = 60;
            pictureBox3.Image = Image.FromFile("HP.gif");
            timer_hp.Start();
            panel1.Enabled = false;
            pictureBox5.Visible = false;
            nr = 0;
        }

        //meniu
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            systemTimer.Stop();
            variables.timer_1 = 60;
            this.Hide();
            Form f = new Form2();
            f.Show();
        }

        //timer_joc
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            variables.timer_1--;
            if (variables.timer_1 >= 0)
            {
                if (ok==1 && amount != 9 && copyCurrent != current)
                {
                    min.Text = (variables.timer_1 / 60).ToString();
                    if (variables.timer_1 % 60 < 10)
                        sec.Text = ("0" + variables.timer_1 % 60).ToString();
                    else
                        sec.Text = (variables.timer_1 % 60).ToString();
                }
                if (variables.timer_1 <= 5)
                    MenuStrip1.Enabled = false;

                if (variables.timer_1 == 0)
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
                    MessageBox.Show("Timpul a expirat !","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Hide();
                    Form f = new Form2();
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
                variables.timer_1 = variables.timer_1 + 10;
                ok = 1;
                time1 = 0;
                panel1.Enabled = true;
                if (coins >= 3)
                    btn_buy.Enabled = true;
                else
                    btn_buy.Enabled = false;
            }
        }
        //timer_head
        private void timer_head_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time2++;
            if (time2 == 12)
            {
                pictureBox3.Image = Image.FromFile("Head.png");
                variables.timer_1 = variables.timer_1 + 5;
                ok = 1;
                timer_head.Stop();
                time2 = 0;
                panel1.Enabled = true;
                if (coins >= 3)
                    btn_buy.Enabled = true;
                else
                    btn_buy.Enabled = false;
            }
        }
        //timer_eye_left
        private void timer_el_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time3++;
            if (time3 == 5)
            {
                pictureBox3.Image = Image.FromFile("Eye_left.png");
                variables.timer_1 = variables.timer_1 + 2;
                ok = 1;
                timer_el.Stop();
                time3 = 0;
                panel1.Enabled = true;
                if (coins >= 3)
                    btn_buy.Enabled = true;
                else
                    btn_buy.Enabled = false;
            }
        }
        //timer_eye_right
        private void timer_er_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time4++;
            if (time4 == 5)
            {
                pictureBox3.Image = Image.FromFile("Eye_right.png");
                variables.timer_1 = variables.timer_1 + 2;
                ok = 1;
                timer_er.Stop();
                time4 = 0;
                panel1.Enabled = true;
                if (coins >= 3)
                    btn_buy.Enabled = true;
                else
                    btn_buy.Enabled = false;
            }
        }
        //timer_mouth
        private void timer_m_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time5++;
            if (time5 == 8)
            {
                pictureBox3.Image = Image.FromFile("Mouth.png");
                variables.timer_1 = variables.timer_1 + 1;
                ok = 1;
                timer_m.Stop();
                time5 = 0;
                panel1.Enabled = true;
                if (coins >= 3)
                    btn_buy.Enabled = true;
                else
                    btn_buy.Enabled = false;
            }
        }
        //timer_body
        private void timer_b_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time6++;
            if (time6 == 18)
            {
                pictureBox3.Image = Image.FromFile("Body.png");
                variables.timer_1 = variables.timer_1 + 4;
                ok = 1;
                timer_b.Stop();
                time6 = 0;
                panel1.Enabled = true;
                if (coins >= 3)
                    btn_buy.Enabled = true;
                else
                    btn_buy.Enabled = false;
            }
        }
        //timer_arm_left
        private void timer_al_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time7++;
            if (time7 == 9)
            {
                pictureBox3.Image = Image.FromFile("Arm_left.png");
                variables.timer_1 = variables.timer_1 + 2;
                ok = 1;
                timer_al.Stop();
                time7 = 0;
                panel1.Enabled = true;
                if (coins >= 3)
                    btn_buy.Enabled = true;
                else
                    btn_buy.Enabled = false;
            }
        }
        //timer_arm_right
        private void timer_ar_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time8++;
            if (time8 == 9)
            {
                pictureBox3.Image = Image.FromFile("Arm_right.png");
                variables.timer_1 = variables.timer_1 + 2;
                ok = 1;
                timer_ar.Stop();
                time8 = 0;
                panel1.Enabled = true;
                if (coins >= 3)
                    btn_buy.Enabled = true;
                else
                    btn_buy.Enabled = false;
            }
        }
        //timer_leg_left
        private void timer_ll_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time9++;
            if (time9 == 5)
            {
                pictureBox3.Image = Image.FromFile("Leg_left.png");
                variables.timer_1 = variables.timer_1 + 2;
                ok = 1;
                timer_ll.Stop();
                time9 = 0;
                panel1.Enabled = true;
                if (coins >= 3)
                    btn_buy.Enabled = true;
                else
                    btn_buy.Enabled = false;
            }
        }
        //time_leg_right
        private void timer_lr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            time10++;
            if (time10 == 5)
            {
                pictureBox3.Image = Image.FromFile("Leg_right.png");
                variables.timer_1 = variables.timer_1 + 2;
                ok = 1;
                timer_lr.Stop();
                time10 = 0;
                panel1.Enabled = true;
                if (coins >= 3)
                    btn_buy.Enabled = true;
                else
                    btn_buy.Enabled = false;
                if (amount == 9)
                {
                    systemTimer.Stop();
                    variables.timer_1 = 0;
                    MessageBox.Show("Ai pierdut !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form f = new Form2();
                    f.Show();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //space pentru a continua (1)
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            rr=false;
            if (e.KeyCode == Keys.Space)
                rr=true;
        }
        //(2)
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rr == true && pictureBox5.Visible==true)
                reset();
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

        private void btn_buy_MouseHover(object sender, EventArgs e)
        {
            btn_buy.ForeColor = Color.White;
        }

        private void btn_buy_MouseLeave(object sender, EventArgs e)
        {
            btn_buy.ForeColor = Color.Black;
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
