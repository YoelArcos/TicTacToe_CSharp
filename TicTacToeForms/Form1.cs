using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeForms
{
    public partial class TicTacToc_MainScreen : Form
    {
        bool playerTurn = true;
        int gamesPlayed = 0;
        public TicTacToc_MainScreen()
        {
            InitializeComponent();
        }
      
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == "" )
            {
                btn.Text = playerTurn ? "X" : "O";
                playerTurn = !playerTurn;
                
            }
            CheckForWinner();
            label_gamesPlayed.Text = gamesPlayed++.ToString();

            
        }

        private void CheckForWinner()
        {

            // Definiere die möglichen Gewinnkombinationen
            int[,] winCombinations = new int[,]
            {   //a //b //c
                {0, 1, 2}, // Erste Zeile
                {3, 4, 5}, // Zweite Zeile
                {6, 7, 8}, // Dritte Zeile
                {0, 3, 6}, // Erste Spalte
                {1, 4, 7}, // Zweite Spalte
                {2, 5, 8}, // Dritte Spalte
                {0, 4, 8}, // Erste Diagonale
                {2, 4, 6}  // Zweite Diagonale
            };

            for (int i = 0; i < 8; i++)
            {
                int a = winCombinations[i, 0];
                int b = winCombinations[i, 1];
                int c = winCombinations[i, 2];

                

                Button b1 = this.Controls["button" + (a + 1).ToString()] as Button;
                Button b2 = this.Controls["button" + (b + 1).ToString()] as Button;
                Button b3 = this.Controls["button" + (c + 1).ToString()] as Button;

               


                if (b1.Text == "" || b2.Text == "" || b3.Text == "") continue; // Überspringe, wenn einer der Buttons leer ist

                if (b1.Text == b2.Text && b2.Text == b3.Text)
                {
                    // Ein Gewinner wurde gefunden
                    MessageBox.Show("Der Gewinner ist " + b1.Text);
                    disableButtons();
                    break; // Beende die Schleife, nachdem ein Gewinner gefunden wurde
                }
            }
        }

        private void disableButtons()
        {
            // Durchlaufe alle Controls und deaktiviere alle Buttons
            foreach (Control c in Controls)
            {
                Button b = c as Button;
                if (b != null)
                {
                    b.Enabled = false; // Deaktiviere den Button
                }
            }
        }

        private void TicTacToc_MainScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
