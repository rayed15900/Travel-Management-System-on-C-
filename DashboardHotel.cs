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
    public partial class DashboardHotel : Form
    {
        public DashboardHotel()
        {
            InitializeComponent();
            lblUsername.Text = Login.GetUsername.ToString();
        }

        public void insertQuery(string query)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
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

        private void btnProfile_Click(object sender, EventArgs e)
        {
            DashboardProfile profile = new DashboardProfile();
            profile.Show();
            this.Hide();
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

        private void btnBooking_Click(object sender, EventArgs e)
        {
            DashboardBooking booking = new DashboardBooking();
            booking.Show();
            this.Hide();
        }

        private void btnEnterHotel1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                string placeQuery = "select * from UserInfo where Username = '" + Login.GetUsername.ToString() + "'";
                SqlCommand cmd = new SqlCommand(placeQuery, con);

                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    string query = "select * from Hotel where Place = '" + read.GetValue(2).ToString() + "'";

                    con.Close();
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(query, con);

                    SqlDataReader read1 = cmd1.ExecuteReader();

                    if (read1.HasRows == true)
                    {
                        read1.Read();
                        insertQuery("update UserInfo set HotelName = '" + read1.GetValue(2).ToString() + "' where username ='" + Login.GetUsername.ToString() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            DashboardHotelBook hotelBook = new DashboardHotelBook();
            hotelBook.Show();
            this.Hide();
        }

        private void btnEnterHotel2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                string placeQuery = "select * from UserInfo where Username = '" + Login.GetUsername.ToString() + "'";
                SqlCommand cmd = new SqlCommand(placeQuery, con);

                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    string query = "select * from Hotel where Place = '" + read.GetValue(2).ToString() + "'";

                    con.Close();
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(query, con);

                    SqlDataReader read1 = cmd1.ExecuteReader();

                    if (read1.HasRows == true)
                    {
                        read1.Read();
                        insertQuery("update UserInfo set HotelName = '" + read1.GetValue(6).ToString() + "' where username ='" + Login.GetUsername.ToString() + "'");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            DashboardHotelBook hotelBook = new DashboardHotelBook();
            hotelBook.Show();
            this.Hide();
        }

        private void DashboardHotel_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                string placeQuery = "select * from UserInfo where Username = '" + Login.GetUsername.ToString() + "'";
                SqlCommand cmd = new SqlCommand(placeQuery, con);

                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    string query = "select * from Hotel where Place = '" + read.GetValue(2).ToString() + "'";

                    con.Close();
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(query, con);

                    SqlDataReader read1 = cmd1.ExecuteReader();

                    if (read1.HasRows == true)
                    {
                        read1.Read();
                        lblHotel1.Text = read1.GetValue(2).ToString();
                        this.pictureBoxHotel1.ImageLocation = @"C:\Users\rayed\Desktop\Travelers Guide\Travel Management System\Travelers Guide\Resources\" + read1.GetValue(2).ToString() + ".jpg";                        
                        lblHotel2.Text = read1.GetValue(6).ToString();
                        this.pictureBoxHotel2.ImageLocation = @"C:\Users\rayed\Desktop\Travelers Guide\Travel Management System\Travelers Guide\Resources\" + read1.GetValue(6).ToString() + ".jpg";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
