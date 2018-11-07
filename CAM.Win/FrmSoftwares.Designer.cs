namespace CAM.Win
{
    partial class FrmSoftwares
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.LblHost = new System.Windows.Forms.Label();
            this.GbSystem = new System.Windows.Forms.GroupBox();
            this.TxtIP = new System.Windows.Forms.TextBox();
            this.LblIP = new System.Windows.Forms.Label();
            this.TxtHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GBSoftwares = new System.Windows.Forms.GroupBox();
            this.DGViewSoftware = new System.Windows.Forms.DataGridView();
            this.GbSystem.SuspendLayout();
            this.GBSoftwares.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGViewSoftware)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 165);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(379, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(1101, 108);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(139, 48);
            this.btnUpload.TabIndex = 6;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(1114, 190);
            this.btnRead.Margin = new System.Windows.Forms.Padding(2);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(139, 48);
            this.btnRead.TabIndex = 5;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // LblHost
            // 
            this.LblHost.AutoSize = true;
            this.LblHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHost.Location = new System.Drawing.Point(6, 31);
            this.LblHost.Name = "LblHost";
            this.LblHost.Size = new System.Drawing.Size(37, 13);
            this.LblHost.TabIndex = 8;
            this.LblHost.Text = "Host:";
            // 
            // GbSystem
            // 
            this.GbSystem.Controls.Add(this.TxtIP);
            this.GbSystem.Controls.Add(this.LblIP);
            this.GbSystem.Controls.Add(this.TxtHost);
            this.GbSystem.Controls.Add(this.LblHost);
            this.GbSystem.Location = new System.Drawing.Point(17, 13);
            this.GbSystem.Name = "GbSystem";
            this.GbSystem.Size = new System.Drawing.Size(1064, 113);
            this.GbSystem.TabIndex = 9;
            this.GbSystem.TabStop = false;
            this.GbSystem.Text = "System Information";
            // 
            // TxtIP
            // 
            this.TxtIP.Location = new System.Drawing.Point(50, 67);
            this.TxtIP.Name = "TxtIP";
            this.TxtIP.Size = new System.Drawing.Size(333, 20);
            this.TxtIP.TabIndex = 11;
            // 
            // LblIP
            // 
            this.LblIP.AutoSize = true;
            this.LblIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIP.Location = new System.Drawing.Point(6, 67);
            this.LblIP.Name = "LblIP";
            this.LblIP.Size = new System.Drawing.Size(23, 13);
            this.LblIP.TabIndex = 10;
            this.LblIP.Text = "IP:";
            // 
            // TxtHost
            // 
            this.TxtHost.Location = new System.Drawing.Point(50, 31);
            this.TxtHost.Name = "TxtHost";
            this.TxtHost.Size = new System.Drawing.Size(333, 20);
            this.TxtHost.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Host:";
            // 
            // GBSoftwares
            // 
            this.GBSoftwares.Controls.Add(this.DGViewSoftware);
            this.GBSoftwares.Controls.Add(this.btnUpload);
            this.GBSoftwares.Location = new System.Drawing.Point(13, 145);
            this.GBSoftwares.Name = "GBSoftwares";
            this.GBSoftwares.Size = new System.Drawing.Size(1247, 685);
            this.GBSoftwares.TabIndex = 11;
            this.GBSoftwares.TabStop = false;
            this.GBSoftwares.Text = "Softwares";
            // 
            // DGViewSoftware
            // 
            this.DGViewSoftware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGViewSoftware.Location = new System.Drawing.Point(32, 80);
            this.DGViewSoftware.Name = "DGViewSoftware";
            this.DGViewSoftware.Size = new System.Drawing.Size(1036, 550);
            this.DGViewSoftware.TabIndex = 7;
            // 
            // FrmSoftwares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GbSystem);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.GBSoftwares);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmSoftwares";
            this.Text = "Intelligent";
            this.GbSystem.ResumeLayout(false);
            this.GbSystem.PerformLayout();
            this.GBSoftwares.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGViewSoftware)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label LblHost;
        private System.Windows.Forms.GroupBox GbSystem;
        private System.Windows.Forms.TextBox TxtHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GBSoftwares;
        private System.Windows.Forms.TextBox TxtIP;
        private System.Windows.Forms.Label LblIP;
        private System.Windows.Forms.DataGridView DGViewSoftware;
    }
}