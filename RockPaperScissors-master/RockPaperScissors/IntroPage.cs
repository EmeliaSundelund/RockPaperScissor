using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockPaperScissors
{
    public partial class IntroPage : Form
    {
        public IntroPage intropage;
        public static string NamePlayer = ""; 



        
        public IntroPage()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

            NamePlayer = textBox2.Text;
            //Detta skall ske när användaren klickar på knappen
            RockPaperScissors rockPaperScissors = new RockPaperScissors();
            //visa komponenten 
            rockPaperScissors.Show();
            //Dölja huvudfönstret 
            this.Hide();
            //Låt loginfönstret referera tillbaka till this aka huvudfönstret 
            //intropage.rock = this;
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
