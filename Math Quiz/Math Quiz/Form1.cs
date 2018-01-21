using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int addend1, addend2;
        int minuend, subtrahend;
        int multiplicand, multiplier;
        int dividend, divisor;
        int timeLeft;

        public void StartTheQuiz()
        {
            //Numbers to be used in the addition problem - Randomly generated
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //Convert numbers to a string to show on display
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            Sum.Value = 0;

            //Numbers to be used in the subraction problem 
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);

            //Convert numbers to a string to show on display
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            difference.Value = 0;

            //Numbers to be used for multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);

            //Convert numbers to a string to show on display
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            product.Value = 0;

            //Numbers to be used for division problem
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;

            //Convert numbers to a string to show on display
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();

            quotient.Value = 0;

            //Starting the Timer            
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        //Sound alerts when correct answer is entered     
        private void CorrectDifferenceAlert(object sender, EventArgs e)
        {
            if (difference.Value == minuend - subtrahend)
                SystemSounds.Beep.Play();
        }
        private void CorrectSumAlert(object sender, EventArgs e)
        {
            if (Sum.Value == addend1 + addend2)
                SystemSounds.Beep.Play();
        }
        private void CorrectProductAlert(object sender, EventArgs e)
        {
            if(product.Value == multiplicand * multiplier)
                SystemSounds.Beep.Play();
        }
        private void CorrectQuotientAlert(object sender, EventArgs e)
        {
            if (quotient.Value == dividend / divisor)
                SystemSounds.Beep.Play();
        }

        //Pressing the start button event
        private void startButton_Click_1(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void LoadDate(object sender, EventArgs e)
        {
            CurrentDateLabel.Text = DateTime.Today.ToString("dd MMMM yyyy");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //If the answer is correct, stop the timer and show a message box
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                if(timeLeft <= 6)
                {
                    timeLabel.BackColor = Color.Red;
                }

                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Times up!";
                timeLabel.BackColor = default(Color);
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                Sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == Sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        
    }
}
