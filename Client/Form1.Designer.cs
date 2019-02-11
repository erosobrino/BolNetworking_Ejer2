namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtServerMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtUserMessage = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btExit = new System.Windows.Forms.Button();
            this.btList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServerMessage
            // 
            this.txtServerMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtServerMessage.Location = new System.Drawing.Point(0, 87);
            this.txtServerMessage.Multiline = true;
            this.txtServerMessage.Name = "txtServerMessage";
            this.txtServerMessage.ReadOnly = true;
            this.txtServerMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServerMessage.Size = new System.Drawing.Size(800, 363);
            this.txtServerMessage.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 38);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(110, 17);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Your name here";
            // 
            // txtUserMessage
            // 
            this.txtUserMessage.Location = new System.Drawing.Point(153, 33);
            this.txtUserMessage.Name = "txtUserMessage";
            this.txtUserMessage.Size = new System.Drawing.Size(137, 22);
            this.txtUserMessage.TabIndex = 2;
            // 
            // btSend
            // 
            this.btSend.Enabled = false;
            this.btSend.Location = new System.Drawing.Point(296, 8);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(116, 73);
            this.btSend.TabIndex = 3;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(688, 8);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(100, 58);
            this.btConnect.TabIndex = 4;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(531, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(573, 8);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(100, 22);
            this.txtIp.TabIndex = 7;
            this.txtIp.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(573, 44);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 22);
            this.txtPort.TabIndex = 8;
            this.txtPort.Text = "31416";
            // 
            // btExit
            // 
            this.btExit.Enabled = false;
            this.btExit.Location = new System.Drawing.Point(418, 8);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(111, 33);
            this.btExit.TabIndex = 9;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btList
            // 
            this.btList.Enabled = false;
            this.btList.Location = new System.Drawing.Point(418, 47);
            this.btList.Name = "btList";
            this.btList.Size = new System.Drawing.Size(111, 34);
            this.btList.TabIndex = 10;
            this.btList.Text = "List";
            this.btList.UseVisualStyleBackColor = true;
            this.btList.Click += new System.EventHandler(this.btList_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btList);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.txtUserMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtServerMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChatRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtServerMessage;
        public System.Windows.Forms.TextBox txtUserMessage;
        public System.Windows.Forms.TextBox txtIp;
        public System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btList;
    }
}

