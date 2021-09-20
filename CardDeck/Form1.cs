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
        }

        public void ShowDeck()
        {
            showLabel.Text = "";
            for (int i = 0; i < deck.Count; i++)
            {
                showLabel.Text += $"{deck[i]} ";
            }
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
        }

        private void dealButton_Click(object sender, EventArgs e)
        {
            ///Deal 5 cards each to dealer and player and display them.
            ///This can be done by using a for loop that runs 5 times,
            ///and each time it adds to the playerCards list a card from 
            ///the deck list, and then removes that card from the deck
            ///list. It then adds to the dealerCards list a card from the
            ///deck list, and then removes that card from the deck list.
            ///
            ///Run the ShowDeck() method

            for (int i = 0; i < 5; i++)
            {
                playerCards.Add(deck[0]);
                deck.RemoveAt(0);

                dealerCards.Add(deck[0]);
                deck.RemoveAt(0);
            }

            dealerCardsLabel.Text = "";
            playerCardsLabel.Text = "";

            for (int i = 0; i < playerCards.Count; i++)
            {
                dealerCardsLabel.Text += $"{dealerCards[i]} ";
                playerCardsLabel.Text += $"{playerCards[i]} ";
            }

            ShowDeck();
        }

        private void collectButton_Click(object sender, EventArgs e)
        {
            ///Put player and dealer cards back into the deck. You will
            ///need to use the AddRange() behaviour to grab from the 
            ///playerCards and the dealerCards lists, and then place 
            ///those cards back to the deck list. 
            ///            
            ///Run the ShowDeck() method
        }
    }
}
