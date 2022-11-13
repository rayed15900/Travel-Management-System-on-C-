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
    public partial class DashboardTransport : Form
    {
        bool bus1 = true;
        bool bus2 = false;
        bool bus3 = false;

        String transportvariant;

        public DashboardTransport()
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

        private void TransportDatabase()
        {
            if (radioButtonAC.Checked == true)
            {
                transportvariant = "AC";
            }
            else if (radioButtonNONAC.Checked == true)
            {
                transportvariant = "NON-AC";
            }

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
                    string query = "select * from Transport where Place = '" + read.GetValue(2).ToString() + "'";

                    con.Close();
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(query, con);

                    SqlDataReader read1 = cmd1.ExecuteReader();

                    if (read1.HasRows == true)
                    {
                        read1.Read();

                        if (bus1)
                        {
                            insertQuery("update UserInfo set TransportName = '" + lblBus1.Text + "', TransportVariant = '" + transportvariant + "' where username ='" + Login.GetUsername.ToString() + "'");

                            if (transportvariant == "AC")
                            {
                                lblBusCost.Text = read1.GetValue(5).ToString();
                                insertQuery("update CostCalculation set TransportCost = '" + read1.GetValue(5).ToString() + "'");
                            }
                            else if (transportvariant == "NON-AC")
                            {
                                lblBusCost.Text = read1.GetValue(6).ToString();
                                insertQuery("update CostCalculation set TransportCost = '" + read1.GetValue(6).ToString() + "'");
                            }
                        }
                        else if (bus2)
                        {
                            insertQuery("update UserInfo set TransportName = '" + lblBus2.Text + "', TransportVariant = '" + transportvariant + "' where username ='" + Login.GetUsername.ToString() + "'");

                            if (transportvariant == "AC")
                            {
                                lblBusCost.Text = read1.GetValue(7).ToString();
                                insertQuery("update CostCalculation set TransportCost = '" + read1.GetValue(7).ToString() + "'");
                            }
                            else if (transportvariant == "NON-AC")
                            {
                                lblBusCost.Text = read1.GetValue(8).ToString();
                                insertQuery("update CostCalculation set TransportCost = '" + read1.GetValue(8).ToString() + "'");
                            }
                        }
                        else if (bus3)
                        {
                            insertQuery("update UserInfo set TransportName = '" + lblBus3.Text + "', TransportVariant = '" + transportvariant + "' where username ='" + Login.GetUsername.ToString() + "'");

                            if (transportvariant == "AC")
                            {
                                lblBusCost.Text = read1.GetValue(9).ToString();
                                insertQuery("update CostCalculation set TransportCost = '" + read1.GetValue(9).ToString() + "'");
                            }
                            else if (transportvariant == "NON-AC")
                            {
                                lblBusCost.Text = read1.GetValue(10).ToString();
                                insertQuery("update CostCalculation set TransportCost = '" + read1.GetValue(10).ToString() + "'");
                            }
                        }
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

        private void bus1click()
        {
            this.pictureBoxSelectBus1.BackgroundImage = Properties.Resources.BusSelect;
            this.pictureBoxSelectBus2.BackgroundImage = Properties.Resources.Nothing;
            this.pictureBoxSelectBus3.BackgroundImage = Properties.Resources.Nothing;
            this.pictureBoxBus1.Show();
            this.pictureBoxBus2.Hide();
            this.pictureBoxBus3.Hide();

            bus1 = true;
            bus2 = false;
            bus3 = false;
        }

        private void pictureBoxSelectBus1_Click(object sender, EventArgs e)
        {
            bus1click();
            insertQuery("update UserInfo set BusNo = 'Bus 1' where username ='" + Login.GetUsername.ToString() + "'");
            TransportDatabase();
        }

        private void bus2click()
        {
            this.pictureBoxSelectBus3.BackgroundImage = Properties.Resources.Nothing;
            this.pictureBoxSelectBus2.BackgroundImage = Properties.Resources.BusSelect;
            this.pictureBoxSelectBus1.BackgroundImage = Properties.Resources.Nothing;
            this.pictureBoxBus1.Hide();
            this.pictureBoxBus2.Show();
            this.pictureBoxBus3.Hide();

            bus1 = false;
            bus2 = true;
            bus3 = false;
        }

        private void pictureBoxSelectBus2_Click(object sender, EventArgs e)
        {
            bus2click();
            insertQuery("update UserInfo set BusNo = 'Bus 2' where username ='" + Login.GetUsername.ToString() + "'");
            TransportDatabase();
        }

        private void bus3click()
        {
            this.pictureBoxSelectBus1.BackgroundImage = Properties.Resources.Nothing;
            this.pictureBoxSelectBus2.BackgroundImage = Properties.Resources.Nothing;
            this.pictureBoxSelectBus3.BackgroundImage = Properties.Resources.BusSelect;
            this.pictureBoxBus1.Hide();
            this.pictureBoxBus2.Hide();
            this.pictureBoxBus3.Show();

            bus1 = false;
            bus2 = false;
            bus3 = true;
        }

        private void pictureBoxSelectBus3_Click(object sender, EventArgs e)
        {
            bus3click();
            insertQuery("update UserInfo set BusNo = 'Bus 3' where username ='" + Login.GetUsername.ToString() + "'");
            TransportDatabase();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            string query = "select Category from UserInfo where username = '" + Login.GetUsername.ToString() + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    if(read.GetValue(0).ToString().Equals("Sea Beach"))
                    {
                        DashboardDestinationSeaBeach sea = new DashboardDestinationSeaBeach();
                        sea.Show();
                        this.Hide();
                    }
                    else if (read.GetValue(0).ToString() == "Hill Side")
                    {
                        DashboardDestinationHillSide hill = new DashboardDestinationHillSide();
                        hill.Show();
                        this.Hide();
                    }
                    else if (read.GetValue(0).ToString() == "Historical")
                    {
                        DashboardDestinationHistorical historical = new DashboardDestinationHistorical();
                        historical.Show();
                        this.Hide();
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            DashboardHotel hotel = new DashboardHotel();
            hotel.Show();
            this.Hide();

            TransportDatabase();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            DashboardBooking booking = new DashboardBooking();
            booking.Show();
            this.Hide();
        }

        private void transportSelect()
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

                    if (read.GetValue(4).ToString() == "Bus 1")
                    {
                        bus1click();
                    }
                    else if (read.GetValue(4).ToString() == "Bus 2")
                    {
                        bus2click();
                    }
                    else if (read.GetValue(4).ToString() == "Bus 3")
                    {
                        bus3click();
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

        private void DashboardTransport_Load(object sender, EventArgs e)
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

                    string query = "select * from Transport where Place = '" + read.GetValue(2).ToString() + "'";

                    con.Close();
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand(query, con);

                    SqlDataReader read1 = cmd1.ExecuteReader();

                    if (read1.HasRows == true)
                    {
                        read1.Read();
                        lblBus1.Text = read1.GetValue(2).ToString();
                        lblBus2.Text = read1.GetValue(3).ToString();
                        lblBus3.Text = read1.GetValue(4).ToString();
                    }
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

            transportSelect();
            TransportDatabase();
        }

        private void radioButtonNONAC_Click(object sender, EventArgs e)
        {
            TransportDatabase();
        }

        private void radioButtonAC_Click(object sender, EventArgs e)
        {
            TransportDatabase();
        }
    }
}