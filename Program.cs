namespace projetAlgo;
class Program
{
    static void Main(string[] args)
    {
        /*Plato p = new Plato(10, 10, "Lettre.txt");
        p = p.ToRead("testalire.txt");
        Console.WriteLine(p.toString());

        List<int> tab = p.Recherche_Mot("MAISON");
        
        //foreach(int s in tab) {
        //Console.WriteLine(s);
        //}

        //Dictionnaire d = new Dictionnaire("Mots_Français.txt", "français");
        //Console.WriteLine(d.toString());
        
        p.Maj_Plateau(tab);
        
        Console.WriteLine(p.toString());
        */
        Jeu jeu = new Jeu();
        Console.ReadKey();
        
    }
}

