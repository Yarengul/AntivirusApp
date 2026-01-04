namespace AntivirusApp
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
            this.btnScanFile = new System.Windows.Forms.Button();
            this.btnScanFolder = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.prgStatus = new System.Windows.Forms.ProgressBar();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnQuarantine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnScanFile
            // 
            this.btnScanFile.Location = new System.Drawing.Point(89, 51);
            this.btnScanFile.Name = "btnScanFile";
            this.btnScanFile.Size = new System.Drawing.Size(75, 23);
            this.btnScanFile.TabIndex = 0;
            this.btnScanFile.Text = "Dosya Tara";
            this.btnScanFile.UseVisualStyleBackColor = true;
            this.btnScanFile.Click += new System.EventHandler(this.btnScanFile_Click);
            // 
            // btnScanFolder
            // 
            this.btnScanFolder.Location = new System.Drawing.Point(89, 159);
            this.btnScanFolder.Name = "btnScanFolder";
            this.btnScanFolder.Size = new System.Drawing.Size(75, 23);
            this.btnScanFolder.TabIndex = 1;
            this.btnScanFolder.Text = "Klasör Tara";
            this.btnScanFolder.UseVisualStyleBackColor = true;
            this.btnScanFolder.Click += new System.EventHandler(this.btnScanFolder_Click);
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(170, 51);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(120, 95);
            this.lstResults.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(158, 202);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "label1";
            // 
            // prgStatus
            // 
            this.prgStatus.Location = new System.Drawing.Point(190, 159);
            this.prgStatus.Name = "prgStatus";
            this.prgStatus.Size = new System.Drawing.Size(100, 23);
            this.prgStatus.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(313, 51);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Seçileni Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnQuarantine
            // 
            this.btnQuarantine.Location = new System.Drawing.Point(313, 94);
            this.btnQuarantine.Name = "btnQuarantine";
            this.btnQuarantine.Size = new System.Drawing.Size(90, 23);
            this.btnQuarantine.TabIndex = 6;
            this.btnQuarantine.Text = "Karantinaya al";
            this.btnQuarantine.UseVisualStyleBackColor = true;
            this.btnQuarantine.Click += new System.EventHandler(this.btnQuarantine_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnQuarantine);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.prgStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnScanFolder);
            this.Controls.Add(this.btnScanFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScanFile;
        private System.Windows.Forms.Button btnScanFolder;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar prgStatus;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnQuarantine;
    }
}

