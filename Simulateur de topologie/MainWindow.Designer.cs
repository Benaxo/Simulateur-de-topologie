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
            this.SuspendLayout();
            // 
            // Titre
            // 
            this.Titre.AutoSize = true;
            this.Titre.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Titre.Location = new System.Drawing.Point(384, 29);
            this.Titre.Name = "Titre";
            this.Titre.Size = new System.Drawing.Size(353, 37);
            this.Titre.TabIndex = 0;
            this.Titre.Text = "Simulateur de Tipologie";
            this.Titre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_generer
            // 
            this.btn_generer.Location = new System.Drawing.Point(68, 122);
            this.btn_generer.Name = "btn_generer";
            this.btn_generer.Size = new System.Drawing.Size(103, 38);
            this.btn_generer.TabIndex = 1;
            this.btn_generer.Text = "Générer";
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
            this.affichage.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.affichage.Location = new System.Drawing.Point(212, 122);
            this.affichage.Name = "affichage";
            this.affichage.Size = new System.Drawing.Size(738, 541);
            this.affichage.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1120, 700);
            this.Controls.Add(this.affichage);
            this.Controls.Add(this.btn_generer);
            this.Controls.Add(this.Titre);
            this.Name = "MainWindow";
            this.Text = "Fenêtre 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titre;
        private System.Windows.Forms.Button btn_generer;
        private System.Windows.Forms.Panel affichage;
    }
}

