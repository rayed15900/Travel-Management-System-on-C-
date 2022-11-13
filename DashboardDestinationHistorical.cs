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
    public partial class DashboardDestinationHistorical : Form
    {
        bool ahsan = true;
        bool mahasthangarh = false;
        bool lalbagh = false;

        public DashboardDestinationHistorical()
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

        private void HistoricalDatabase()
        {
            if (ahsan)
            {
                insertQuery("update UserInfo set Category = 'Historical', Place = 'Ahsan Manzil' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (mahasthangarh)
            {
                insertQuery("update UserInfo set Category = 'Historical', Place = 'Mahasthangarh' where username ='" + Login.GetUsername.ToString() + "'");
            }
            else if (lalbagh)
            {
                insertQuery("update UserInfo set Category = 'Historical', Place = 'Lalbagh Fort' where username ='" + Login.GetUsername.ToString() + "'");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            HistoricalDatabase();

            DashboardDestination destination = new DashboardDestination();
            destination.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            HistoricalDatabase();

            try
            {
                DashboardTransport transport = new DashboardTransport();
                transport.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pnlAhsanManzil_Click(object sender, EventArgs e)
        {
            this.pnlAhsanManzil.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
            this.pnlMahasthangarh.BackgroundImage = Properties.Resources.Nothing;
            this.pnlLalbaghFort.BackgroundImage = Properties.Resources.Nothing;

            ahsan = true;
            mahasthangarh = false;
            lalbagh = false;

            HistoricalDatabase();
        }

        private void pnlMahasthangarh_Click(object sender, EventArgs e)
        {
            this.pnlAhsanManzil.BackgroundImage = Properties.Resources.Nothing;
            this.pnlMahasthangarh.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
            this.pnlLalbaghFort.BackgroundImage = Properties.Resources.Nothing;

            ahsan = false;
            mahasthangarh = true;
            lalbagh = false;

            HistoricalDatabase();
        }

        private void pnlLalbaghFort_Click(object sender, EventArgs e)
        {
            this.pnlAhsanManzil.BackgroundImage = Properties.Resources.Nothing;
            this.pnlMahasthangarh.BackgroundImage = Properties.Resources.Nothing;
            this.pnlLalbaghFort.BackgroundImage = Properties.Resources.DestinationPanelBlack1;

            ahsan = false;
            mahasthangarh = false;
            lalbagh = true;

            HistoricalDatabase();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            DashboardBooking booking = new DashboardBooking();
            booking.Show();
            this.Hide();
        }

        private void DashboardDestinationHistorical_Load(object sender, EventArgs e)
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
                        this.pnlAhsanManzil.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
                        this.pnlMahasthangarh.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlLalbaghFort.BackgroundImage = Properties.Resources.Nothing;

                        ahsan = true;
                        mahasthangarh = false;
                        lalbagh = false;
                    }
                    else if (read.GetValue(0).ToString() == "Ahsan Manzil")
                    {
                        this.pnlAhsanManzil.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
                        this.pnlMahasthangarh.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlLalbaghFort.BackgroundImage = Properties.Resources.Nothing;

                        ahsan = true;
                        mahasthangarh = false;
                        lalbagh = false;
                    }
                    else if (read.GetValue(0).ToString() == "Mahasthangarh")
                    {
                        this.pnlAhsanManzil.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlMahasthangarh.BackgroundImage = Properties.Resources.DestinationPanelBlack1;
                        this.pnlLalbaghFort.BackgroundImage = Properties.Resources.Nothing;

                        ahsan = false;
                        mahasthangarh = true;
                        lalbagh = false;
                    }
                    else if (read.GetValue(0).ToString() == "Lalbagh Fort")
                    {
                        this.pnlAhsanManzil.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlMahasthangarh.BackgroundImage = Properties.Resources.Nothing;
                        this.pnlLalbaghFort.BackgroundImage = Properties.Resources.DestinationPanelBlack1;

                        ahsan = false;
                        mahasthangarh = false;
                        lalbagh = true;
                    }
                    HistoricalDatabase();
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
