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
    public partial class DashboardBooking : Form
    {
        public DashboardBooking()
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

        private void totalCost()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                string query = "select * from CostCalculation where Username = '" + Login.GetUsername.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    try
                    {
                        if (read.GetValue(0).ToString() != string.Empty &&
                        read.GetValue(1).ToString() != string.Empty &&
                        read.GetValue(2).ToString() != string.Empty &&
                        read.GetValue(3).ToString() != string.Empty &&
                        read.GetValue(4).ToString() != string.Empty &&
                        read.GetValue(5).ToString() != string.Empty &&
                        Convert.ToInt32(txtNumberOfPeople.Text) > 0)
                        {
                            string TransportCost = read.GetValue(1).ToString();
                            string HotelRoomCost = read.GetValue(2).ToString();
                            string HotelRoomQuantity = read.GetValue(3).ToString();
                            string Days = read.GetValue(4).ToString();
                            string NumberOfPeople = read.GetValue(5).ToString();

                            int transportCost = Convert.ToInt32(TransportCost);
                            int hotelRoomCost = Convert.ToInt32(HotelRoomCost);
                            int hotelRoomQuantity = Convert.ToInt32(HotelRoomQuantity);
                            int days = Convert.ToInt32(Days);
                            int numberOfPeople = Convert.ToInt32(NumberOfPeople);

                            int cal = (transportCost * numberOfPeople * 2) + (hotelRoomCost * hotelRoomQuantity * days);

                            insertQuery("update UserInfo set TotalCost = '" + cal + "' where username ='" + Login.GetUsername.ToString() + "'");

                            lblTourCost.Text = "Total Tour Cost: " + cal + " ৳";
                        }
                    }
                    catch (Exception) { }                    
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

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DashboardHotelBook hotelBook = new DashboardHotelBook();
            hotelBook.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                string query = "select * from UserInfo where Username = '" + Login.GetUsername.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    if(read.GetValue(10).ToString() == string.Empty || Convert.ToInt32(read.GetValue(10).ToString()) == 0)
                    {
                        MessageBox.Show("Please fill up number of people");
                    }
                    else if (read.GetValue(8).ToString() == string.Empty)
                    {
                        MessageBox.Show("Please fill up departure date");
                    }
                    else if (read.GetValue(9).ToString() == string.Empty)
                    {
                        MessageBox.Show("Please fill up arrival date");
                    }
                    else
                    {
                        DashboardHome home = new DashboardHome();
                        home.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception)
            {
                
            }
            finally
            {
                con.Close();
            }
        }

        private void dayCount()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                string query = "select * from CostCalculation where Username = '" + Login.GetUsername.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    if (read.GetValue(4).ToString() == string.Empty)
                    {
                        lblDays.Visible = false;
                    }
                    else
                    {
                        lblDays.Text = "Your staying for " + read.GetValue(4).ToString() + " days";
                        lblDays.Visible = true;
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

        private void DashboardBooking_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                string query = "select * from UserInfo where Username = '" + Login.GetUsername.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    lblDestinationName.Text = read.GetValue(2).ToString();
                    lblTransportName.Text = read.GetValue(3).ToString() + " (" + read.GetValue(5).ToString() + ")";
                    lblHotelName.Text = read.GetValue(6).ToString() + " (" + read.GetValue(7).ToString() + ")";

                    try
                    {
                        string num = read.GetValue(10).ToString();

                        if (read.GetValue(10).ToString() != string.Empty && Convert.ToInt32(num) > 0)
                        {
                            txtNumberOfPeople.Text = read.GetValue(10).ToString();
                        }
                        if (read.GetValue(8).ToString() != string.Empty && read.GetValue(9).ToString() != string.Empty)
                        {
                            dateTimePickerDeparture.Text = read.GetValue(8).ToString();
                            dateTimePickerArrival.Text = read.GetValue(9).ToString();
                        }
                    }
                    catch (Exception)
                    {
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

            dayCount();
            totalCost();
        }

        private void dateTimePickerDeparture_ValueChanged(object sender, EventArgs e)
        {
            insertQuery("update UserInfo set Departure = '" + Convert.ToDateTime(dateTimePickerDeparture.Text) + "' where username ='" + Login.GetUsername.ToString() + "'");
        }

        private void dateTimePickerArrival_ValueChanged(object sender, EventArgs e)
        {
            insertQuery("update UserInfo set Arrival = '" + Convert.ToDateTime(dateTimePickerArrival.Text) + "' where username ='" + Login.GetUsername.ToString() + "'");

            DateTime departure = dateTimePickerDeparture.Value.Date;
            DateTime arrival = dateTimePickerArrival.Value.Date;

            TimeSpan ts = arrival - departure;

            int days = ts.Days;

            if(days <=0)
            {
                MessageBox.Show("Please select appropriate dates");
                lblDays.Visible = false;
            }
            else
            {
                lblDays.Text = "Your staying for " + days + " days";
                lblDays.Visible = true;
                insertQuery("update CostCalculation set Days = '" + days + "' where username ='" + Login.GetUsername.ToString() + "'");
            }

            totalCost();
        }

        private void txtNumberOfPeople_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtNumberOfPeople.Text) <= 0)
                {
                    MessageBox.Show("Please enter valid information");
                    txtNumberOfPeople.Clear();
                }
            }
            catch (Exception)
            {

            }

            insertQuery("update UserInfo set NumberOfPeople = '" + txtNumberOfPeople.Text + "' where username ='" + Login.GetUsername.ToString() + "'");
            insertQuery("update CostCalculation set NumberOfPeople = '" + txtNumberOfPeople.Text + "' where username ='" + Login.GetUsername.ToString() + "'");
            totalCost();
        }
    }
}
