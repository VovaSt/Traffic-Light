using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traffic_Light
{
    public partial class Form1 : Form
    {
        States CurrentState = States.RED;
        bool isMoveUp = true;
        bool isDelayRequeried = false;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            SolidBrush grayBrush = new SolidBrush(Color.Gray);

            int x = 38;
            int y = 38;
            int width = 60;
            int height = 60;

            e.Graphics.FillEllipse(grayBrush, x - 3, y - 3, width + 6, height + 6);
            e.Graphics.FillEllipse(grayBrush, x - 3, y - 3 + 80, width + 6, height + 6);
            e.Graphics.FillEllipse(grayBrush, x - 3, y - 3 + 160, width + 6, height + 6);

            if (CurrentState == States.RED)
            {
                e.Graphics.FillEllipse(redBrush, x, y, width, height);
            }
            else if (CurrentState == States.YELLOW)
            {
                e.Graphics.FillEllipse(yellowBrush, x, y + 80, width, height);
            }
            else if (CurrentState == States.GREEN)
            {
                e.Graphics.FillEllipse(greenBrush, x, y + 160, width, height);
            }           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            if (isDelayRequeried)
            {
                isDelayRequeried = false;
            }
            else
            {
                if (isMoveUp)
                {
                    CurrentState++;
                    if (CurrentState == States.GREEN)
                    {
                        isMoveUp = false;
                        isDelayRequeried = true;
                    }
                }
                else
                {
                    CurrentState--;
                    if (CurrentState == States.RED)
                    {
                        isMoveUp = true;
                        isDelayRequeried = true;
                    }
                }
            }
        }
    }

    enum States : int
    {
        RED,
        YELLOW,
        GREEN
    }
}
