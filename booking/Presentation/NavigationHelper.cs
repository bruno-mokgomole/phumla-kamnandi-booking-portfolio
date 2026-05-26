using System;
using System.Drawing;
using System.Windows.Forms;

namespace booking.Presentation
{
    internal static class NavigationHelper
    {
        internal static void AddHomeButton(Form form)
        {
            Button button = new Button
            {
                Text = "Return to Home",
                Size = new Size(120, 27),
                Location = new Point(Math.Max(8, form.ClientSize.Width - 130), 8),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            button.BackColor = Color.White;
            button.ForeColor = Color.Black;
            button.UseVisualStyleBackColor = false;

            button.Click += (sender, args) =>
            {
                ManageBooking home = new ManageBooking();
                home.Show();
                form.Hide();
            };

            form.Controls.Add(button);
            button.BringToFront();
        }

        internal static void ApplyReadableControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button || control is TextBox || control is ListBox)
                {
                    control.BackColor = Color.White;
                    control.ForeColor = Color.Black;
                }

                if (control is Button button)
                    button.UseVisualStyleBackColor = false;

                if (control is TextBox textBox)
                    textBox.BorderStyle = BorderStyle.FixedSingle;

                if (control is ListBox listBox)
                    listBox.BorderStyle = BorderStyle.FixedSingle;

                if (control.HasChildren)
                    ApplyReadableControls(control);
            }
        }
    }
}
