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
    public partial class DashboardHotelBook : Form
    {
        public DashboardHotelBook()
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

        private void btnHotel_Click(object sender, EventArgs e)
        {
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DashboardTransport transport = new DashboardTransport();
            transport.Show();
            this.Hide();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            DashboardBooking booking = new DashboardBooking();
            booking.Show();
            this.Hide();
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            DashboardHotel hotel = new DashboardHotel();
            hotel.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (comboBoxSingle.Text == "Quantity" && comboBoxDouble.Text == "Quantity" && comboBoxSuite.Text == "Quantity")
            {
                MessageBox.Show("Please select quantity");
            }
            else
            {
                DashboardBooking booking = new DashboardBooking();
                booking.Show();
                this.Hide();
            }
        }

        private void singleRoom()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                string hotelQuery = "select * from UserInfo where Username = '" + Login.GetUsername.ToString() + "'";
                SqlCommand cmd = new SqlCommand(hotelQuery, con);

                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    string query = "select * from HotelCost where HotelName = '" + read.GetValue(6).ToString() + "'";

                    con.Close();
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(query, con);

                    SqlDataReader read1 = cmd1.ExecuteReader();

                    if (read1.HasRows == true)
                    {
                        read1.Read();
                        insertQuery("update CostCalculation set HotelRoomCost = '" + read1.GetValue(2).ToString() + "' where username ='" + Login.GetUsername.ToString() + "'");
                        insertQuery("update UserInfo set HotelRoom = 'Single Room' where username ='" + Login.GetUsername.ToString() + "'");
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

            this.pnlSingle.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
            this.pnlDouble.BackgroundImage = Properties.Resources.Nothing;
            this.pnlSuite.BackgroundImage = Properties.Resources.Nothing;
            this.comboBoxSingle.Visible = true;
            this.comboBoxDouble.Visible = false;
            this.comboBoxSuite.Visible = false;
        }

        private void pnlSingle_Click(object sender, EventArgs e)
        {
            singleRoom();
            comboBoxDouble.Text = "Quantity";
            comboBoxSuite.Text = "Quantity";
        }

        private void doubleRoom()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                string hotelQuery = "select * from UserInfo where Username = '" + Login.GetUsername.ToString() + "'";
                SqlCommand cmd = new SqlCommand(hotelQuery, con);

                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    string query = "select * from HotelCost where HotelName = '" + read.GetValue(6).ToString() + "'";

                    con.Close();
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(query, con);

                    SqlDataReader read1 = cmd1.ExecuteReader();

                    if (read1.HasRows == true)
                    {
                        read1.Read();
                        insertQuery("update CostCalculation set HotelRoomCost = '" + read1.GetValue(3).ToString() + "' where username ='" + Login.GetUsername.ToString() + "'");
                        insertQuery("update UserInfo set HotelRoom = 'Double Room' where username ='" + Login.GetUsername.ToString() + "'");
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

            this.pnlSingle.BackgroundImage = Properties.Resources.Nothing;
            this.pnlDouble.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
            this.pnlSuite.BackgroundImage = Properties.Resources.Nothing;
            this.comboBoxSingle.Visible = false;
            this.comboBoxDouble.Visible = true;
            this.comboBoxSuite.Visible = false;
        }

        private void pnlDouble_Click(object sender, EventArgs e)
        {
            doubleRoom();
            
            comboBoxSingle.Text = "Quantity";
            comboBoxSuite.Text = "Quantity";
        }

        private void suite()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                string hotelQuery = "select * from UserInfo where Username = '" + Login.GetUsername.ToString() + "'";
                SqlCommand cmd = new SqlCommand(hotelQuery, con);

                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    string query = "select * from HotelCost where HotelName = '" + read.GetValue(6).ToString() + "'";

                    con.Close();
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(query, con);

                    SqlDataReader read1 = cmd1.ExecuteReader();

                    if (read1.HasRows == true)
                    {
                        read1.Read();
                        insertQuery("update CostCalculation set HotelRoomCost = '" + read1.GetValue(4).ToString() + "' where username ='" + Login.GetUsername.ToString() + "'");
                        insertQuery("update UserInfo set HotelRoom = 'Suite' where username ='" + Login.GetUsername.ToString() + "'");
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

            this.pnlSingle.BackgroundImage = Properties.Resources.Nothing;
            this.pnlDouble.BackgroundImage = Properties.Resources.Nothing;
            this.pnlSuite.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
            this.comboBoxSingle.Visible = false;
            this.comboBoxDouble.Visible = false;
            this.comboBoxSuite.Visible = true;
        }

        private void pnlSuite_Click(object sender, EventArgs e)
        {
            suite();
            comboBoxSingle.Text = "Quantity";
            comboBoxDouble.Text = "Quantity";
        }

        private void pnlSingle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HotelSelect()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            string query = "select * from UserInfo where username = '" + Login.GetUsername.ToString() + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    if (read.GetValue(7).ToString() == "Single Room")
                    {
                        singleRoom();
                    }
                    else if (read.GetValue(7).ToString() == "Double Room")
                    {
                        doubleRoom();
                    }
                    else if (read.GetValue(7).ToString() == "Suite")
                    {
                        suite();
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

        private void DashboardHotelBook_Load(object sender, EventArgs e)
        {
            HotelSelect();

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            try
            {
                string hotelQuery = "select * from UserInfo where Username = '" + Login.GetUsername.ToString() + "'";
                SqlCommand cmd = new SqlCommand(hotelQuery, con);

                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    string query = "select * from HotelCost where HotelName = '" + read.GetValue(6).ToString() + "'";

                    con.Close();
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(query, con);

                    SqlDataReader read1 = cmd1.ExecuteReader();

                    if (read1.HasRows == true)
                    {
                        read1.Read();
                        btnSingleCost.Text = read1.GetValue(2).ToString();
                        btnDoubleCost.Text = read1.GetValue(3).ToString();
                        btnSuiteCost.Text = read1.GetValue(4).ToString();
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

        private void comboBoxSingle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxSingle.Text == "One")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '1' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxSingle.Text == "Two")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '2' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxSingle.Text == "Three")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '3' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxSingle.Text == "Four")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '4' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxSingle.Text == "Five")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '5' where username ='" + Login.GetUsername.ToString() + "'");
            }
        }

        private void comboBoxDouble_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDouble.Text == "One")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '1' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxDouble.Text == "Two")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '2' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxDouble.Text == "Three")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '3' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxDouble.Text == "Four")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '4' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxDouble.Text == "Five")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '5' where username ='" + Login.GetUsername.ToString() + "'");
            }
        }

        private void comboBoxSuite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSuite.Text == "One")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '1' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxSuite.Text == "Two")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '2' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxSuite.Text == "Three")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '3' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxSuite.Text == "Four")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '4' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (comboBoxSuite.Text == "Five")
            {
                insertQuery("update CostCalculation set HotelRoomQuantity = '5' where username ='" + Login.GetUsername.ToString() + "'");
            }
        }
    }
}