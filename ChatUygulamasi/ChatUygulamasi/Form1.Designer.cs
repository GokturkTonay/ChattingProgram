namespace ChatUygulamasi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.gboxGiris = new System.Windows.Forms.GroupBox();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.btnBaglan = new System.Windows.Forms.Button();
            this.lstMesajlar = new System.Windows.Forms.ListBox();
            this.gboxSohbet = new System.Windows.Forms.GroupBox();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.gboxGiris.SuspendLayout();
            this.gboxSohbet.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxGiris
            // 
            this.gboxGiris.Controls.Add(this.lblKullaniciAdi);
            this.gboxGiris.Controls.Add(this.txtKullaniciAdi);
            this.gboxGiris.Controls.Add(this.btnBaglan);
            this.gboxGiris.Location = new System.Drawing.Point(42, 31);
            this.gboxGiris.Name = "gboxGiris";
            this.gboxGiris.Size = new System.Drawing.Size(385, 153);
            this.gboxGiris.TabIndex = 0;
            this.gboxGiris.TabStop = false;
            this.gboxGiris.Text = "Giriş";
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciAdi.Location = new System.Drawing.Point(12, 48);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(108, 24);
            this.lblKullaniciAdi.TabIndex = 1;
            this.lblKullaniciAdi.Text = "KullanıcıAdı";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(126, 45);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(135, 27);
            this.txtKullaniciAdi.TabIndex = 2;
            // 
            // btnBaglan
            // 
            this.btnBaglan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaglan.Location = new System.Drawing.Point(267, 36);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(112, 44);
            this.btnBaglan.TabIndex = 3;
            this.btnBaglan.Text = "Bağlan";
            this.btnBaglan.UseVisualStyleBackColor = true;
            this.btnBaglan.Click += new System.EventHandler(this.btnBaglan_Click);
            // 
            // lstMesajlar
            // 
            this.lstMesajlar.FormattingEnabled = true;
            this.lstMesajlar.ItemHeight = 16;
            this.lstMesajlar.Location = new System.Drawing.Point(6, 30);
            this.lstMesajlar.Name = "lstMesajlar";
            this.lstMesajlar.Size = new System.Drawing.Size(373, 116);
            this.lstMesajlar.TabIndex = 5;
            // 
            // gboxSohbet
            // 
            this.gboxSohbet.Controls.Add(this.btnGonder);
            this.gboxSohbet.Controls.Add(this.txtMesaj);
            this.gboxSohbet.Controls.Add(this.lstMesajlar);
            this.gboxSohbet.Location = new System.Drawing.Point(42, 190);
            this.gboxSohbet.Name = "gboxSohbet";
            this.gboxSohbet.Size = new System.Drawing.Size(385, 233);
            this.gboxSohbet.TabIndex = 7;
            this.gboxSohbet.TabStop = false;
            this.gboxSohbet.Text = "Sohbet";
            // 
            // txtMesaj
            // 
            this.txtMesaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMesaj.Location = new System.Drawing.Point(6, 177);
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(199, 27);
            this.txtMesaj.TabIndex = 6;
            this.txtMesaj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMesaj_KeyDown);
            // 
            // btnGonder
            // 
            this.btnGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonder.Location = new System.Drawing.Point(211, 170);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(113, 43);
            this.btnGonder.TabIndex = 7;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 455);
            this.Controls.Add(this.gboxSohbet);
            this.Controls.Add(this.gboxGiris);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gboxGiris.ResumeLayout(false);
            this.gboxGiris.PerformLayout();
            this.gboxSohbet.ResumeLayout(false);
            this.gboxSohbet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxGiris;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button btnBaglan;
        private System.Windows.Forms.ListBox lstMesajlar;
        private System.Windows.Forms.GroupBox gboxSohbet;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.TextBox txtMesaj;
    }
}

