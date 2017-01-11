using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matching_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AssigniconsToSquares();
        }

        // Use this Random object to choose random icons for the squares
        Random random = new Random();
        // Each of these letters is an interesting icon
        // in the Webdings font,
        // and each icon appears twice in this list
        List<string> icons = new List<string> { "!", "!", "N", "N", ",", ",", "k", "k", "b", "b", "v", "v", "w", "w", "z", "z", };


        Label clickedlabel1 = null;
        Label clickedlabel2 = null;

        private void checkforwinner()
        {
            foreach(Control labelz in tableLayoutPanel1.Controls)
            {
                Label checkz = labelz as Label;
                if (checkz.ForeColor == checkz.BackColor)
                {
                    return;
                }
            }
            MessageBox.Show("You got everything correct","CONGRATULATIONS!");
            Close();
        }

        private void AssigniconsToSquares()
        {
            // The TableLayoutPanel has 16 labels,
            // and the icon list has 16 icons,
            // so an icon is pulled at random from the list
            // and added to each label
            foreach (Control controlbs in tableLayoutPanel1.Controls)
            {
                Label iconlabel = controlbs as Label;
                if (iconlabel != null)
                {
                    int randomnum = random.Next(icons.Count);
                    iconlabel.Text = icons[randomnum];
                    // hiding the pictures i could have also used :
                    // iconlabel.Visible = false;
                    iconlabel.ForeColor = iconlabel.BackColor;
                    icons.RemoveAt(randomnum);
                }
                    
            }
        }


        //Every label's Click event is handled by this event handler
        private void label_click(object sender, EventArgs e)
        {
            Label clicklabel = sender as Label;
            if (clicklabel != null)
            {
                // If the clicked label is black, the player clicked
                // an icon that's already been revealed --
                // ignore the click
                if (clicklabel.ForeColor == Color.Black)
                {
                    return;
                }
                // If firstClicked is null, this is the first icon 
                // in the pair that the player clicked,
                // so set firstClicked to the label that the player 
                // clicked, change its color to black, and return
                if (clickedlabel1 == null)
                {
                    clickedlabel1 = clicklabel;
                    clickedlabel1.ForeColor = Color.Black;
                    return;
                }
                
               else if(clickedlabel2 == null) 
                {
                    clickedlabel2 = clicklabel;
                    clickedlabel2.ForeColor = Color.Black;
                    checkforwinner();
                    return;
                }
                 
                // if the text (so image) is not the same in both buffers we cleear the buffer label variables and reset  color 
                else if (clickedlabel1.Text != clickedlabel2.Text )
                {

                    clickedlabel1.ForeColor = clickedlabel1.BackColor;
                    clickedlabel2.ForeColor = clickedlabel2.BackColor;
                    clickedlabel2 = null;
                    clickedlabel1 = null;
                    //here we will do as normal and assingn the new clicked label to cklickedlabel1
                    clickedlabel1 = clicklabel;
                    clickedlabel1.ForeColor = Color.Black;
                    return;
                }

                else
                {
                    clickedlabel2 = null;
                    clickedlabel1 = null;
                    clickedlabel1 = clicklabel;
                    clickedlabel1.ForeColor = Color.Black;
                    return;
                }
              
            }
        }
    }
}
