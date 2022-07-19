namespace IsIlaniOtomasyonu.Is_Veren
{
    partial class BasvuranBilgi
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
            this.cbxCalisma = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxOkul = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxTecrube = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxMaas = new System.Windows.Forms.TextBox();
            this.cbxAskerlik = new System.Windows.Forms.ComboBox();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCinsiyet = new System.Windows.Forms.ComboBox();
            this.dgwBasvuranlar = new System.Windows.Forms.DataGridView();
            this.btnSıfırla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBasvuranlar)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxCalisma
            // 
            this.cbxCalisma.Font = new System.Drawing.Font("Century Schoolbook", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxCalisma.FormattingEnabled = true;
            this.cbxCalisma.Items.AddRange(new object[] {
            "TAM ZAMANLI",
            "PART TIME",
            "STAJ"});
            this.cbxCalisma.Location = new System.Drawing.Point(8, 326);
            this.cbxCalisma.Name = "cbxCalisma";
            this.cbxCalisma.Size = new System.Drawing.Size(218, 30);
            this.cbxCalisma.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(5, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 21);
            this.label6.TabIndex = 27;
            this.label6.Text = "Çalışma Şekli";
            // 
            // cbxOkul
            // 
            this.cbxOkul.Font = new System.Drawing.Font("Century Schoolbook", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxOkul.FormattingEnabled = true;
            this.cbxOkul.Items.AddRange(new object[] {
            "İlkokul",
            "Lise",
            "Ön Lisans",
            "Lisans",
            "Yüksek Lisans",
            "Doktora"});
            this.cbxOkul.Location = new System.Drawing.Point(8, 269);
            this.cbxOkul.Name = "cbxOkul";
            this.cbxOkul.Size = new System.Drawing.Size(219, 30);
            this.cbxOkul.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(5, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "Okul Durumu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = "Tecrübe";
            // 
            // cbxTecrube
            // 
            this.cbxTecrube.Font = new System.Drawing.Font("Century Schoolbook", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxTecrube.FormattingEnabled = true;
            this.cbxTecrube.Items.AddRange(new object[] {
            "0",
            "0-2",
            "2-5",
            "5-10",
            "10+"});
            this.cbxTecrube.Location = new System.Drawing.Point(8, 212);
            this.cbxTecrube.Name = "cbxTecrube";
            this.cbxTecrube.Size = new System.Drawing.Size(222, 30);
            this.cbxTecrube.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(5, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "Maaş(MAX)";
            // 
            // tbxMaas
            // 
            this.tbxMaas.Font = new System.Drawing.Font("Century Schoolbook", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxMaas.Location = new System.Drawing.Point(9, 156);
            this.tbxMaas.Name = "tbxMaas";
            this.tbxMaas.Size = new System.Drawing.Size(222, 29);
            this.tbxMaas.TabIndex = 21;
            // 
            // cbxAskerlik
            // 
            this.cbxAskerlik.Font = new System.Drawing.Font("Century Schoolbook", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxAskerlik.FormattingEnabled = true;
            this.cbxAskerlik.Items.AddRange(new object[] {
            "ÖNEMLİ",
            "ÖNEMSİZ"});
            this.cbxAskerlik.Location = new System.Drawing.Point(9, 99);
            this.cbxAskerlik.Name = "cbxAskerlik";
            this.cbxAskerlik.Size = new System.Drawing.Size(222, 30);
            this.cbxAskerlik.TabIndex = 20;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.BackColor = System.Drawing.Color.Wheat;
            this.btnFiltrele.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFiltrele.Location = new System.Drawing.Point(44, 384);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(82, 54);
            this.btnFiltrele.TabIndex = 19;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.UseVisualStyleBackColor = false;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 18;
            this.label2.Text = "Askerlik";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "Cinsiyet";
            // 
            // cbxCinsiyet
            // 
            this.cbxCinsiyet.Font = new System.Drawing.Font("Century Schoolbook", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxCinsiyet.FormattingEnabled = true;
            this.cbxCinsiyet.Items.AddRange(new object[] {
            "KADIN",
            "ERKEK",
            "FARKETMEZ"});
            this.cbxCinsiyet.Location = new System.Drawing.Point(8, 33);
            this.cbxCinsiyet.Name = "cbxCinsiyet";
            this.cbxCinsiyet.Size = new System.Drawing.Size(222, 30);
            this.cbxCinsiyet.TabIndex = 16;
            // 
            // dgwBasvuranlar
            // 
            this.dgwBasvuranlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwBasvuranlar.Location = new System.Drawing.Point(294, 12);
            this.dgwBasvuranlar.Name = "dgwBasvuranlar";
            this.dgwBasvuranlar.RowTemplate.Height = 24;
            this.dgwBasvuranlar.Size = new System.Drawing.Size(495, 426);
            this.dgwBasvuranlar.TabIndex = 15;
            // 
            // btnSıfırla
            // 
            this.btnSıfırla.BackColor = System.Drawing.Color.Wheat;
            this.btnSıfırla.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSıfırla.Location = new System.Drawing.Point(132, 384);
            this.btnSıfırla.Name = "btnSıfırla";
            this.btnSıfırla.Size = new System.Drawing.Size(98, 54);
            this.btnSıfırla.TabIndex = 29;
            this.btnSıfırla.Text = "Sıfırla";
            this.btnSıfırla.UseVisualStyleBackColor = false;
            this.btnSıfırla.Click += new System.EventHandler(this.btnSıfırla_Click);
            // 
            // BasvuranBilgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSıfırla);
            this.Controls.Add(this.cbxCalisma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxOkul);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxTecrube);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxMaas);
            this.Controls.Add(this.cbxAskerlik);
            this.Controls.Add(this.btnFiltrele);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxCinsiyet);
            this.Controls.Add(this.dgwBasvuranlar);
            this.DoubleBuffered = true;
            this.Name = "BasvuranBilgi";
            this.Text = "BasvuranBilgi";
            this.Load += new System.EventHandler(this.BasvuranBilgi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwBasvuranlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCalisma;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxOkul;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxTecrube;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxMaas;
        private System.Windows.Forms.ComboBox cbxAskerlik;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCinsiyet;
        private System.Windows.Forms.DataGridView dgwBasvuranlar;
        private System.Windows.Forms.Button btnSıfırla;
    }
}