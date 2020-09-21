using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFootballObjects
{
    [Serializable]
    public abstract class Personnes
    {
        #region VARIABLES MEMBRES
        protected static int _nextId;
        protected int _id;
        protected string _nom;
        protected string _prenom;
        protected DateTime _dateNaissance;
        protected DateTime _debutActivite;
        protected string _photo;
        #endregion

        #region SETTER / GETTER
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }
        public string NomPrenom
        {
            get { return Nom + " " + Prenom; }
        }
        public DateTime DateNaissance
        {
            get { return _dateNaissance; }
            set { _dateNaissance = value; }
        }
        public int Age
        {

            get
            {
                return DateTime.Now.Year - DateNaissance.Year -
                       (DateTime.Now.Month < DateNaissance.Month ? 1 :
                       (DateTime.Now.Month == DateNaissance.Month && DateTime.Now.Day < DateNaissance.Day) ? 1 : 0);
            }
        }
        public DateTime DebutActivite
        {
            get { return _debutActivite; }
            set { _debutActivite = value; }
        }
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Personnes()
        {
            this.Id = Interlocked.Increment(ref _nextId);
            this.Nom = "CLAES";
            this.Prenom = "ISEN";
            this.DateNaissance = new DateTime(1999, 6, 7);
            this.DebutActivite = new DateTime(2017, 6, 7);
            this.Photo = "Images/Photo_Isen";
        }
        public Personnes(string nom, string prenom, DateTime dateNaissance, DateTime debutActivite, string photo)
        {
            this.Id = Interlocked.Increment(ref _nextId);
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
            return "Id : " + Id.ToString() + " // Nom : " + Nom.ToString() + " // Prenom : " + Prenom.ToString() + " // Date de naissance : " + DateNaissance.ToString("d") + " // Début d'activité : " + DebutActivite.ToString("d") + " // Photo : " + Photo.ToString();
        }

        public abstract void Draw();

        #endregion
    }
}
