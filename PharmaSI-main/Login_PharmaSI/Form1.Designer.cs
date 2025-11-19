namespace Login_PharmaSI   // <-- doit être identique à Form1.cs
{
    partial class Form1      // <-- même classe, 'partial'
    {
        private System.ComponentModel.IContainer components = null;

        // === CHAMPS QUE Form1.cs UTILISE ===
        private System.Windows.Forms.Button ButtonConnexion;
        private System.Windows.Forms.TextBox LoginIdentifiant;
        private System.Windows.Forms.TextBox LoginMotDePasse;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelMdp;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ButtonConnexion = new System.Windows.Forms.Button();
            this.LoginIdentifiant = new System.Windows.Forms.TextBox();
            this.LoginMotDePasse = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelMdp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonConnexion
            // 
            this.ButtonConnexion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ButtonConnexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(195)))), ((int)(((byte)(108)))));
            this.ButtonConnexion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonConnexion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonConnexion.ForeColor = System.Drawing.Color.White;
            this.ButtonConnexion.Location = new System.Drawing.Point(433, 469);
            this.ButtonConnexion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonConnexion.Name = "ButtonConnexion";
            this.ButtonConnexion.Size = new System.Drawing.Size(305, 40);
            this.ButtonConnexion.TabIndex = 3;
            this.ButtonConnexion.Text = "Se connecter";
            this.ButtonConnexion.UseVisualStyleBackColor = false;
            this.ButtonConnexion.Click += new System.EventHandler(this.ButtonConnexion_Click);
            // 
            // LoginIdentifiant
            // 
            this.LoginIdentifiant.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoginIdentifiant.Location = new System.Drawing.Point(433, 325);
            this.LoginIdentifiant.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoginIdentifiant.Name = "LoginIdentifiant";
            this.LoginIdentifiant.Size = new System.Drawing.Size(305, 26);
            this.LoginIdentifiant.TabIndex = 1;
            // 
            // LoginMotDePasse
            // 
            this.LoginMotDePasse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoginMotDePasse.Location = new System.Drawing.Point(433, 413);
            this.LoginMotDePasse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoginMotDePasse.Name = "LoginMotDePasse";
            this.LoginMotDePasse.Size = new System.Drawing.Size(305, 26);
            this.LoginMotDePasse.TabIndex = 2;
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelLogin.AutoSize = true;
            this.labelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(107)))), ((int)(((byte)(71)))));
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.ForeColor = System.Drawing.Color.White;
            this.labelLogin.Location = new System.Drawing.Point(428, 294);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(106, 26);
            this.labelLogin.TabIndex = 4;
            this.labelLogin.Text = "Identifiant";
            // 
            // labelMdp
            // 
            this.labelMdp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelMdp.AutoSize = true;
            this.labelMdp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(107)))), ((int)(((byte)(71)))));
            this.labelMdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMdp.ForeColor = System.Drawing.SystemColors.Control;
            this.labelMdp.Location = new System.Drawing.Point(428, 382);
            this.labelMdp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMdp.Name = "labelMdp";
            this.labelMdp.Size = new System.Drawing.Size(142, 26);
            this.labelMdp.TabIndex = 5;
            this.labelMdp.Text = "Mot de passe";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(107)))), ((int)(((byte)(71)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(505, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "Connexion";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.Image = global::Login_PharmaSI.Properties.Resources.Box_connexion;
            this.pictureBox3.Location = new System.Drawing.Point(385, 60);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(400, 500);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(107)))), ((int)(((byte)(71)))));
            this.pictureBox4.Image = global::Login_PharmaSI.Properties.Resources.Group1;
            this.pictureBox4.Location = new System.Drawing.Point(530, 85);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(120, 120);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.ButtonConnexion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1130, 644);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMdp);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.LoginMotDePasse);
            this.Controls.Add(this.LoginIdentifiant);
            this.Controls.Add(this.ButtonConnexion);
            this.Controls.Add(this.pictureBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connexion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}
