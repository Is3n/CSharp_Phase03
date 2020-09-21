using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootballObjects
{
    [Serializable]
    public class Joueurs : Personnes
    {
        #region VARIABLES MEMBRES
        private int _position;
        #endregion

        #region SETTER / GETTER
        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Joueurs()
        {
            this.Nom = "CLAES";
            this.Prenom = "ISEN";
            this.DateNaissance = new DateTime(1999,7,6);
            this.DebutActivite = new DateTime(2016,7,6);
            this.Photo = "Images/Photo_Isen.jpg";
            this.Position = 8;
        }
        public Joueurs(string nom, string prenom, DateTime dateNaissance, DateTime debutActivite, string photo, int position) : base(nom, prenom, dateNaissance, debutActivite, photo)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaissance = dateNaissance;
            this.DebutActivite = debutActivite;
            this.Photo = photo;
            this.Position = position;
        }
        #endregion

        #region METHODES

        public override string ToString()
        {
            return base.ToString() + " // Position : " + Position;
        }
        public override void Draw()
        {
            Console.WriteLine(ToString());
        }

        #endregion
    }
}
