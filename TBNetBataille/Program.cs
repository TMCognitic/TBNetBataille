using TBNetBataille.Bataille;
using TBNetBataille.Cartes;
using TBNetBataille.Tools;

namespace TBNetBataille
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JeuDeCarte jeu = new JeuDeCarte();
            Log.Display(jeu.ToString());
            Partie partie = jeu.CreePartieDeBataille();
            partie.Demarrer();
        }
    }
}