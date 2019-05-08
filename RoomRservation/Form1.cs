using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomRservation
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(string text)
        {
            Text = text;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlHome.BringToFront();
        }

        private void btnAvailability_Click(object sender, EventArgs e)
        {
            pnlAvailbility.BringToFront();
            loadRoomBookings();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            pnlHome.BringToFront();
            btnViewAll_Click(sender, e);
        }


        private void btnBooking_Click(object sender, EventArgs e)
        {
            pnlForm1.BringToFront();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }



        //method call



        private void clearAddCustomerForm()
        {
            txtboxContactID.Clear();
            txtboxFirstName.Clear();
            txtboxLastName.Clear();
            textBoxNIC.Clear();
            txtboxAddress.Clear();
            txtboxContactNumber.Clear();
            adults.Clear();
            children.Clear();
            cmbDeluxeRoom.SelectedIndex = 0;
            cmbSuiteRoom.SelectedIndex = 0;
            cmbStandardRoom.SelectedIndex = 0;

        }

        
           

       

    /*    private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Text.Contains(cmbSuiteRoom.Text))
            {
                MessageBox.Show("no item is selected");
            }
        }
   */   
      
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {


            if (txtboxFirstName.Text == "" || txtboxLastName.Text == "" || textBoxNIC.Text == "" || txtboxAddress.Text == "" || txtboxContactNumber.Text == "" || adults.Text == "" || children.Text == "")
            {
                MessageBox.Show("Please fill the fields");
            }



            else if (!ValidationRoomRes.validateName(txtboxFirstName.Text) || txtboxFirstName.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid first Name");
            }
            else if (!ValidationRoomRes.validateName(txtboxLastName.Text) || txtboxLastName.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Last Name");
            }
            else if (!ValidationRoomRes.validateNIC(textBoxNIC.Text) || textBoxNIC.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid NIC");
            }

            else if (!ValidationRoomRes.validatePhoneNo(txtboxContactNumber.Text) || txtboxContactNumber.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Phone number");
            }
            else if (!ValidationRoomRes.validateNumbers(adults.Text) || adults.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter  number of adults 1 - 12");
            }
            else if (!ValidationRoomRes.validateChildren(children.Text) || children.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter  number of children  0-12");
            }
            else if (cmbDeluxeRoom.Text == "" &&  cmbSuiteRoom.Text == "" && cmbStandardRoom.Text == "")
            {
                MessageBox.Show("Please enter number of rooms");
            }

            else if (!radioMale.Checked && !radioFemale.Checked)
            {
                MessageBox.Show("You forgot to select the gender!");
            }
            else
            {


                ContactClass c = new ContactClass();
                //c.ContactID = Int32.Parse(txtboxContactID.Text);
                c.FirstName = txtboxFirstName.Text;
                c.LastName = txtboxLastName.Text;
                c.NIC = textBoxNIC.Text;
                c.ContactNo = txtboxContactNumber.Text;
                c.Address = txtboxAddress.Text;
                String gender = "";

                if (radioMale.Checked)
                {
                    gender = "Male";
                }
                else if (radioFemale.Checked)
                {
                    gender = "Female";

                }

                c.Gender = gender;
                c.checkin = dob.Value.ToShortDateString();
                c.checkout = dateTimePicker1.Value.ToShortDateString();

                c.adults = adults.Text;
                c.children = children.Text;
                c.DeluxeRoom = cmbDeluxeRoom.Text;
                c.SuiteRoom = cmbSuiteRoom.Text;
                c.StandardRoom = cmbStandardRoom.Text;

                // c.Room = cmbRoom.Text;
                // c.Room = Int32.Parse(cmbSuiteRoom.Text);

                c.InsertCustomer();
                //   getRoomPrice();

                dgvAllCustomers.DataSource = loadAllCustomers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


            if (txtboxFirstName.Text == "" || txtboxLastName.Text == "" || textBoxNIC.Text == "" || txtboxAddress.Text == "" || txtboxContactNumber.Text == "" || adults.Text == "" || children.Text == "")
            {
                MessageBox.Show("Please fill the fields");
            }



            else if (!ValidationRoomRes.validateName(txtboxFirstName.Text) || txtboxFirstName.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid first Name");
            }
            else if (!ValidationRoomRes.validateName(txtboxLastName.Text) || txtboxLastName.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Last Name");
            }
            else if (!ValidationRoomRes.validateNIC(textBoxNIC.Text) || textBoxNIC.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid NIC");
            }

            else if (!ValidationRoomRes.validatePhoneNo(txtboxContactNumber.Text) || txtboxContactNumber.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Phone number");
            }
            else if (!ValidationRoomRes.validateNumbers(adults.Text) || adults.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter  number of adults 1 - 12");
            }
            else if (!ValidationRoomRes.validateChildren(children.Text) || children.Text.Equals(String.Empty))
            {
                MessageBox.Show("Please enter  number of children  0-12");
            }
            else if (cmbDeluxeRoom.Text == "" && cmbSuiteRoom.Text == "" && cmbStandardRoom.Text == "")
            {
                MessageBox.Show("Please enter a number of rooms");
            }

            else if (!radioMale.Checked && !radioFemale.Checked)
            {
                MessageBox.Show("You forgot to select the gender!");
            }
            else
            {
                ContactClass c = new ContactClass();
                c.ContactID = Int32.Parse(txtboxContactID.Text);
                c.FirstName = txtboxFirstName.Text;
                c.LastName = txtboxLastName.Text;
                c.NIC = textBoxNIC.Text;
                c.ContactNo = txtboxContactNumber.Text;
                c.Address = txtboxAddress.Text;
                String gender = "";

                if (radioMale.Checked)
                {
                    gender = "Male";
                }
                else if (radioFemale.Checked)
                {
                    gender = "Female";

                }

                c.Gender = gender;
                c.checkin = dob.Value.ToString("yyyy-MM-dd");
                c.checkout = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                c.adults = adults.Text;
                c.children = children.Text;
                c.DeluxeRoom = cmbDeluxeRoom.Text;
                c.SuiteRoom = cmbSuiteRoom.Text;
                c.StandardRoom = cmbStandardRoom.Text;
                //  c.Room = cmbRoom.Text;
                //  c.Room = Int32.Parse(cmbSuiteRoom.Text);

                c.UpdateCustomer();

                clearAddCustomerForm();
                dgvAllCustomers.DataSource = loadAllCustomers();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtboxContactID.Text != "")
            {

                ContactClass c = new ContactClass();
                ContactClass d = new ContactClass();
                d = c.Search("ContactID = '" + txtboxContactID.Text + "'");

                txtboxFirstName.Text = d.FirstName;
                txtboxLastName.Text = d.LastName;
                textBoxNIC.Text = d.NIC;
                txtboxContactNumber.Text = d.ContactNo;
                txtboxAddress.Text = d.Address;

                if (d.Gender.Equals("Male"))
                {
                    radioMale.Checked = true;
                }
                else
                {
                    radioFemale.Checked = false;
                }

                dob.Value = Convert.ToDateTime(d.checkin);
                dateTimePicker1.Value = Convert.ToDateTime(d.checkout);
                // new DateTime(int year, int month, int date);
                //  c.DateOfBirth = dob.Value.ToString("yyyy-MM-dd");

                // txtAge.Text = d.age;
                adults.Text = d.adults;
                children.Text = d.children;
                cmbDeluxeRoom.Text = d.DeluxeRoom.ToString();
                cmbSuiteRoom.Text = d.SuiteRoom.ToString();
                cmbStandardRoom.Text = d.StandardRoom.ToString();

                // cmbSuiteRoom.Text = d.Room.ToString();

                // getRoomPrice();
            }
        }

        
        
            
               public DataTable loadAllCustomers()
               {
                   DataTable dt = new DataTable();

                   using (DBConect db = new DBConect())
                   {
                       String q = "select ContactID as 'Customer ID ',FirstName as 'First Name',LastName as 'Last Name' from Customers";
                       MySqlCommand cmd = new MySqlCommand(q, db.con);
                       MySqlDataReader r = cmd.ExecuteReader();
                       dt.Load(r);
                   }
                   return dt;
               }
        /*
               private void btnCheckForRoomType_Click(object sender, EventArgs e)
               {
                   dgvAvailability.DataSource = getAvailabilityForRoomType(cmbAvailableType.Text);
               }
*/
        
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            dgvAllCustomers.DataSource = loadAllCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtboxFirstName.Text == "" || txtboxLastName.Text == "" || textBoxNIC.Text == "" || txtboxAddress.Text == "" || txtboxContactNumber.Text == "" || adults.Text == "" || children.Text == "")
            {
                MessageBox.Show("Please enter field you want to delete");
            }
            else { 
            ContactClass c = new ContactClass();
            c.ContactID = Int32.Parse(txtboxContactID.Text);

            c.deleteCustomer();

            clearAddCustomerForm();
            dgvAllCustomers.DataSource = loadAllCustomers();
        }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAddCustomerForm();
        }

       
        private void txtboxContactID_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Show();
            this.Close();
        }

        private void dgvAllCustomers_MouseClick_1(object sender, MouseEventArgs e)
        {
            String contactID = dgvAllCustomers.SelectedRows[0].Cells[0].Value.ToString();
            txtboxContactID.Text = contactID;
            btnSearch_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isAvailable())
            {
                MessageBox.Show("Available");
            }else
            {
                MessageBox.Show("Not Available");
            }

        }

        private Boolean isAvailable()
        {
            DateTime roomCheckin = Convert.ToDateTime(CheckIn.Value.ToString());
            DateTime roomCheckout = Convert.ToDateTime(CheckOut.Value.ToString());
            String roomType = cmbRoomTypes.Text;

            Boolean flag = true;

            if (roomBookList.Count > 0)
            {
                foreach (RoomBooking room in roomBookList)
                {
                    if (room.roomType.Equals(roomType))
                    {



                        





                        //roomCheckin - X
                        //roomCheckout - Y

                        //01

                        //if(room.checkInDate > roomCheckin || room.checkOutDate < roomCheckout)
                        //{
                        //    return false;
                        //}
                        //else if(room.checkInDate < roomCheckin || room.checkOutDate < roomCheckout)
                        //{
                        //    return false;
                        //}
                        //else if(room.checkInDate > roomCheckin || room.checkOutDate > roomCheckout){
                        //    return false;
                        //}

                      
                    }
                }
                return true;
            }
            else
            {
                loadRoomBookings();
                return isAvailable();
            }
        }

        List<RoomBooking> roomBookList = new List<RoomBooking>();
        private void loadRoomBookings()
        {

            roomBookList.Clear();
            using (DBConect db = new DBConect())
            {
                String q = "select * from room_booking where RoomType='" + cmbRoomTypes.Text + "'";
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime checkin = Convert.ToDateTime(reader["checkin"].ToString());
                    DateTime checkOut = Convert.ToDateTime(reader["checkout"].ToString());
                    roomBookList.Add(new RoomBooking(reader["RoomType"].ToString(), reader["RoomNo"].ToString(), checkin, checkOut));
                }

            }
        }

        /*   private void btnTotal_Click(object sender, EventArgs e)
           {
               if (ValidationRoomRes.validateDiscountText(txtDiscount.Text))
               {
                   double discount;

                   if (!txtDiscount.Text.Equals(""))
                   {
                       discount = Double.Parse(txtDiscount.Text);
                   }
                   else
                   {
                       discount = 1;
                   }
                   //  double price = Double.Parse(lblPrice1.Text) * Int32.Parse(cmbRoom.Text);
                   double discountPrice = Double.Parse(lblPrice1.Text) * (Int32.Parse(cmbSuiteRoom.Text) + Int32.Parse(cmbSuiteRoom.Text) + Int32.Parse(cmbStandardRoom.Text)) * discount / 100;
                   double totalPrice = Double.Parse(lblPrice1.Text) * (Int32.Parse(cmbSuiteRoom.Text) + Int32.Parse(cmbSuiteRoom.Text) + Int32.Parse(cmbStandardRoom.Text)) - discountPrice;
                   lblTotal1.Text = totalPrice.ToString();
               }
               else
               {
                   MessageBox.Show("Disount should be a number between 0 and 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }

           }*/
        /*
       private void btnCheckForRoomType_Click(object sender, EventArgs e)
       {
           String q;
           if (type.Equals(""))
           {
               q = "select r.RoomID as 'Room ID',r.Type as 'Room Type',c.FirstName as 'First Name', b.CheckIn as 'Check In', b.CheckOut as 'Check Out' from rooms r,room_booking b,customers c where r.RoomID = b.RoomID AND c.ContactID = b.CustomerID";
           }
           else
           {
               q = "select r.RoomID as 'Room ID',r.Type as 'Room Type',c.FirstName as 'First Name', b.CheckIn as 'Check In', b.CheckOut as 'Check Out' from rooms r,room_booking b,customers c where r.RoomID = b.RoomID AND c.ContactID = b.CustomerID AND r.Type = '" + type + "'";
           }


           DataTable dt = new DataTable();

           using (DBConect db = new DBConect())
           {
               MySqlCommand cmd = new MySqlCommand(q, db.con);
               MySqlDataReader r = cmd.ExecuteReader();

               dt.Load(r);
               return dt;
           }*/
        /*
     private void getRoomPrice()
    {
    String q = "select Price from rooms where Type = '" + cmbDeluxeRoom.Text + "' || Type = '" + cmbSuiteRoom +"' || type = '" + cmbStandardRoom.Text +"'" ;
    using (DBConect db = new DBConect())
    {
        MySqlCommand cmd = new MySqlCommand(q, db.con);
        MySqlDataReader r = cmd.ExecuteReader();
        if (r.HasRows)
        {
            while(r.Read()){
                lblPrice1.Text = (Double.Parse(r[0].ToString()) * Int32.Parse(cmbSuiteRoom.Text)).ToString() ;
            }
        }
    }
}






private void chkDiscount_CheckedChanged_1(object sender, EventArgs e)
{

 if (chkDiscount.Checked)
 {
     lblDiscount.Enabled = true;
     txtDiscount.Enabled = true;
 }
 else
 {
     lblDiscount.Enabled = false;
     txtDiscount.Enabled = false;
 }
}


*/
    }
}