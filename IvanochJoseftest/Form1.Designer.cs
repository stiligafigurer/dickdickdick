﻿namespace IvanochJoseftest
{
    partial class Form1
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
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbKategori = new System.Windows.Forms.ListBox();
            this.lvEpisodes = new System.Windows.Forms.ListView();
            this.Namn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNyKategori = new System.Windows.Forms.Button();
            this.btnSparaKategori = new System.Windows.Forms.Button();
            this.btnTaBortKategori = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.btnNyPodcast = new System.Windows.Forms.Button();
            this.btnSpara = new System.Windows.Forms.Button();
            this.btnTaBortPodcast = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lvPodcast = new System.Windows.Forms.ListView();
            this.Avsnitt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbUppFrek = new System.Windows.Forms.ComboBox();
            this.cbKategori = new System.Windows.Forms.ComboBox();
            this.Nummer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Datum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(966, 560);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 74);
            this.button2.TabIndex = 0;
            this.button2.Text = "Click For Dick";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(821, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kategorier:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbKategori
            // 
            this.lbKategori.FormattingEnabled = true;
            this.lbKategori.ItemHeight = 20;
            this.lbKategori.Location = new System.Drawing.Point(825, 36);
            this.lbKategori.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbKategori.Name = "lbKategori";
            this.lbKategori.Size = new System.Drawing.Size(268, 204);
            this.lbKategori.TabIndex = 3;
            // 
            // lvEpisodes
            // 
            this.lvEpisodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nummer,
            this.Namn,
            this.Datum});
            this.lvEpisodes.Location = new System.Drawing.Point(14, 346);
            this.lvEpisodes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvEpisodes.Name = "lvEpisodes";
            this.lvEpisodes.Size = new System.Drawing.Size(594, 305);
            this.lvEpisodes.TabIndex = 4;
            this.lvEpisodes.UseCompatibleStateImageBehavior = false;
            this.lvEpisodes.View = System.Windows.Forms.View.Details;
            // 
            // Namn
            // 
            this.Namn.Text = "Namn";
            this.Namn.Width = 188;
            // 
            // btnNyKategori
            // 
            this.btnNyKategori.Location = new System.Drawing.Point(825, 285);
            this.btnNyKategori.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNyKategori.Name = "btnNyKategori";
            this.btnNyKategori.Size = new System.Drawing.Size(84, 29);
            this.btnNyKategori.TabIndex = 5;
            this.btnNyKategori.Text = "Ny kategori";
            this.btnNyKategori.UseVisualStyleBackColor = true;
            // 
            // btnSparaKategori
            // 
            this.btnSparaKategori.Location = new System.Drawing.Point(917, 284);
            this.btnSparaKategori.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSparaKategori.Name = "btnSparaKategori";
            this.btnSparaKategori.Size = new System.Drawing.Size(84, 29);
            this.btnSparaKategori.TabIndex = 6;
            this.btnSparaKategori.Text = "Spara";
            this.btnSparaKategori.UseVisualStyleBackColor = true;
            // 
            // btnTaBortKategori
            // 
            this.btnTaBortKategori.Location = new System.Drawing.Point(1009, 284);
            this.btnTaBortKategori.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTaBortKategori.Name = "btnTaBortKategori";
            this.btnTaBortKategori.Size = new System.Drawing.Size(84, 29);
            this.btnTaBortKategori.TabIndex = 7;
            this.btnTaBortKategori.Text = "Ta bort";
            this.btnTaBortKategori.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(825, 250);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 26);
            this.textBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "URL:";
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(18, 250);
            this.tbURL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(273, 26);
            this.tbURL.TabIndex = 10;
            // 
            // btnNyPodcast
            // 
            this.btnNyPodcast.Location = new System.Drawing.Point(348, 288);
            this.btnNyPodcast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNyPodcast.Name = "btnNyPodcast";
            this.btnNyPodcast.Size = new System.Drawing.Size(99, 29);
            this.btnNyPodcast.TabIndex = 11;
            this.btnNyPodcast.Text = "Ny Podcast";
            this.btnNyPodcast.UseVisualStyleBackColor = true;
            // 
            // btnSpara
            // 
            this.btnSpara.Location = new System.Drawing.Point(453, 288);
            this.btnSpara.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSpara.Name = "btnSpara";
            this.btnSpara.Size = new System.Drawing.Size(84, 29);
            this.btnSpara.TabIndex = 12;
            this.btnSpara.Text = "Spara";
            this.btnSpara.UseVisualStyleBackColor = true;
            // 
            // btnTaBortPodcast
            // 
            this.btnTaBortPodcast.Location = new System.Drawing.Point(543, 288);
            this.btnTaBortPodcast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTaBortPodcast.Name = "btnTaBortPodcast";
            this.btnTaBortPodcast.Size = new System.Drawing.Size(84, 29);
            this.btnTaBortPodcast.TabIndex = 13;
            this.btnTaBortPodcast.Text = "Ta bort";
            this.btnTaBortPodcast.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Uppdateringsfrekvens:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(488, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Kategori:";
            // 
            // lvPodcast
            // 
            this.lvPodcast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Avsnitt,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvPodcast.Location = new System.Drawing.Point(18, 16);
            this.lvPodcast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvPodcast.Name = "lvPodcast";
            this.lvPodcast.Size = new System.Drawing.Size(589, 165);
            this.lvPodcast.TabIndex = 16;
            this.lvPodcast.UseCompatibleStateImageBehavior = false;
            this.lvPodcast.View = System.Windows.Forms.View.Details;
            this.lvPodcast.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvPodcast_ItemSelectionChanged);
            // 
            // Avsnitt
            // 
            this.Avsnitt.Text = "Avsnitt";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Namn";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Frekvens";
            this.columnHeader3.Width = 116;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Kategori";
            this.columnHeader4.Width = 126;
            // 
            // cbUppFrek
            // 
            this.cbUppFrek.FormattingEnabled = true;
            this.cbUppFrek.Location = new System.Drawing.Point(310, 248);
            this.cbUppFrek.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUppFrek.Name = "cbUppFrek";
            this.cbUppFrek.Size = new System.Drawing.Size(136, 28);
            this.cbUppFrek.TabIndex = 17;
            // 
            // cbKategori
            // 
            this.cbKategori.FormattingEnabled = true;
            this.cbKategori.Location = new System.Drawing.Point(492, 250);
            this.cbKategori.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbKategori.Name = "cbKategori";
            this.cbKategori.Size = new System.Drawing.Size(136, 28);
            this.cbKategori.TabIndex = 18;
            // 
            // Nummer
            // 
            this.Nummer.Text = "Nummer";
            // 
            // Datum
            // 
            this.Datum.Text = "Datum";
            this.Datum.Width = 122;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 666);
            this.Controls.Add(this.cbKategori);
            this.Controls.Add(this.cbUppFrek);
            this.Controls.Add(this.lvPodcast);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTaBortPodcast);
            this.Controls.Add(this.btnSpara);
            this.Controls.Add(this.btnNyPodcast);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnTaBortKategori);
            this.Controls.Add(this.btnSparaKategori);
            this.Controls.Add(this.btnNyKategori);
            this.Controls.Add(this.lvEpisodes);
            this.Controls.Add(this.lbKategori);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbKategori;
        private System.Windows.Forms.ListView lvEpisodes;
        private System.Windows.Forms.ColumnHeader Namn;
        private System.Windows.Forms.Button btnNyKategori;
        private System.Windows.Forms.Button btnSparaKategori;
        private System.Windows.Forms.Button btnTaBortKategori;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Button btnNyPodcast;
        private System.Windows.Forms.Button btnSpara;
        private System.Windows.Forms.Button btnTaBortPodcast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvPodcast;
        private System.Windows.Forms.ColumnHeader Avsnitt;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox cbUppFrek;
        private System.Windows.Forms.ComboBox cbKategori;
        private System.Windows.Forms.ColumnHeader Nummer;
        private System.Windows.Forms.ColumnHeader Datum;
    }
}

