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
    public partial class DashboardDestinationSeaBeach : Form
    {
        bool cox = true;
        bool kuakata = false;
        bool saint = false;
        public DashboardDestinationSeaBeach()
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

        private void SeaBeachDatabase()
        {
            if (cox)
            {
                insertQuery("update UserInfo set Category = 'Sea Beach', Place = 'Coxs Bazar' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (kuakata)
            {
                insertQuery("update UserInfo set Category = 'Sea Beach', Place = 'Kuakata' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (saint)
            {
                insertQuery("update UserInfo set Category = 'Sea Beach', Place = 'Saint Martin' where username ='" + Login.GetUsername.ToString() + "'");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            SeaBeachDatabase();

            DashboardDestination destination = new DashboardDestination();
            destination.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SeaBeachDatabase();            

            DashboardTransport transport = new DashboardTransport();
            transport.Show();
            this.Hide();
        }

        public void pnlCoxBazar_Click(object sender, EventArgs e)
        {
            this.pnlCoxBazar.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
            this.pnlKuakata.BackgroundImage = Properties.Resources.Nothing;
            this.pnlSaintMartin.BackgroundImage = Properties.Resources.Nothing;

            cox = true;
            kuakata = false;
            saint = false;

            SeaBeachDatabase();
        }

        private void pnlKuakata_Click(object sender, EventArgs e)
        {
            this.pnlCoxBazar.BackgroundImage = Properties.Resources.Nothing;
            this.pnlKuakata.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
            this.pnlSaintMartin.BackgroundImage = Properties.Resources.Nothing;

            cox = false;
            kuakata = true;
            saint = false;

            SeaBeachDatabase();
        }

        private void pnlSaintMartin_Click(object sender, EventArgs e)
        {
            this.pnlCoxBazar.BackgroundImage = Properties.Resources.Nothing;
            this.pnlKuakata.BackgroundImage = Properties.Resources.Nothing;
            this.pnlSaintMartin.BackgroundImage = Properties.Resources.DestinationPanelBlack1;

            cox = false;
            kuakata = false;
            saint = true;

            SeaBeachDatabase();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            DashboardBooking booking = new DashboardBooking();
            booking.Show();
            this.Hide();
        }

        private void DashboardDestinationSeaBeach_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            string query = "select Place from UserInfo where username = '" + Login.GetUsername.ToString() + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows == true)
                {
                    read.Read();

                    if (read.GetValue(0).ToString().Equals(string.Empty))
                    {
                        this.pnlCoxBazar.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
                        this.pnlKuakata.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlSaintMartin.BackgroundImage = Properties.Resources.Nothing;

                        cox = true;
                        kuakata = false;
                        saint = false;
                    }
                    else if (read.GetValue(0).ToString() == "Coxs Bazar")
                    {
                        this.pnlCoxBazar.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
                        this.pnlKuakata.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlSaintMartin.BackgroundImage = Properties.Resources.Nothing;

                        cox = true;
                        kuakata = false;
                        saint = false;
                    }
                    else if (read.GetValue(0).ToString() == "Kuakata")
                    {
                        this.pnlCoxBazar.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlKuakata.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
                        this.pnlSaintMartin.BackgroundImage = Properties.Resources.Nothing;

                        cox = false;
                        kuakata = true;
                        saint = false;
                    }
                    else if (read.GetValue(0).ToString() == "Saint Martin")
                    {
                        this.pnlCoxBazar.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlKuakata.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlSaintMartin.BackgroundImage = Properties.Resources.DestinationPanelBlack1;

                        cox = false;
                        kuakata = false;
                        saint = true;
                    }

                    SeaBeachDatabase();
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
