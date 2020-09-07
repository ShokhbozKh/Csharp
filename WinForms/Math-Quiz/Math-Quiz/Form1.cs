using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        // To generate random numbers
        Random randomizer = new Random();

        // For addition problems
        int add1;
        int add2;

        // For substraction problems
        int sub1;
        int sub2;

        // For multiplication problems
        int mul1;
        int mul2;

        // For division problems
        int div1;
        int div2;

        // Timer tracker
        int timeLeft;
        public Form1()
        {
            InitializeComponent();
        }

        // Begin the quiz
        public void StartQuiz()
        {
            // Set values for the addition part
            add1 = randomizer.Next(51);
            add2 = randomizer.Next(51);

            // Set values of the Add labels
            plusLeftLabel.Text = add1.ToString();
            plusRightLabel.Text = add2.ToString();

            // Set the initial answer to 0
            sum.Value = 0;

            // Set values for the substraction part
            sub1 = randomizer.Next(1, 101);
            sub2 = randomizer.Next(1, sub1);

            // Set values of the Substract labels
            minusLeftLabel.Text = sub1.ToString();
            minusRightLabel.Text = sub2.ToString();

            // Set the initial answer to 0
            difference.Value = 0;

            // Set values for the multiplication part
            mul1 = randomizer.Next(2, 11);
            mul2 = randomizer.Next(2, 11);

            // Set values for the Multiplication Labels
            timesLeftLabel.Text = mul1.ToString();
            timesRightLabel.Text = mul2.ToString();

            // Set the initial answer to 0
            product.Value = 0;

            // Set values for the division part
            // get the value of divisor first
            // and multiply random by it for divinded
            div2 = randomizer.Next(2, 11);
            div1 = randomizer.Next(2, 11) * div2;

            // Set values for the Division Lables
            divideLeftLabel.Text = div1.ToString();
            divideRightLabel.Text = div2.ToString();

            // Set the initial answer to 0
            quotient.Value = 0;

            // Start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        // Check the answer
        public bool CheckTheAnswer()
        {
            if ((add1 + add2 == sum.Value)
                && (sub1 - sub2 == difference.Value)
                && (mul1 * mul2 == product.Value)
                && (div1 / div2 == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        private void Button1_Click(object sender, EventArgs e)
        {
            StartQuiz();
            startButton.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If answer is correct, stop the quiz
                // and show message box
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Conguratilations");
                startButton.Enabled = true;
            }
            else if(timeLeft > 0)
            {
                // Display new time left
                // update the Time Left Label
                timeLeft -= 1;
                timeLabel.Text = $"{timeLeft} seconds";

                // If less than 5 seconds left
                // set borders to red
                if(timeLeft < 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                // If the user ran out of time, stop the timer,
                // show message box and fill the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = add1 + add2;
                difference.Value = sub1 - sub2;
                product.Value = mul1 * mul2;
                quotient.Value = div1 / div2;
                startButton.Enabled = true;
                timeLabel.BackColor = Color.White;
            }

        }

        private void Answer_Enter(object sender, EventArgs e)
        {
            if(sender is NumericUpDown answerBox)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);            
            }
        }

        private void Check_Sum(object sender, EventArgs e)
        {
            if (add1 + add2 == sum.Value)
                sum.BackColor = Color.Green;
            else
                sum.BackColor = Color.Red;
        }

        private void Check_Difference(object sender, EventArgs e)
        {
            if (sub1 - sub2 == difference.Value)
                difference.BackColor = Color.Green;
            else
                difference.BackColor = Color.Red;
        }

        private void Check_Product(object sender, EventArgs e)
        {
            if (mul1 * mul2 == product.Value)
                product.BackColor = Color.Green;
            else
                product.BackColor = Color.Red;
        }

        private void Check_Quotient(object sender, EventArgs e)
        {
            if (div1 / div2 == quotient.Value)
                quotient.BackColor = Color.Green;
            else
                quotient.BackColor = Color.Red;
        }
    }
}
