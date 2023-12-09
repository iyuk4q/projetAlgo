using System;
namespace projetAlgo
{
	public class Dictionnaire
	{
        string langue;
        string fichier;
        string[] dico;
        StreamReader sr;
        public Dictionnaire(string fichier, string langue)
        {
            this.fichier = fichier;
            this.langue = langue;
            sr = new StreamReader(fichier);
            dico = sr.ReadToEnd().Split(' ');
        }
        public string toString()
        {
            sr = new StreamReader(fichier);
            string rep = "";
            for (int i = 0; i < 26; i++)
            {
                int nb = 0;
                nb = sr.ReadLine().Split(' ').Length;
                rep += "nombre de " + ((char)(65 + i)).ToString() + " :" + nb + " \n";
            }
            return rep;
        }

        static string[] fusion(string[] tab1, string[] tab2)
        {
            string[] tab = new string[tab1.Length + tab2.Length];
            int nb1 = 0, nb2 = 0, nb = 0;
            while (nb1 < tab1.Length && nb2 < tab2.Length)
            {
                if (string.Compare(tab1[nb1], tab2[nb2]) == -1)
                {
                    tab[nb] = tab1[nb1];
                    nb++; nb1++;
                }
                else
                {
                    tab[nb] = tab2[nb2];
                    nb++; nb2++;
                }
            }
            while (nb1 < tab1.Length || nb2 < tab2.Length)
            {
                if (nb1 >= tab1.Length)
                {
                    tab[nb] = tab2[nb2];
                    nb++; nb2++;
                }
                else
                {
                    tab[nb] = tab1[nb1];
                    nb++; nb1++;
                }
            }
            return tab;
        }
        static string[] trifusion(string[] tab)
        {
            string[] tab1 = null, tab2 = null;
            if (tab.Length == 1)
            {
                return tab;
            }
            else
            {
                tab2 = new string[tab.Length % 2 + tab.Length / 2];
                tab1 = new string[tab.Length / 2];
                for (int i = 0; i < tab.Length / 2; i++)
                {
                    tab1[i] = tab[i];
                }
                for (int j = tab.Length / 2; j < tab.Length; j++)
                {
                    tab2[j - tab.Length / 2] = tab[j];
                }
                return fusion(trifusion(tab1), trifusion(tab2));
            }
        }

        public string[] trifu_dico()
        {
            return trifusion(this.dico);
        }

        public bool RDR(string mot)
        {
            string[] tab1 = trifu_dico();
            int debut = 0, fin = tab1.Length-1;
            return RechercheDichoRecursif(debut, fin, tab1, mot);
        }

        static bool RechercheDichoRecursif(int debut, int fin, string[] t, string Elt)
        {

            if (debut > fin || t == null || t.Length <= 0)
            {
                return false;
            }
            else
            {
                int milieu = (debut + fin) / 2;
                if (Elt == t[milieu])
                {
                    return true;
                }
                else if (string.Compare(Elt, t[milieu]) == 1)
                {
                    return RechercheDichoRecursif(milieu + 1, fin, t, Elt);
                }
                else if (string.Compare(Elt, t[milieu]) == -1)
                {
                    return RechercheDichoRecursif(debut, milieu - 1, t, Elt);
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

