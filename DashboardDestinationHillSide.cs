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
    public partial class DashboardDestinationHillSide : Form
    {
        bool nilgiri = true;
        bool boga = false;
        bool sajek = false;

        public DashboardDestinationHillSide()
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

        private void HillSideDatabase()
        {
            if (nilgiri)
            {
                insertQuery("update UserInfo set Category = 'Hill Side', Place = 'Nilgiri' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (boga)
            {
                insertQuery("update UserInfo set Category = 'Hill Side', Place = 'Boga Lake' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (sajek)
            {
                insertQuery("update UserInfo set Category = 'Hill Side', Place = 'Sajek Valley' where username ='" + Login.GetUsername.ToString() + "'");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HillSideDatabase();

            DashboardTransport transport = new DashboardTransport();
            transport.Show();
            this.Hide();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            HillSideDatabase();

            DashboardDestination destination = new DashboardDestination();
            destination.Show();
            this.Hide();
        }

        private void pnlNilgiri_Click(object sender, EventArgs e)
        {
            this.pnlNilgiri.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
            this.pnlBogaLake.BackgroundImage = Properties.Resources.Nothing;
            this.pnlSajek.BackgroundImage = Properties.Resources.Nothing;

            nilgiri = true;
            boga = false;
            sajek = false;

            HillSideDatabase();
        }

        private void pnlBogaLake_Click(object sender, EventArgs e)
        {
            this.pnlNilgiri.BackgroundImage = Properties.Resources.Nothing;
            this.pnlBogaLake.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
            this.pnlSajek.BackgroundImage = Properties.Resources.Nothing;

            nilgiri = false;
            boga = true;
            sajek = false;

            HillSideDatabase();
        }

        private void pnlSajek_Click(object sender, EventArgs e)
        {
            this.pnlNilgiri.BackgroundImage = Properties.Resources.Nothing;
            this.pnlBogaLake.BackgroundImage = Properties.Resources.Nothing;
            this.pnlSajek.BackgroundImage = Properties.Resources.DestinationPanelBlack1;

            nilgiri = false;
            boga = false;
            sajek = true;

            HillSideDatabase();            
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            DashboardBooking booking = new DashboardBooking();
            booking.Show();
            this.Hide();
        }

        private void DashboardDestinationHillSide_Load(object sender, EventArgs e)
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
                        this.pnlNilgiri.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
                        this.pnlBogaLake.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlSajek.BackgroundImage = Properties.Resources.Nothing;

                        nilgiri = true;
                        boga = false;
                        sajek = false;
                    }
                    else if (read.GetValue(0).ToString() == "Nilgiri")
                    {
                        this.pnlNilgiri.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
                        this.pnlBogaLake.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlSajek.BackgroundImage = Properties.Resources.Nothing;

                        nilgiri = true;
                        boga = false;
                        sajek = false;
                    }
                    else if (read.GetValue(0).ToString() == "Boga Lake")
                    {
                        this.pnlNilgiri.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlBogaLake.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
                        this.pnlSajek.BackgroundImage = Properties.Resources.Nothing;

                        nilgiri = false;
                        boga = true;
                        sajek = false;
                    }
                    else if (read.GetValue(0).ToString() == "Sajek Valley")
                    {
                        this.pnlNilgiri.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlBogaLake.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlSajek.BackgroundImage = Properties.Resources.DestinationPanelBlack1;

                        nilgiri = false;
                        boga = false;
                        sajek = true;
                    }

                    HillSideDatabase();                   
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
