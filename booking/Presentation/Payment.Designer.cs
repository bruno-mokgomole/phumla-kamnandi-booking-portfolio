namespace booking.Presentation
{
    partial class Payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payment));
            this.btnPay = new System.Windows.Forms.Button();
            this.txtExpires = new System.Windows.Forms.TextBox();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.groupBoxBankingInfo = new System.Windows.Forms.GroupBox();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.txtAccNumber = new System.Windows.Forms.TextBox();
            this.txtAccHolder = new System.Windows.Forms.TextBox();
            this.lblExpirey = new System.Windows.Forms.Label();
            this.lblCVV = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblAccNumber = new System.Windows.Forms.Label();
            this.lblAccHolder = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.groupBoxBankingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPay
            // 
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.Black;
            this.btnPay.Location = new System.Drawing.Point(68, 511);
            this.btnPay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(119, 30);
            this.btnPay.TabIndex = 17;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // txtExpires
            // 
            this.txtExpires.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpires.Location = new System.Drawing.Point(156, 154);
            this.txtExpires.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExpires.Name = "txtExpires";
            this.txtExpires.Size = new System.Drawing.Size(192, 22);
            this.txtExpires.TabIndex = 9;
            // 
            // txtCVV
            // 
            this.txtCVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCVV.Location = new System.Drawing.Point(156, 123);
            this.txtCVV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(192, 22);
            this.txtCVV.TabIndex = 8;
            // 
            // groupBoxBankingInfo
            // 
            this.groupBoxBankingInfo.BackColor = System.Drawing.Color.Black;
            this.groupBoxBankingInfo.Controls.Add(this.txtExpires);
            this.groupBoxBankingInfo.Controls.Add(this.txtCVV);
            this.groupBoxBankingInfo.Controls.Add(this.txtBank);
            this.groupBoxBankingInfo.Controls.Add(this.txtAccNumber);
            this.groupBoxBankingInfo.Controls.Add(this.txtAccHolder);
            this.groupBoxBankingInfo.Controls.Add(this.lblExpirey);
            this.groupBoxBankingInfo.Controls.Add(this.lblCVV);
            this.groupBoxBankingInfo.Controls.Add(this.lblBank);
            this.groupBoxBankingInfo.Controls.Add(this.lblAccNumber);
            this.groupBoxBankingInfo.Controls.Add(this.lblAccHolder);
            this.groupBoxBankingInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBankingInfo.ForeColor = System.Drawing.Color.White;
            this.groupBoxBankingInfo.Location = new System.Drawing.Point(68, 289);
            this.groupBoxBankingInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxBankingInfo.Name = "groupBoxBankingInfo";
            this.groupBoxBankingInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxBankingInfo.Size = new System.Drawing.Size(375, 206);
            this.groupBoxBankingInfo.TabIndex = 16;
            this.groupBoxBankingInfo.TabStop = false;
            this.groupBoxBankingInfo.Text = "Banking Details";
            // 
            // txtBank
            // 
            this.txtBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(156, 95);
            this.txtBank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(192, 22);
            this.txtBank.TabIndex = 7;
            // 
            // txtAccNumber
            // 
            this.txtAccNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccNumber.Location = new System.Drawing.Point(156, 65);
            this.txtAccNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAccNumber.Name = "txtAccNumber";
            this.txtAccNumber.Size = new System.Drawing.Size(192, 22);
            this.txtAccNumber.TabIndex = 6;
            // 
            // txtAccHolder
            // 
            this.txtAccHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccHolder.Location = new System.Drawing.Point(156, 37);
            this.txtAccHolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAccHolder.Name = "txtAccHolder";
            this.txtAccHolder.Size = new System.Drawing.Size(192, 22);
            this.txtAccHolder.TabIndex = 5;
            // 
            // lblExpirey
            // 
            this.lblExpirey.AutoSize = true;
            this.lblExpirey.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirey.Location = new System.Drawing.Point(19, 158);
            this.lblExpirey.Name = "lblExpirey";
            this.lblExpirey.Size = new System.Drawing.Size(52, 16);
            this.lblExpirey.TabIndex = 4;
            this.lblExpirey.Text = "Expires";
            // 
            // lblCVV
            // 
            this.lblCVV.AutoSize = true;
            this.lblCVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCVV.Location = new System.Drawing.Point(19, 129);
            this.lblCVV.Name = "lblCVV";
            this.lblCVV.Size = new System.Drawing.Size(34, 16);
            this.lblCVV.TabIndex = 3;
            this.lblCVV.Text = "CVV";
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.Location = new System.Drawing.Point(19, 101);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(38, 16);
            this.lblBank.TabIndex = 2;
            this.lblBank.Text = "Bank";
            // 
            // lblAccNumber
            // 
            this.lblAccNumber.AutoSize = true;
            this.lblAccNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccNumber.Location = new System.Drawing.Point(19, 71);
            this.lblAccNumber.Name = "lblAccNumber";
            this.lblAccNumber.Size = new System.Drawing.Size(106, 16);
            this.lblAccNumber.TabIndex = 1;
            this.lblAccNumber.Text = "Account Number";
            // 
            // lblAccHolder
            // 
            this.lblAccHolder.AutoSize = true;
            this.lblAccHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccHolder.Location = new System.Drawing.Point(19, 43);
            this.lblAccHolder.Name = "lblAccHolder";
            this.lblAccHolder.Size = new System.Drawing.Size(99, 16);
            this.lblAccHolder.TabIndex = 0;
            this.lblAccHolder.Text = "Account Holder";
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(165, 191);
            this.txtDeposit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.ReadOnly = true;
            this.txtDeposit.Size = new System.Drawing.Size(160, 22);
            this.txtDeposit.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(527, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDeposit.Location = new System.Drawing.Point(65, 191);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(61, 16);
            this.lblDeposit.TabIndex = 11;
            this.lblDeposit.Text = "Deposit";
            this.lblDeposit.Click += new System.EventHandler(this.lblDeposit_Click);
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(529, 554);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.groupBoxBankingInfo);
            this.Controls.Add(this.txtDeposit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDeposit);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Payment";
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.Payment_Load);
            this.groupBoxBankingInfo.ResumeLayout(false);
            this.groupBoxBankingInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.TextBox txtExpires;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.GroupBox groupBoxBankingInfo;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.TextBox txtAccNumber;
        private System.Windows.Forms.TextBox txtAccHolder;
        private System.Windows.Forms.Label lblExpirey;
        private System.Windows.Forms.Label lblCVV;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblAccNumber;
        private System.Windows.Forms.Label lblAccHolder;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDeposit;
    }
}