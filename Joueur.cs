using System;
namespace projetAlgo
{
	public class Joueur
	{
        private string nomdujoueur;
        private List<string> motstrouvés;
        private int score;
        public Joueur(string nomdujoueur)
        {
            this.nomdujoueur = nomdujoueur;
            this.score = 0;
            this.motstrouvés = new List<string>();
        }

        public string toString()
        {
            return "Nom du joueur : " + this.nomdujoueur + "\nMots trouvés : " + this.motstrouvés + "\nScores : " + this.score;
        }

        public void Add_score(int value)
        {
            this.score += value;
        }

        public bool Contient(string mots)
        {
            return this.motstrouvés.Contains(mots);
        }
    }
}

