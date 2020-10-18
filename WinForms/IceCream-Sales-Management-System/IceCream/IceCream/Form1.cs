using System;
using System.Drawing;
using System.Windows.Forms;

namespace IceCream
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MenuBox_Click(object sender, EventArgs e)
        {
            if(sideBar.Width == 250)
            {
                sideBar.Width = 80;
            }
            else
            {
                sideBar.Width = 250;
            }
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            if(reportLeftoverButton.Visible == false)
            {
                reportPeriodButton.Visible = true;
                reportSalesButton.Visible = true;
                reportDebtsButton.Visible = true;
                reportLeftoverButton.Visible = true;
            }
            else
            {
                reportPeriodButton.Visible = false;
                reportSalesButton.Visible = false;
                reportDebtsButton.Visible = false;
                reportLeftoverButton.Visible = false;
            }

            reportsButton.ForeColor = Color.FromArgb(218, 218, 220);
            reportsButton.Image = System.Drawing.Image.FromFile("C:\\Users\\khido\\OneDrive\\Документы\\GitHub\\Csharp\\WinForms\\IceCream-Sales-Management-System\\icons-white\\reports-icon.png");
        }

        private void PartnersButton_Click(object sender, EventArgs e)
        {
            partnersButton.Image = System.Drawing.Image.FromFile("C:\\Users\\khido\\OneDrive\\Документы\\GitHub\\Csharp\\WinForms\\IceCream-Sales-Management-System\\icons\\partners-icon1.png");
        }
    }
}
