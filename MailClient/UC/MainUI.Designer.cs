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
            this.pnlComposeSend = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRecipient = new System.Windows.Forms.Label();
            this.tbpReceive = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lsvMail = new System.Windows.Forms.ListView();
            this.lblSender = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblContent1 = new System.Windows.Forms.Label();
            this.lblNotifyImage = new System.Windows.Forms.Label();
            this.lblNotify = new System.Windows.Forms.Label();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtContent1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tbpSend.SuspendLayout();
            this.pnlComposeSend.SuspendLayout();
            this.tbpReceive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(676, 404);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(116, 32);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
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
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(45, 404);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(138, 32);
            this.btnSign.TabIndex = 6;
            this.btnSign.Text = "Sign this mail";
            this.btnSign.UseVisualStyleBackColor = true;
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
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(108, 101);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(684, 20);
            this.txtTitle.TabIndex = 4;
            // 
            // txtRecipient
            // 
            this.txtRecipient.Location = new System.Drawing.Point(108, 65);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(684, 20);
            this.txtRecipient.TabIndex = 3;
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
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(42, 104);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(60, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title:          ";
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
            // tbpReceive
            // 
            this.tbpReceive.Controls.Add(this.splitContainer1);
            this.tbpReceive.Location = new System.Drawing.Point(4, 22);
            this.tbpReceive.Name = "tbpReceive";
            this.tbpReceive.Padding = new System.Windows.Forms.Padding(3);
            this.tbpReceive.Size = new System.Drawing.Size(826, 469);
            this.tbpReceive.TabIndex = 1;
            this.tbpReceive.Text = "Receive";
            this.tbpReceive.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lsvMail);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtContent1);
            this.splitContainer1.Panel2.Controls.Add(this.txtSubject);
            this.splitContainer1.Panel2.Controls.Add(this.txtSender);
            this.splitContainer1.Panel2.Controls.Add(this.lblNotify);
            this.splitContainer1.Panel2.Controls.Add(this.lblNotifyImage);
            this.splitContainer1.Panel2.Controls.Add(this.lblContent1);
            this.splitContainer1.Panel2.Controls.Add(this.lblSubject);
            this.splitContainer1.Panel2.Controls.Add(this.lblSender);
            this.splitContainer1.Size = new System.Drawing.Size(820, 463);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 0;
            // 
            // lsvMail
            // 
            this.lsvMail.GridLines = true;
            this.lsvMail.Location = new System.Drawing.Point(4, 4);
            this.lsvMail.Name = "lsvMail";
            this.lsvMail.Size = new System.Drawing.Size(217, 456);
            this.lsvMail.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvMail.TabIndex = 0;
            this.lsvMail.UseCompatibleStateImageBehavior = false;
            this.lsvMail.View = System.Windows.Forms.View.List;
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Location = new System.Drawing.Point(32, 41);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(57, 13);
            this.lblSender.TabIndex = 0;
            this.lblSender.Text = "From:        ";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(32, 83);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(57, 13);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "Title:         ";
            // 
            // lblContent1
            // 
            this.lblContent1.AutoSize = true;
            this.lblContent1.Location = new System.Drawing.Point(32, 124);
            this.lblContent1.Name = "lblContent1";
            this.lblContent1.Size = new System.Drawing.Size(56, 13);
            this.lblContent1.TabIndex = 2;
            this.lblContent1.Text = "Content:   ";
            // 
            // lblNotifyImage
            // 
            this.lblNotifyImage.AutoSize = true;
            this.lblNotifyImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotifyImage.Image = global::MailClient.Properties.Resources.icons8_customs_officer_32;
            this.lblNotifyImage.Location = new System.Drawing.Point(31, 374);
            this.lblNotifyImage.Name = "lblNotifyImage";
            this.lblNotifyImage.Size = new System.Drawing.Size(36, 25);
            this.lblNotifyImage.TabIndex = 3;
            this.lblNotifyImage.Text = "    ";
            // 
            // lblNotify
            // 
            this.lblNotify.AutoSize = true;
            this.lblNotify.Location = new System.Drawing.Point(101, 383);
            this.lblNotify.Name = "lblNotify";
            this.lblNotify.Size = new System.Drawing.Size(106, 13);
            this.lblNotify.TabIndex = 4;
            this.lblNotify.Text = "NOT VERIFIED YET";
            // 
            // txtSender
            // 
            this.txtSender.Location = new System.Drawing.Point(104, 38);
            this.txtSender.Name = "txtSender";
            this.txtSender.ReadOnly = true;
            this.txtSender.Size = new System.Drawing.Size(461, 20);
            this.txtSender.TabIndex = 5;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(104, 80);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.ReadOnly = true;
            this.txtSubject.Size = new System.Drawing.Size(461, 20);
            this.txtSubject.TabIndex = 6;
            // 
            // txtContent1
            // 
            this.txtContent1.Location = new System.Drawing.Point(35, 141);
            this.txtContent1.Multiline = true;
            this.txtContent1.Name = "txtContent1";
            this.txtContent1.ReadOnly = true;
            this.txtContent1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent1.Size = new System.Drawing.Size(530, 215);
            this.txtContent1.TabIndex = 7;
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
            this.tbpReceive.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lsvMail;
        private System.Windows.Forms.Label lblNotifyImage;
        private System.Windows.Forms.Label lblContent1;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.Label lblNotify;
        private System.Windows.Forms.TextBox txtContent1;
    }
}
