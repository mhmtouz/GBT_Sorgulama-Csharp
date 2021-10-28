namespace GBT_Sorgulama
{
    partial class frmGiris
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiris));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTcno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.conMenuGiris = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.girişYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conMenuGiris.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(313, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "TC No";
            // 
            // txtTcno
            // 
            this.txtTcno.Location = new System.Drawing.Point(379, 86);
            this.txtTcno.Name = "txtTcno";
            this.txtTcno.Size = new System.Drawing.Size(100, 20);
            this.txtTcno.TabIndex = 0;
            this.txtTcno.Text = "85478939840";
            this.txtTcno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTcno_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(322, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(379, 114);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(100, 20);
            this.txtSifre.TabIndex = 1;
            this.txtSifre.Text = "123123";
            // 
            // btnGiris
            // 
            this.btnGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGiris.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiris.Image = ((System.Drawing.Image)(resources.GetObject("btnGiris.Image")));
            this.btnGiris.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGiris.Location = new System.Drawing.Point(355, 168);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(96, 31);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCikis.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.btnCikis.Image = ((System.Drawing.Image)(resources.GetObject("btnCikis.Image")));
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCikis.Location = new System.Drawing.Point(437, 239);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(68, 32);
            this.btnCikis.TabIndex = 5;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(306, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kullanıcı Girişi";
            // 
            // conMenuGiris
            // 
            this.conMenuGiris.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.girişYapToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.conMenuGiris.Name = "contextMenuStrip1";
            this.conMenuGiris.Size = new System.Drawing.Size(121, 48);
            // 
            // girişYapToolStripMenuItem
            // 
            this.girişYapToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("girişYapToolStripMenuItem.Image")));
            this.girişYapToolStripMenuItem.Name = "girişYapToolStripMenuItem";
            this.girişYapToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.girişYapToolStripMenuItem.Text = "Giriş Yap";
            this.girişYapToolStripMenuItem.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("çıkışToolStripMenuItem.Image")));
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // frmGiris
            // 
            this.AcceptButton = this.btnGiris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCikis;
            this.ClientSize = new System.Drawing.Size(517, 294);
            this.ContextMenuStrip = this.conMenuGiris;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtTcno);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GBT Sorgulama";
            this.Load += new System.EventHandler(this.frmGiris_Load);
            this.conMenuGiris.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtTcno;
        private System.Windows.Forms.ContextMenuStrip conMenuGiris;
        private System.Windows.Forms.ToolStripMenuItem girişYapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
    }
}

