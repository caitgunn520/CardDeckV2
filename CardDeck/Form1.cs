using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardDeck
{
    public partial class Form1 : Form
    {
        //standard deck of cards
        List<string> deck = new List<string>();

        List<string> playerCards = new List<string>();
        List<string> dealerCards = new List<string>();

        public Form1()
        {
            InitializeComponent();

            //fill deck with standard 52 cards
            //H - Hearts, D - Diamonds, C - Clubs, S - Spades
            
            deck.AddRange(new string[] { "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "10H", "JH", "QH", "KH", "AH" });
            deck.AddRange(new string[] { "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "10D", "JD", "QD", "KD", "AD" });
            deck.AddRange(new string[] { "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "10C", "JC", "QC", "KC", "AC" });
            deck.AddRange(new string[] { "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "JS", "QS", "KS", "AS" });

            ShowDeck();

            //disable all buttons except for Shuffle button
            EnableButton(shuffleButton);
            DisableButton(dealButton);
            DisableButton(collectButton);
        }

        public void ShowDeck()
        {
            showLabel.Text = "";
            for (int i = 0; i < deck.Count; i++)
            {
                showLabel.Text += $"{deck[i]} ";
            }
        }

        public void DealCards(List<string> hand, Label handLabel)
        {
            for (int i = 0; i < 5;  i++)
            {
                hand.Add(deck[0]);
                deck.RemoveAt(0);
            }

            handLabel.Text = "";
            
            for (int i = 0; i < hand.Count; i++)
            {
                handLabel.Text += $"{hand[i]} ";
            }
        }

        public void EnableButton (Button button)
        {
            button.Enabled = true;
            button.BackColor = Color.GreenYellow;
        }

        public void DisableButton (Button button)
        {
            button.Enabled = false;
            button.BackColor = Color.LightGray;
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
            List<string> deckTemp = new List<string>();
            Random randGen = new Random();

            while (deck.Count > 0)
            {
                int index = randGen.Next(0, deck.Count);
                deckTemp.Add(deck[index]);
                deck.RemoveAt(index);
            }

            deck = deckTemp;

            ShowDeck();

            //enable deal button and disable shuffle button
            EnableButton(dealButton);
            DisableButton(shuffleButton);
        }

        private void dealButton_Click(object sender, EventArgs e)
        {
            DealCards(dealerCards, dealerCardsLabel);
            DealCards(playerCards, playerCardsLabel);
            
            ShowDeck();

            //enable collect button and disable deal button
            EnableButton(collectButton);
            DisableButton(dealButton);
        }

        private void collectButton_Click(object sender, EventArgs e)
        {
            ///Put player and dealer cards back into the deck. You will
            ///need to use the AddRange() behaviour to grab from the 
            ///playerCards and the dealerCards lists, and then place 
            ///those cards back to the deck list. 
            ///            
            ///Run the ShowDeck() method

            deck.AddRange(dealerCards);
            deck.AddRange(playerCards);

            dealerCards.Clear();
            playerCards.Clear();

            ShowDeck();
            dealerCardsLabel.Text = "";
            playerCardsLabel.Text = "";

            //enable shuffle button and disable collect button
            EnableButton(shuffleButton);
            DisableButton(collectButton);
        }
    }
}
