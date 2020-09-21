using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyFootballObjects
{
    [Serializable]
    public class Equipes
    {
        #region VARIABLES MEMBRES
        protected static int _nextMatricule;
        private int _matricule;
        private string _nom;
        private DateTime _dateCreation;
        private string _logo;
        private ObservableCollection<Personnes> _listePersonnes;
        #endregion

        #region SETTER / GETTER
        public int Matricule
        {
            get { return _matricule; }
            set { _matricule = value; }
        }
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public DateTime DateCreation
        {
            get { return _dateCreation; }
            set { _dateCreation = value; }
        }
        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
        public ObservableCollection<Personnes> ListePersonnes
        {
            get { return _listePersonnes; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Equipes()
        {
            this.Matricule = Interlocked.Increment(ref _nextMatricule);
            this.Nom = "FC MonJardin";
            this.DateCreation = new DateTime(1900, 7, 6);
            this.Logo = "Images/TeamWithoutPic.jpg";
            this._listePersonnes = new ObservableCollection<Personnes>();
        }
        public Equipes(string nom, DateTime dateCreation, string logo)
        {
            this.Matricule = Interlocked.Increment(ref _nextMatricule);
            this.Nom = nom;
            this.DateCreation = dateCreation;
            this.Logo = logo;
            this._listePersonnes = new ObservableCollection<Personnes>();
        }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return " Matricule : " + Matricule + " // Nom : " + Nom + " // Date de creation : " + DateCreation.ToString("d") + " // Logo : " + Logo;
        }
        public void Draw()
        {
            Console.WriteLine(ToString());
            foreach (Personnes Obj in ListePersonnes)
            {
                Console.WriteLine(Obj.ToString());
            }
            Console.WriteLine();
        }
        public void AfficherCollection()
        {
            Console.WriteLine(ToString());
            foreach (Personnes item in ListePersonnes)
            {
                item.Draw();
            }
        }
        public void AddCollection(Personnes ObjCollParam)
        {
            ListePersonnes.Add(ObjCollParam);
        }
        public void RemoveCollection(Personnes ObjCollParam)
        {
            ListePersonnes.Remove(ObjCollParam);
        }
        public void ReinitialiserCollection()
        {
            ListePersonnes.Clear();
        }

        public void SaveAsBinaryFormat(string filename)
        {
            BinaryFormatter xmlFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, this);
            }
        }

        public Equipes LoadFromBinaryFormat(string filename)
        {
            Equipes team1 = new Equipes();
            try
            {
                BinaryFormatter xmlFormat = new BinaryFormatter();
                using (Stream fStream = File.OpenRead(filename))
                {
                    team1 = (Equipes)xmlFormat.Deserialize(fStream);
                }
            }
            catch (Exception)
            {
                team1 = new Equipes();
            }
            return team1;

        }

        #endregion

    }
}
