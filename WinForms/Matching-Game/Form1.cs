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

        // Points to the first Label control
        Label firstClicked = null;

        // Points to the second label contorl
        Label secondClicked = null;

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
                    iconLabel.ForeColor = Color.Blue;
                    icons.RemoveAt(random);
                }
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            // The timer is only on after two non-matching
            // icons have een shown to the player,
            // so ignore any clicks if the timer is running
            if(timer1.Enabled == true)
                return;

            // If secondClicked is not null, the player has
            // already clicked twice and the game
            // has not yet reset -- ignore click
            if (secondClicked != null)
                return;

            if (sender is Label clickedLabel)
            {

                // If the clicked label is black, the player
                // clicked an icon that's already been revealed
                // ignore click
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                // If firstClicked is null, this is the first icon
                // change its color to black and return

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }

                // If the player gets this far, the timer isn't
                // running and firstClicked isn't null
                // so this must be the second icon the player clicked
                // set its color to black
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                if(firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                // If the player get this far, the player
                // clicked two different icons, so start
                // the timer (which will wait 3/4 of a second
                // and then hide the icons)
                timer1.Start();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            // Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Reset firstClicked and secondClicked
            // to let program recognize it's first click again
            firstClicked = null;
            secondClicked = null;
        }
    }
}
