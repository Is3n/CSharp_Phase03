using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootballObjects
{
    [Serializable]
    public class Entraineurs : Personnes
    {
        #region VARIABLES MEMBRES
        
        #endregion

        #region SETTER / GETTER
        
        #endregion

        #region CONSTRUCTEURS
        public Entraineurs()
        {
            this.Nom = "CLAES";
            this.Prenom = "ISEN";
            this.DateNaissance = new DateTime(1999, 7, 6);
            this.DebutActivite = new DateTime(2017, 7, 6);
            this.Photo = "Images/Photo_Isen.jpg";
        }
        public Entraineurs(string nom, string prenom, DateTime dateNaissance, DateTime debutActivite, string photo) : base(nom, prenom, dateNaissance, debutActivite, photo)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = dateNaissance;
            this.DebutActivite = debutActivite;
            this.Photo = photo;
        }
        #endregion

        #region METHODES

        public override string ToString()
        {
            return base.ToString();
        }
        public override void Draw()
        {
            Console.WriteLine(ToString());
        }

        #endregion
    }
}
