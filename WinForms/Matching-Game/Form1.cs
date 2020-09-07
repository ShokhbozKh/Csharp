using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        List<string> icons = new List<string>
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            // Assign random value from icons
            // to each Label

            foreach(Control control in tableLayoutPanel1.Controls)
            {
                if (control is Label iconLabel)
                {
                    // Get random number between the length
                    // of the Icons collection

                    int random = randomizer.Next(icons.Count);
                    iconLabel.Text = icons[random];

                    icons.RemoveAt(random);
                }
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if(clickedLabel != null)
            {
                // If the clicked label is black, the player
                // clicked an icon that's already been revealed
                // ignore click

                if(clickedLabel.ForeColor == Color.Black)
                    return;

                clickedLabel.ForeColor = Color.Black;
            }
        }
    }
}
