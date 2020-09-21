using MyFootballObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Joueurs j1 = new Joueurs();
            Joueurs j2 = new Joueurs("Hazard", "Eden", new DateTime(1992,04,24), new DateTime(2008, 04, 24), "Images/PersonneWithoutPic.jpeg", 11);
            Joueurs j3 = new Joueurs("De Bruyne", "Kevin", new DateTime(1992, 08, 11), new DateTime(2008, 08, 11), "Images/PersonneWithoutPic.jpeg", 11);

            Console.WriteLine("\n ********************************* ");
            Console.WriteLine(" *** Affichage de deux Joueurs *** ");
            Console.WriteLine(" ********************************* ");

            j1.Draw();
            j2.Draw();
            j3.Draw();

            Entraineurs coach1 = new Entraineurs();
            Entraineurs coach2 = new Entraineurs("PreudHomme", "Michel", new DateTime(1952, 04, 24), new DateTime(2002, 04, 24), "Images/PersonneWithoutPic.jpeg");

            Console.WriteLine("\n ********************************* ");
            Console.WriteLine(" * Affichage de deux Entraineurs * ");
            Console.WriteLine(" ********************************* ");

            coach1.Draw();
            coach2.Draw();

            Console.WriteLine("\n ********************************* ");
            Console.WriteLine(" **** Affichage d'une Equipe ***** ");
            Console.WriteLine(" ********************************* ");

            Equipes equipe1 = new Equipes("Belgium", new DateTime(1930, 09, 04), "Image/Belgium.svg.png");
            Equipes equipe2 = new Equipes("FC MonJardin", new DateTime(1930, 09, 04), "Image/TeamWithoutPic.jpg");
            Equipes equipe3 = new Equipes("equipe3", new DateTime(1930, 09, 04), "Image/Belgium.svg/png");
            Equipes equipe4 = new Equipes("equipe4", new DateTime(1930, 09, 04), "Image/Belgium.svg/png");

            equipe1.AddCollection(coach1);
            equipe1.AddCollection(j1);
            equipe1.AddCollection(j2);
            equipe1.AddCollection(j3);

            equipe2.AddCollection(coach2);
            equipe2.AddCollection(j1);

            equipe1.Draw();
            equipe2.Draw();


            //equipe1.SaveAsBinaryFormat(equipe1.Nom + equipe1.Matricule);

            /*
            Console.WriteLine("\n ****** Load Equipe ***** ");
            equipe1 = equipe1.LoadFromBinaryFormat(equipe1.Nom + equipe1.Matricule);
            equipe1.Draw();*/


            Console.WriteLine("\n ********************************* ");
            Console.WriteLine(" *** Affichage d'un championnat ** ");
            Console.WriteLine(" ********************************* ");

            Championnats champ1 = new Championnats("Test league", new DateTime(1930, 09, 04), "Image/TeamWithoutPic.jpg");
            Championnats champ2 = new Championnats("Test2 league", new DateTime(1930, 09, 04), "Image/TeamWithoutPic.jpg");
            Championnats champ3 = new Championnats();

            //champ1.AddCollection(equipe1);
            //champ1.AddCollection(equipe2);

            //champ2.AddCollection(equipe3);
            //champ2.AddCollection(equipe4);

            champ1.Draw(); //Affiche les équipes
            champ1.AfficherCollection(); //Affiche les équipes + joueurs

            Console.WriteLine(" ********************************* ");

            champ2.Draw(); //Affiche les équipes
            champ2.AfficherCollection(); //Affiche les équipes + joueurs

            //champ1.SaveAsBinaryFormat(champ1.Nom);
            //champ2.SaveAsBinaryFormat(champ2.Nom);

            Console.WriteLine("\n ****** Load Championnat ***** ");
            champ1 = champ1.LoadFromBinaryFormat(champ1.Nom);
            champ2 = champ2.LoadFromBinaryFormat(champ2.Nom);
            champ3 = champ3.LoadFromBinaryFormat(champ1.Nom);

            champ1.Draw(); //Affiche les équipes
            champ1.AfficherCollection(); //Affiche les équipes + joueurs
            Console.WriteLine(" ********************************* ");
            champ2.Draw(); //Affiche les équipes
            champ2.AfficherCollection(); //Affiche les équipes + joueurs
            Console.WriteLine(" ********************************* ");
            champ3.Draw(); //Affiche les équipes
            champ3.AfficherCollection(); //Affiche les équipes + joueurs

            Console.WriteLine("\n\t Appuyez sur une touche \n");
            Console.ReadKey();


            Console.WriteLine("************************************************** ");
            Console.WriteLine(" **************  MyPersonalFootData  ************** ");
            Console.WriteLine(" ************************************************** ");


            Equipes Standard = new Equipes("Standard de Liege", new DateTime(1898, 01, 01), "Images/Royal_Standard_de_Liege.svg.png");
            Equipes Eupen = new Equipes("KAS Eupen", new DateTime(1945, 01, 01), "Images/Eupen.svg.png");

            Standard.AddCollection(coach2);
            Standard.AddCollection(new Joueurs());
            Standard.AddCollection(new Joueurs("Bodart", "Arnaud", new DateTime(2000, 01, 01), new DateTime(2018, 01, 01), "Images/PersonneWithoutPic.jpeg", 1));
            Standard.AddCollection(new Joueurs("Vanheusden", "Zinho", new DateTime(2000, 02, 02), new DateTime(2018, 02, 02), "Images/PersonneWithoutPic.jpeg", 3));
            Standard.AddCollection(new Joueurs("Marin", "Razvan", new DateTime(2000, 03, 03), new DateTime(2018, 03, 03), "Images/PersonneWithoutPic.jpeg", 6));
            Standard.AddCollection(new Joueurs("Carcela", "Mehdi", new DateTime(2000, 04, 04), new DateTime(2018, 04, 04), "Images/PersonneWithoutPic.jpeg", 9));
            Standard.AddCollection(new Joueurs("Edmilson", "Junior", new DateTime(2000, 05, 05), new DateTime(2018, 05, 05), "Images/PersonneWithoutPic.jpeg", 11));
            Standard.AddCollection(new Joueurs("Oulare", "Obbi", new DateTime(2000, 06, 06), new DateTime(2018, 06, 06), "Images/PersonneWithoutPic.jpeg", 10));

            Eupen.AddCollection(new Entraineurs("San Jose", "Benat", new DateTime(2000, 01, 01), new DateTime(2018, 01, 01), "Images/PersonneWithoutPic.jpeg"));
            Eupen.AddCollection(new Joueurs());
            Eupen.AddCollection(new Joueurs("Milicevic", "Danijel", new DateTime(2000, 01, 01), new DateTime(2018, 01, 01), "Images/PersonneWithoutPic.jpeg", 8));

            Championnats JPL = new Championnats("Jupiler Pro League", new DateTime(1895, 01, 01), "Images/jupiler-pro-league.png");

            JPL.AddCollection(Standard);
            JPL.AddCollection(Eupen);

            //JPL.AfficherCollection();

            Championnats WorldCup = new Championnats("FIFA World Cup", new DateTime(1930, 01, 01), "Images/FIFA_World_Cup_2018_Logo.png");

            WorldCup.AddCollection(equipe1);



            MyPersonalFootData FootData1 = new MyPersonalFootData();

            FootData1.AddCollection(JPL);
            FootData1.AddCollection(WorldCup);

            //FootData1.LoadFromBinaryFormat(FootData1.Nom + FootData1.Prenom);

            FootData1.AfficherCollection();

            FootData1.SaveAsBinaryFormat(FootData1.Nom + FootData1.Prenom);

            Console.WriteLine("\n\t Appuyez sur une touche pour mettre fin a l'application\n");
            Console.ReadKey();
            Console.WriteLine("\n\t Confirmation de l'arret de l'application");
            Console.ReadKey();
        }
    }
}
