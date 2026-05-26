using booking.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace booking.Presentation
{
    public partial class Confirmation : Form
    {
        public Confirmation()
            : this("Reservation is complete. Use the buttons below to send or print the confirmation.")
        {
        }

        public Confirmation(string confirmationText)
        {
            InitializeComponent();
            pictureBox1.SendToBack();
            NavigationHelper.ApplyReadableControls(this);
            NavigationHelper.AddHomeButton(this);
            txtConfirmation.Text = confirmationText;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string message = "Confirmation letter has successfully been sent"; 
            string title = "Booking Confirmation Email"; 
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Question); 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Confirmation report has been sent to the printer.", "Print Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
