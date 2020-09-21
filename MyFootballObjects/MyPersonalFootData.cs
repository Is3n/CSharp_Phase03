using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyFootballObjects
{
    [Serializable]
    public class MyPersonalFootData
    {
        #region VARIABLES MEMBRES
        private string _nom;
        private string _prenom;
        private ObservableCollection<Championnats> _maCollection;
        #endregion

        #region SETTER / GETTER
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
        public ObservableCollection<Championnats> MaCollection
        {
            get { return _maCollection; }
        }
        //public List<ICartoObj> ListeICartoObj { get; } = new List<ICartoObj>();
        #endregion

        #region CONSTRUCTEURS
        public MyPersonalFootData()
        {
            this.Nom = "Claes";
            this.Prenom = "Isen";
            this._maCollection = new ObservableCollection<Championnats>();
        }
        public MyPersonalFootData(string nom, string prenom)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this._maCollection = new ObservableCollection<Championnats>();
        }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return base.ToString() + " // Nom : " + Nom + " // Prenom : " + Prenom;
        }
        public void Draw()
        {
            Console.WriteLine(ToString());
            foreach (Championnats Obj in _maCollection)
            {
                Console.WriteLine(Obj.ToString());
            }
            Console.WriteLine();
        }
        public void AfficherCollection()
        {
            foreach (Championnats item in MaCollection)
            {
                item.AfficherCollection();
            }
        }
        public void AddCollection(Championnats ObCollParam)
        {
            MaCollection.Add(ObCollParam);
        }
        public void RemoveCollection(Championnats ObCollParam)
        {
            MaCollection.Remove(ObCollParam);
        }
        public void ReinitialiserCollection()
        {
            MaCollection.Clear();
        }
        public void SaveAsBinaryFormat(string filename)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, MaCollection);
            }
        }
        public void LoadFromBinaryFormat(string filename)
        {
            try
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                using (Stream fStream = File.OpenRead(filename))
                {
                    this._maCollection = binFormat.Deserialize(fStream) as ObservableCollection<Championnats>;
                }
            }
            catch (Exception)
            {
                this._maCollection = new ObservableCollection<Championnats>();
            }
        }
        #endregion

    }
}
