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
    public partial class Registration : Form
    {
        public Registration()
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

        }

        private void lblLogin_MouseClick(object sender, MouseEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void lblLogin_MouseEnter(object sender, EventArgs e)
        {
            this.lblLogin.BackColor = Color.FromArgb(100, 0, 0, 0);
            this.lblLogin.ForeColor = Color.FromArgb(100, 255, 255, 255);
        }

        private void lblLogin_MouseLeave(object sender, EventArgs e)
        {
            this.lblLogin.BackColor = Color.FromArgb(0, 0, 0, 0);
            this.lblLogin.ForeColor = Color.FromArgb(62, 59, 59);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                errorProvider1.SetError(txtName, "Name Required");
                return;
            }
            else
            {
                errorProvider1.SetError(txtName, string.Empty);
            }

            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                errorProvider2.SetError(txtEmail, "Email Required");
                return;
            }
            else
            {
                errorProvider2.SetError(txtEmail, string.Empty);
            }

            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                errorProvider3.SetError(txtUsername, "Username Required");
                return;
            }
            else
            {
                errorProvider3.SetError(txtUsername, string.Empty);
            }

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider4.SetError(txtPassword, "Password Required");
                return;
            }
            else
            {
                errorProvider4.SetError(txtPassword, string.Empty);
            }

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AVF1SU1;Initial Catalog= Travel Management System;Integrated Security=True");
            con.Open();

            string UniqueQuery = "alter table Registration add constraint u unique(Username)";
            string insertQuery = "insert into Registration (Name, Email, Username,  Password, DOB) values ( '" + txtName.Text + "','" + txtEmail.Text + "','" + txtUsername.Text + "','" + txtPassword.Text + "','" + Convert.ToDateTime(DOB.Text) + "')";
            
            try
            {
                SqlCommand cmd1 = new SqlCommand(UniqueQuery, con);
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Successfully Registered");
                else
                    MessageBox.Show("Unsuccessful");
            }
            catch(Exception)
            {
                MessageBox.Show("Username Matched! Please try a different one");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
