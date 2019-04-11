namespace MailClient.UC
{
    partial class MainUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpSend = new System.Windows.Forms.TabPage();
            this.tbpReceive = new System.Windows.Forms.TabPage();
            this.pnlComposeSend = new System.Windows.Forms.Panel();
            this.lblRecipient = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tbpSend.SuspendLayout();
            this.pnlComposeSend.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpSend);
            this.tabControl1.Controls.Add(this.tbpReceive);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(834, 495);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpSend
            // 
            this.tbpSend.Controls.Add(this.pnlComposeSend);
            this.tbpSend.Location = new System.Drawing.Point(4, 22);
            this.tbpSend.Name = "tbpSend";
            this.tbpSend.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSend.Size = new System.Drawing.Size(826, 469);
            this.tbpSend.TabIndex = 0;
            this.tbpSend.Text = "Compose & Send";
            this.tbpSend.UseVisualStyleBackColor = true;
            // 
            // tbpReceive
            // 
            this.tbpReceive.Location = new System.Drawing.Point(4, 22);
            this.tbpReceive.Name = "tbpReceive";
            this.tbpReceive.Padding = new System.Windows.Forms.Padding(3);
            this.tbpReceive.Size = new System.Drawing.Size(826, 469);
            this.tbpReceive.TabIndex = 1;
            this.tbpReceive.Text = "Receive";
            this.tbpReceive.UseVisualStyleBackColor = true;
            // 
            // pnlComposeSend
            // 
            this.pnlComposeSend.Controls.Add(this.btnSend);
            this.pnlComposeSend.Controls.Add(this.btnEncrypt);
            this.pnlComposeSend.Controls.Add(this.btnSign);
            this.pnlComposeSend.Controls.Add(this.txtContent);
            this.pnlComposeSend.Controls.Add(this.txtTitle);
            this.pnlComposeSend.Controls.Add(this.txtRecipient);
            this.pnlComposeSend.Controls.Add(this.lblContent);
            this.pnlComposeSend.Controls.Add(this.lblTitle);
            this.pnlComposeSend.Controls.Add(this.lblRecipient);
            this.pnlComposeSend.Location = new System.Drawing.Point(7, 7);
            this.pnlComposeSend.Name = "pnlComposeSend";
            this.pnlComposeSend.Size = new System.Drawing.Size(813, 456);
            this.pnlComposeSend.TabIndex = 0;
            // 
            // lblRecipient
            // 
            this.lblRecipient.AutoSize = true;
            this.lblRecipient.Location = new System.Drawing.Point(42, 68);
            this.lblRecipient.Name = "lblRecipient";
            this.lblRecipient.Size = new System.Drawing.Size(59, 13);
            this.lblRecipient.TabIndex = 0;
            this.lblRecipient.Text = "To:            ";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(42, 104);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(60, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title:          ";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(42, 135);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(59, 13);
            this.lblContent.TabIndex = 2;
            this.lblContent.Text = "Content:    ";
            // 
            // txtRecipient
            // 
            this.txtRecipient.Location = new System.Drawing.Point(108, 65);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(684, 20);
            this.txtRecipient.TabIndex = 3;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(108, 101);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(684, 20);
            this.txtTitle.TabIndex = 4;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(45, 152);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(747, 237);
            this.txtContent.TabIndex = 5;
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(45, 404);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(138, 32);
            this.btnSign.TabIndex = 6;
            this.btnSign.Text = "Sign this mail";
            this.btnSign.UseVisualStyleBackColor = true;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(309, 404);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(150, 32);
            this.btnEncrypt.TabIndex = 7;
            this.btnEncrypt.Text = "Encrypt this mail";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(676, 404);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(116, 32);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "MainUI";
            this.Size = new System.Drawing.Size(840, 511);
            this.tabControl1.ResumeLayout(false);
            this.tbpSend.ResumeLayout(false);
            this.pnlComposeSend.ResumeLayout(false);
            this.pnlComposeSend.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpSend;
        private System.Windows.Forms.TabPage tbpReceive;
        private System.Windows.Forms.Panel pnlComposeSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRecipient;
    }
}
