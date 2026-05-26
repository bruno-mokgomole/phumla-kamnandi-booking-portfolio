using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using booking.Presentation;

namespace booking
{
    public partial class ManageBooking : Form
    {
        public ManageBooking()
        {
            InitializeComponent();
            pictureBox2.SendToBack();
            NavigationHelper.ApplyReadableControls(this);

            /*
            // setting the date selection to be Now at minumum to prevent booking days that already past
            CheckindTPicker.MinDate = DateTime.Now;

            //Increment check out date to be at least one day after checking, to prevent checkin and checkout on the same day
            checkoutdTPicker.MinDate = CheckindTPicker.Value.AddDays(1);*/

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*private void CheckindTPicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedStartDateTime = CheckindTPicker.Value;

            DateTime newMinEndDate = selectedStartDateTime.AddDays(1);     //Used this to test how to use datePicker

            checkoutdTPicker.MinDate = newMinEndDate;

            if (checkoutdTPicker.Value < newMinEndDate)
            {
                checkoutdTPicker.Value = newMinEndDate;
            }
        }*/

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnMakeBooking_Click(object sender, EventArgs e)
        {
            BookingForm fm3 = new BookingForm();
            fm3.Show();
            this.Hide();
        }

        private void btnModifyBooking_Click(object sender, EventArgs e)
        {
            Search form = new Search(SearchMode.Modify);
            form.Show();
            this.Hide();
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            Search form = new Search(SearchMode.Cancel);
            form.Show();
            this.Hide();
        }

        private void btnEnquiry_Click(object sender, EventArgs e)
        {
            Search form = new Search(SearchMode.Enquiry);
            form.Show();
            this.Hide();
        }

        private void btnViewAllBookings_Click(object sender, EventArgs e)
        {
            BookingsList form = new BookingsList();
            form.Show();
            this.Hide();
        }
    }
}
