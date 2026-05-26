namespace booking.Presentation
{
    partial class BookingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingForm));
            this.btnReservation = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSearchAvailability = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rdbNewGuest = new System.Windows.Forms.RadioButton();
            this.grpBoxBookingInfo = new System.Windows.Forms.GroupBox();
            this.dateTimePickerCheckOut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCheckIn = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownRooms = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownChildren = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAdults = new System.Windows.Forms.NumericUpDown();
            this.lblChildren = new System.Windows.Forms.Label();
            this.lblAdults = new System.Windows.Forms.Label();
            this.lblRooms = new System.Windows.Forms.Label();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rdbExisting = new System.Windows.Forms.RadioButton();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.grpBoxPersonalInfo = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDOB = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.grpBoxBookingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpBoxPersonalInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReservation
            // 
            this.btnReservation.Location = new System.Drawing.Point(158, 356);
            this.btnReservation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Size = new System.Drawing.Size(134, 30);
            this.btnReservation.TabIndex = 23;
            this.btnReservation.Text = "Make Reservation";
            this.btnReservation.UseVisualStyleBackColor = true;
            this.btnReservation.Click += new System.EventHandler(this.btnReservation_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(33, 611);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(134, 26);
            this.btnSubmit.TabIndex = 22;
            this.btnSubmit.Text = "Confirm Reservation";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnSearchAvailability
            // 
            this.btnSearchAvailability.Location = new System.Drawing.Point(32, 357);
            this.btnSearchAvailability.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearchAvailability.Name = "btnSearchAvailability";
            this.btnSearchAvailability.Size = new System.Drawing.Size(113, 29);
            this.btnSearchAvailability.TabIndex = 21;
            this.btnSearchAvailability.Text = "Search Availability";
            this.btnSearchAvailability.UseVisualStyleBackColor = true;
            this.btnSearchAvailability.Click += new System.EventHandler(this.btnSearchAvailability_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, -2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(368, 147);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // rdbNewGuest
            // 
            this.rdbNewGuest.AutoSize = true;
            this.rdbNewGuest.ForeColor = System.Drawing.Color.White;
            this.rdbNewGuest.Location = new System.Drawing.Point(142, 400);
            this.rdbNewGuest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbNewGuest.Name = "rdbNewGuest";
            this.rdbNewGuest.Size = new System.Drawing.Size(78, 17);
            this.rdbNewGuest.TabIndex = 19;
            this.rdbNewGuest.TabStop = true;
            this.rdbNewGuest.Text = "New Guest";
            this.rdbNewGuest.UseVisualStyleBackColor = true;
            this.rdbNewGuest.Visible = false;
            // 
            // grpBoxBookingInfo
            // 
            this.grpBoxBookingInfo.BackColor = System.Drawing.Color.Black;
            this.grpBoxBookingInfo.Controls.Add(this.dateTimePickerCheckOut);
            this.grpBoxBookingInfo.Controls.Add(this.dateTimePickerCheckIn);
            this.grpBoxBookingInfo.Controls.Add(this.numericUpDownRooms);
            this.grpBoxBookingInfo.Controls.Add(this.numericUpDownChildren);
            this.grpBoxBookingInfo.Controls.Add(this.numericUpDownAdults);
            this.grpBoxBookingInfo.Controls.Add(this.lblChildren);
            this.grpBoxBookingInfo.Controls.Add(this.lblAdults);
            this.grpBoxBookingInfo.Controls.Add(this.lblRooms);
            this.grpBoxBookingInfo.Controls.Add(this.lblCheckOut);
            this.grpBoxBookingInfo.Controls.Add(this.lblCheckIn);
            this.grpBoxBookingInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxBookingInfo.ForeColor = System.Drawing.Color.White;
            this.grpBoxBookingInfo.Location = new System.Drawing.Point(32, 168);
            this.grpBoxBookingInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpBoxBookingInfo.Name = "grpBoxBookingInfo";
            this.grpBoxBookingInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpBoxBookingInfo.Size = new System.Drawing.Size(317, 174);
            this.grpBoxBookingInfo.TabIndex = 18;
            this.grpBoxBookingInfo.TabStop = false;
            this.grpBoxBookingInfo.Text = "Booking Info";
            // 
            // dateTimePickerCheckOut
            // 
            this.dateTimePickerCheckOut.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckOut.Location = new System.Drawing.Point(158, 65);
            this.dateTimePickerCheckOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerCheckOut.Name = "dateTimePickerCheckOut";
            this.dateTimePickerCheckOut.Size = new System.Drawing.Size(136, 19);
            this.dateTimePickerCheckOut.TabIndex = 23;
            // 
            // dateTimePickerCheckIn
            // 
            this.dateTimePickerCheckIn.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerCheckIn.Location = new System.Drawing.Point(158, 36);
            this.dateTimePickerCheckIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerCheckIn.Name = "dateTimePickerCheckIn";
            this.dateTimePickerCheckIn.Size = new System.Drawing.Size(136, 19);
            this.dateTimePickerCheckIn.TabIndex = 22;
            // 
            // numericUpDownRooms
            // 
            this.numericUpDownRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownRooms.Location = new System.Drawing.Point(158, 90);
            this.numericUpDownRooms.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownRooms.Name = "numericUpDownRooms";
            this.numericUpDownRooms.Size = new System.Drawing.Size(135, 19);
            this.numericUpDownRooms.TabIndex = 21;
            // 
            // numericUpDownChildren
            // 
            this.numericUpDownChildren.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownChildren.Location = new System.Drawing.Point(158, 141);
            this.numericUpDownChildren.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownChildren.Name = "numericUpDownChildren";
            this.numericUpDownChildren.Size = new System.Drawing.Size(135, 19);
            this.numericUpDownChildren.TabIndex = 20;
            // 
            // numericUpDownAdults
            // 
            this.numericUpDownAdults.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownAdults.Location = new System.Drawing.Point(158, 115);
            this.numericUpDownAdults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownAdults.Name = "numericUpDownAdults";
            this.numericUpDownAdults.Size = new System.Drawing.Size(135, 19);
            this.numericUpDownAdults.TabIndex = 11;
            // 
            // lblChildren
            // 
            this.lblChildren.AutoSize = true;
            this.lblChildren.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChildren.Location = new System.Drawing.Point(26, 143);
            this.lblChildren.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChildren.Name = "lblChildren";
            this.lblChildren.Size = new System.Drawing.Size(126, 13);
            this.lblChildren.TabIndex = 19;
            this.lblChildren.Text = "Children (0 - 17 years old)";
            // 
            // lblAdults
            // 
            this.lblAdults.AutoSize = true;
            this.lblAdults.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdults.Location = new System.Drawing.Point(26, 120);
            this.lblAdults.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdults.Name = "lblAdults";
            this.lblAdults.Size = new System.Drawing.Size(36, 13);
            this.lblAdults.TabIndex = 3;
            this.lblAdults.Text = "Adults";
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRooms.Location = new System.Drawing.Point(26, 95);
            this.lblRooms.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(92, 13);
            this.lblRooms.TabIndex = 2;
            this.lblRooms.Text = "Number of Rooms";
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOut.Location = new System.Drawing.Point(26, 71);
            this.lblCheckOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(58, 13);
            this.lblCheckOut.TabIndex = 1;
            this.lblCheckOut.Text = "Check-Out";
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckIn.Location = new System.Drawing.Point(26, 47);
            this.lblCheckIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(50, 13);
            this.lblCheckIn.TabIndex = 0;
            this.lblCheckIn.Text = "Check-In";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // rdbExisting
            // 
            this.rdbExisting.AutoSize = true;
            this.rdbExisting.ForeColor = System.Drawing.Color.White;
            this.rdbExisting.Location = new System.Drawing.Point(32, 400);
            this.rdbExisting.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbExisting.Name = "rdbExisting";
            this.rdbExisting.Size = new System.Drawing.Size(92, 17);
            this.rdbExisting.TabIndex = 16;
            this.rdbExisting.TabStop = true;
            this.rdbExisting.Text = "Existing Guest";
            this.rdbExisting.UseVisualStyleBackColor = true;
            this.rdbExisting.Visible = false;
            this.rdbExisting.CheckedChanged += new System.EventHandler(this.rdbExisting_CheckedChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(16, 120);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(88, 42);
            this.txtID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(115, 19);
            this.txtID.TabIndex = 1;
            // 
            // grpBoxPersonalInfo
            // 
            this.grpBoxPersonalInfo.Controls.Add(this.txtAddress);
            this.grpBoxPersonalInfo.Controls.Add(this.lblName);
            this.grpBoxPersonalInfo.Controls.Add(this.txtEmail);
            this.grpBoxPersonalInfo.Controls.Add(this.txtDOB);
            this.grpBoxPersonalInfo.Controls.Add(this.lblID);
            this.grpBoxPersonalInfo.Controls.Add(this.txtName);
            this.grpBoxPersonalInfo.Controls.Add(this.lblDOB);
            this.grpBoxPersonalInfo.Controls.Add(this.txtID);
            this.grpBoxPersonalInfo.Controls.Add(this.lblAddress);
            this.grpBoxPersonalInfo.Controls.Add(this.lblEmail);
            this.grpBoxPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxPersonalInfo.ForeColor = System.Drawing.Color.White;
            this.grpBoxPersonalInfo.Location = new System.Drawing.Point(33, 421);
            this.grpBoxPersonalInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpBoxPersonalInfo.Name = "grpBoxPersonalInfo";
            this.grpBoxPersonalInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpBoxPersonalInfo.Size = new System.Drawing.Size(317, 174);
            this.grpBoxPersonalInfo.TabIndex = 15;
            this.grpBoxPersonalInfo.TabStop = false;
            this.grpBoxPersonalInfo.Text = "Personal Info";
            this.grpBoxPersonalInfo.Visible = false;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(88, 143);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(115, 19);
            this.txtAddress.TabIndex = 14;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(16, 71);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Full Name";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(88, 115);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(115, 19);
            this.txtEmail.TabIndex = 13;
            // 
            // txtDOB
            // 
            this.txtDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDOB.Location = new System.Drawing.Point(88, 90);
            this.txtDOB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.Size = new System.Drawing.Size(115, 19);
            this.txtDOB.TabIndex = 12;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(16, 47);
            this.lblID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 4;
            this.lblID.Text = "ID";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(88, 66);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(115, 19);
            this.txtName.TabIndex = 11;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(16, 95);
            this.lblDOB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(66, 13);
            this.lblDOB.TabIndex = 9;
            this.lblDOB.Text = "Date of Birth";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(16, 143);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Address";
            // 
            // BookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(369, 671);
            this.Controls.Add(this.btnReservation);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSearchAvailability);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.rdbNewGuest);
            this.Controls.Add(this.grpBoxBookingInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rdbExisting);
            this.Controls.Add(this.grpBoxPersonalInfo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BookingForm";
            this.Text = "Booking";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.grpBoxBookingInfo.ResumeLayout(false);
            this.grpBoxBookingInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAdults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpBoxPersonalInfo.ResumeLayout(false);
            this.grpBoxPersonalInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReservation;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSearchAvailability;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton rdbNewGuest;
        private System.Windows.Forms.GroupBox grpBoxBookingInfo;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckIn;
        private System.Windows.Forms.NumericUpDown numericUpDownRooms;
        private System.Windows.Forms.NumericUpDown numericUpDownChildren;
        private System.Windows.Forms.NumericUpDown numericUpDownAdults;
        private System.Windows.Forms.Label lblChildren;
        private System.Windows.Forms.Label lblAdults;
        private System.Windows.Forms.Label lblRooms;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rdbExisting;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox grpBoxPersonalInfo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDOB;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblAddress;
    }
}