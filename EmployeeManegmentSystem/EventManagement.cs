
using EmployeeManegmentSystem;
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

namespace EventManagement
{
    public partial class EventManagement : Form
    {
        //private object cmbDfB;

        //private String hallIDTemp;

        public EventManagement()
        {
            InitializeComponent();
        }


        private void btnEvent_Click(object sender, EventArgs e)
        {
            pnlEvent.BringToFront();

        }

        private void pnlEvent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBookingEventHalls_Click_1(object sender, EventArgs e)
        {
            pnlEventHallsAvailability.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlEvent.BringToFront();
        }

        private void btnEntertainmentAva_Click(object sender, EventArgs e)
        {
            pnlEntertainmentAva.BringToFront();
        }

        private void pnlEventHallsAvailability_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBookingHall_Click(object sender, EventArgs e)
        {
            pnlBookingHalls.BringToFront();
        }

        private void gbAvailability_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmbHallType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblHallType_Click(object sender, EventArgs e)
        {

        }

        private void lblCheckDate_Click(object sender, EventArgs e)
        {

        }

        private void dateSelectDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtAvailabilityView_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAvailabitity_Click(object sender, EventArgs e)
        {
            //dgvHallAv.DataSource = getAvailabilityFromHallType(cmbHallType.Text);
        }

        /*private DataTable getAvailabilityFromHallType(String type)
        {

            String q;
            if (type.Equals(""))
            {
                q = "select r.HallId as 'Room ID',r.Type as 'Room Type',c.FirstName as 'First Name', b.CheckIn as 'Check In', b.CheckOut as 'Check Out' from rooms r,room_booking b,customers c where r.RoomID = b.RoomID AND c.ContactID = b.CustomerID";
            }
            else
            {
                q = "select r.RoomID as 'Room ID',r.Type as 'Room Type',c.FirstName as 'First Name', b.CheckIn as 'Check In', b.CheckOut as 'Check Out' from rooms r,room_booking b,customers c where r.RoomID = b.RoomID AND c.ContactID = b.CustomerID AND r.Type = '" + type + "'";
            }


            DataTable dt = new DataTable();

            using (DBConnect db = new DBConnect())
            {
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();

                dt.Load(r);
                return dt;
            }
        }*/

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pnlEntertainmentAva_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pnlBookingHalls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlEventBooking.BringToFront();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlEventBooking_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Event ev = new Event();
            ev.CustomerEId = Int32.Parse(txtHallSearch.Text);

            ev.deleteEvent();
            clearAddEventForm();
            //dgvAllCustomers.DataSource = loadAllCustomers();*/
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbHallDiscount_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            

            if (!ValidationEvent.validateName(txtName.Text) || txtName.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Name");
            }
            else if (!ValidationEvent.validatePhoneNo(txtHallContactNo.Text) || txtHallContactNo.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Phone number");
            }
            else if (!ValidationEvent.validateNic(txtNic.Text) || txtNic.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Nic NO");
            }
            else if (txtHallAddress.Text == "")
            {
                MessageBox.Show("Please enter the Address");
            }
            else if (comHallType.Text == "")
            {
                MessageBox.Show("Please enter a valid Hall Type");
            }
            else if (txtHallCount.Text == "")
            {
                MessageBox.Show("Please enter the Member Count");
            }
            else
            {
                Hall h = new Hall();
                h.Name = txtName.Text;
                h.ContactNo = txtHallContactNo.Text;
                h.Nic = txtNic.Text;
                h.Address = txtHallAddress.Text;
                h.HallType = comHallType.Text;
                h.HallDate = hallDate.Value.ToShortDateString();
                h.HallCount = txtHallCount.Text;
                h.InsertHall();
                getHallPrice(h.HallType);

            }


            /*bool result = Hall.InsertHall(h);
            if (result)
            {
                MessageBox.Show("Employee inserted successfully");
            }
            else
            {
                MessageBox.Show("Employee insertion failed");
            }*/
            dgvHallBookings.DataSource = loadDataToDgvHallBookings();
        }
        private void getHallPrice(String type)

        {
         
            String q = "select HallPrice from hallprice where HallType = '" + type + "'";
            using (DBConnect db = new DBConnect())
            {
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        lblHallPrice.Text = (Double.Parse(r[0].ToString())).ToString();
                    }
                }
            }


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEventSubmit_Click(object sender, EventArgs e)
        {


            if (!ValidationEvent.validateName(txtEName.Text) || txtEName.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Name");
            }
            else if (!ValidationEvent.validatePhoneNo(txtEContactNo.Text) || txtEContactNo.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Phone number");
            }
            else if (!ValidationEvent.validateNic(txtENic.Text) || txtENic.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Nic NO");
            }
            else if (txtEAddress.Text == "")
            {
                MessageBox.Show("Please enter the Address");
            }
            else if (!rdbELocal.Checked && !rdbEForeign.Checked)
            {
                MessageBox.Show("Please enter Select The Standards");
            }
            else if (cmbEType.Text == "")
            {
                MessageBox.Show("Please enter a valid Hall Type");
            }
            else if (txtECount.Text == "")
            {
                MessageBox.Show("Please enter a valid Hall Type");
            }

            else
            {
                Event ev = new Event();
                ev.EName = txtEName.Text;
                ev.EContactNo = txtEContactNo.Text;
                ev.ENic = txtENic.Text;
                ev.EAddress = txtEAddress.Text;
                String standards = "";
                if (rdbELocal.Checked)
                {
                    standards = "Local";
                }
                else if (rdbEForeign.Checked)
                {
                    standards = "Foreign";
                }
                ev.EStandards = standards;
                ev.EType = cmbEType.Text;
                ev.EDate = EDate.Value.ToString("yyyy-MM-dd");
                ev.ECount = Int32.Parse(txtECount.Text);

                ev.InsertEvent();
                //getEventPrice();


            }

        }

        private void btnHallUpdate_Click(object sender, EventArgs e)
        {
            

            /*string NamePattern = "^[a-zA-Z][a-zA-Z\\s]+$";
            string AddressPattern = "^[a-zA-Z][a-zA-Z\\s]+$";
            string ContactPattern = "[0-9]{10}";

            bool isNameValid = Regex.IsMatch(txtName.Text, NamePattern);
            bool isAddressValid = Regex.IsMatch(txtHallAddress.Text, AddressPattern);
            bool isContactValid = Regex.IsMatch(txtHallContactNo.Text, ContactPattern);*/

            if (!ValidationEvent.validateName(txtName.Text) || txtName.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Name");
            }
            else if (!ValidationEvent.validatePhoneNo(txtHallContactNo.Text) || txtHallContactNo.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Phone number");
            }
            else if (!ValidationEvent.validateNic(txtNic.Text) || txtNic.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Nic NO");
            }
            else if (txtHallAddress.Text == "")
            {
                MessageBox.Show("Please enter the Address");
            }
            else if (comHallType.Text == "")
            {
                MessageBox.Show("Please enter a valid Hall Type");
            }
            else if (txtHallCount.Text == "")
            {
                MessageBox.Show("Please enter the Member Count");
            }

            else
            {
                Hall h = new Hall();
                h.HallId = Int32.Parse(txtHallSearch.Text);
                h.Name = txtName.Text;
                h.ContactNo = txtHallContactNo.Text;
                h.Nic = txtNic.Text;
                h.Address = txtHallAddress.Text;
                h.HallType = comHallType.Text;
                h.HallDate = hallDate.Value.ToShortDateString();
                h.HallCount = txtHallCount.Text;
                h.UpdateHall();
                getHallPrice(h.HallType);
                clearAddEventForm();
            }

            /*bool result = Hall.InsertHall(h);
            if (result)
            {
                MessageBox.Show("Employee inserted successfully");
            }
            else
            {
                MessageBox.Show("Employee insertion failed");
            }*/
            dgvHallBookings.DataSource = loadDataToDgvHallBookings();
        }

        private void btnHallSearch_Click(object sender, EventArgs e)
        {
            //hallIDTemp = txtHallSearch.Text;

            Hall h = new Hall();
            Hall d = new Hall();
            d = h.Search("HallId = '" + txtHallSearch.Text + "'");

            txtName.Text = d.Name;
            txtHallContactNo.Text = d.ContactNo;
            txtNic.Text = d.ContactNo;
            txtHallAddress.Text = d.Address;
            comHallType.Text = d.HallType;
            hallDate.Value = Convert.ToDateTime(d.HallDate);
            

            txtHallCount.Text = d.HallCount;


            

        }

        private void btnHallDelete_Click(object sender, EventArgs e)
        {
            Hall h = new Hall();
            h.HallId = Int32.Parse(txtHallSearch.Text);

            h.deleteHall();
            clearAddHallForm();
            dgvHallBookings.DataSource = loadDataToDgvHallBookings();
            //dgvAllCustomers.DataSource = loadAllCustomers();*/
        }

        private void txtHallSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAddHallForm();
        }

        private void clearAddHallForm()
        {
            txtName.Clear();
            txtHallContactNo.Clear();
            txtNic.Clear();
            txtHallAddress.Clear();
            comHallType.SelectedIndex = 0;
            txtHallCount.Clear();
            txtHallDiscount.Clear();
            lblHallTotPrice.Text = "0";
            
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            pnlReport.BringToFront();
        }

        private void txtEventContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEventUpdate_Click(object sender, EventArgs e)
        {
            

            /*string NamePattern = "^[a-zA-Z][a-zA-Z\\s]+$";
            string AddressPattern = "^[a-zA-Z][a-zA-Z\\s]+$";
            string ContactPattern = "[0-9]{10}";*/

            /*bool isNameValid = Regex.IsMatch(txtEName.Text, NamePattern);
            bool isAddressValid = Regex.IsMatch(txtEAddress.Text, AddressPattern);
            bool isContactValid = Regex.IsMatch(txtEContactNo.Text, ContactPattern);*/

            if (!ValidationEvent.validateName(txtEName.Text) || txtEName.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Name");
            }
            else if (!ValidationEvent.validatePhoneNo(txtEContactNo.Text) || txtEContactNo.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Phone number");
            }
            else if (!ValidationEvent.validateNic(txtENic.Text) || txtENic.Equals(String.Empty))
            {
                MessageBox.Show("Please enter a valid Nic NO");
            }
            else if (txtEAddress.Text == "")
            {
                MessageBox.Show("Please enter the Address");
            }
            else if (!rdbELocal.Checked && !rdbEForeign.Checked)
            {
                MessageBox.Show("Please enter Select The Standards");
            }
            else if (cmbEType.Text == "")
            {
                MessageBox.Show("Please enter a valid Hall Type");
            }
            else if (txtECount.Text == "")
            {
                MessageBox.Show("Please enter a valid Hall Type");
            }

            else
            {

                Event ev = new Event();
                ev.CustomerEId = Int32.Parse(txtESearch.Text);
                ev.EName = txtEName.Text;
                ev.EContactNo = txtEContactNo.Text;
                ev.ENic = txtENic.Text;
                ev.EAddress = txtEAddress.Text;
                String standards = "";
                if (rdbELocal.Checked)
                {
                    standards = "Local";
                }
                else if (rdbEForeign.Checked)
                {
                    standards = "Foreign";
                }
                ev.EStandards = standards;
                ev.EType = cmbEType.Text;
                ev.EDate = EDate.Value.ToShortDateString();
                ev.ECount = Int32.Parse(txtECount.Text);
                ev.UpdateEvent();

                clearAddEventForm();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHallTotal_Click(object sender, EventArgs e)
        {
            if (ValidationEvent.validateDiscountText(txtHallDiscount.Text))
            {
                double discount;

                if (!txtHallDiscount.Text.Equals(""))
                {
                    discount = Double.Parse(txtHallDiscount.Text);
                }
                else
                {
                    discount = 1;
                }
                double discountPrice = Double.Parse(lblHallPrice.Text) * discount / 100;
                double totalPrice = Double.Parse(lblHallPrice.Text) - discountPrice;
                lblHallTotPrice.Text = totalPrice.ToString();
            }
            else
            {
                MessageBox.Show("Disount should be a number between 0 and 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                lblHallDiscount.Enabled = true;
                txtHallDiscount.Enabled = true;
            }
            else
            {
                lblHallDiscount.Enabled = false;
                txtHallDiscount.Enabled = false;
            }
        }

        private void txtHallCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnESearch_Click(object sender, EventArgs e)
        {
            Event ev = new Event();
            Event e1 = new Event();
            e1 = ev.Search("CustomerEId = '" + txtESearch.Text + "'");

            txtEName.Text = e1.EName;
            txtEContactNo.Text = e1.EContactNo;
            txtENic.Text = e1.EContactNo;
            txtEAddress.Text = e1.EAddress;
            if(e1.EStandards.Equals("Local"))
            {
                rdbELocal.Checked = true;
            }
            else
            {
                rdbEForeign.Checked = false;
            }
            cmbEType.Text = e1.EType;
            EDate.Value = Convert.ToDateTime(e1.EDate);
            // new DateTime(int year, int month, int date);

            txtECount.Text = e1.ECount.ToString();

        }

        private void btnEventClear_Click(object sender, EventArgs e)
        {
            clearAddEventForm();
        }

        private void clearAddEventForm()
        {
            txtESearch.Clear();
            txtEName.Clear();
            txtEContactNo.Clear();
            txtENic.Clear();
            txtEAddress.Clear();
            cmbEType.SelectedIndex = 0;
            txtECount.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgvAllReport.DataSource = loadAllHallReport();

        }

        public DataTable loadAllHallReport()
        {
            DataTable dt = new DataTable();

            using (DBConnect db = new DBConnect())
            {
                String q = "select HallId as 'Hall Booking ID ',Name as 'Name', HallType as 'Hall Type',  HallCount as 'Hall Count' from customerhall";
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();
                dt.Load(r);
            }
            return dt;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dgvHallBookings.DataSource = loadDataToDgvHallBookings();
        }

        private DataTable loadDataToDgvHallBookings()
        {
            DataTable dt = new DataTable();
            String q = "SELECT `HallId`, `Name`,`HallType`, `HallDate`,`HallCount` FROM `customerhall`";
            using(DBConnect db = new DBConnect())
            {
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();
                dt.Load(r);
                return dt;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
