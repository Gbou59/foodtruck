using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Tools
{
    class Connexion
    {
        private static SqlConnection _instance;
        
        public static SqlConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance=new SqlConnection(@"Data Source=(LocalDb)\foodtrucksql;Integrated Security=True");
                    CreateTable();
                }
                return _instance;
            }
        }

        private Connexion() { }

        private static void CreateTable()
        {
            //Table Utilisateur
            string request =
                "if not exists(SELECT * FROM sysobjects where name='utilisateur' and xtype='U') " +
                "CREATE TABLE[utilisateur]("+
                "[IdUtilisateur] INT IDENTITY(1, 1) NOT NULL," +
                "[Nom] VARCHAR(50) NOT NULL," +
                "[Prenom] VARCHAR(50) NOT NULL," +
                "[Telephone] VARCHAR(50) NULL," +
                "[Email] VARCHAR(50) NOT NULL," +
                "[Identifiant] VARCHAR(50) NOT NULL," +
                "[Motdepasse] VARCHAR(50) NOT NULL," +
                "[droitadmin] INT DEFAULT((0)) NOT NULL)";
            SqlCommand command = new SqlCommand(request, Instance);
            Instance.Open();
            command.ExecuteNonQuery();
            command.Dispose();

            //Table tableproduits
            request =
                 "if not exists(SELECT * FROM sysobjects where name='utilisateur' and xtype='U') " +
                 "CREATE TABLE[tableproduits](" +
                  "[IdProduit] INT IDENTITY(1, 1) NOT NULL,"+
                  "[TypeProduit] VARCHAR(50) NOT NULL,"+
                  "[Nom] VARCHAR(50) NOT NULL,"+
                  "[Descrition]    VARCHAR(50) NOT NULL,"+
                  "[PrixProduit]   INT NOT NULL,"+
                  "[Disponibilite] INT NOT NULL)";
            command = new SqlCommand(request, Instance);
            Instance.Open();
            command.ExecuteNonQuery();
            command.Dispose();

            //Table preparation
            request =
             "if not exists(SELECT * FROM sysobjects where name='preparation' and xtype='U') " +
             "CREATE TABLE[preparation](" +
             "[IdPreparation] INT IDENTITY(1, 1) NOT NULL,"+
             "[IdCommande] INT NOT NULL,"+
             "[DateDebutPrepa] DATE NOT NULL,"+
             "[DateFinPrepa] DATE NOT NULL,"+
             "[DateLivraison] DATE NOT NULL,"+
             "[StatutPreparation] VARCHAR(50) NULL)";
            command = new SqlCommand(request, Instance);
            Instance.Open();
            command.ExecuteNonQuery();
            command.Dispose();

            //Table Panier
            request =
                 "if not exists(SELECT * FROM sysobjects where name='Panier' and xtype='U') " +
                "CREATE TABLE[Panier]("+
                "[IdPanier] INT IDENTITY (1, 1) NOT NULL,"+
                "[IdLignePanier] INT NOT NULL,"+
                "[Remarque]VARCHAR(50) NULL)";
            command = new SqlCommand(request, Instance);
            Instance.Open();
            command.ExecuteNonQuery();
            command.Dispose();

            //Table lignepanier
            request =
                "if not exists(SELECT * FROM sysobjects where name='lignepanier' and xtype='U') " +
                "CREATE TABLE[lignepanier](" +
                "[Idligne] INT IDENTITY(1, 1) NOT NULL," +
                "[TypeLigne] VARCHAR(50) NOT NULL," +
                "[IdProduit] INT NOT NULL," +
                "[QuantiteLigne] INT NOT NULL," +
                "[PrixLigne] INT NOT NULL)";
            command = new SqlCommand(request, Instance);
            Instance.Open();
            command.ExecuteNonQuery();
            command.Dispose();

            //Table Commande
            request =
             "if not exists(SELECT * FROM sysobjects where name='commande' and xtype='U') " +
              "CREATE TABLE[commande](" + 
              "[IdCommande] INT IDENTITY(1, 1) NOT NULL," +
              "[IdUtilisateur] INT NOT NULL,"+
              "[IdPanier] INT NOT NULL,"+
              "[MoyenPaiement] VARCHAR(50) NULL,"+
              "[DateCreation] DATE NOT NULL,"+
              "[DateValidation] DATE NOT NULL,"+
              "[RemarqueCommande] TEXT NULL)";
            command = new SqlCommand(request, Instance);
            Instance.Open();
            command.ExecuteNonQuery();
            command.Dispose();



        }

    }
}
