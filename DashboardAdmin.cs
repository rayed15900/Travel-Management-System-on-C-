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
    public partial class DashboardAdmin : Form
    {
        public DashboardAdmin()
        {
            InitializeComponent();
            lblUsername.Text = "Admin";
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

        private void btnX_MouseEnter(object sender, EventArgs e)
        {
            this.btnX.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        }

        private void btnX_MouseLeave(object sender, EventArgs e)
        {
            this.btnX.ForeColor = ColorTranslator.FromHtml("#000000");
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void refreshGrid()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from UserInfo", con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridViewUserInfo.DataSource = dt;
                dataGridViewUserInfo.Refresh();
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

        private void DashboardAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'travel_Management_SystemDataSet.UserInfo' table. You can move, or remove it, as needed.
            this.userInfoTableAdapter.Fill(this.travel_Management_SystemDataSet.UserInfo);
            txtUsername.Enabled = false;
            txtCategory.Enabled = false;
            txtPlace.Enabled = false;
            txtTransportName.Enabled = false;
            txtTransportVariant.Enabled = false;
            txtHotelName.Enabled = false;
            txtHotelRoom.Enabled = false;
            dateTimePickerDeparture.Enabled = false;
            dateTimePickerArrival.Enabled = false;
            txtNumberOfPeople.Enabled = false;
            txtTotalCost.Enabled = false;
        }

        private void dataGridViewUserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                //string username = dataGridViewUserInfo.Rows[e.RowIndex].Cells[0].Value.ToString();

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("select * from UserInfo", con);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    txtUsername.Text = dt.Rows[e.RowIndex]["username"].ToString();
                    txtCategory.Text = dt.Rows[e.RowIndex]["category"].ToString();
                    txtPlace.Text = dt.Rows[e.RowIndex]["place"].ToString();
                    txtTransportName.Text = dt.Rows[e.RowIndex]["transportName"].ToString();
                    txtTransportVariant.Text = dt.Rows[e.RowIndex]["transportVariant"].ToString();
                    txtHotelName.Text = dt.Rows[e.RowIndex]["hotelName"].ToString();
                    txtHotelRoom.Text = dt.Rows[e.RowIndex]["hotelRoom"].ToString();
                    dateTimePickerDeparture.Text = dt.Rows[e.RowIndex]["departure"].ToString();
                    dateTimePickerArrival.Text = dt.Rows[e.RowIndex]["arrival"].ToString();
                    txtNumberOfPeople.Text = dt.Rows[e.RowIndex]["numberOfPeople"].ToString();
                    txtTotalCost.Text = dt.Rows[e.RowIndex]["totalCost"].ToString();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtCategory.Enabled = true;
            txtPlace.Enabled = true;
            txtTransportName.Enabled = true;
            txtTransportVariant.Enabled = true;
            txtHotelName.Enabled = true;
            txtHotelRoom.Enabled = true;
            dateTimePickerDeparture.Enabled = true;
            dateTimePickerArrival.Enabled = true;
            txtNumberOfPeople.Enabled = true;
            txtTotalCost.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            string query = "update UserInfo set Category = '" + txtCategory.Text + "', Place = '" + txtPlace.Text + "', TransportName = '" + txtTransportName.Text + "', TransportVariant = '" + txtTransportVariant.Text + "', HotelName = '" + txtHotelName.Text + "', HotelRoom = '" + txtHotelRoom.Text + "', Departure = '" + Convert.ToDateTime(dateTimePickerDeparture.Text) + "', Arrival = '" + Convert.ToDateTime(dateTimePickerArrival.Text) + "', NumberOfPeople = '" + txtNumberOfPeople.Text + "', TotalCost = '" + txtTotalCost.Text + "' where username = '" + txtUsername.Text + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Successfully Updated");
                    refreshGrid();
                }
                else
                {
                    MessageBox.Show("Not Successfull");
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

            txtUsername.Enabled = false;
            txtCategory.Enabled = false;
            txtPlace.Enabled = false;
            txtTransportName.Enabled = false;
            txtTransportVariant.Enabled = false;
            txtHotelName.Enabled = false;
            txtHotelRoom.Enabled = false;
            dateTimePickerDeparture.Enabled = false;
            dateTimePickerArrival.Enabled = false;
            txtNumberOfPeople.Enabled = false;
            txtTotalCost.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            insertQuery("delete from UserInfo where username = '" + txtUsername.Text + "'");
            insertQuery("delete from Registration where username = '" + txtUsername.Text + "'");
            insertQuery("delete from CostCalculation where username = '" + txtUsername.Text + "'");
            refreshGrid();
        }
    }
}
