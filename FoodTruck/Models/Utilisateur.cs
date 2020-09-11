using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTruck.Tools;

namespace FoodTruck.Models
{
    public class Utilisateur
    {
        private int idutilisateur;
        private string nom;
        private string prenom;
        private string telephone;
        private string email;
        private string identifiant;
        private string motdepasse;
        private int droitadmin;
        protected static SqlCommand command;
        protected static SqlDataReader reader;


        public int Idutilisateur { get => idutilisateur; set => idutilisateur = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Identifiant { get => identifiant; set => identifiant = value; }
        public string Motdepasse { get => motdepasse; set => motdepasse = value; }
        public int Droitadmin { get => droitadmin; set => droitadmin = value; }
        public string Email { get => email; set => email = value; }



        public bool Update(Utilisateur uactif)
            {
                string request = "UPDATE utilisateur set Nom = @nom, Prenom = @prenom, Telephone = @telephone, Email = @email,Identifiant=@identifiant,Motdepasse=@motdepasse,droitadmin=@droitadmin  " +
                "where idutilisateur=@id";
            command = new SqlCommand(request, Connexion.Instance);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            command.Parameters.Add(new SqlParameter("@email", Email));
            command.Parameters.Add(new SqlParameter("@id", Idutilisateur));
            Connexion.Instance.Open();
            command.Dispose();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            Connexion.Instance.Close();
            return nbRow == 1;
        }


        public static Utilisateur ConnectUtilisateur(string id, string mdp)
        {
            
            string request = "SELECT IdUtilisateur,Nom,Prenom,Telephone,Email,Identifiant,Motdepasse,droitadmin FROM utilisateur WHERE Identifiant=@id AND Motdepasse=@mdp) " +
                "values (@identifiant,@motdepasse)";
            command = new SqlCommand(request, Connexion.Instance);
            Connexion.Instance.Open();
            command.Parameters.Add(new SqlParameter("@id", id));
            command.Parameters.Add(new SqlParameter("@mdp", mdp));
            reader = command.ExecuteReader();
            Utilisateur uactif=null;


            if (reader.Read())
            {
                uactif = new Utilisateur()
                {
                    Idutilisateur= reader.GetInt32(1),
                    Nom = reader.GetString(2),
                    Prenom = reader.GetString(3),
                    Telephone = reader.GetString(4),
                    Email = reader.GetString(5),
                    Identifiant = id,
                    Motdepasse = mdp,
                    Droitadmin = reader.GetInt32(8)
                };
            }

            reader.Close();

            command.Dispose();
            Connexion.Instance.Close();

            return uactif;
        }

        public bool InscriptionUtilisateur()
        {
            string request = "INSERT INTO utilisateur (Nom,Prenom,Telephone,Email,Identifiant,Motdepasse,droitadmin) "+
                "OUTPUT INSERTED.IdUtilisateur values (@nom,@prenom,@telephone,@email,@identifiant,@motdepasse,@droitadmin)";
            command = new SqlCommand(request, Connexion.Instance);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            command.Parameters.Add(new SqlParameter("@email", Email));
            command.Parameters.Add(new SqlParameter("@identifiant", Identifiant));
            command.Parameters.Add(new SqlParameter("@motdepasse", Motdepasse));
            command.Parameters.Add(new SqlParameter("@droitadmin", Droitadmin));
            Connexion.Instance.Open();
            Idutilisateur = (int)command.ExecuteScalar();
            command.Dispose();
            Connexion.Instance.Close();
            return Idutilisateur > 0;
        }

    }



}
