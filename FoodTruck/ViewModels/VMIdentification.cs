using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FoodTruck.Models;
using FoodTruck.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FoodTruck.ViewModels
{
    class VMIdentification:ViewModelBase
    {

        public string Identifiant { get; set; }
        public string Motdepasse { get; set; }

        public ICommand ConnectUtil { get; set; }
        public ICommand NewUserNav { get; set; }

        private identification iWindow;

        //public Personne Personne { get; set; }

        public VMIdentification(identification w)
        {
            ConnectUtil = new RelayCommand(Connection);
            NewUserNav = new RelayCommand(NewUserNavCde);
            iWindow = w;


        }


        private void Connection()
        {
            string id = Identifiant;
            string mdp = Motdepasse;
            if (Utilisateur.ConnectUtilisateur(id, mdp) is Utilisateur)
            {
                MessageBox.Show("Connection validée");
            }
        }

        private void NewUserNavCde()
        {
            inscription w = new inscription();
            w.Show();
            iWindow.Close();

        }


    }
}
