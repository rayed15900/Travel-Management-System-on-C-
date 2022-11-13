using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Travelers_Guide
{
    public partial class DashboardProfile : Form
    {
        public DashboardProfile()
        {
            InitializeComponent();
            lblUsername.Text = Login.GetUsername.ToString();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DashboardProfile profile = new DashboardProfile();
            profile.Show();
            this.Hide();
        }

        private void btnX_MouseEnter(object sender, EventArgs e)
        {
            this.btnX.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        }

        private void btnX_MouseLeave(object sender, EventArgs e)
        {
            this.btnX.ForeColor = ColorTranslator.FromHtml("#000000");
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            DashboardDestination destination = new DashboardDestination();
            destination.Show();
            this.Hide();
        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            DashboardTransport transport = new DashboardTransport();
            transport.Show();
            this.Hide();
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            DashboardHotel hotel = new DashboardHotel();
            hotel.Show();
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            DashboardHome home = new DashboardHome();
            home.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void DashboardProfile_Load(object sender, EventArgs e)
        {
            txtNameProfile.Enabled = false;
            txtEmailProfile.Enabled = false;
            txtUsernameProfile.Enabled = false;
            DOB.Enabled = false;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            string query = "select * from Registration where Username = @user";
                        
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@user", Login.GetUsername.ToString());

            SqlDataReader read = cmd.ExecuteReader();

            if(read.HasRows == true)
            {
                read.Read();
                txtNameProfile.Text = read.GetValue(1).ToString();
                txtEmailProfile.Text = read.GetValue(2).ToString();
                txtUsernameProfile.Text = read.GetValue(3).ToString();
                DOB.Text = read.GetValue(5).ToString();
            }

            con.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtNameProfile.Enabled = true;
            txtEmailProfile.Enabled = true;
            txtUsernameProfile.Enabled = false;
            DOB.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            string query = "update Registration set Name = '" + this.txtNameProfile.Text + "', Email = '" + txtEmailProfile.Text + "', Username = '" + txtUsernameProfile.Text + "', DOB = '" + Convert.ToDateTime(DOB.Text) + "' where username = '" + txtUsernameProfile.Text + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                if(cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Successfully Saved");
                }
                else
                {
                    MessageBox.Show("Not Successfull");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }


            txtNameProfile.Enabled = false;
            txtEmailProfile.Enabled = false;
            txtUsernameProfile.Enabled = false;
            DOB.Enabled = false;
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            DashboardBooking booking = new DashboardBooking();
            booking.Show();
            this.Hide();
        }
    }
}
