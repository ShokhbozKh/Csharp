using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            Button butt1 = new Button();
            Button butt2 = new Button();
            Button butt3 = new Button();
            Button butt4 = new Button();
            Button butt5 = new Button();
            Button butt6 = new Button();

            Button[] buttons = new Button[] { butt1, butt2, butt3, butt4, butt5, butt6 };
            int count = 1;
            foreach(Button but in buttons)
            {
                if(count == 4)
                {
                    but.Text = $"but {count}";
                    but.BackColor = Color.AliceBlue;
                    but.Click += (object sender, EventArgs e) => MessageBox.Show(but.Text);

                    tableLayoutPanel2.Controls.Add(but, 3, 3);
                    tableLayoutPanel2.BackColor = Color.Yellow;
                    count++;

                    continue;
                }
                but.Text = $"but {count}";
                but.BackColor = Color.AliceBlue;
                but.Click += (object sender, EventArgs e) => MessageBox.Show(but.Text);

                tableLayoutPanel2.Controls.Add(but);
                tableLayoutPanel2.BackColor = Color.Yellow;
                count++;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
