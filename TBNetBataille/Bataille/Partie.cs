using TBNetBataille.Cartes;
using TBNetBataille.Tools;

namespace TBNetBataille.Bataille
{
    class Partie
    {
        private readonly Queue<Carte> _cartesJ1;
        private readonly Queue<Carte> _cartesJ2;
        private readonly Stack<Carte> _tasJ1;
        private readonly Stack<Carte> _tasJ2;

        public Partie(Queue<Carte> cartesJ1, Queue<Carte> cartesJ2)
        {
            _cartesJ1 = cartesJ1;
            _cartesJ2 = cartesJ2;
            _tasJ1 = new Stack<Carte>();
            _tasJ2 = new Stack<Carte>();
        }

        public void Demarrer()
        {
            bool estBataille = false;
            while (_cartesJ1.Count > 0 && _cartesJ2.Count > 0)
            {
                _tasJ1.Push(_cartesJ1.Dequeue());
                _tasJ2.Push(_cartesJ2.Dequeue());

                if (!estBataille)
                {
                    Console.Clear();
                }
                estBataille = false;
                Log.Display(_tasJ1.Peek(), _tasJ2.Peek());

                if (_tasJ1.Peek().Valeur > _tasJ2.Peek().Valeur)
                {
                    Log.Display("Le joueur 1 gagne la manche");
                    Transfert(_cartesJ1);
                }
                else if (_tasJ2.Peek().Valeur > _tasJ1.Peek().Valeur)
                {
                    Log.Display("Le joueur 2 gagne la manche");
                    Transfert(_cartesJ2);
                }
                else
                {
                    estBataille = true;
                    Log.Display("!!!!!!!    Bataille    !!!!!!!");
                    try
                    {
                        _tasJ1.Push(_cartesJ1.Dequeue());
                        Log.Display("Le joueur 1 a posé une carte face cachée");
                    }
                    catch (InvalidOperationException)
                    {
                        Transfert(_cartesJ2);
                    }

                    try
                    {
                        _tasJ2.Push(_cartesJ2.Dequeue());
                        Log.Display("Le joueur 2 a posé une carte face cachée");
                    }
                    catch (InvalidOperationException)
                    {
                        Transfert(_cartesJ1);
                    }
                }

                Log.Display($"Cartes J1 : {_cartesJ1.Count} -- Cartes J2 : {_cartesJ2.Count}");
                
                Task.Delay(100).Wait(); //Attend 1/10ème de seconde
            }

            if (_cartesJ1.Count == 0)
            {
                if(_tasJ1.Count > 0 || _tasJ2.Count > 0)
                {
                    Log.Display("Le joueur 2 ramasse le pot");
                    Transfert(_cartesJ2);
                }

                Log.Display("Le joueur 1 n'a plus de carte");
                Log.Display("Joueur 2 gagne");
            }
            else
            {
                if (_tasJ1.Count > 0 || _tasJ2.Count > 0)
                {
                    Log.Display("Le joueur 1 ramasse le pot");
                    Transfert(_cartesJ1);
                }
                Log.Display("Le joueur 2 n'a plus de carte");
                Log.Display("Joueur 1 gagne");
            }

            Log.Display($"Cartes J1 : {_cartesJ1.Count} -- Cartes J2 : {_cartesJ2.Count}");
        }

        private void Transfert(Queue<Carte> queueDuGagnant)
        {
            foreach (Carte carte in _tasJ1)
            {
                queueDuGagnant.Enqueue(carte);
            }
            _tasJ1.Clear();

            foreach (Carte carte in _tasJ2)
            {
                queueDuGagnant.Enqueue(carte);
            }
            _tasJ2.Clear();
        }
    }
}
