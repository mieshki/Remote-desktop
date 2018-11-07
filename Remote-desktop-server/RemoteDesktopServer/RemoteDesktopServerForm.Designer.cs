namespace RemoteDesktopServer
{
    partial class RemoteDesktopServer
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIpAddr = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnShare = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(27, 49);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(62, 46);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 1;
            // 
            // txtIpAddr
            // 
            this.txtIpAddr.Location = new System.Drawing.Point(62, 20);
            this.txtIpAddr.Name = "txtIpAddr";
            this.txtIpAddr.Size = new System.Drawing.Size(100, 20);
            this.txtIpAddr.TabIndex = 3;
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(27, 23);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(22, 13);
            this.lblIp.TabIndex = 2;
            this.lblIp.Text = "Ip: ";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(30, 72);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(132, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnShare
            // 
            this.btnShare.Location = new System.Drawing.Point(30, 101);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(132, 23);
            this.btnShare.TabIndex = 5;
            this.btnShare.Text = "Share my screen";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RemoteDesktopServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 145);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIpAddr);
            this.Controls.Add(this.lblIp);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(204, 184);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(204, 184);
            this.Name = "RemoteDesktopServer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoteDesktopServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIpAddr;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Timer timer1;
    }
}

