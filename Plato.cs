using System;
namespace projetAlgo
{
	public class Plato
	{
		string[,] plateau;
		string fichier;
		int hauteur;
		int largeur;

		public Plato(int hauteur, int largeur, string fichier)
		{
			this.hauteur = hauteur;
			this.largeur = largeur;
			this.fichier = "Lettre.txt";
			this.plateau = new string [hauteur,largeur];
			genePlateau();
		}

		public void genePlateau()
		{
			string[] InfoLettre = null;
			List<string> Listelettres = new List<string>();
			string[] lignes = File.ReadAllLines(this.fichier);
			foreach(string ligne in lignes )
			{
				InfoLettre = ligne.Split(',');
				for(int i = 0; i < int.Parse(InfoLettre[1]); i++)
				{
					Listelettres.Add(InfoLettre[0]);
				}
			}

			Random r = new Random();
			int nb = 0;
            for (int i = 0; i < hauteur; i++)
			{
				for (int j = 0; j < largeur; j++)
				{
					nb = r.Next(Listelettres.Count());

                    plateau[i,j] = Listelettres[nb];
					Listelettres.RemoveAt(nb);
				}
			}
		}

        public string toString()
		{
			
			string chainedecaractere = null;
			for(int i = 0; i < hauteur; i++)
			{
				for(int j = 0; j < largeur; j++)
				{
					chainedecaractere += plateau[i,j] + " ";
				}
				chainedecaractere += "\n";
			}
			return chainedecaractere;
		}

        public void ToFile(string nomfile)
		{
			File.WriteAllText(nomfile, toString());
		}

        public Plato ToRead(string nomfile)
		{
			string[] PlateauProvisoire = File.ReadAllLines(nomfile);
			hauteur = PlateauProvisoire.Length;
			largeur = PlateauProvisoire[0].Split(' ').Length;
			this.plateau = new string[hauteur, largeur];
			string[] l;
			for(int i = 0; i < plateau.GetLength(0); i++)
			{
                l = PlateauProvisoire[i].Split(' ');
                for (int j = 0; j < plateau.GetLength(1); j++)
				{
					plateau[i, j] = l[j];
				}
			}
			return this;
		}

        public List<int> Recherche_Mot(string mot, int x = 0, int y = 0, int k = 0, int j = 0, List<int> coordonnees = null)
        {
            if (k == mot.Length)
            {
                return coordonnees;
            }
            if (k == 0)
            {
                coordonnees = new List<int>();
                for (j=j; j < largeur; j++)
                {
                    if (mot[k].ToString() == plateau[hauteur - 1, j])
                    {
                        coordonnees.Add(hauteur - 1);
                        coordonnees.Add(j);
                        return Recherche_Mot(mot, hauteur - 1, j, k + 1, j, coordonnees);

                    }
                }
            }

            if (x > 0 && mot[k].ToString() == plateau[x - 1, y])
            {
                coordonnees.Add(x - 1);
                coordonnees.Add(y);
                return Recherche_Mot(mot, x - 1, y, k + 1, j, coordonnees);

            }
            if (y >= -1 && mot[k].ToString() == plateau[x, y + 1])
            {
                coordonnees.Add(x);
                coordonnees.Add(y + 1);
                return Recherche_Mot(mot, x, y + 1, k + 1, j, coordonnees);

            }
            if (y > 0 && mot[k].ToString() == plateau[x, y - 1])
            {
                coordonnees.Add(x);
                coordonnees.Add(y - 1);
                return Recherche_Mot(mot, x, y - 1, k + 1, j, coordonnees);

            }

            if (j >= largeur - 1)
            {
                return null;
            }

            return Recherche_Mot(mot, x, y - 1, 0, j + 1, null);

        }


        static List<string> tricol(List<string> col)
        {
            string lettre = "";
            for (int i = col.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (col[j] == " " || col[j + 1] == " ")
                    {
                        if (string.Compare(col[j], col[j + 1]) == 1)
                        {
                            lettre = col[j];
                            col[j] = col[j + 1];
                            col[j + 1] = lettre;
                        }
                    }
                }
            }
            return col;
        }


        public void Maj_Plateau(List<int> coordonnees)
		{
			if(coordonnees!=null)
            {
				for (int i = 0; i < coordonnees.Count; i = i + 2)
				{
					plateau[coordonnees[i], coordonnees[i + 1]] = " ";
				}
			  
				List<string> col;
				for (int j = 0; j < largeur; j++)
				{
					col = new List<string>();
					for(int i = 0; i < hauteur; i++)
					{
						col.Add(plateau[i,j]);
					}
					col = tricol(col);
					for (int i = 0; i < hauteur; i++)
					{
						plateau[i, j] = col[i];
					}
				
				}
			}
		}
    }
}


