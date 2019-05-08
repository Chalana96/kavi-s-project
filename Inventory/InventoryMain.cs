using System;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventory
{
    public partial class InventoryMain : Form
    {
        public InventoryMain()
        {
            InitializeComponent();
            addFoodItemGridView();
            addOtherItemGridView();
            addSupplierDetailsGridView();
        }


        int indexRow;



        private void btnAddFood_Click(object sender, EventArgs e)
        {

            string itemNamePattern = "^[a-zA-Z][a-zA-Z\\s]+$";
            



            bool isItemNameValid = Regex.IsMatch(txtItemName.Text, itemNamePattern);
            


            if (txtItemName.Text == "" || txtPricePerUnit.Text == "")
            {
                MessageBox.Show("Please fill the field");
            }

            else if (!isItemNameValid)
            {
                MessageBox.Show("Please Enter valid Item Name");
            }
            

            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO fooditems(`itemNo`,`itemName`, `category`, `pricePerUnit`, `quantity`, `purchaseDate`, `expiryDate`) VALUES ('" + txtItemNo.Text + "','" + txtItemName.Text + "','" + cmbCategory.Text + "','" + txtPricePerUnit.Text + "','" + txtQty.Text + "','" + dtpPurchaseDate.Value.ToShortDateString() + "','" + dtpExpiryDate.Value.ToShortDateString() + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted");
                con.Close();

            }
            

            dgvFoodItems.Rows.Add(txtItemNo.Text, txtItemName.Text, cmbCategory.Text, txtPricePerUnit.Text, txtQty.Text, dtpPurchaseDate.Value.ToShortDateString(), dtpExpiryDate.Value.ToShortDateString());

        }




        private void txtItemNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvFoodItems.CurrentCell.RowIndex;
            dgvFoodItems.Rows.RemoveAt(rowIndex);

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `fooditems` WHERE itemNo='" + txtItemNo.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");

           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string itemNamePattern = "^[a-zA-Z][a-zA-Z\\s]+$";




            bool isItemNameValid = Regex.IsMatch(txtItemName.Text, itemNamePattern);



            if (txtItemName.Text == "" || txtPricePerUnit.Text == "")
            {
                MessageBox.Show("Please fill the field");
            }

            else if (!isItemNameValid)
            {
                MessageBox.Show("Please Enter valid Item Name");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE `fooditems` SET `itemNo`='" + txtItemNo.Text + "',`itemName`='" + txtItemName.Text + "',`category`='" + cmbCategory.Text + "',`pricePerUnit`='" + txtPricePerUnit.Text + "',`quantity`='" + txtQty.Text + "',`purchaseDate`='" + dtpPurchaseDate.Value.ToShortDateString() + "',`expiryDate`='" + dtpExpiryDate.Value.ToShortDateString() + "' WHERE itemNo = '" + txtItemNo.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated");
                con.Close();

                int indexRow = dgvFoodItems.CurrentCell.RowIndex;
                dgvFoodItems.Rows[indexRow].Cells[0].Value = txtItemNo.Text;
                dgvFoodItems.Rows[indexRow].Cells[1].Value = txtItemName.Text;
                dgvFoodItems.Rows[indexRow].Cells[2].Value = cmbCategory.Text;
                dgvFoodItems.Rows[indexRow].Cells[3].Value = txtPricePerUnit.Text;
                dgvFoodItems.Rows[indexRow].Cells[4].Value = txtQty.Text;
               
            }
        }
        

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtItemNo.Clear();
            txtItemName.Clear();
            txtPricePerUnit.Clear();
            txtQty.Clear();
            cmbCategory.SelectedIndex = 0;

        }

        void addFoodItemGridView()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM fooditems", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvFoodItems.Rows.Add();
                dgvFoodItems.Rows[n].Cells[0].Value = item["itemNo"].ToString();
                dgvFoodItems.Rows[n].Cells[1].Value = item["itemName"].ToString();
                dgvFoodItems.Rows[n].Cells[2].Value = item["category"].ToString();
                dgvFoodItems.Rows[n].Cells[3].Value = item["pricePerUnit"].ToString();
                dgvFoodItems.Rows[n].Cells[4].Value = item["quantity"].ToString();
                dgvFoodItems.Rows[n].Cells[5].Value = item["purchaseDate"].ToString();
                dgvFoodItems.Rows[n].Cells[6].Value = item["expiryDate"].ToString();

            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvFoodItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvFoodItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)

            dgvFoodItems.CurrentRow.Selected = true;

            txtItemNo.Text = dgvFoodItems.Rows[e.RowIndex].Cells["itemNo"].FormattedValue.ToString();
            txtItemName.Text = dgvFoodItems.Rows[e.RowIndex].Cells["itemName"].FormattedValue.ToString();
            cmbCategory.Text = dgvFoodItems.Rows[e.RowIndex].Cells["category"].FormattedValue.ToString();
            txtPricePerUnit.Text = dgvFoodItems.Rows[e.RowIndex].Cells["pricePerUnit"].FormattedValue.ToString();
            txtQty.Text = dgvFoodItems.Rows[e.RowIndex].Cells["quantity"].FormattedValue.ToString();
            dtpPurchaseDate.Text = dgvFoodItems.Rows[e.RowIndex].Cells["purchaseDate"].FormattedValue.ToString();
            dtpExpiryDate.Text = dgvFoodItems.Rows[e.RowIndex].Cells["expiryDate"].FormattedValue.ToString();

        }

        //------------------pnlMain------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void btnFoodItem_Click(object sender, EventArgs e)
        {
            pnlFoodItem.BringToFront();
        }

        private void btnMainHome_Click(object sender, EventArgs e)
        {
            pnlMain.BringToFront();
        }

        private void btnOtherItems_Click(object sender, EventArgs e)
        {
            pnlOtherItems.BringToFront();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            pnlSuppliers.BringToFront();
        }

        private void btnPurchasedItem_Click(object sender, EventArgs e)
        {
            pnlPurchasedItems.BringToFront();
        }








        private void btnMainAddFoodItem_Click(object sender, EventArgs e)
        {
            pnlAddFoodItems.BringToFront();
        }

        private void btnMainAddOtherItems_Click(object sender, EventArgs e)
        {
            pnlAddOtherItem.BringToFront();
        }

        private void btnMainAddSupplier_Click(object sender, EventArgs e)
        {
            pnlAddSupplier.BringToFront();
        }

        private void btnMainFoodStock_Click(object sender, EventArgs e)
        {
            pnlFoodStock.BringToFront();

            //dgvAddOtherItems.Rows.Add(txtOtherItemNo.Text, txtOtherItemName.Text, cmbOtherItemCategory.Text, txtOtherItemPricePerUnit.Text, txtOtherItemQty.Text, dtpOtherItemPurchaseDate.Value.ToShortDateString(), dtpOtherItemExpiryDate.Value.ToShortDateString());

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM fooditems", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvFoodItemStock.Rows.Add();
                dgvFoodItemStock.Rows[n].Cells[0].Value = item["itemNo"].ToString();
                dgvFoodItemStock.Rows[n].Cells[1].Value = item["itemName"].ToString();
                dgvFoodItemStock.Rows[n].Cells[2].Value = item["category"].ToString();
                dgvFoodItemStock.Rows[n].Cells[3].Value = item["pricePerUnit"].ToString();
                dgvFoodItemStock.Rows[n].Cells[4].Value = item["quantity"].ToString();
                dgvFoodItemStock.Rows[n].Cells[5].Value = item["purchaseDate"].ToString();
                dgvFoodItemStock.Rows[n].Cells[6].Value = item["expiryDate"].ToString();

                //dgvAddOtherItems.Rows.Add(txtOtherItemNo.Text, txtOtherItemName.Text, cmbOtherItemCategory.Text, txtOtherItemPricePerUnit.Text, txtOtherItemQty.Text, dtpOtherItemPurchaseDate.Value.ToShortDateString(), dtpOtherItemExpiryDate.Value.ToShortDateString());

            }
        }

        private void btnMainOtherItemStock_Click(object sender, EventArgs e)
        {
            pnlOtherItemStock.BringToFront();

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM otheritems", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvOtherItemsStock.Rows.Add();
                dgvOtherItemsStock.Rows[n].Cells[0].Value = item["itemNo"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[1].Value = item["itemName"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[2].Value = item["category"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[3].Value = item["pricePerUnit"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[4].Value = item["quantity"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[5].Value = item["purchaseDate"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[6].Value = item["expiryDate"].ToString();


            }
        }

        private void btnMainSupplierDetails_Click(object sender, EventArgs e)
        {
            pnlSupplierDetails.BringToFront();

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM suppliers", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvSupplierDetails2.Rows.Add();
                dgvSupplierDetails2.Rows[n].Cells[0].Value = item["supplierId"].ToString();
                dgvSupplierDetails2.Rows[n].Cells[1].Value = item["supplierName"].ToString();
                dgvSupplierDetails2.Rows[n].Cells[2].Value = item["contactNo"].ToString();
                dgvSupplierDetails2.Rows[n].Cells[3].Value = item["email"].ToString();
                dgvSupplierDetails2.Rows[n].Cells[4].Value = item["address"].ToString();

            }
        }

            private void btnMainFoodItemAvailable_Click(object sender, EventArgs e)
        {

        }

        private void btnMainOtherItemAvailable_Click(object sender, EventArgs e)
        {

        }

        private void btnMainPurchasedItemManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {

        }







        //-------pnlFoodItem-------------------------------------------------------------------------------------------------------------------------------

        private void btnAddFoodItem_Click(object sender, EventArgs e)
        {
            pnlAddFoodItems.BringToFront();
        }

        private void btnFoodStock_Click(object sender, EventArgs e)
        {
            pnlFoodStock.BringToFront();

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM fooditems", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvFoodItemStock.Rows.Add();
                dgvFoodItemStock.Rows[n].Cells[0].Value = item["itemNo"].ToString();
                dgvFoodItemStock.Rows[n].Cells[1].Value = item["itemName"].ToString();
                dgvFoodItemStock.Rows[n].Cells[2].Value = item["category"].ToString();
                dgvFoodItemStock.Rows[n].Cells[3].Value = item["pricePerUnit"].ToString();
                dgvFoodItemStock.Rows[n].Cells[4].Value = item["quantity"].ToString();
                dgvFoodItemStock.Rows[n].Cells[5].Value = item["purchaseDate"].ToString();
                dgvFoodItemStock.Rows[n].Cells[6].Value = item["expiryDate"].ToString();

                //dgvAddOtherItems.Rows.Add(txtOtherItemNo.Text, txtOtherItemName.Text, cmbOtherItemCategory.Text, txtOtherItemPricePerUnit.Text, txtOtherItemQty.Text, dtpOtherItemPurchaseDate.Value.ToShortDateString(), dtpOtherItemExpiryDate.Value.ToShortDateString());

            }
        }

        private void btnFoodAvailability_Click(object sender, EventArgs e)
        {

        }



        //--------pnlOtherItems------------------------------------------------------------------------------------------------------------------------------------------------------

        private void btnAddOtherItem_Click(object sender, EventArgs e)
        {
            pnlAddOtherItem.BringToFront();
        }

        private void btnOtherItemStock_Click(object sender, EventArgs e)
        {
            pnlOtherItemStock.BringToFront();

            pnlOtherItemStock.BringToFront();

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM otheritems", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvOtherItemsStock.Rows.Add();
                dgvOtherItemsStock.Rows[n].Cells[0].Value = item["itemNo"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[1].Value = item["itemName"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[2].Value = item["category"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[3].Value = item["pricePerUnit"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[4].Value = item["quantity"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[5].Value = item["purchaseDate"].ToString();
                dgvOtherItemsStock.Rows[n].Cells[6].Value = item["expiryDate"].ToString();


            }
        }

        private void btnOtherItemAvailability_Click(object sender, EventArgs e)
        {

        }

        //-----------pnlSuppliers----------------------------------------------------------------------------------------------------------------------------

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            pnlAddSupplier.BringToFront();
        }

        private void btnSupplierDetails_Click(object sender, EventArgs e)
        {
            pnlSupplierDetails.BringToFront();
        }

        // -------------pnlPurchasedItems-------------------------------------------------------------------------------------------------------------------------------

        private void btnAddPurchasedItems_Click(object sender, EventArgs e)
        {
            pnlAddPurchasedItem.BringToFront();
        }

        private void btnPurchaseItemsDetails_Click(object sender, EventArgs e)
        {
            pnlPurchasedItemsDetails.BringToFront();
        }

        private void btnReturnPurchasedItems_Click(object sender, EventArgs e)
        {
            pnlReturnPurchasedItems.BringToFront();
        }



        //-----------pnlAddOtherItems----------------------------------------------------------------------------------------------------------------------------------

        private void btnOtherItemAdd_Click(object sender, EventArgs e)
        {
            string OtherItemNamePattern = "^[a-zA-Z][a-zA-Z\\s]+$";




            bool isOtherItemNameValid = Regex.IsMatch(txtOtherItemName.Text, OtherItemNamePattern);



            if (txtOtherItemName.Text == "" || txtOtherItemNo.Text == "" || txtOtherItemPricePerUnit.Text == "" || txtOtherItemQty.Text == "")
            {
                MessageBox.Show("Please fill the field");
            }

            else if (!isOtherItemNameValid)
            {
                MessageBox.Show("Please Enter valid Item Name");
            }


            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO otheritems(`itemNo`,`itemName`, `category`, `pricePerUnit`, `quantity`, `purchaseDate`, `expiryDate`) VALUES ('" + txtOtherItemNo.Text + "','" + txtOtherItemName.Text + "','" + cmbOtherItemCategory.Text + "','" + txtOtherItemPricePerUnit.Text + "','" + txtOtherItemQty.Text + "','" + dtpOtherItemPurchaseDate.Value.ToShortDateString() + "','" + dtpOtherItemExpiryDate.Value.ToShortDateString() + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted");
                con.Close();



                dgvAddOtherItems.Rows.Add(txtOtherItemNo.Text, txtOtherItemName.Text, cmbOtherItemCategory.Text, txtOtherItemPricePerUnit.Text, txtOtherItemQty.Text, dtpOtherItemPurchaseDate.Value.ToShortDateString(), dtpOtherItemExpiryDate.Value.ToShortDateString());

            }

        }

        private void btnOtherItemUpdate_Click(object sender, EventArgs e)
        {
            string OtherItemNamePattern = "^[a-zA-Z][a-zA-Z\\s]+$";




            bool isOtherItemNameValid = Regex.IsMatch(txtOtherItemName.Text, OtherItemNamePattern);



            if (txtOtherItemName.Text == "" || txtOtherItemNo.Text == "" || txtOtherItemPricePerUnit.Text == "" || txtOtherItemQty.Text == "")
            {
                MessageBox.Show("Please fill the field");
            }

            else if (!isOtherItemNameValid)
            {
                MessageBox.Show("Please Enter valid Item Name");
            }


            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE `otheritems` SET `itemNo`='" + txtOtherItemNo.Text + "',`itemName`='" + txtOtherItemName.Text + "',`category`='" + cmbOtherItemCategory.Text + "',`pricePerUnit`='" + txtOtherItemPricePerUnit.Text + "',`quantity`='" + txtOtherItemQty.Text + "',`purchaseDate`='" + dtpOtherItemPurchaseDate.Value.ToShortDateString() + "',`expiryDate`='" + dtpOtherItemExpiryDate.Value.ToShortDateString() + "' WHERE itemNo = '" + txtOtherItemNo.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated");
                con.Close();

                int indexRow = dgvAddOtherItems.CurrentCell.RowIndex;
                dgvAddOtherItems.Rows[indexRow].Cells[0].Value = txtOtherItemNo.Text;
                dgvAddOtherItems.Rows[indexRow].Cells[1].Value = txtOtherItemName.Text;
                dgvAddOtherItems.Rows[indexRow].Cells[2].Value = cmbOtherItemCategory.Text;
                dgvAddOtherItems.Rows[indexRow].Cells[3].Value = txtOtherItemPricePerUnit.Text;
                dgvAddOtherItems.Rows[indexRow].Cells[4].Value = txtOtherItemQty.Text;
            }
        }

        private void btnOtherItemDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvAddOtherItems.CurrentCell.RowIndex;
            dgvAddOtherItems.Rows.RemoveAt(rowIndex);

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `otheritems` WHERE itemNo='" + txtOtherItemNo.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");

            
        }

        private void btnOtherItemClear_Click(object sender, EventArgs e)
        {
            txtOtherItemNo.Clear();
            txtOtherItemName.Clear();
            txtOtherItemPricePerUnit.Clear();
            txtOtherItemQty.Clear();
            cmbOtherItemCategory.SelectedIndex = 0;


        }

        void addOtherItemGridView()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM otheritems", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvAddOtherItems.Rows.Add();
                dgvAddOtherItems.Rows[n].Cells[0].Value = item["itemNo"].ToString();
                dgvAddOtherItems.Rows[n].Cells[1].Value = item["itemName"].ToString();
                dgvAddOtherItems.Rows[n].Cells[2].Value = item["category"].ToString();
                dgvAddOtherItems.Rows[n].Cells[3].Value = item["pricePerUnit"].ToString();
                dgvAddOtherItems.Rows[n].Cells[4].Value = item["quantity"].ToString();
                dgvAddOtherItems.Rows[n].Cells[5].Value = item["purchaseDate"].ToString();
                dgvAddOtherItems.Rows[n].Cells[6].Value = item["expiryDate"].ToString();

            }
        }

        private void dgvAddOtherItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAddOtherItems.CurrentRow.Selected = true;

            txtOtherItemNo.Text = dgvAddOtherItems.Rows[e.RowIndex].Cells["itemNo"].FormattedValue.ToString();
            txtOtherItemName.Text = dgvAddOtherItems.Rows[e.RowIndex].Cells["itemName"].FormattedValue.ToString();
            cmbOtherItemCategory.Text = dgvAddOtherItems.Rows[e.RowIndex].Cells["category"].FormattedValue.ToString();
            txtOtherItemPricePerUnit.Text = dgvAddOtherItems.Rows[e.RowIndex].Cells["pricePerUnit"].FormattedValue.ToString();
            txtOtherItemQty.Text = dgvAddOtherItems.Rows[e.RowIndex].Cells["quantity"].FormattedValue.ToString();
            dtpOtherItemPurchaseDate.Text = dgvAddOtherItems.Rows[e.RowIndex].Cells["purchaseDate"].FormattedValue.ToString();
            dtpOtherItemExpiryDate.Text = dgvAddOtherItems.Rows[e.RowIndex].Cells["expiryDate"].FormattedValue.ToString();
        }



        //----------pnlAddSuppliers---------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void btnAddSupplierDetails_Click(object sender, EventArgs e)
        {
            string supplierNamePattern = "^[a-zA-Z][a-zA-Z\\s]+$";
            string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            string contactNoPattern = "[0-9]{10}";



            bool isSupplierNameValid = Regex.IsMatch(txtSupplierName.Text, supplierNamePattern);
            bool isContactNoValid = Regex.IsMatch(txtContactNo.Text, contactNoPattern);
            bool isEmailValid = Regex.IsMatch(txtEmail.Text, emailPattern);



            if (txtSupplierId.Text == "" || txtSupplierName.Text == "" || txtContactNo.Text == "" || txtEmail.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Please fill the field");
            }

            else if (!isSupplierNameValid)
            {
                MessageBox.Show("Please Enter valid Supplier Name");
            }
            else if (!isContactNoValid)
            {
                MessageBox.Show("Please Enter valid Contact No");
            }
            else if (!isEmailValid)
            {
                MessageBox.Show("Please Enter valid e-mail");
            }



            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO suppliers(`supplierId`,`supplierName`, `contactNo`, `email`, `address`) VALUES ('" + txtSupplierId.Text + "','" + txtSupplierName.Text + "','" + txtContactNo.Text + "','" + txtEmail.Text + "','" + txtAddress.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted");
                con.Close();



                dgvSupplierDetails.Rows.Add(txtSupplierId.Text, txtSupplierName.Text, txtContactNo.Text, txtEmail.Text, txtAddress.Text);


            }


        }

        private void btnSupplierDetailsUpdate_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `suppliers` SET `supplierId`='" + txtSupplierId.Text + "',`supplierName`='" + txtSupplierName.Text + "',`contactNo`='" + txtContactNo.Text + "',`email`='" + txtEmail.Text + "',`address`='" + txtAddress.Text + "' WHERE supplierId = '" + txtSupplierId.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            con.Close();
        }

        private void btnSupplierDetailsDelete_Click(object sender, EventArgs e)
        {

            int rowIndex = dgvSupplierDetails.CurrentCell.RowIndex;
            dgvSupplierDetails.Rows.RemoveAt(rowIndex);

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `suppliers` WHERE supplierId='" + txtSupplierId.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");

            
        }

        private void btnSupplierDetailsClear_Click(object sender, EventArgs e)
        {
            txtSupplierId.Clear();
            txtSupplierName.Clear();
            txtContactNo.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
        }

        void addSupplierDetailsGridView()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM suppliers", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dgvSupplierDetails.Rows.Add();
                dgvSupplierDetails.Rows[n].Cells[0].Value = item["supplierId"].ToString();
                dgvSupplierDetails.Rows[n].Cells[1].Value = item["supplierName"].ToString();
                dgvSupplierDetails.Rows[n].Cells[2].Value = item["contactNo"].ToString();
                dgvSupplierDetails.Rows[n].Cells[3].Value = item["email"].ToString();
                dgvSupplierDetails.Rows[n].Cells[4].Value = item["address"].ToString();
                

            }
        }

        private void dgvSupplierDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSupplierDetails.CurrentRow.Selected = true;

            txtSupplierId.Text = dgvSupplierDetails.Rows[e.RowIndex].Cells["supplierId"].FormattedValue.ToString();
            txtSupplierName.Text = dgvSupplierDetails.Rows[e.RowIndex].Cells["supplierName"].FormattedValue.ToString();
            txtContactNo.Text = dgvSupplierDetails.Rows[e.RowIndex].Cells["contactNo"].FormattedValue.ToString();
            txtEmail.Text = dgvSupplierDetails.Rows[e.RowIndex].Cells["email"].FormattedValue.ToString();
            txtAddress.Text = dgvSupplierDetails.Rows[e.RowIndex].Cells["address"].FormattedValue.ToString();
            
        }

        //-----------pnlAddPurchasedItem------------------------------------------------------------------------------------------------------------------------------------------------

        private void btnAddPurchasedItem_Click(object sender, EventArgs e)
        {
            string PurchasedItemNamePattern = "^[a-zA-Z][a-zA-Z\\s]+$";




            bool isPurchasedItemNameValid = Regex.IsMatch(txtPurchasedItemName.Text, PurchasedItemNamePattern);



            if (txtPurchasedItemName.Text == "" || txtPurchasedSupplierId.Text == "" || txtPurchasedItemNo.Text == "" || txtPurchasedPricePerUnit.Text == "" || txtPurchasedQuantity.Text == "" || txtPurchasedSupplierId.Text == "" || dtpPurchaseDate.Text == "") 
            {
                MessageBox.Show("Please fill the field");
            }

            else if (!isPurchasedItemNameValid)
            {
                MessageBox.Show("Please Enter valid Item Name");
            }


            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=hotel;SslMode=none");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO purchaseditems(`purchasedId`,`itemNo`, `itemName`, `pricePerUnit`, `quantity`, `supplierId`, `purchasedDate`) VALUES ('" + txtOtherItemNo.Text + "','" + txtOtherItemName.Text + "','" + cmbOtherItemCategory.Text + "','" + txtOtherItemPricePerUnit.Text + "','" + txtOtherItemQty.Text + "','" + dtpOtherItemPurchaseDate.Value.ToShortDateString() + "','" + dtpOtherItemExpiryDate.Value.ToShortDateString() + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted");
                con.Close();



                dgvPurchasedItems.Rows.Add(txtPurchasedId.Text, txtPurchasedItemNo.Text, txtPurchasedItemName.Text, txtPurchasedPricePerUnit.Text, txtPurchasedQuantity.Text, txtPurchasedSupplierId.Text, dtpPurchaseDate.Value.ToShortDateString());

            }
        }

        private void btnUpdatepurchasedItem_Click(object sender, EventArgs e)
        {

        }

        private void btnDeletePurchasedItem_Click(object sender, EventArgs e)
        {

        }

        private void btnClearPurchasedItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}


