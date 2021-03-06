
namespace LTCPool_UTSharp
{
    partial class MainWindow
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.paidRewLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.unpaidRewLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HashSpeedLbl = new System.Windows.Forms.Label();
            this.excp24RewardsLbl = new System.Windows.Forms.Label();
            this.TotEarnLbl = new System.Windows.Forms.Label();
            this.globalUpdater = new System.Windows.Forms.Timer(this.components);
            this.settingsFDialog = new System.Windows.Forms.OpenFileDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.totWorkLbl = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Informations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(33, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hashing Speed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(33, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Excpected 24/hrs Rewards:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(33, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Earnings:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(605, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Paid Rewards:";
            // 
            // paidRewLbl
            // 
            this.paidRewLbl.AutoSize = true;
            this.paidRewLbl.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidRewLbl.ForeColor = System.Drawing.Color.DarkGreen;
            this.paidRewLbl.Location = new System.Drawing.Point(701, 37);
            this.paidRewLbl.Name = "paidRewLbl";
            this.paidRewLbl.Size = new System.Drawing.Size(140, 19);
            this.paidRewLbl.TabIndex = 3;
            this.paidRewLbl.Text = "0.000000000000000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(587, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "Unpaid Rewards:";
            // 
            // unpaidRewLbl
            // 
            this.unpaidRewLbl.AutoSize = true;
            this.unpaidRewLbl.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unpaidRewLbl.ForeColor = System.Drawing.Color.Green;
            this.unpaidRewLbl.Location = new System.Drawing.Point(701, 57);
            this.unpaidRewLbl.Name = "unpaidRewLbl";
            this.unpaidRewLbl.Size = new System.Drawing.Size(140, 19);
            this.unpaidRewLbl.TabIndex = 3;
            this.unpaidRewLbl.Text = "0.000000000000000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(787, 529);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Status:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importSettingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importSettingsToolStripMenuItem
            // 
            this.importSettingsToolStripMenuItem.Name = "importSettingsToolStripMenuItem";
            this.importSettingsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.importSettingsToolStripMenuItem.Text = "Import Settings";
            this.importSettingsToolStripMenuItem.Click += new System.EventHandler(this.importSettingsToolStripMenuItem_Click);
            // 
            // HashSpeedLbl
            // 
            this.HashSpeedLbl.AutoSize = true;
            this.HashSpeedLbl.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HashSpeedLbl.ForeColor = System.Drawing.Color.Green;
            this.HashSpeedLbl.Location = new System.Drawing.Point(195, 83);
            this.HashSpeedLbl.Name = "HashSpeedLbl";
            this.HashSpeedLbl.Size = new System.Drawing.Size(23, 25);
            this.HashSpeedLbl.TabIndex = 1;
            this.HashSpeedLbl.Text = "0";
            // 
            // excp24RewardsLbl
            // 
            this.excp24RewardsLbl.AutoSize = true;
            this.excp24RewardsLbl.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excp24RewardsLbl.ForeColor = System.Drawing.Color.Green;
            this.excp24RewardsLbl.Location = new System.Drawing.Point(296, 214);
            this.excp24RewardsLbl.Name = "excp24RewardsLbl";
            this.excp24RewardsLbl.Size = new System.Drawing.Size(23, 25);
            this.excp24RewardsLbl.TabIndex = 1;
            this.excp24RewardsLbl.Text = "0";
            // 
            // TotEarnLbl
            // 
            this.TotEarnLbl.AutoSize = true;
            this.TotEarnLbl.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotEarnLbl.ForeColor = System.Drawing.Color.Green;
            this.TotEarnLbl.Location = new System.Drawing.Point(186, 170);
            this.TotEarnLbl.Name = "TotEarnLbl";
            this.TotEarnLbl.Size = new System.Drawing.Size(23, 25);
            this.TotEarnLbl.TabIndex = 1;
            this.TotEarnLbl.Text = "0";
            // 
            // globalUpdater
            // 
            this.globalUpdater.Interval = 10000;
            this.globalUpdater.Tick += new System.EventHandler(this.globalUpdater_Tick);
            // 
            // settingsFDialog
            // 
            this.settingsFDialog.Filter = "JSON Files|*.json";
            this.settingsFDialog.Title = "Import Settings";
            this.settingsFDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.settingsFDialog_FileOk);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(33, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 25);
            this.label10.TabIndex = 9;
            this.label10.Text = "Total Work:";
            // 
            // totWorkLbl
            // 
            this.totWorkLbl.AutoSize = true;
            this.totWorkLbl.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totWorkLbl.ForeColor = System.Drawing.Color.Green;
            this.totWorkLbl.Location = new System.Drawing.Point(156, 128);
            this.totWorkLbl.Name = "totWorkLbl";
            this.totWorkLbl.Size = new System.Drawing.Size(23, 25);
            this.totWorkLbl.TabIndex = 1;
            this.totWorkLbl.Text = "0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 554);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.unpaidRewLbl);
            this.Controls.Add(this.paidRewLbl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TotEarnLbl);
            this.Controls.Add(this.excp24RewardsLbl);
            this.Controls.Add(this.totWorkLbl);
            this.Controls.Add(this.HashSpeedLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Viewport";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label paidRewLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label unpaidRewLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label HashSpeedLbl;
        private System.Windows.Forms.Label excp24RewardsLbl;
        private System.Windows.Forms.Label TotEarnLbl;
        public System.Windows.Forms.Timer globalUpdater;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSettingsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog settingsFDialog;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label totWorkLbl;
    }
}

