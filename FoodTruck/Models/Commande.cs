using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Models
{
    class Commande
    {
        private int idcommande;
        private int idpanier;
        private int idutilisateur;
        private string moyenpaiement;
        private DateTime datecreation;
        private DateTime datevalidation;
        private string remarquecommande;

        public int Idcommande { get => idcommande; set => idcommande = value; }
        public int Idpanier { get => idpanier; set => idpanier = value; }
        public int Idutilisateur { get => idutilisateur; set => idutilisateur = value; }
        public string Moyenpaiement { get => moyenpaiement; set => moyenpaiement = value; }
        public DateTime Datecreation { get => datecreation; set => datecreation = value; }
        public DateTime Datevalidation { get => datevalidation; set => datevalidation = value; }
        public string Remarquecommande { get => remarquecommande; set => remarquecommande = value; }



    }
}
