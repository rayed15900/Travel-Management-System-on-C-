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
    public partial class Login : Form
    {
        public static object GetUsername;
        public Login()
        {
            InitializeComponent();
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

        private void btnX_MouseMove(object sender, EventArgs e)
        {
            this.btnX.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
        }

        private void btnX_MouseLeave(object sender, EventArgs e)
        {
            this.btnX.ForeColor = ColorTranslator.FromHtml("#000000");
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxShowPassword.Checked)
            {
                txtPasswordLogin.PasswordChar = '\0';

            }
            else
            {
                txtPasswordLogin.PasswordChar = '•';

            }
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
        }

        private void lblRegister_MouseClick(object sender, MouseEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }

        private void lblRegister_MouseEnter(object sender, EventArgs e)
        {
            this.lblRegister.BackColor = Color.FromArgb(100, 0, 0, 0);
            this.lblRegister.ForeColor = Color.FromArgb(100, 255, 255, 255);
        }

        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            this.lblRegister.BackColor = Color.FromArgb(0, 0, 0, 0);
            this.lblRegister.ForeColor = Color.FromArgb(62, 59, 59);
        }

        private void txtpasswordLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPasswordLogin_Click(object sender, EventArgs e)
        {

        }

        private void txtUsernameLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUsernameLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsernameLogin.Text.Trim()))
            {
                errorProvider1.SetError(txtUsernameLogin, "Username Required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUsernameLogin, string.Empty);
            }
            if (string.IsNullOrEmpty(txtPasswordLogin.Text.Trim()))
            {
                errorProvider2.SetError(txtPasswordLogin, "Password Required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtPasswordLogin, string.Empty);
            }

            if(txtUsernameLogin.Text == "admin" && txtPasswordLogin.Text == "admin123")
            {
                DashboardAdmin admin = new DashboardAdmin();
                admin.Show();
                this.Hide();
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
                con.Open();

                string query = "select count(*) from Registration where Username = '" + txtUsernameLogin.Text + "' and Password = '" + txtPasswordLogin.Text + "' ";

                GetUsername = txtUsernameLogin.Text;

                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);

                    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                    if (temp == 1)
                    {
                        insertQuery("if not exists (select * from UserInfo where username = '" + txtUsernameLogin.Text + "') Begin insert into UserInfo (Username) values ('" + txtUsernameLogin.Text + "') End");
                        insertQuery("if not exists (select * from CostCalculation where username = '" + txtUsernameLogin.Text + "') Begin insert into CostCalculation (Username) values ('" + txtUsernameLogin.Text + "') End");

                        DashboardHome home = new DashboardHome();
                        home.Show();
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Login Unsuccessfull");
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
}
