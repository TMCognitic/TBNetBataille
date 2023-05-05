using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBNetBataille.Bataille;

namespace TBNetBataille.Cartes
{
    sealed class JeuDeCarte
    {
        private readonly List<Carte> _cartes;

        public JeuDeCarte()
        {
            _cartes = new List<Carte>();
            //Ajout des cartes
            for (int i = 0; i < 52; i++)
            {
                _cartes.Add(new Carte((Couleurs)(i / 13), (Valeurs)(i % 13) + 2));
            }

            //Ajout des Jokers
            _cartes.Add(new Carte(Couleurs.Coeur, Valeurs.Joker));
            //_cartes.Add(new Carte(Couleurs.Coeur, Valeurs.Joker));
        }

        public Partie CreePartieDeBataille()
        {
            Queue<Carte> cartesJ1 = new Queue<Carte>();
            Queue<Carte> cartesJ2 = new Queue<Carte>();

            bool estJoueur1 = true;
            while (_cartes.Count > 0)
            {
                int rand = Random.Shared.Next(_cartes.Count);
                (estJoueur1 ? cartesJ1 : cartesJ2).Enqueue(_cartes[rand]);
                _cartes.Remove(_cartes[rand]);
                estJoueur1 = !estJoueur1;
            }

            return new Partie(cartesJ1, cartesJ2);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Carte carte in _cartes)
            {
                stringBuilder.AppendLine(carte.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
