using Simulateur_de_topologie.Base;
using System.Drawing;

public class Lien
{
    public Noeud NoeudOrigine { get; }
    public Noeud NoeudDestination { get; }
    public enum TypeLien { Direct, Cercle }
    public TypeLien TypeDeLien { get; }

    public Lien(Noeud origine, Noeud destination, TypeLien type)
    {
        NoeudOrigine = origine;
        NoeudDestination = destination;
        TypeDeLien = type;
    }

    public void DessinerLien(Graphics g)
    {
        if (TypeDeLien == TypeLien.Direct)
        {
            g.DrawLine(Pens.Black, NoeudOrigine.Position, NoeudDestination.Position);
        }
        // Ajoutez le code pour dessiner le lien de type Diffusion
    }
}
