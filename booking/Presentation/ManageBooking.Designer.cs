namespace booking
{
    partial class ManageBooking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBooking));
            this.btnEnquiry = new System.Windows.Forms.Button();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnModifyBooking = new System.Windows.Forms.Button();
            this.btnMakeBooking = new System.Windows.Forms.Button();
            this.btnViewAllBookings = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnquiry
            // 
            this.btnEnquiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnquiry.Location = new System.Drawing.Point(110, 273);
            this.btnEnquiry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnquiry.Name = "btnEnquiry";
            this.btnEnquiry.Size = new System.Drawing.Size(191, 31);
            this.btnEnquiry.TabIndex = 26;
            this.btnEnquiry.Text = "Booking Enquiry";
            this.btnEnquiry.UseVisualStyleBackColor = true;
            this.btnEnquiry.Click += new System.EventHandler(this.btnEnquiry_Click);
            // 
            // btnViewAllBookings
            // 
            this.btnViewAllBookings.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAllBookings.Location = new System.Drawing.Point(110, 309);
            this.btnViewAllBookings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewAllBookings.Name = "btnViewAllBookings";
            this.btnViewAllBookings.Size = new System.Drawing.Size(191, 31);
            this.btnViewAllBookings.TabIndex = 27;
            this.btnViewAllBookings.Text = "View All Bookings";
            this.btnViewAllBookings.UseVisualStyleBackColor = true;
            this.btnViewAllBookings.Click += new System.EventHandler(this.btnViewAllBookings_Click);
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelBooking.Location = new System.Drawing.Point(110, 236);
            this.btnCancelBooking.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(191, 33);
            this.btnCancelBooking.TabIndex = 25;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // btnModifyBooking
            // 
            this.btnModifyBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyBooking.Location = new System.Drawing.Point(110, 201);
            this.btnModifyBooking.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModifyBooking.Name = "btnModifyBooking";
            this.btnModifyBooking.Size = new System.Drawing.Size(191, 31);
            this.btnModifyBooking.TabIndex = 24;
            this.btnModifyBooking.Text = "Modify Booking";
            this.btnModifyBooking.UseVisualStyleBackColor = true;
            this.btnModifyBooking.Click += new System.EventHandler(this.btnModifyBooking_Click);
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeBooking.Location = new System.Drawing.Point(110, 167);
            this.btnMakeBooking.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Size = new System.Drawing.Size(191, 30);
            this.btnMakeBooking.TabIndex = 23;
            this.btnMakeBooking.Text = "Make Booking";
            this.btnMakeBooking.UseVisualStyleBackColor = true;
            this.btnMakeBooking.Click += new System.EventHandler(this.btnMakeBooking_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(413, 369);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // ManageBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 366);
            this.Controls.Add(this.btnViewAllBookings);
            this.Controls.Add(this.btnEnquiry);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.btnModifyBooking);
            this.Controls.Add(this.btnMakeBooking);
            this.Controls.Add(this.pictureBox2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManageBooking";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnquiry;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnModifyBooking;
        private System.Windows.Forms.Button btnMakeBooking;
        private System.Windows.Forms.Button btnViewAllBookings;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

