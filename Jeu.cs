using System;
namespace projetAlgo
{
	public class Jeu
	{
		int score;
		private Dictionnaire dico = new Dictionnaire("Mots_Français.txt", "français");
		private Plato p = new Plato(10,10,"Lettres.txt");
		private Joueur joueur;

		public Jeu()
		{
			jeu();
		}

		public void jeu()
		{
			int hauteur = 0;
			int largeur = 0;
			DateTime d = DateTime.Now;


			Console.WriteLine("Bonjour, veuillez entrer le prénom du premier joueur");
            string nom1 = Console.ReadLine();
            Console.WriteLine("Bonjour, veuillez entrer le prénom du deuxième joueur");
			string nom2 = Console.ReadLine();
			Joueur joueur1 = new Joueur(nom1);
			Joueur joueur2 = new Joueur(nom2);
			Console.WriteLine("Voulez vous jouer à partir d'un nouveau ou un ancien plato ? ");
            string rep1 = Console.ReadLine();
            Plato p = new Plato(hauteur, largeur, "Lettre.txt");
			while((rep1 != "ancien" && rep1 != "nouveau") || rep1 == null)
			{
                Console.WriteLine("Erreur, Saisir : nouveau ou ancien");
                rep1 = Console.ReadLine();
            }
            if (rep1 == "ancien")
			{
                Console.WriteLine("Saisir nom fichier");
                string rep = Console.ReadLine();
                p.ToRead(rep);
                Console.WriteLine(p.toString());
				while (DateTime.Now<d+ TimeSpan.FromSeconds(30))
				{
                    Console.WriteLine("\nSaisissez un mot sur le plateau :");
                    string tentative = Console.ReadLine();
					tentative = tentative.ToUpper();
					if(tentative.Length < 2)
					{
						Console.WriteLine("Ce mot est trop court !");
					}
					else if(!(this.dico.RDR(tentative)))
					{
						Console.WriteLine("Ce mot n'existe pas");
					}
					else if(this.p.Recherche_Mot(tentative) == null)
					{
						Console.WriteLine("Ce mot n'est pas sur le plateau");
                    }
					else
					{
                        List<int> tab = p.Recherche_Mot(tentative);
                        p.Maj_Plateau(tab);
                        Console.WriteLine(p.toString());
                    }
					if(DateTime.Now >= d + TimeSpan.FromSeconds(30))
					{
						d = d + TimeSpan.FromSeconds(30);
                    }
                }
            }
			else if(rep1 == "nouveau")
			{
                Console.WriteLine("Choisissez les dimensions de votre plateau : \nhauteur ? ");
                hauteur = int.Parse(Console.ReadLine());
                Console.WriteLine("largeur ?");
                largeur = int.Parse(Console.ReadLine());
                p = new Plato(hauteur, largeur, "Lettre.txt");
                Console.WriteLine(p.toString());
                while (DateTime.Now<d+ TimeSpan.FromSeconds(30))
				{
                    Console.WriteLine("\nSaisissez un mot sur le plateau :");
                    string tentative = Console.ReadLine();
                    tentative = tentative.ToUpper();
                    if (tentative.Length < 2)
                    {
                        Console.WriteLine("Ce mot est trop court !");
                    }
                    else if (!(this.dico.RDR(tentative)))
                    {
                        Console.WriteLine("Ce mot n'existe pas");
                    }
                    else if (this.p.Recherche_Mot(tentative) == null)
                    {
                        Console.WriteLine("Ce mot n'est pas sur le plateau");
                    }
                    else
                    {
                        List<int> tab = p.Recherche_Mot(tentative);
                        p.Maj_Plateau(tab);
                        Console.WriteLine(p.toString());
                    }
                    if (DateTime.Now >= d + TimeSpan.FromSeconds(30))
                    {
                        d = d + TimeSpan.FromSeconds(30);
                    }
                }
            }
        }


		/*static void Motstrouvés()
		{
            Plato p = new Plato();
            p.ToRead("fichier.txt");
            Console.WriteLine(p.toString());
            Console.WriteLine("Choisissez un mot parmis ce plato");
            string motentree = Console.ReadLine();
			p.Maj_Plateau(coordonnees);
            Console.WriteLine(p.toString());

        }

        /*public int Score(int score)
		{
            Plato p = new Plato();
            score = 0;
			if(Maj_Plateau == null)
			{
				score = 0;
			}
			else
			{
				Maj_Plateau();
			}
			Console.WriteLine("Votre score est de ");
			return score;
		}
		*/
	}
}

