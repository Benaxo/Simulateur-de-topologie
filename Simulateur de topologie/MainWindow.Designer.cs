namespace Simulateur_de_topologie
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Titre = new System.Windows.Forms.Label();
            this.btn_generer = new System.Windows.Forms.Button();
            this.affichage = new System.Windows.Forms.Panel();
            this.btn_enregistrer = new System.Windows.Forms.Button();
            this.anneauDif = new System.Windows.Forms.Button();
            this.anneauPap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Titre
            // 
            this.Titre.AutoSize = true;
            this.Titre.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Titre.Location = new System.Drawing.Point(453, 27);
            this.Titre.Name = "Titre";
            this.Titre.Size = new System.Drawing.Size(363, 37);
            this.Titre.TabIndex = 0;
            this.Titre.Text = "Simulateur de Topologie";
            this.Titre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_generer
            // 
            this.btn_generer.Location = new System.Drawing.Point(78, 284);
            this.btn_generer.Name = "btn_generer";
            this.btn_generer.Size = new System.Drawing.Size(190, 38);
            this.btn_generer.TabIndex = 1;
            this.btn_generer.Text = "Générer Aléatoirement";
            this.btn_generer.UseVisualStyleBackColor = true;
            this.btn_generer.Click += new System.EventHandler(this.btn_generer_Click);
            // 
            // affichage
            // 
            this.affichage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.affichage.BackColor = System.Drawing.SystemColors.Info;
            this.affichage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.affichage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.affichage.Location = new System.Drawing.Point(301, 103);
            this.affichage.MaximumSize = new System.Drawing.Size(800, 500);
            this.affichage.MinimumSize = new System.Drawing.Size(800, 500);
            this.affichage.Name = "affichage";
            this.affichage.Size = new System.Drawing.Size(800, 500);
            this.affichage.TabIndex = 2;
            this.affichage.Paint += new System.Windows.Forms.PaintEventHandler(this.affichage_Paint);
            this.affichage.MouseLeave += new System.EventHandler(this.affichage_MouseLeave);
            this.affichage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.affichage_MouseMove);
            // 
            // btn_enregistrer
            // 
            this.btn_enregistrer.Location = new System.Drawing.Point(1129, 103);
            this.btn_enregistrer.Name = "btn_enregistrer";
            this.btn_enregistrer.Size = new System.Drawing.Size(103, 39);
            this.btn_enregistrer.TabIndex = 3;
            this.btn_enregistrer.Text = "Exporter";
            this.btn_enregistrer.UseVisualStyleBackColor = true;
            // 
            // anneauDif
            // 
            this.anneauDif.Location = new System.Drawing.Point(78, 103);
            this.anneauDif.Name = "anneauDif";
            this.anneauDif.Size = new System.Drawing.Size(190, 36);
            this.anneauDif.TabIndex = 4;
            this.anneauDif.Text = "Anneau à diffusion";
            this.anneauDif.UseVisualStyleBackColor = true;
            this.anneauDif.Click += new System.EventHandler(this.anneauDif_Click);
            // 
            // anneauPap
            // 
            this.anneauPap.Location = new System.Drawing.Point(78, 172);
            this.anneauPap.Name = "anneauPap";
            this.anneauPap.Size = new System.Drawing.Size(190, 36);
            this.anneauPap.TabIndex = 5;
            this.anneauPap.Text = "Anneau PaP";
            this.anneauPap.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1287, 719);
            this.Controls.Add(this.anneauPap);
            this.Controls.Add(this.anneauDif);
            this.Controls.Add(this.btn_enregistrer);
            this.Controls.Add(this.affichage);
            this.Controls.Add(this.btn_generer);
            this.Controls.Add(this.Titre);
            this.Name = "MainWindow";
            this.Text = "v";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titre;
        private System.Windows.Forms.Button btn_generer;
        private System.Windows.Forms.Panel affichage;
        private System.Windows.Forms.Button btn_enregistrer;
        private System.Windows.Forms.Button anneauDif;
        private System.Windows.Forms.Button anneauPap;
    }
}

