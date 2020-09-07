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
        readonly Random randomizer = new Random();

        List<string> icons;

        // Points to the first Label control
        Label firstClicked;

        // Points to the second label contorl
        Label secondClicked;

        // Track the time of the game
        int timeTracker;

        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            // Reset ui attributes to initial values
            timeTracker = 0;
            timeCounter.Text = "0 seconds";

            // Assign values of the icons
            icons = new List<string>
            {
            "!", "!", "N", "N", ",", ",",
            "b", "b", "v", "v", "w", "w",
            "j", "j", "z", "z", "@", "@",
            "e", "e", "x", "x", "$", "$",
            "f", "f", "m", "m", "L", "L"
            };

            // set initial values to the clicked icons
            firstClicked = null;
            secondClicked = null;

            // Assign random value from icons
            // to each Label
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                // Check if the control is label and not belongs to timer part
                if (control is Label iconLabel)
                {
                    // Get random number between the length
                    // of the Icons collection
                    int random = randomizer.Next(icons.Count);
                    iconLabel.Text = icons[random];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(random);
                }
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            // Start the time counter
            if (timeCounter.Enabled)
            {
                timeCounter.Enabled = true;
                timer2.Start();
            }

            // The timer is only on after two non-matching
            // icons have een shown to the player,
            // so ignore any clicks if the timer is running
            if (timer1.Enabled == true)
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
                if (clickedLabel.ForeColor == Color.CadetBlue)
                    return;

                // If firstClicked is null, this is the first icon
                // change its color to CadetBlue and return

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.CadetBlue;

                    // Enable the timer, so if player takes
                    // more than 3 second to choose the second
                    // icon, to hide the first selection
                    timer3.Enabled = true;
                    timer3.Start();
                    return;
                }

                // If the player gets this far, the timer isn't
                // running and firstClicked isn't null
                // so this must be the second icon the player clicked
                // set its color to CadetBlue
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.CadetBlue;

                // If the player won the game
                // and decided to start a new one
                // stop the thread
                if (CheckForWin())
                    return;

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                // If the player get this far, the player
                // clicked two different icons, so start
                // the timer (which will wait 1/2 of a second
                // and then hide the icons)
                timer1.Start();

                // Disable countdown for the firstSelect icon
                timer3.Stop();
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

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timeTracker += 1;
            timeCounter.Text = $"{timeTracker} seconds";
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            // Check if the timer was triggered correctly
            // and there is a selected icon
            if (firstClicked != null)
                firstClicked.ForeColor = firstClicked.BackColor;

            // Reset the first clicked icon to null
            firstClicked = null;

            // Stop the timer until the next first selection
            timer3.Stop();
        }


        private bool CheckForWin()
        {
            // go through all of the labels in the TableLayoutPanel,
            // checking each one to see if its icon is matched

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Label iconLabel)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return false; ;
                    }
                }
            }

            timer2.Stop();

            // If the loop didn't return, it didn't
            // find any unmatched icons
            // That means the user won. Show a message and close the form
            MessageBox.Show($"Conguratilations, you've finished the game in {timeTracker} seconds.", "You matched all the icons!");

            // Ask the user if he wants to start a new game
            // if not, finish the application
            if (MessageBox.Show("Do you want to start a new game?", "Restart", MessageBoxButtons.YesNo) == DialogResult.Yes)
                AssignIconsToSquares();
            else
                Close();

            return true;
        }
    }
}
