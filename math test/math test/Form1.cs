using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace math_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Create a Random object called randomizer 
        // to generate random numbers.
        Random randomizer = new Random();


        // This integer variable keeps track of the 
        // remaining time.
        int timeLeft;

        // These integer variables store the numbers 
        // for the addition problem. 
        int addend1;
        int addend2;

        // These integer variables store the numbers 
        // for the subtraction problem. 
        int minuend;
        int subtrahend;

        // These integer variables store the numbers 
        // for the multiplication problem. 
        int multiplicand;
        int multiplier;

        // These integer variables store the numbers 
        // for the division problem. 
        int dividend;
        int divisor;

        //number of times you got the test correct and the number of tests ur taken
        int cor = 0;
        int all = 0;
       
        


        public void StartTheQuiz()
        {
            // Fill in the addition problem.
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers
            // into strings so that they can be displayed
            // in the label controls.
            plusleftlabel.Text = addend1.ToString();
            plusrightlabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // Fill in the subtraction problem.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusleftlabel.Text = minuend.ToString();
            minusrightlabel.Text = subtrahend.ToString();
            differance.Value = 0;

            // Fill in the multiplication problem.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            productleftlabel.Text = multiplicand.ToString();
            productrightlabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the quotient problem.
            divisor = randomizer.Next(2, 11);
            int temporerydiv = randomizer.Next(2, 11);
            dividend = divisor * temporerydiv;
            quotientleftlabel.Text = dividend.ToString();
            quotientrightlabel.Text = divisor.ToString();
            quotient.Value = 0;



            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        // pressing the start button
        private void startbutton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            //disable the start button
            startbutton.Enabled = false;
            //restore the ccolor of the timer label in case it had been turned red
            timeLabel.BackColor = Color.Transparent;
            all = all + 1;

        }


        //what happens each time the cloack ticks (in our case 1000ms=1sec witch can change from timer1 properties :interval)
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                cor = cor + 1;
                string precentwin = "Bravo! this makes " + cor.ToString()+ " out of " + all.ToString();
                MessageBox.Show(precentwin, "You answered correctly!");
                startbutton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                string precentloss = "Sorry! this drops your score to " + cor.ToString() + " out of " + all.ToString();
                MessageBox.Show( precentloss,"You didn't finish in time.");
                sum.Value = addend1 + addend2;
                differance.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                //enable the start button again
                startbutton.Enabled = true;

            }
            if (timeLeft < 6)
            {
                timeLabel.BackColor = Color.Red;
            }
        }


        //checks the values the user inputs against the answers
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (minuend - subtrahend == differance.Value)
                && (dividend / divisor == quotient.Value) && (multiplier * multiplicand == product.Value))
                return true;
            else
                return false;

        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lenghtofanswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lenghtofanswer);
            }

        }



        //making the sound effect for each one of the boxes
        //substitution box
        private void pingmesub(object sender, EventArgs e)
        {
            NumericUpDown answerbox = sender as NumericUpDown;
            if (answerbox.Value == minuend - subtrahend)
            {
                SoundPlayer correctsound = new SoundPlayer(@"E:\Correct.wav");
                correctsound.Play();
            }
        }
        //multiplication box
        private void pingmulti(object sender, EventArgs e)
        {
            NumericUpDown answerbox = sender as NumericUpDown;
            if (answerbox.Value == multiplicand * multiplier)
            {
                SoundPlayer correctsound = new SoundPlayer(@"E:\Correct.wav");
                correctsound.Play();
            }
        }
        //quotient box
        private void pingmediv(object sender, EventArgs e)
        {
            NumericUpDown answerbox = sender as NumericUpDown;
            if (answerbox.Value == dividend / divisor)
            {
                SoundPlayer correctsound = new SoundPlayer(@"E:\Correct.wav");
                correctsound.Play();
            }
        }
        //summetion box
        private void pingmesum(object sender, EventArgs e)
        {
            NumericUpDown answerbox = sender as NumericUpDown;
            if (answerbox.Value == addend1 + addend2)
            {
                SoundPlayer correctsound = new SoundPlayer(@"E:\Correct.wav");
                correctsound.Play();
            }
        }
    }
}