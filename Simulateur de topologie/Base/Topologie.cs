using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulateur_de_topologie;

namespace Simulateur_de_topologie.Base
{
    public class Topologie
    {
        private float panelWidth;
        private float panelHeight;
        public enum TypeTopologie
        {
            EtoileDif,
            AnneauDif,
            BusDif,
            EtoilePaP,
            AnneauPaP,
            BusPaP,
            Arbre,
            Maillage
        }
        private Random random = new Random();
        public List<Noeud> Noeuds { get; private set; }
        public List<Lien> Liens { get; private set; }
        public PointDiffusion P { get; private set; }

        public bool p = false;

        public TypeTopologie Type { get; private set; }

        public Topologie(TypeTopologie type)
        {
            Type = type;
            Noeuds = new List<Noeud>();
            Liens = new List<Lien>();

        }
        
        /******* Génération aléatoire ********/
        /*public void GenererAleatoirement(int nombreDeNoeuds, int largeur, int hauteur, Random random)
        {

            // Sélectionnez un type de topologie aléatoirement
            TypeTopologie typeAleatoire = (TypeTopologie)random.Next(0, Enum.GetValues(typeof(TypeTopologie)).Length);

            float rayon = largeur / 4;

            switch (typeAleatoire)
            {
                case TypeTopologie.EtoileDif:
                    GenererEtoileDiffusion(nombreDeNoeuds, rayon, e.Graphics);
                    break;

                case TypeTopologie.AnneauDif:
                    // Générer une topologie AnneauDiffusion
                    GenererEtoileDiffusion(nombreDeNoeuds, rayon);
                    break;

                case TypeTopologie.BusDif:
                    // Générer une topologie BusDiffusion
                    GenererEtoileDiffusion(nombreDeNoeuds, rayon);
                    break;

                case TypeTopologie.EtoilePaP:
                    // Générer une topologie EtoilePointAPoint
                    GenererEtoileDiffusion(nombreDeNoeuds, rayon);
                    break;

                case TypeTopologie.AnneauPaP:
                    // Générer une topologie AnneauPointAPoint
                    GenererEtoileDiffusion(nombreDeNoeuds, rayon);
                    break;

                case TypeTopologie.BusPaP:
                    // Générer une topologie BusPointAPoint
                    GenererEtoileDiffusion(nombreDeNoeuds, rayon);
                    break;

                case TypeTopologie.Arbre:
                    // Générer une topologie Arbre
                    GenererEtoileDiffusion(nombreDeNoeuds, rayon);
                    break;

                case TypeTopologie.Maillage:
                    // Générer une topologie Maillage
                    GenererEtoileDiffusion(nombreDeNoeuds, rayon);
                    break;

                default:
                    throw new InvalidOperationException("Type de topologie non reconnu");
            }
        }*/


        private bool ChevaucheUnAutreNoeud(Noeud noeud)
        {
            foreach (var n in Noeuds)
            {
                double distance = Math.Sqrt(Math.Pow(n.Position.X - noeud.Position.X, 2) + Math.Pow(n.Position.Y - noeud.Position.Y, 2));

                if (distance < 2 * Noeud.Rayon)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ListeDeLiensContient(Noeud n1, Noeud n2)
        {
            return Liens.Any(lien => (lien.NoeudOrigine == n1 && lien.NoeudDestination == n2) || (lien.NoeudOrigine == n2 && lien.NoeudDestination == n1));
        }


        /******* Méthodes Topologie à diffusion ********/
        
        public void GenererBusDiffusion(PointF debutBus, PointF finBus, int nombreNoeuds)
        {
            // Créer les noeuds et les lier au bus
            float longueurBus = finBus.X - debutBus.X;
            float espace = longueurBus / (nombreNoeuds + 1); // +1 pour avoir un espace à chaque extrémité

            for (int i = 1; i <= nombreNoeuds; i++)
            {
                // Position horizontale du noeud
                float x = debutBus.X + espace * i;

                // Créer le nœud au-dessus ou en dessous du bus
                PointF positionNoeud = new PointF(x, debutBus.Y - 50); // 50 est l'écart du bus, à ajuster selon les besoins

                Noeuds.Add(new Noeud(i, positionNoeud));

                // Ici, ajoutez également le lien entre le noeud et le bus.
            }
        }
        public void AnneauDif(int nombreNoeuds, float rayon, int largeur, int hauteur)
        {
            // Effacez les nœuds existants avant de générer de nouveaux nœuds
            Noeuds.Clear();

            // Supposons que le centre est au milieu du panneau
            PointDiffusion centre = new PointDiffusion(largeur / 2, hauteur / 2);

            for (int i = 0; i < nombreNoeuds; i++)
            {
                float angle = (float)(2 * Math.PI / nombreNoeuds) * i;
                float x = centre.X + rayon * (float)Math.Cos(angle);
                float y = centre.Y + rayon * (float)Math.Sin(angle);

                Noeuds.Add(new Noeud(i, new PointF(x, y)));
            }
        }




        public void GenererEtoileDiffusion(int nombreNoeuds, float rayon, Graphics g)
        {
            P = new PointDiffusion(RandomFloat(random, rayon, panelWidth - rayon), RandomFloat(random, rayon, panelHeight - rayon));

            for (int i = 0; i < nombreNoeuds; i++)
            {
                float angle = (float)(2 * Math.PI / nombreNoeuds) * i;
                float x = P.X + rayon * (float)Math.Cos(angle);
                float y = P.Y + rayon * (float)Math.Sin(angle);

                Noeuds.Add(new Noeud(i, new PointF(x, y)));
            }

            if (P == null) return;  // Si le point central n'est pas défini, on ne dessine rien.

            // Dessiner chaque noeud et le lien vers le point central
            foreach (Noeud noeud in Noeuds)
            {
                // Dessiner le lien entre le noeud et le point central
                g.DrawLine(Pens.Blue, new PointF(P.X, P.Y), noeud.Position);

                // Dessiner le noeud lui-même
                noeud.DessinerNoeud(g, panelWidth, panelHeight);
            }
        }


        public float RandomFloat(Random random, float min, float max)
        {
            return (float)random.NextDouble() * (max - min) + min;
        }


        /******* Méthodes Topologie PaP ********/


        /*******Dessins********/
        public void DessinerEtoileDiffusion(Graphics g)
        {
            if (P == null) return;  // Si le point central n'est pas défini, on ne dessine rien.

            // Dessiner chaque noeud et le lien vers le point central
            foreach (Noeud noeud in Noeuds)
            {
                // Dessiner le lien entre le noeud et le point central
                g.DrawLine(Pens.Blue, new PointF(P.X, P.Y), noeud.Position);

                // Dessiner le noeud lui-même
                noeud.DessinerNoeud(g, panelWidth, panelHeight);
            }
        }
        public void DessinerBusDif(Graphics g, PointF debutBus, PointF finBus)
        {
            // Dessiner le bus lui-même
            g.DrawLine(Pens.Blue, debutBus, finBus);

            // Dessiner les liens des noeuds
            foreach (Noeud noeud in Noeuds)
            {
                g.DrawLine(Pens.Red, noeud.Position, new PointF(noeud.Position.X, debutBus.Y));

                // Dessiner le noeud lui-même
                noeud.DessinerNoeud(g, panelWidth, panelHeight);
            }
        }
        public void DessinerAnneauDif(Graphics g)
        {
            for (int i = 0; i < Noeuds.Count; i++)
            {
                Noeud noeudActuel = Noeuds[i];
                Noeud noeudSuivant = (i == Noeuds.Count - 1) ? Noeuds[0] : Noeuds[i + 1];

                // Dessiner le lien entre le noeud actuel et le noeud suivant
                g.DrawLine(Pens.Blue, noeudActuel.Position, noeudSuivant.Position);

                // Dessiner le noeud lui-même
                noeudActuel.DessinerNoeud(g, panelWidth, panelHeight);
            }
        }
        


    }


    //Class pour générer les points dans les topologies à dif
    public class PointDiffusion
    {
        public float X { get; set; }
        public float Y { get; set; }

        public PointDiffusion(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

}
