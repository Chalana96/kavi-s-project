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

namespace Finance
{
   

    public partial class FormFinance : Form
    {

        String EmpId;
        public FormFinance(String empID)
        {
            this.EmpId = empID;
            InitializeComponent();
            gridView();
            gridViewBar();
            gridViewEmployee();
        }

        int RowIndex;
        double totalAccommodation = 0, totalBar = 0;

        private void btnMainIn_Click(object sender, EventArgs e)
        {
            panelIncome.BringToFront();
        }

        private void btnpnlin_Click(object sender, EventArgs e)
        {
            panelIncome.BringToFront();
        }

        private void inDeptAccom_Click(object sender, EventArgs e)
        {
            pnlInAcc.BringToFront();
        }

        private void inDeptBar_Click(object sender, EventArgs e)
        {
            pnlInBar.BringToFront();
        }

        private void eventBtnSave_Click(object sender, EventArgs e)
        {
            gridEventView.Rows.Add(eventID.Text, eventBillDate.Value.ToShortDateString(), eventBillAmt.Text);
        }

        private void inDeptEvent_Click(object sender, EventArgs e)
        {
            pnlInEvent.BringToFront();
        }

        private void orderBtnSave_Click(object sender, EventArgs e)
        {
            gridOrderView.Rows.Add(orderID.Text, orderDte.Value.ToShortDateString(), orderAmt.Text);
        }

        private void inDeptRest_Click(object sender, EventArgs e)
        {
            pnlInKitchen.BringToFront();
        }
        
        private void exDeptEmp_Click(object sender, EventArgs e)
        {
            pnlExEmployee.BringToFront();
        }

        private void exDeptInven_Click(object sender, EventArgs e)
        {
            pnlExInventory.BringToFront();
        }
 
        private void btnpnlex_Click(object sender, EventArgs e)
        {
            panelExpenses.BringToFront();
        }

        private void btnMainEx_Click(object sender, EventArgs e)
        {
            panelExpenses.BringToFront();
        }

        private void btnFHome_Click(object sender, EventArgs e)
        {
            pnlFinanceMain.BringToFront();
        }





        //--------------------------------Accommodation Department Operations-------------------------------------

        private void inAccSave_Click(object sender, EventArgs e)
        {
            if (inCustID.Text == "" || inRoomID.Text == "" || inCustAmt.Text == "")
            {
                MessageBox.Show("Please Fill all the fields.");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `accommodation`(`aCusID`, `aRoomID`, `aCheckIn`, `aCheckOut`, `aBillAmount`) VALUES ('" + inCustID.Text + "', '" + inRoomID.Text + "', '" + checkInDte.Value.ToShortDateString() + "', '" + checkOutDte.Value.ToShortDateString() + "', '" + inCustAmt.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Added");
                con.Close();
                gridInAccView.Rows.Add(inCustID.Text, inRoomID.Text, checkInDte.Value.ToShortDateString(), checkOutDte.Value.ToShortDateString(), inCustAmt.Text);
            }
        }

        private void inAccClear_Click(object sender, EventArgs e)
        {
            inCustID.Clear();
            inRoomID.Clear();
            inCustAmt.Clear();
            lblTotalAmt.Update();
        }

        private void inAccDelete_Click(object sender, EventArgs e)
        {
            int RowIndex = gridInAccView.CurrentCell.RowIndex;
            gridInAccView.Rows.RemoveAt(RowIndex);

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `accommodation` WHERE aCusID = '" + inCustID.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("successfully deleted");
            con.Close();
        }

        private void inAccUpdate_Click(object sender, EventArgs e)
        {
            if (inCustID.Text == "" || inRoomID.Text == "" || inCustAmt.Text == "")
            {
                MessageBox.Show("Please Fill all the fields.");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE `accommodation` SET `aCusID`= '" + inCustID.Text + "',`aRoomID`= '" + inRoomID.Text + "',`aCheckIn`= '" + checkInDte.Value.ToShortDateString() + "',`aCheckOut`= '" + checkOutDte.Value.ToShortDateString() + "',`aBillAmount`= '" + inCustAmt.Text + "' WHERE aCusID = '" + inCustID.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated");
                con.Close();

                int indexRow = gridInAccView.CurrentCell.RowIndex;
                gridInAccView.Rows[indexRow].Cells[0].Value = inCustID.Text;
                gridInAccView.Rows[indexRow].Cells[1].Value = inRoomID.Text;
                gridInAccView.Rows[indexRow].Cells[2].Value = checkInDte.Value.ToShortDateString();
                gridInAccView.Rows[indexRow].Cells[3].Value = checkOutDte.Value.ToShortDateString();
                gridInAccView.Rows[indexRow].Cells[4].Value = inCustAmt.Text;
            }
            
        }

        void gridView()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from accommodation", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = gridInAccView.Rows.Add();
                gridInAccView.Rows[n].Cells[0].Value = item["aCusID"].ToString();
                gridInAccView.Rows[n].Cells[1].Value = item["aRoomID"].ToString();
                gridInAccView.Rows[n].Cells[2].Value = item["aCheckIn"].ToString();
                gridInAccView.Rows[n].Cells[3].Value = item["aCheckOut"].ToString();
                gridInAccView.Rows[n].Cells[4].Value = item["aBillAmount"].ToString();
            }
        }

        private void gridInAccView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int n = gridInAccView.SelectedRows[0].Index;
            inCustID.Text = gridInAccView.Rows[n].Cells[0].Value.ToString();
            inRoomID.Text = gridInAccView.Rows[n].Cells[1].Value.ToString();
            checkInDte.Text = gridInAccView.Rows[n].Cells[2].Value.ToString();
            checkOutDte.Text = gridInAccView.Rows[n].Cells[3].Value.ToString();
            inCustAmt.Text = gridInAccView.Rows[n].Cells[4].Value.ToString();
        }

        private void totalAcc_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridInAccView.Rows.Count; i++)
            {
                totalAccommodation += Convert.ToDouble(gridInAccView.Rows[i].Cells["BillAmount"].Value.ToString());
                lblTotalAmt.Text = totalAccommodation.ToString();
            }
        }






        //--------------------------------Bar Facilities Department Operations-------------------------------------

        private void bBtnSave_Click(object sender, EventArgs e)
        {
            if (bCustID.Text == "" || bBillAmt.Text == "")
            {
                MessageBox.Show("Please Fill all the fields.");
            }
            else {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `bar`(`b_cusID`, `b_billDate`, `b_billAmount`) VALUES ('" + bCustID.Text + "', '" + bBillDte.Value.ToShortDateString() + "', '" + bBillAmt.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successful");
                con.Close();
                gridBarView.Rows.Add(bCustID.Text, bBillDte.Value.ToShortDateString(), bBillAmt.Text);
            }
        }

        private void bBtnClear_Click(object sender, EventArgs e)
        {
            bCustID.Clear();
            bBillAmt.Clear();
         }

        private void bBtnUpdate_Click(object sender, EventArgs e)
        {
            if (bCustID.Text == "" || bBillAmt.Text == "")
            {
                MessageBox.Show("Please Fill all the fields.");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE `bar` SET `b_cusID`= '" + bCustID.Text + "',`b_billDate`= '" + bBillDte.Value.ToShortDateString() + "',`b_billAmount`= '" + bBillAmt.Text + "' WHERE b_cusID = '" + bCustID.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated");
                con.Close();

                int indexRow = gridBarView.CurrentCell.RowIndex;
                gridBarView.Rows[indexRow].Cells[0].Value = bCustID.Text;
                gridBarView.Rows[indexRow].Cells[1].Value = bBillDte.Value.ToShortDateString();
                gridBarView.Rows[indexRow].Cells[2].Value = bBillAmt.Text;
             }
        }

        private void bBtnDelete_Click(object sender, EventArgs e)
        {
            int RowIndex = gridBarView.CurrentCell.RowIndex;
            gridBarView.Rows.RemoveAt(RowIndex);

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root; database=saultresort");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `bar` WHERE b_cusID = '"+bCustID.Text+"'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("successfully deleted");
            con.Close();
        }

        void gridViewBar()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from bar", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = gridBarView.Rows.Add();
                gridBarView.Rows[n].Cells[0].Value = item["b_cusID"].ToString();
                gridBarView.Rows[n].Cells[1].Value = item["b_billDate"].ToString();
                gridBarView.Rows[n].Cells[2].Value = item["b_billAmount"].ToString();
            }
        }

        private void gridBarView_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            int n = gridBarView.SelectedRows[0].Index;
            bCustID.Text = gridBarView.Rows[n].Cells[0].Value.ToString();
            bBillDte.Text = gridBarView.Rows[n].Cells[1].Value.ToString();
            bBillAmt.Text = gridBarView.Rows[n].Cells[2].Value.ToString();

        }

        private void btnTotalBar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridBarView.Rows.Count; i++)
            {
                totalBar += Convert.ToDouble(gridBarView.Rows[i].Cells["barBillAmt"].Value.ToString());
                lblTotBar.Text = totalBar.ToString();
            }
        }








        //--------------------------------Employee Department Operations-------------------------------------

        private void empBtnSave_Click(object sender, EventArgs e)
        {
            if (empID.Text == "" || empTotSal.Text == "")
            {
                MessageBox.Show("Please Fill all the fields.");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `employeeFiance`(`emp_ID`, `emp_slryStrtDte`, `emp_slryEndDte`, `emp_totSlry`) VALUES ('" + empID.Text + "', '" + empSlryStrtDte.Value.ToShortDateString() + "', '" + empSlryEndDte.Value.ToShortDateString() + "', '" + empTotSal.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved");
                con.Close();
                gridEmployeeView.Rows.Add(empID.Text, empSlryStrtDte.Value.ToShortDateString(), empSlryEndDte.Value.ToShortDateString(), empTotSal.Text);
            }
        }

        private void empBtnUpdate_Click(object sender, EventArgs e)
        {
            if (empID.Text == "" || empTotSal.Text == "")
            {
                MessageBox.Show("Please Fill all the fields.");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE `employeeFiance` SET `emp_ID`= '" + empID.Text + "',`emp_slryStrtDte`= '" + empSlryStrtDte.Value.ToShortDateString() + "',`emp_slryEndDte`= '" + empSlryEndDte.Value.ToShortDateString() + "',`emp_totSlry`= '" + empTotSal.Text + "' WHERE emp_ID = '" + empID.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated");
                con.Close();
                int indexRow = gridEmployeeView.CurrentCell.RowIndex;
                gridEmployeeView.Rows[indexRow].Cells[0].Value = empID.Text;
                gridEmployeeView.Rows[indexRow].Cells[1].Value = empSlryStrtDte.Value.ToShortDateString();
                gridEmployeeView.Rows[indexRow].Cells[2].Value = empSlryEndDte.Value.ToShortDateString();
                gridEmployeeView.Rows[indexRow].Cells[3].Value = empTotSal.Text;
            }
        }

        private void empBtnDelete_Click(object sender, EventArgs e)
        {
            int RowIndex = gridEmployeeView.CurrentCell.RowIndex;
            gridEmployeeView.Rows.RemoveAt(RowIndex);

            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `employeeFiance` WHERE emp_ID = '" + empID.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("successfully deleted");
            con.Close();
        }

        private void empBtnClear_Click(object sender, EventArgs e)
        {
            empID.Clear();
            empTotSal.Clear();
        }

        void gridViewEmployee()
        {
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=saultresort");
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("select * from employeeFiance", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = gridEmployeeView.Rows.Add();
                gridEmployeeView.Rows[n].Cells[0].Value = item["emp_ID"].ToString();
                gridEmployeeView.Rows[n].Cells[1].Value = item["emp_slryStrtDte"].ToString();
                gridEmployeeView.Rows[n].Cells[2].Value = item["emp_slryEndDte"].ToString();
                gridEmployeeView.Rows[n].Cells[3].Value = item["emp_totSlry"].ToString();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ChangePassword.ChangePassword ch = new ChangePassword.ChangePassword(this.EmpId);
            ch.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }

        private void gridEmployeeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int n = gridEmployeeView.SelectedRows[0].Index;
            empID.Text = gridEmployeeView.Rows[n].Cells[0].Value.ToString();
            empSlryStrtDte.Text = gridEmployeeView.Rows[n].Cells[1].Value.ToString();
            empSlryEndDte.Text = gridEmployeeView.Rows[n].Cells[2].Value.ToString();
            empTotSal.Text = gridEmployeeView.Rows[n].Cells[3].Value.ToString();
        }

    }

}
