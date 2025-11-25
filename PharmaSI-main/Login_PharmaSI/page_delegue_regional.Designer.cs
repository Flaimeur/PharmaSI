
namespace Login_PharmaSI
{
    partial class page_delegue_regional
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(page_delegue_regional));
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pbDeconnexion = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeconnexion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(107)))), ((int)(((byte)(71)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(882, 177);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(414, 74);
            this.label10.TabIndex = 36;
            this.label10.Text = "Bonjour ... 👋\r\n";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(107)))), ((int)(((byte)(71)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(782, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(590, 52);
            this.label8.TabIndex = 34;
            this.label8.Text = "Statue :  Délégué Régional👥";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(86, 235);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 20);
            this.label9.TabIndex = 27;
            // 
            // pbDeconnexion
            // 
            this.pbDeconnexion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbDeconnexion.Image = ((System.Drawing.Image)(resources.GetObject("pbDeconnexion.Image")));
            this.pbDeconnexion.Location = new System.Drawing.Point(1812, 60);
            this.pbDeconnexion.Name = "pbDeconnexion";
            this.pbDeconnexion.Size = new System.Drawing.Size(60, 62);
            this.pbDeconnexion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDeconnexion.TabIndex = 35;
            this.pbDeconnexion.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox9.ErrorImage = global::Login_PharmaSI.Properties.Resources.Box_connexion;
            this.pictureBox9.Image = global::Login_PharmaSI.Properties.Resources.Box_connexion;
            this.pictureBox9.InitialImage = global::Login_PharmaSI.Properties.Resources.Box_connexion_shade;
            this.pictureBox9.Location = new System.Drawing.Point(264, 151);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(1608, 918);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 19;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox10.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox10.ErrorImage")));
            this.pictureBox10.Image = global::Login_PharmaSI.Properties.Resources.Group1;
            this.pictureBox10.Location = new System.Drawing.Point(51, 85);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(150, 154);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 26;
            this.pictureBox10.TabStop = false;
            // 
            // page_delegue_regional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1904, 1131);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pbDeconnexion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "page_delegue_regional";
            this.Text = "Delegue regional";
            ((System.ComponentModel.ISupportInitialize)(this.pbDeconnexion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pbDeconnexion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox10;
    }
}