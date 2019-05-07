using EmployeeManegmentSystem;
using Finance;
using Inventory;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomRservation
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {

            Thread t = new Thread(new ThreadStart(startSplashScreen));
            t.Start();
            Thread.Sleep(2000);                           
            InitializeComponent();
            t.Abort();
        }

        private void startSplashScreen()
        {
            Application.Run(new SplashScreen());
        }

        public object Sqlcommand { get; private set; }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           DialogResult d = MessageBox.Show("Are you sure you want to add this user ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (d.Equals(DialogResult.Yes)){
                addUser();
            }
       

        }
        private void addUser()
        {

            String userName = txtUn.Text;
            String password = txtPw.Text;

            String q = "insert into Users(userName,password) values ('" + userName + "','" + password + "')";

            try
            {
                using (DBConnect db = new DBConnect())
                {

                    db.insert(q);
                    //SqlCommand cmd = new SqlCommand(q, db.con);
                    //cmd.ExecuteNonQuery();
                    //MessageBox.Show("User inserted successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //clearTexts();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
                

        }

        private void clearTexts()
        {
            txtPw.Clear();
            txtUn.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            

            String userName = txtUn.Text;
            String password = txtPw.Text;
            String pass = null ;
            String jobRole = null;
            String q = "select password,jobRole from employee where employeeID = '" + userName + "'";

            using (DBConnect db = new DBConnect())
            {
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();

                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        pass = r["password"].ToString();
                        jobRole = r["jobRole"].ToString();
                    }

                    if (pass.Equals(password)){

                        if (jobRole.Equals("Receptionist")){
                            frmMain m = new frmMain(txtUn.Text);
                            this.Hide();
                            m.Show();
                        }else if (jobRole.Equals("Manager"))
                        {
                            frmHome home = new frmHome(txtUn.Text);
                            this.Hide();
                            home.Show();
                        }else if (jobRole.Equals("StockManager"))
                        {
                            InventoryMain inv = new InventoryMain(txtUn.Text);
                            this.Hide();
                            inv.Show();
                        }else if (jobRole.Equals("FinanceManager"))
                        {
                            FormFinance fiance = new FormFinance(txtUn.Text);
                            fiance.Show();
                            this.Hide();
                        }else if (jobRole.Equals("RestaurantManager"))
                        {
                            Rest_Managment.RestManagment res = new Rest_Managment.RestManagment(txtUn.Text);
                            res.Show();
                            this.Hide();
                        }



                    }
                    else {
                        MessageBox.Show("Invalid Password");
                    }
                }else
                {
                    MessageBox.Show("Invalid user name");
                }
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtPw_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
