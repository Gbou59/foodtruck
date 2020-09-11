using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Models
{
    public class Utilisateur
    {
        private int idutilisateur;
        private string nom;
        private string prenom;
        private string telephone;
        private string identifiant;
        private string motdepasse;
        private int droitadmin;

        public int Idutilisateur { get => idutilisateur; set => idutilisateur = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Identifiant { get => identifiant; set => identifiant = value; }
        public string Motdepasse { get => motdepasse; set => motdepasse = value; }
        public int Droitadmin { get => droitadmin; set => droitadmin = value; }


        public void inscription()
        {

        }

        public void modification(string identifiant)
        {

        }

        public Utilisateur getutilisateur()
        {


            return;
        }

        public newutilisateur()
        {
            string request = "INSERT INTO"
        }

    }



}
