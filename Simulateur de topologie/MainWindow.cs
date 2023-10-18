using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulateur_de_topologie.Base;
using static Simulateur_de_topologie.Base.Topologie;

namespace Simulateur_de_topologie
{
    public partial class MainWindow : Form
    {
        private List<Noeud> listeDeNoeuds = new List<Noeud>();
        private List<Lien> listeDeLiens = new List<Lien>();
        private Random random = new Random();
        private Noeud noeudSousLaSouris = null;
        private Topologie uneTopologie;


        public MainWindow()
        {
            InitializeComponent();
            //TypeTopologie typeAleatoire = (TypeTopologie)random.Next(0, Enum.GetValues(typeof(TypeTopologie)).Length);
            uneTopologie = new Topologie(TypeTopologie.AnneauDif);
        }

        private void btn_generer_Click(object sender, EventArgs e)
        {
            listeDeNoeuds.Clear();  // Supprimez tous les nœuds existants
            listeDeLiens.Clear();

            int nombreDeNoeuds = random.Next(3, 31);

            TypeTopologie typeAleatoire = (TypeTopologie)random.Next(0, Enum.GetValues(typeof(TypeTopologie)).Length);

            // Initialisation de uneTopologie avec le type aléatoire
            uneTopologie = new Topologie(typeAleatoire);

            // Appel de la méthode GenererAleatoirement
            //uneTopologie.GenererAleatoirement(nombreDeNoeuds, 100, 100, random);

            listeDeNoeuds = uneTopologie.Noeuds;
            listeDeLiens = uneTopologie.Liens;

            // Puis dessinez tous les nœuds
            affichage.Invalidate();  // Cela déclenche l'événement Paint
        }
        private void anneauDif_Click(object sender, EventArgs e)
        {
            int nombreDeNoeuds = random.Next(3, 10);
            float rayon = 100;
            uneTopologie.AnneauDif(nombreDeNoeuds, rayon, affichage.Width, affichage.Height);
            affichage.Invalidate();  // Déclenche l'événement Paint pour redessiner le panneau
        }



        private void affichage_Paint(object sender, PaintEventArgs e)
        {
            // Effacez tout le contenu précédent en remplissant le panneau avec la couleur d'arrière-plan
            e.Graphics.Clear(affichage.BackColor);

            // Dessinez la topologie actuelle
            uneTopologie.DessinerAnneauDif(e.Graphics);
        }


        private bool ChevaucheUnAutreNoeud(Noeud noeud)
        {
            foreach (var n in listeDeNoeuds)
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
            return listeDeLiens.Any(lien => (lien.NoeudOrigine == n1 && lien.NoeudDestination == n2) || (lien.NoeudOrigine == n2 && lien.NoeudDestination == n1));
        }

        private void affichage_MouseMove(object sender, MouseEventArgs e)
        {
            bool detailsChanged = false;

            foreach (var noeud in listeDeNoeuds)
            {
                if (noeud.ContientSouris(e.Location))
                {
                    if (!noeud.AfficherDetails) // Si les détails ne sont pas déjà affichés.
                    {
                        noeud.AfficherDetails = true;
                        detailsChanged = true;
                    }
                }
                else
                {
                    if (noeud.AfficherDetails) // Si les détails sont affichés mais que la souris n'est pas sur le nœud.
                    {
                        noeud.AfficherDetails = false;
                        detailsChanged = true;
                    }
                }
            }

            // Si les détails d'un nœud ont changé, redessinez le panneau.
            if (detailsChanged)
            {
                affichage.Invalidate();
            }
        }
        private void affichage_MouseLeave(object sender, EventArgs e)
        {
            if (noeudSousLaSouris != null)
            {
                noeudSousLaSouris.AfficherDetails = false;
                noeudSousLaSouris = null;
                affichage.Invalidate();
            }
        }

       
    }
}
