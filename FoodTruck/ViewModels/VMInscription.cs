using FoodTruck.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FoodTruck.ViewModels
{
    class VMInscription:ViewModelBase
    {

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Identifiant { get; set; }
        public string Motdepasse { get; set; }
        public int droitadmin { get; set; }

        public ICommand NewUser { get; set; }


        public VMInscription()
        { 
            NewUser = new RelayCommand(NewUserCde);

        }

        private void NewUserCde()
        {
            Utilisateur user = new Utilisateur();
            user.Nom = Nom;
            user.Prenom = Prenom;
            user.Telephone = Telephone;
            user.Email = Email;
            user.Identifiant = Identifiant;
            user.Motdepasse = Motdepasse;
            user.Droitadmin = droitadmin;
            if (user.InscriptionUtilisateur()) {
                MessageBox.Show("Inscription validée");
            }

        }


    }
}
