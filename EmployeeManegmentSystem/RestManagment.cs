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
using MySql.Data.MySqlClient;
using RoomRservation;

namespace Rest_Managment
{
    public partial class RestManagment : Form
    {
        String empID;
        public RestManagment(String empId)
        {
            this.empID = empId;
            InitializeComponent();
            gridview();
        }
        int indexRow;
        double price, amount, quantity, total = 0;

        private void btnAddMenus_Click(object sender, EventArgs e)
        {
            pnlAddMenus.BringToFront();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            pnlAddOrders.BringToFront();
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            pnlTakeAway.BringToFront();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            pnlPayment.BringToFront();
        }


        //Order Add
        private void btnOrderAdd_Click(object sender, EventArgs e) 
        {
            string mealNamePattern = "^[a-zA-Z][a-zA-Z\\s]+$";
            //string pricePerMealPattern = "^[1 - 9]\\d * (\\.\\d +)?$";
            string quantityPattern = "^[0-9]+$";

            bool ismealNameValid = Regex.IsMatch(txtOrderMealName.Text, mealNamePattern);
           // bool ispricePerMealValid = Regex.IsMatch(txtOrderPricePerMeal.Text, pricePerMealPattern);
            bool isquantityValid = Regex.IsMatch(txtOrderQuantity.Text, quantityPattern);

            if (!ismealNameValid || txtOrderMealName.Text == "")
            {
                MessageBox.Show("Please enter a valid Meal Name");
            }
           /* else if (!ispricePerMealValid || txtOrderPricePerMeal.Text == "")
            {
                MessageBox.Show("Please enter a valid Price per meal");
            }*/
            else if (!isquantityValid || txtOrderQuantity.Text == "")
            {
                MessageBox.Show("Please enter a valid Quantity ");
            }
           

            else
            {
                dgvOrderList.Rows.Add(txtOrderID.Text, txtOrderMealName.Text, txtOrderPricePerMeal.Text, txtOrderQuantity.Text);

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
           con.Open();
           MySqlCommand cmd = new MySqlCommand("INSERT INTO res_order(`order_id`, `Meal_name`, `price_per_unit`, `quantity`) VALUES ('" + txtOrderID.Text + "','" + txtOrderMealName.Text + "','" + txtOrderPricePerMeal.Text + "','" + txtOrderQuantity.Text + "')", con);
           cmd.ExecuteNonQuery();
           MessageBox.Show("Successful Added an Order");
           con.Close();
            }
        }




        //Order Delete

        private void btnOrderDelete_Click(object sender, EventArgs e) 
        {

             MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
               con.Open();
               MySqlCommand cmd = new MySqlCommand("DELETE FROM `res_order` WHERE order_id ='" + txtOrderID.Text + "' ", con);
               cmd.ExecuteNonQuery();
               MessageBox.Show("Successfully Deleted");
               con.Close();


            int rowIndex = dgvOrderList.CurrentCell.RowIndex;
            dgvOrderList.Rows.RemoveAt(rowIndex);
        }



        //Order Clear
        private void btnOrderClear_Click(object sender, EventArgs e)        //////////////////////////////////////////////////////Order Clear
        {
            txtOrderID.Clear();
            txtOrderMealName.Clear();
            txtOrderPricePerMeal.Clear();
            txtOrderQuantity.Clear();
        }




        //Button Add Menu
        private void btnAddMenu_Click(object sender, EventArgs e)
        {
           

                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO res_add_menu (`menu_id`, `menu_name`, `price_per_unit`) VALUES ('" + txtMenuID.Text + "','" + txtMenuName.Text + "','" + txtPricePerMenu.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successful Added an Order");
                con.Close();

            dgvAddMenus.Rows.Add(txtMenuID.Text, txtMenuName.Text, txtPricePerMenu.Text);
            
        }



        //Button Delete Menu
        private void btnDeleteMenu_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `res_add_menu` WHERE menu_id ='" + txtMenuID.Text + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Deleted");
            con.Close();


            int rowIndex = dgvAddMenus.CurrentCell.RowIndex;
            dgvAddMenus.Rows.RemoveAt(rowIndex);
        }





        //Button Clear Menu
        private void btnClearMenu_Click(object sender, EventArgs e)
        {
            txtMenuID.Clear();
            txtMenuName.Clear();
            txtPricePerMenu.Clear();
        }




        //Button Add TakeAway
        private void btnAddTakeAway_Click(object sender, EventArgs e)
        {

            dgvTakeAwayList.Rows.Add(txtTOrderID.Text, txtTMealName.Text, txtTPricePerMeal.Text,txtTQuantity.Text);
        }





        //Button Delete TakeAway
        private void btnDeleteTakeAway_Click(object sender, EventArgs e)
        {

             MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
                con.Open();
                 MySqlCommand cmd = new MySqlCommand("DELETE FROM `res_order` WHERE order_id ='" + txtOrderID.Text + "' ", con);
                cmd.ExecuteNonQuery();
                 MessageBox.Show("Successfully Deleted");
                 con.Close();


            

            int rowIndex = dgvTakeAwayList.CurrentCell.RowIndex;
            dgvTakeAwayList.Rows.RemoveAt(rowIndex);
        }






        //Button Clear TakeAway
        private void btnClearTakeAway_Click(object sender, EventArgs e)
        {
            txtTOrderID.Clear();
            txtTMealName.Clear();
            txtTPricePerMeal.Clear();
            txtTQuantity.Clear();
        }



        //Button Table Reservation
        private void btnTableReservation_Click(object sender, EventArgs e)
        {
            pnlTableReservation.BringToFront();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }



        //Button Order Update
        private void btnOrderUpdate_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `res_order` SET `order_id`='" + txtOrderID.Text + "',`Meal_name`='" + txtOrderMealName.Text + "',`price_per_unit`='" + txtOrderPricePerMeal.Text + "',`quantity`='" + txtOrderQuantity.Text + "' WHERE order_id = '" + txtOrderID.Text + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            con.Close();

            //DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            int indexRow = dgvOrderList.CurrentCell.RowIndex;
            dgvOrderList.Rows[indexRow].Cells[0].Value = txtOrderID.Text;
            dgvOrderList.Rows[indexRow].Cells[1].Value = txtOrderMealName.Text;
            dgvOrderList.Rows[indexRow].Cells[2].Value = txtOrderPricePerMeal.Text;
            dgvOrderList.Rows[indexRow].Cells[3].Value = txtOrderQuantity.Text;
        }





        //Button Menu UpDate
        private void btnUpdateMenu_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `res_add_menu` SET `menu_id`='" + txtMenuID.Text + "',`menu_name`='" + txtMenuName.Text + "',`price_per_unit`='" + txtPricePerMenu.Text + "' WHERE menu_id = '" + txtMenuID.Text + "'", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            con.Close();


            //DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            int indexRow = dgvAddMenus.CurrentCell.RowIndex;
            dgvAddMenus.Rows[indexRow].Cells[0].Value = txtMenuID.Text;
            dgvAddMenus.Rows[indexRow].Cells[1].Value = txtMenuName.Text;
            dgvAddMenus.Rows[indexRow].Cells[2].Value = txtPricePerMenu.Text;
  
        }





        //Order List Grid
        void gridview()
        {
           MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from res_order", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvOrderList.Rows.Add();
                dgvOrderList.Rows[n].Cells[0].Value = item["order_id"].ToString();
                dgvOrderList.Rows[n].Cells[1].Value = item["Meal_name"].ToString();
                dgvOrderList.Rows[n].Cells[2].Value = item["price_per_unit"].ToString();
                dgvOrderList.Rows[n].Cells[3].Value = item["quantity"].ToString();

            }
            {

            }
        }

        private void dgvOrderList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
                int n = dgvOrderList.SelectedRows[0].Index;
                txtOrderID.Text = dgvOrderList.Rows[n].Cells[0].Value.ToString();
                txtOrderMealName.Text = dgvOrderList.Rows[n].Cells[1].Value.ToString();
                txtOrderPricePerMeal.Text = dgvOrderList.Rows[n].Cells[2].Value.ToString();
                txtOrderQuantity.Text = dgvOrderList.Rows[n].Cells[3].Value.ToString();
                
            
        }

        private void btnAddItem_Click(object sender, EventArgs e)/////////////////////Payment Add Items
        {
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO res_payment( `meal_id`, `order_id`, `meal_type`, `price`, `quantity`, `amount`, `total_amount`) VALUES ('" + txtMealID.Text + "','" + txtOrderID1.Text + "','" + cmbMealType.Text + "','" + txtPricePerUnit.Text + "','" + txtQuantity.Text + "','" + lblamount.Text + "','" + lblTotalAmount.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successful Added a payment");
                con.Close();

                dataGridView3.Rows.Add(txtMealID.Text, txtOrderID.Text, cmbMealType.Text, txtPricePerUnit.Text, txtQuantity.Text, lblamount.Text);
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

            try
            {

                price = Convert.ToDouble(txtPricePerUnit.Text);
                quantity = Convert.ToDouble(txtQuantity.Text);
                amount = price * quantity;
                lblamount.Text = amount.ToString();

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Fields can not be empty");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int n = dataGridView1.SelectedRows[0].Index;
            txtOrderID1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
            cmbMealType.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
            txtPricePerUnit.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
            txtQuantity.Text = dataGridView1.Rows[n].Cells[3].Value.ToString();
        }

        private void RestManagment_Load(object sender, EventArgs e)
        {

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ChangePassword.ChangePassword ch = new ChangePassword.ChangePassword(this.empID);
            ch.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin l = new frmLogin();
            l.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)//////////////////////////////////////////Payment clear button
        {

            cmbMealType.SelectedIndex = 0;
            lblTotalAmount.Text = "0";
            lblamount.Text = "0";
            txtOrderID1.Clear();
            txtPricePerUnit.Clear();
            txtQuantity.Clear();
            txtMealID.Clear();

            int rowIndex = dataGridView3.CurrentCell.RowIndex;
            dataGridView3.Rows.RemoveAt(rowIndex);
        }

        private void btnViewOrders_Click(object sender, EventArgs e)//////////////////////////////////Payment View Orders
        {

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from res_order", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["order_id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Meal_name"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["price_per_unit"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["quantity"].ToString();

            }
        }
        

        private void btnButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                total += Convert.ToDouble(dataGridView3.Rows[i].Cells["Amount4"].Value.ToString());
            }
            lblTotalAmount.Text = total.ToString();


            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `res_payment` SET `total_amount`='" + lblTotalAmount.Text + "' WHERE `meal_id` = '" + txtMealID.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            try
            {

                MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=projectmysql");
                conn.Open();
                MySqlCommand cmdd = new MySqlCommand("DELETE FROM `bar_order` WHERE order_id ='" + txtOrderID.Text + "' ", conn);
                cmdd.ExecuteNonQuery();

                con.Close();


                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);




            }
            catch (FormatException exr)
            {

            }


        }



        /*private void btnTimeCheckAvailability_Click(object sender, EventArgs e)
        {
            startdate = monthCalendar1.SelectedDate.Year + "-" + monthCalendar1.SelectedDate.Month + "-" + monthCalendar1.SelectedDate.Day + "" + comboBox1.Text;
            enddate = monthCalendar1.SelectedDate.Year + "-" + monthCalendar1.SelectedDate.Month + "-" + monthCalendar1.SelectedDate.Day + "" + comboBox2.Text;
            //respone .Write(startdate)
            findAvailableTable();
            comboBox3.Visible = true;
        }

        private void btnBookNow_Click(object sender, EventArgs e)
        {

        }*/


    }
}
