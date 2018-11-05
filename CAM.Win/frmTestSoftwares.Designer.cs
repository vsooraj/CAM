namespace CAM.Win
{
    partial class frmTestSoftwares
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
            this.dgvSoftwares = new System.Windows.Forms.DataGridView();
            this.LblHost = new System.Windows.Forms.Label();
            this.GbSystem = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GBSoftwares = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.LblIP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoftwares)).BeginInit();
            this.GbSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 165);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(379, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(1121, 772);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.btnRead.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(139, 48);
            this.btnRead.TabIndex = 5;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // dgvSoftwares
            // 
            this.dgvSoftwares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoftwares.Location = new System.Drawing.Point(36, 190);
            this.dgvSoftwares.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvSoftwares.Name = "dgvSoftwares";
            this.dgvSoftwares.RowTemplate.Height = 28;
            this.dgvSoftwares.Size = new System.Drawing.Size(1064, 630);
            this.dgvSoftwares.TabIndex = 4;
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
            this.GbSystem.Controls.Add(this.textBox2);
            this.GbSystem.Controls.Add(this.LblIP);
            this.GbSystem.Controls.Add(this.textBox1);
            this.GbSystem.Controls.Add(this.LblHost);
            this.GbSystem.Location = new System.Drawing.Point(36, 13);
            this.GbSystem.Name = "GbSystem";
            this.GbSystem.Size = new System.Drawing.Size(1064, 113);
            this.GbSystem.TabIndex = 9;
            this.GbSystem.TabStop = false;
            this.GbSystem.Text = "System Information";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(333, 20);
            this.textBox1.TabIndex = 9;
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
            this.GBSoftwares.Location = new System.Drawing.Point(13, 145);
            this.GBSoftwares.Name = "GBSoftwares";
            this.GBSoftwares.Size = new System.Drawing.Size(1247, 685);
            this.GBSoftwares.TabIndex = 11;
            this.GBSoftwares.TabStop = false;
            this.GBSoftwares.Text = "Softwares";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(50, 67);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(333, 20);
            this.textBox2.TabIndex = 11;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
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
            this.LblIP.Click += new System.EventHandler(this.label2_Click);
            // 
            // frmTestSoftwares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GbSystem);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.dgvSoftwares);
            this.Controls.Add(this.GBSoftwares);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmTestSoftwares";
            this.Text = "Intelligent";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoftwares)).EndInit();
            this.GbSystem.ResumeLayout(false);
            this.GbSystem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.DataGridView dgvSoftwares;
        private System.Windows.Forms.Label LblHost;
        private System.Windows.Forms.GroupBox GbSystem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GBSoftwares;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label LblIP;
    }
}