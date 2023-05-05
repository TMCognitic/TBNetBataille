using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TBNetBataille.Cartes
{
    sealed class Carte
    {
        //public static bool operator >(Carte carte1, Carte carte2)
        //{
        //    return carte1.Valeur > carte2.Valeur;
        //}

        //public static bool operator >=(Carte carte1, Carte carte2)
        //{
        //    return carte1 > carte2 || carte1 == carte2;
        //}

        //public static bool operator <(Carte carte1, Carte carte2)
        //{
        //    return carte1.Valeur < carte2.Valeur;
        //}

        //public static bool operator <=(Carte carte1, Carte carte2)
        //{
        //    return carte1 < carte2 || carte1 == carte2;
        //}

        //public static bool operator ==(Carte carte1, Carte carte2)
        //{
        //    return carte1.Equals(carte2);
        //}

        //public static bool operator !=(Carte carte1, Carte carte2)
        //{
        //    return !carte1.Equals(carte2);
        //}

        //public override bool Equals(object? obj)
        //{
        //    Carte? carte = obj as Carte;

        //    if (carte is null)
        //        return false;

        //    return Valeur == carte.Valeur;
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine((int)Valeur, (int)Couleur);
        //}

        public Couleurs Couleur { get; init; }
        public Valeurs Valeur { get; init; }

        public Carte(Couleurs couleur, Valeurs valeur)
        {
            Couleur = couleur;
            Valeur = valeur;
        }

        public override string ToString()
        {
            return Valeur == Valeurs.Joker ? "Joker" : $"{Valeur} de {Couleur}";
        }
    }
}
