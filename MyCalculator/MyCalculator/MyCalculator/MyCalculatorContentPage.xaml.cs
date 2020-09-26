/*
 Programmeur:   Ziad Biram
 Date:          29 Avril 2020
 But:           Devoir1_Calculatrice

 ContentPage xaml : MyCalculatorContentPage.xaml
 ContentPage xaml.cs : MyCalculatorContentPage.xaml.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCalculatorContentPage : ContentPage
    {
        #region Constructeur

        public MyCalculatorContentPage()
        {
            InitializeComponent();
        }
        #endregion

        #region Variable

        private string symbole;
        private string value;
        private double number;
        private double resultat = 0;
        private double numberNew = 0;
        private int compteurOperateur = 0;
        private string numEntryString;
        private Boolean initialisateur;
        private Boolean clearMainEntry;

        #endregion

        #region Number Clique
        public void Number_Click(object sender, EventArgs e)
        {
            try
            {
                numEntryString = (sender as Button).Text;
                if(initialisateur == true)
                {
                    historyEntry.Text = "";
                    numberEntry.Text = "0";
                    initialisateur = false;
                }
                if (clearMainEntry == true)
                {
                    numberEntry.Text = "0";
                    clearMainEntry = false;
                }

                if (numberEntry.Text == "0" && numberEntry.Text != null)
                {
                    numberEntry.Text = numEntryString;
                }
                else
                {
                    numberEntry.Text += numEntryString;
                }
                value = numberEntry.Text;
            }
            catch (Exception oEx)
            {
                DisplayAlert("Alert", oEx.ToString(), "OK");
            }
        }
        #endregion

        #region Clear Button
        public void clear_Click(object sender, EventArgs e)
        {
            try
            {
                if ((sender as Button).Text == "C")
                {
                    numberEntry.Text = "0";
                    historyEntry.Text = "";
                    value = "0";
                    resultat = 0;
                    compteurOperateur = 0;
                }
            }
            catch (Exception Ex)
            {
                DisplayAlert("Alert", Ex.ToString(), "OK");
            }
        }
        #endregion

        #region Operation
        public void Operation_Click(object sender, EventArgs e)
        {
            try
            {
                CalculePrincipale((sender as Button).Text);
                symbole = (sender as Button).Text;
                clearMainEntry = true;
            }
            catch (Exception Ex)
            {
                DisplayAlert("Alert", Ex.ToString(), "OK");
            }
        }
        #endregion

        #region Egale Bouton
        public void equal_Click(object sender, EventArgs e)
        {
            try
            {
                CalculePrincipale((sender as Button).Text);

                value = "0";
                resultat = 0;
                symbole = "";
                number = 0;
                numberNew = 0;
                compteurOperateur = 0;
                initialisateur = true;

            }
            catch (Exception Ex)
            {
                DisplayAlert("Alert", Ex.ToString(), "OK");
            }
        }
        #endregion

        #region Calcule Methode 
        public void CalculePrincipale(string caracAjoter)
        {
            historyEntry.Text += value + caracAjoter;
            compteurOperateur += 1;

            if (compteurOperateur >= 2)
            {
                numberNew = Convert.ToDouble(value);
                switch (symbole)
                {
                    case "+":
                        resultat = number + numberNew;
                        numberEntry.Text = resultat.ToString();
                        break;

                    case "-":
                        resultat = number - numberNew;
                        numberEntry.Text = resultat.ToString();
                        break;

                    case "*":
                        resultat = number * numberNew;
                        numberEntry.Text = resultat.ToString();
                        break;

                    case "/":
                        if (numberNew == 0)
                        {
                            numberEntry.Text = "ERR";
                            resultat = 0;
                            initialisateur = true;
                            clearMainEntry = true;
                            compteurOperateur = 0;
                        }
                        else
                        {
                            resultat = (double)(number / numberNew);
                            numberEntry.Text = resultat.ToString();
                        }
                        break;
                }
                number = resultat;
            }
            else
            {
                number = Convert.ToDouble(value);
            }
        }
        #endregion

    }
}