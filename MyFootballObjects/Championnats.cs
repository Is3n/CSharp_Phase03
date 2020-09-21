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
    public class Championnats
    {
        #region VARIABLES MEMBRES
        protected static int _nextId;
        private int _id;
        private string _nom;
        private DateTime _dateCreation;
        private string _logo;
        private ObservableCollection<Equipes> _listeEquipes;
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
        public ObservableCollection<Equipes> ListeEquipes
        {
            get { return _listeEquipes; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Championnats()
        {
            this.Id = Interlocked.Increment(ref _nextId);
            this.Nom = "Brico league";
            this.DateCreation = new DateTime(1950, 7, 6);
            this.Logo = "Images/TeamWithoutPic.jpg";
            this._listeEquipes = new ObservableCollection<Equipes>();
        }
        public Championnats(string nom, DateTime dateCreation, string logo)
        {
            this.Id = Interlocked.Increment(ref _nextId);
            this.Nom = nom;
            this.DateCreation = dateCreation;
            this.Logo = logo;
            this._listeEquipes = new ObservableCollection<Equipes>();
        }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return " Id : " + Id + " // Nom : " + Nom + " // Date de creation : " + DateCreation.ToString("d") + " // Logo : " + Logo;
        }
        public void Draw()
        {
            Console.WriteLine(ToString());
            foreach (Equipes Obj in ListeEquipes)
            {
                Console.WriteLine(Obj.ToString());
            }
            Console.WriteLine();
        }
        public void AfficherCollection()
        {
            Console.WriteLine(ToString());
            foreach (Equipes item in ListeEquipes)
            {
                item.Draw();
            }
        }
        public void AddCollection(Equipes ObjsCollParam)
        {
            ListeEquipes.Add(ObjsCollParam);
        }
        public void RemoveCollection(Equipes ObjsCollParam)
        {
            ListeEquipes.Remove(ObjsCollParam);
        }
        public void ReinitialiserCollection()
        {
            ListeEquipes.Clear();
        }

        public void SaveAsBinaryFormat(string filename)
        {
            BinaryFormatter xmlFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, this);
            }
        }

        public Championnats LoadFromBinaryFormat(string filename)
        {
            Championnats ch1 = new Championnats();
            try
            {
                BinaryFormatter xmlFormat = new BinaryFormatter();
                using (Stream fStream = File.OpenRead(filename))
                {
                     ch1 = (Championnats)xmlFormat.Deserialize(fStream);
                }
            }
            catch (Exception)
            {
                 ch1 = new Championnats();
            }
            return ch1;

        }

        #endregion

    }
}
