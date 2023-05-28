using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockPaperScissors
{
    public partial class RockPaperScissors : Form
    {
        public RockPaperScissors rockpaperscissors;
        public TextBox usertxt; 

        //Variabler 
        int rounds = 3;
        int timerPerRound = 5;
        bool gameOver = false;

        //Där random sparas
        int randomNumber = 0;

        //Genererar randomnumber till objekt 
        Random rnd = new Random();
        string NBIChoice;
        string playerChoice;
        int playerScore;
        int NBIScore;

        //Array för CPU urval, 6 för att randomize mer 
        string[] CPUchoiceList = { "rock", "paper", "scissor","paper", "scissor", "rock", "Bosse" };

        //Metod för att möjligöra timer vid installation.
        public RockPaperScissors()
        {
            InitializeComponent();
           
            //Placeholder        
            countDownTimer.Enabled = true;
            playerChoice = "none";
            txtCountdown.Text = "4";
        }

        //Metoder för det olika knapparna.
        private void btnRock_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            playerChoice = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.paper;
            playerChoice = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.scissors;
            playerChoice = "scissor";
        }
        //Metod som gör att timern räknar ner.
        private void countDownTimerEvent(object sender, EventArgs e)
        {
            timerPerRound -= 1;
            txtCountdown.Text = timerPerRound.ToString();
            txtRounds.Text = "Rounds: " + rounds;

            //För att stoppa timern från att börja räkna ner på 0 . -1 . -2 etc
            if (timerPerRound == 0)
            {
                countDownTimer.Enabled = false;
                timerPerRound = 5;

                //Randomize bilden för CPU 
                randomNumber = rnd.Next(0, CPUchoiceList.Length);
                NBIChoice = CPUchoiceList[randomNumber];


                //Switchcase för de olika bilderna för NBI 

                switch (NBIChoice)
                {
                    case "rock":
                        picNBI.Image = Properties.Resources.rock;

                        break;
                    case "paper":
                        picNBI.Image = Properties.Resources.paper;

                        break;
                    case "scissor":
                        picNBI.Image = Properties.Resources.scissors;

                        break;

                        //Sätter upp bosses bild
                    case "Bosse":
                        picNBI.Image = Properties.Resources.Bosse;
                        picNBI.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                }

                //if statement för om det finns rundor kvar eller om någon har vunnit
                if (rounds > 0) //här 

                {
                    checkGame();   

                }

                else 
                {
                    finishGame();
                    txtScore.Text = "Player: " + playerScore + " - " + "NBI: " + NBIScore;
                    //Startar med Bosse för att han ska vinna oavsett score
                    if (NBIChoice == "Bosse")
                    {

                        MessageBox.Show("You both loose, Bosse wins!");
                    }

                    //If-statement för om spelaren vinner över NBI
                    else if (playerScore > NBIScore)

                    {
                        MessageBox.Show("Player won this round!");
                    }

                    //If-statement för om speler bli oavgjort.
                    else if (playerScore == NBIScore)
                    {

                        MessageBox.Show("Nobody won this round!");
                    }

                    //Något sker här, score:en räknar inte upp och då blir parametrarna fel
                    else
                    {

                        MessageBox.Show("NBI won this round!");
                    }


                }
            }
        }


           //Funktion som kollar vem som vunnit och tilldelar poäng och kontrollräknar rundorna.
            private void checkGame()
            {
            

            //Bosses lösning för messagebox och score
            if (NBIChoice == "Bosse")
            {
                MessageBox.Show("You both loose, Bosse wins!");

                //Score sätts tillbaka till 0
                NBIScore = 0;
                playerScore = 0;
                rounds -= 1;
                
            }

            //När spelet blir oavgjort
            else if (NBIChoice == playerChoice)
            {
                MessageBox.Show("Draw");
                rounds -= 1;
                

            }

            //Rustar alla alternativ där datorn vinner över spelaren.
            else if (playerChoice == "rock" && NBIChoice == "paper" || playerChoice == "scissor" && NBIChoice == "rock"|| playerChoice == "paper" && NBIChoice == "scissor")
            {
                MessageBox.Show("NBI Wins");

                //Vinner datorn så ökas poängen
                NBIScore++;

                rounds -= 1; 

              
               


            }

            // Kommer upp om spelaren inte gör ett val
            else if (playerChoice == "none")
            {

                MessageBox.Show("Please choose.");
                rounds -= 1;
                

            }

            //Om spelaren vinner
            else
            { 
                MessageBox.Show("You win!");

                //Vinner spelaren så ökas poängen
                playerScore++;
                rounds -= 1;
                txtScore.Text = "Player: " + playerScore + " - " + "NBI: " + NBIScore;
            }
            
            startNextRound();
            }


        //Funktion för att fortsätta rundan 
        private void startNextRound()
        {
            
            if (gameOver == true)
            {
                txtScore.Text = "Player: " + playerScore + " - " + "NBI: " + NBIScore;
                return; 
                
            }

            txtScore.Text = "Player: " + playerScore + " - " + "NBI: " + NBIScore;
            playerChoice = "none";
            countDownTimer.Enabled = true;
            picPlayer.Image = Properties.Resources.Primary_1NBI_Handelsakademin_RGB;
            picNBI.Image = Properties.Resources.Primary_1NBI_Handelsakademin_RGB;
        }

        //När spelaren trycker på restart-knappen
        private void btnRestart_Click_1(object sender, EventArgs e)
        {
            playerScore = 0;
            NBIScore = 0;
            rounds = 3;
            txtScore.Text = "Player: " + playerScore + " - " + "NBI: " + NBIScore;

            playerChoice = "none";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.Primary_1NBI_Handelsakademin_RGB;
            picNBI.Image = Properties.Resources.Primary_1NBI_Handelsakademin_RGB;

            gameOver = false;
        }


        //Knapp för att stänga ner spelet.
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RockPaperScissors_Load(object sender, EventArgs e)
        {
            label1.Text = IntroPage.NamePlayer; 

        }

        //Funktion för att stänga hela programmet
        private void RockPaperScissors_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void finishGame()
        {
            //Bosses lösning för messagebox och score
            if (NBIChoice == "Bosse")
            {
                MessageBox.Show("You both loose, Bosse wins!");

                //Score sätts tillbaka till 0
                NBIScore = 0;
                playerScore = 0;
                txtScore.Text = "Player: " + playerScore + " - " + "NBI: " + NBIScore;
            }

            //Rustar alla alternativ där datorn vinner över spelaren.
            else if (playerChoice == "rock" && NBIChoice == "paper" || playerChoice == "scissor" && NBIChoice == "rock" || playerChoice == "paper" && NBIChoice == "scissor")
            {
            

                //Vinner datorn så ökas poängen
                NBIScore++;
                txtScore.Text = "Player: " + playerScore + " - " + "NBI: " + NBIScore;

            }    

            //Om spelaren vinner
            else
            {
             
                //Vinner spelaren så ökas poängen
                playerScore++;            
                txtScore.Text = "Player: " + playerScore + " - " + "NBI: " + NBIScore;
            }
            txtScore.Text = "Player: " + playerScore + " - " + "NBI: " + NBIScore;
        }

    }
}
