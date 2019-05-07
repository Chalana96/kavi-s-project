using MySql.Data.MySqlClient;
using RoomRservation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmployeeManegmentSystem
{
    public partial class frmHome : Form
    {
        String employeeID;

        public frmHome(String employeeID)
        {
            this.employeeID = employeeID;
            InitializeComponent();
        }

        private void pnlFront_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void calander_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            pnlFront.BringToFront();
        }

        private void btnRegistraion_Click(object sender, EventArgs e)
        {
            pnlEmpReg.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblSecond.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("MM dd yyyy");
            lblday.Text = DateTime.Now.ToString("dddd");
            lblSecond.Location = new Point(lblTime.Location.X + lblTime.Width - 30, lblSecond.Location.Y);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlFront.BringToFront();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void radioSingle_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
            {
                MessageBox.Show("Please enter a value to Employee ID!");
                return;
            }
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            pnlAttendance.BringToFront();
        }


       
        public DataTable loadAllEmployees()
        {
            DataTable dt = new DataTable();
            using (DBConnect db = new DBConnect())
            {
                String q = "select `employeeID`, `name`, `nic`, `dob`, `state`, `address`, `contactNo`, `jobRole`, `gender` from Employee";
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();
                dt.Load(r);
            }
            return dt;
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
           
            pnlSalary.BringToFront();
            
        }

        private void btnDep_Click(object sender, EventArgs e)
        {
            pnlDept.BringToFront();
        }

        private void btnSalaryProcess_Click(object sender, EventArgs e)
        {
            pnlPaySheet.BringToFront();
        }

        private void btnSalaryCancel_Click(object sender, EventArgs e)
        {
            pnlFront.BringToFront();
        }

        private void btnPaySheetCancel_Click(object sender, EventArgs e)
        {
            pnlSalary.BringToFront();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void grpboxEmployee_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin l = new frmLogin();            
            l.Show();
            this.Close();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
          //emp.EmployeeID = txtEmpID.Text;
            emp.Name = txtName.Text;
            emp.Nic = txtNIC.Text;
            DateTime dt = cmbDfB.Value;
           emp.Dob = dt.ToString("yyyy-MM-dd");
        
            if (radioSingle.Checked)
            {
                emp.State = "Single";
            }else
            {
                emp.State = "Married";
            }
            emp.Address = txtAddress.Text;
            emp.ContactNo = txtContact.Text;
            emp.JobRole = comboJobROLL.Text;
            if(radioMale.Checked)
            {
                emp.Gender = "Male";
            }else
            {
                emp.Gender = "Female";
            }
            if (emp.Image != null)
            {              
                FileStream fstream = new FileStream(this.lblUnderB.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                emp.Image = br.ReadBytes((int)fstream.Length);
            }



            if (!validation.validateName(emp.Name) || emp.Name.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid  Name");
            }

            else if (!validation.validateNICNo(emp.Nic) || emp.Nic.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid NIC number");
            }

            else if (!radioSingle.Checked && !radioMarried.Checked)
            {
                MessageBox.Show("You forgot to select the State!");
            }

            else if (!validation.validateAddress(emp.Address) || emp.Address.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Address");
            }

            else if (!radioMale.Checked && !radioFemale.Checked)
            {
                MessageBox.Show("You forgot to select the gender!");
            }

            else if (!validation.validateContactNo(emp.ContactNo) || emp.ContactNo.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid contact number");
            }

            else if (emp.JobRole == "")
            {
                MessageBox.Show("Please enter a valid Job Roll");
            }
            else if (!radioMale.Checked && !radioFemale.Checked)
            {
                MessageBox.Show("You forgot to select the gender!");
            }

            else
            {
                emp.InsertEmployee();
                btnclear_Click(sender, e);

             
            }  
                

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png)";

            if(image.ShowDialog() == DialogResult.OK)
            {
                String picpath = image.FileName.ToString();
                lblUnderB.Text = picpath;
                picpath = lblUnderB.Text;
                picEmployee.ImageLocation = picpath;
           
                Image img = Image.FromFile(picpath);
                picEmployee.Image = RotateImage(img, 0);
            }
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void lblUnderB_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchBarCode_Click(object sender, EventArgs e)
        {
  

            String barCode = txtID.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                picBarcode.Image = brCode.Draw(barCode, 30);
            }
            catch (Exception)
            {

            }
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.EmployeeID = txtID.Text;

            emp.Name = txtName.Text;
            emp.Nic = txtNIC.Text;

            DateTime dt = cmbDfB.Value;
            emp.Dob = dt.ToString("yyyy-MM-dd");
            if (radioSingle.Checked)
            {
                emp.State = "Single";
            }
            else
            {
                emp.State = "Married";
            }
            emp.Address = txtAddress.Text;
            emp.ContactNo = txtContact.Text;
            emp.JobRole = comboJobROLL.Text;
            if (emp.Image != null)
            {

                FileStream fstream = new FileStream(this.lblUnderB.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                emp.Image = br.ReadBytes((int)fstream.Length);
            }
            if (radioMale.Checked)

            {
                emp.Gender = "Male";
            }
            else
            {
                emp.Gender = "Female";
            }

            emp.updateEmployee();
            btnclear_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            Employee d = new Employee();

            d = emp.Search("employeeID = '" + txtID.Text + "'");
            try
            {

                txtName.Text = d.Name;
                txtNIC.Text = d.Nic;

                if (d.State.Equals("Single"))
                {
                    radioSingle.Checked = true;
                }
                else
                {
                    radioMarried.Checked = false;
                }

                txtAddress.Text = d.Address;
                txtContact.Text = d.ContactNo;
                comboJobROLL.Text = d.JobRole;

                if (d.State.Equals("Male"))
                {
                    radioMale.Checked = true;
                }
                else
                {
                    radioFemale.Checked = false;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Cannot find an employee from  employee ID : " + emp.EmployeeID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void radioMale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMale == null)
            {

                MessageBox.Show("Employee Gender is Empty");
            }

        }
        private void radioFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFemale == null)
            {

                MessageBox.Show("Employee Gender is Empty");
            }
        }

        private void lblGender_Click(object sender, EventArgs e)
        {

        }

        private void picEmployee_Click(object sender, EventArgs e)
        {

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtNIC.Clear();
            txtAddress.Clear();
            txtContact.Clear();
            comboJobROLL.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            emp.EmployeeID = (txtID.Text);

            emp.deleteEmployee();
            btnclear_Click(sender, e);

        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Console.Beep(2000, 500);
                btnSearch_Click(sender, e);
            }
        }

        private void txtEmpID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                salaryFormFill();
            }
        }

        private void salaryFormFill()
        {
            getNameAndJobRole();
          
        }

        public void getNameAndJobRole()
        {
            using (DBConnect db = new DBConnect())
            {
                String q = "select employeeID,name,jobRole from employee where employeeId = '" + txtEmpID.Text + "'";
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtEmpName.Text = reader[1].ToString();
                        txtJobRole.Text = reader[2].ToString();
                    }
                }
            }
        }

        private void btnJobManagement_Click(object sender, EventArgs e)
        {

            jobManagemant job = new jobManagemant();
            job.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            dgvEmp.DataSource = loadAllEmployees();
            pnlAllEmp.BringToFront();
        }

        private void txtEmpID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ChangePassword.ChangePassword c = new ChangePassword.ChangePassword(employeeID);
            c.Show();
        }

        private void dgvEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblHotelName_Click(object sender, EventArgs e)
        {

        }

        private void comboJobROLL_MouseClick(object sender, MouseEventArgs e)
        {
            using(DBConnect db = new DBConnect())
            {
                comboJobROLL.Items.Clear();
                String q = "select jobRole from salary group by jobRole";
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    
                    comboJobROLL.Items.Add(r[0].ToString());
                }
            }
        }

        private void comboJobROLL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    //public void gethourlyRateAndotRate()
    //{
    //    using (DBConnect db = new DBConnect())
    //    {
    //        String q = "select employeeID,name,jobRole from employee where employeeId = '" + txtEmpID.Text + "'";
    //        MySqlCommand cmd = new MySqlCommand(q, db.con);
    //        MySqlDataReader reader = cmd.ExecuteReader();

    //        if (reader.HasRows)
    //        {
    //            while (reader.Read())
    //            {
    //                txtEmpName.Text = reader[1].ToString();
    //                txtJobRole.Text = reader[2].ToString();
    //            }
    //        }
    //    }
    //}

}
