using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Blink_effect
{
    public class BlinkingLabel
        : Label
    {
        Timer timer;
        public BlinkingLabel()
        {
            timer = new Timer();
            this.FirstColor = Color.Black;
            this.SecondColor = Color.Red;
            this.Interval = 1000;
            this.EnableBlinking = false;
            this.timer.Tick += new EventHandler(timer_Tick);

        }
        void timer_Tick(object sender, EventArgs e)
        {
            if ((Spânzurătoarea.variables.timer_1 <= 10 && Spânzurătoarea.variables.timer_1 != 0) || (Spânzurătoarea.variables.timer_2 <= 10 && Spânzurătoarea.variables.timer_2 != 0))
                if (this.ForeColor == this.FirstColor)
                    this.ForeColor = this.SecondColor;
                else
                    this.ForeColor = this.FirstColor;
        }

        [Category("Blinking Settings")]
        public Color FirstColor { get; set; }
        [Category("Blinking Settings")]
        public Color SecondColor { get; set; }
        [Category("Blinking Settings")]
        public int Interval
        {
            get { return this.timer.Interval; }
            set { this.timer.Interval = value; }
        }
        [Category("Blinking Settings")]
        public bool EnableBlinking
        {
            get { return this.timer.Enabled; }
            set { this.timer.Enabled = value; }
        }
    }
}
