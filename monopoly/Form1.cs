using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace monopoly
{
    
    public partial class Form1 : Form
    {
        


        public class Land
        {
            int order;
            public int price;
            public string name;
            public string owner;
            public int locationX;
            public int locationY;
            

            public Land(int order, int price, string name, int x, int y, string owner = "Unoccupied")
            {
                this.order = order;
                this.price = price;
                this.name = name;
                this.owner = owner;
                this.locationX = x;
                this.locationY = y;
            }
            

        }
        Land free1 = new Land(0, 0, "free", 874, 249);
        Land free2 = new Land(0, 0, "free", 453, 68);
        Land free3 = new Land(0, 0, "free", 32, 249);
        Land free4 = new Land(0, 0, "free", 452, 522);

        Land hotel1 = new Land(1, 200, "mazoon diary", 874, 430);
        Land Gas1 = new Land(2, 5000, "National Bank", 874, 338);
        Land House1 = new Land(3, 750, "Mazoon Electric", 874, 157);
        Land Bank1 = new Land(4, 500, "Small", 874, 68);
        Land water1 = new Land(5, 900, "Bank Muscat", 733, 68);
        Land electric1 = new Land(6, 75, "Khedmah", 594, 68);

        Land hotel2 = new Land(7, 350, "Hayat", 312, 68);
        Land Gas2 = new Land(8, 5000, "In Mubaylah", 171, 68);
        Land House2 = new Land(9, 7500, "Big", 32, 68);
        Land Bank2 = new Land(10, 500, "Crown Plaza", 32, 160);
        Land water2 = new Land(11, 1250, "In Suwaiq", 32, 341);
        Land electric2 = new Land(12, 500, "Oman Electric", 32, 430);

        Land hotel3 = new Land(13, 500, "5 stars", 32, 522);
        Land Gas3 = new Land(14, 50, "Bank Dhofar", 172, 522);
        Land House3 = new Land(15, 250, "1 room", 311, 522);
        Land Bank3 = new Land(16, 6000, "Qeen Palace", 593, 522);
        Land water3 = new Land(17, 25000, "In Salalah", 733, 522);
        Land electric3 = new Land(18, 122, "In Salalah", 32, 430);

       

        Random rand = new Random();
        bool turn; // turn of players
        int redPosition;
        int bluePosition;
        int redBalance;
        int blueBalance;
        public string RedplayerName;
        public string BlueplayerName;
        Land[] arrayOfLands;
        Land currentLand;

        public int computePosition(int newSteps, int oldPosition, bool turn)
        {
            int newPosition = newSteps + oldPosition;
            if(newPosition > 21)
            {
                newPosition -= 21;
                if (turn)
                {
                    redBalance += 3000;
                }
                else
                {
                    blueBalance += 3000;
                }
            }

            return newPosition;
        }
        public void checkWinner()
        {
            if(redBalance >= 30000)
            {
                timer1.Stop();
                var result = MessageBox.Show("red Wins the game", "dfdsfd",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.None);
                if(result == DialogResult.OK)
                {
                    restartGame();
                }

            }else if(blueBalance > 30000)
            {
                timer1.Stop();
                var result = MessageBox.Show("red Wins the game", "dfdsfd",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.None);
                if (result == DialogResult.OK)
                {
                    restartGame();
                }
            }else if(redBalance < 0)
            {
                timer1.Stop();
                var result = MessageBox.Show("red player lost the game, Blue wins", "dfdsfd",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.None);
                if (result == DialogResult.OK)
                {
                    restartGame();
                }
            }
            else if (blueBalance < 0)
            {
                timer1.Stop();
                var result = MessageBox.Show("blue player lost the game,Red wins", "dfdsfd",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.None);
                if (result == DialogResult.OK)
                {
                    restartGame();
                }
            }
        }
        public void RentOrPenalty(bool turn, Land Current) {
            if (turn && Current.owner == "Red player")
            {
                redBalance += currentLand.price;
            }else if(turn && Current.owner == "Blue player")
            {
                redBalance = (int)(redBalance * 0.5);
            }else if(!turn && Current.owner == "Blue player")
            {
                blueBalance += Current.price;
            }
            else if (!turn && Current.owner == "Red player")
            {
                blueBalance = (int)(blueBalance * 0.5);
            }
        }
        
        public void restartGame()
        {
            Application.Restart();
           
        }
        public Form1()
        {
            InitializeComponent();
            Form2 f2 = new Form2();
            f2.StartPosition = FormStartPosition.CenterParent;
            f2.ShowDialog(this);
            RedplayerName = f2.Controls.Find("RedplayerName", false)[0].Text;
            BlueplayerName = f2.Controls.Find("BlueplayerName", false)[0].Text;

                   
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            blue.Left -= 150;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            int throwDice = rand.Next(1, 7);
            Dice.Text = throwDice.ToString();

            if (turn)
            {

                redPosition = computePosition(throwDice, redPosition, turn);
                Land landToVisit = arrayOfLands[redPosition-1];
                currentLand = landToVisit;
                red.Location = new Point(landToVisit.locationX+10, landToVisit.locationY+10);
                RentOrPenalty(turn, currentLand);
                endRound.Enabled = true;
                diceButton.Enabled = false;
            }
            else
            {
                bluePosition = computePosition(throwDice, bluePosition, turn);
                Land landToVisit = arrayOfLands[bluePosition - 1];
                currentLand = landToVisit;
                RentOrPenalty(turn, currentLand);
                blue.Location = new Point(landToVisit.locationX + 40, landToVisit.locationY + 10);
                endRound.Enabled = true;
                diceButton.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            arrayOfLands = new Land[]{ hotel1, Gas1, free1, House1, Bank1, water1, electric1, free2, hotel2, Gas2, House2, Bank2, free3, water2, electric2, hotel3, Gas3, House3, free4, Bank3, water3, electric3 };
            turn = Convert.ToBoolean(rand.NextDouble() >= 0.5);// if true it is red if false it is blue
            redBalance = 2500;//starting balance
            blueBalance = 2500;//starting balance
            redPosition = 0;
            bluePosition = 0;


            land1name.Text = hotel1.name;
            land1owner.Text = "Unoccupied";
            land1price.Text = hotel1.price.ToString();

            land2name.Text = Gas1.name;
            land2owner.Text = "Unoccupied";
            land2price.Text = Gas1.price.ToString();

            land3name.Text = House1.name;
            land3owner.Text = "Unoccupied";
            land3price.Text = House1.price.ToString();

            land4name.Text = Bank1.name;
            land4owner.Text = "Unoccupied";
            land4price.Text = Bank1.price.ToString();

            land5name.Text = water1.name;
            land5owner.Text = "Unoccupied";
            land5price.Text = water1.price.ToString();

            land6name.Text = electric1.name;
            land6owner.Text = "Unoccupied";
            land6price.Text = electric1.price.ToString();

            ///
            land7name.Text = hotel2.name;
            land7owner.Text = "Unoccupied";
            land7price.Text = hotel2.price.ToString();

            land8name.Text = Gas2.name;
            land8owner.Text = "Unoccupied";
            land8price.Text = Gas2.price.ToString();

            land9name.Text = House2.name;
            land9owner.Text = "Unoccupied";
            land9price.Text = House2.price.ToString();

            land10name.Text = Bank2.name;
            land10owner.Text = "Unoccupied";
            land10price.Text = Bank2.price.ToString();

            land11name.Text = water2.name;
            land11owner.Text = "Unoccupied";
            land11price.Text = water2.price.ToString();

            land12name.Text = electric2.name;
            land12owner.Text = "Unoccupied";
            land12price.Text = electric2.price.ToString();
            //
            land13name.Text = hotel3.name;
            land13owner.Text = "Unoccupied";
            land13price.Text = hotel3.price.ToString();

            land14name.Text = Gas3.name;
            land14owner.Text = "Unoccupied";
            land14price.Text = Gas3.price.ToString();

            land15name.Text = House3.name;
            land15owner.Text = "Unoccupied";
            land15price.Text = House3.price.ToString();

            land16name.Text = Bank3.name;
            land16owner.Text = "Unoccupied";
            land16price.Text = Bank3.price.ToString();

            land17name.Text = water3.name;
            land17owner.Text = "Unoccupied";
            land17price.Text = water3.price.ToString();


            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            turnLabel.Text = turn ? "RED(" + RedplayerName + ")" : "Blue(" + BlueplayerName + ")";
            redMoney.Text = redBalance.ToString();
            blueMoney.Text = blueBalance.ToString();
            land1owner.Text = hotel1.owner;
            land2owner.Text = Gas1.owner;
            land3owner.Text = House1.owner;
            land4owner.Text = Bank1.owner;
            land5owner.Text = water1.owner;
            land6owner.Text = electric1.owner;
            land7owner.Text = hotel2.owner;
            land8owner.Text = Gas2.owner;
            land9owner.Text = House2.owner;
            land10owner.Text = Bank2.owner;
            land11owner.Text = water2.owner;
            land12owner.Text = electric2.owner;
            land13owner.Text = hotel3.owner;
            land14owner.Text = House3.owner;
            land15owner.Text = Bank3.owner;
            land16owner.Text = water3.owner;
            land17owner.Text = electric3.owner;

            if (currentLand != null)
            {
                if(currentLand.price == 0)
                {
                    buyButton.Enabled = false;
                    buyButton.Text = "Free land, can't buy";
                }
                else
                {
                    if (turn && redBalance < currentLand.price || !turn && blueBalance < currentLand.price)
                    {
                        buyButton.Enabled = false;
                        buyButton.Text = "No enough Balnce to buy";
                    }
                    else
                    {
                        buyButton.Enabled = true;
                        buyButton.Text = "BUY";
                    }
                }

                if (currentLand.owner != "Unoccupied" || currentLand == null)
                {
                    buyButton.Enabled = false;
                }
                landName.Text = currentLand.name;
                landPrice.Text = currentLand.price.ToString();
            }

            checkWinner();
        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void endRound_Click(object sender, EventArgs e)
        {
            turn = !turn;
            diceButton.Enabled = true;
            currentLand = null;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            if(currentLand != null && currentLand.owner == "Unoccupied")
            {
                if (turn)
                {
                    redBalance -= currentLand.price;
                    currentLand.owner = "Red player";

                }
                else
                {
                    blueBalance -= currentLand.price;
                    currentLand.owner = "Blue player";
                }

            }
            


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void land5name_Click(object sender, EventArgs e)
        {

        }
    }
}
