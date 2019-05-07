using EmployeeManegmentSystem;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangePassword
{
    public partial class ChangePassword : Form
    {
        String employeeID;
        String currentPassword;


        public ChangePassword(String employeeID)
        {
            this.employeeID = employeeID;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCPempID.Text = employeeID;
            using (DBConnect db = new DBConnect())
            {
                String q = "select name , password from employee where employeeID = '" + employeeID + "'";
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    lblCPempName.Text = r[0].ToString();
                    currentPassword = r[1].ToString();
                }
            }
        }

        private void btnCP_Click(object sender, EventArgs e)
        {
            if (!txtCPCurrentP.Text.Equals(""))
            {
                if (txtCPCurrentP.Text.Equals(currentPassword))
                {
                    if (!txtCPNewPass.Text.Equals(""))
                    {
                        if (txtCPNewPass.Text.Equals(txtCPConfirm.Text))
                        {

                            using(DBConnect db = new DBConnect())
                            {
                                String q = "update employee set password = '" + txtCPNewPass.Text + "' where employeeID = '" + employeeID + "'";
                                MySqlCommand cmd = new MySqlCommand(q, db.con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Password updated successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtCPConfirm.Clear();
                                txtCPCurrentP.Clear();
                                txtCPNewPass.Clear();
                                this.Close();

                            }

                        }else
                        {
                            MessageBox.Show("New password and confirm password does not match..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }else
                    {
                        MessageBox.Show("Please fill the new password..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }else
                {
                    MessageBox.Show("Current password is invalid..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }else
            {
                MessageBox.Show("Please fill the current password..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
