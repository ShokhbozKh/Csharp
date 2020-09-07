using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BackgroundButton_Click(object sender, EventArgs e)
        {
            // Show the oclor dialog box. If the user clicks OK, change the
            // PictureBox contro's background to the color the user chose.

            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            // Clear the picture
            pictureBox1.Image = null;
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            // Show the file dialog to user to select a picture
            // If a picture is selected load to the pictureBox
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Ask user if he wants to close the application
            bool isConfirmed = MessageBox.Show("Are you sure you want to close the application?", "Close the application", MessageBoxButtons.YesNo) == DialogResult.Yes;
            
            // If confirmed close the form
            if (isConfirmed)
            {
                Close();
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If user selects the Stretch check box
            // change the PictureBox's SizeMode property
            // to Stretch. If user clears the check box
            // change it to Normal

            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}
