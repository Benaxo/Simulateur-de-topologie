using System;
using System.Drawing;
using Simulateur_de_topologie;

namespace Simulateur_de_topologie.Base
{ 
    public class Noeud
    {
        // Attributs
        private int id;
        private PointF position; // Coordonnées du nœud
        


        // Propriétés
        public int IdNoeud 
        { 
            get { return id; } 
        }
        public PointF Position 
        { 
            get { return position; } 
            set => position = value;  
        }
        public static float Rayon { get; } = 13.0f;
        public bool AfficherDetails { get; set; } = false;


        // Constructeur
        public Noeud(int id, PointF position)
        {
            this.id = id;
            this.position = position;
        }

        // Méthode pour dessiner le nœud
        public void DessinerNoeud(Graphics g, float panelWidth, float panelHeight)

        {
            // Dessiner le cercle
            g.FillEllipse(Brushes.Red, position.X - Rayon, position.Y - Rayon, 2 * Rayon, 2 * Rayon);

            if (AfficherDetails)
            {
                // Dessiner l'ID et la position du nœud au-dessus du cercle
                string details = $"Id: {id}, Position: ({position.X}, {position.Y})";
                SizeF textSize = g.MeasureString(details, new Font("Arial", 10));

                float xText = position.X - textSize.Width / 2; // Centrer le texte horizontalement par rapport au nœud.
                float yText = position.Y - Rayon - textSize.Height - 5; // Afficher le texte au-dessus du nœud avec un petit espace.

                // Vérifier si le texte sort du panneau et l'ajuster si nécessaire.
                if (xText < 0) xText = 5; // Petite marge par rapport au bord gauche.
                if (yText < 0) yText = 5; // Petite marge par rapport au bord supérieur.
                if (xText + textSize.Width > panelWidth) xText = panelWidth - textSize.Width - 5; // Ajuster par rapport au bord droit.
                if (yText + textSize.Height > panelHeight) yText = position.Y + Rayon + 5; // Afficher le texte en dessous du nœud si nécessaire.

                g.DrawString(details, new Font("Arial", 10), Brushes.Black, xText, yText);
            }
        }

        public bool ContientSouris(PointF point)
        {
            // Utilisez une distance simple pour déterminer si le point est à l'intérieur du cercle
            return (Math.Pow(Position.X - point.X, 2) + Math.Pow(Position.Y - point.Y, 2)) <= Math.Pow(Rayon, 2);
        }

    }
}