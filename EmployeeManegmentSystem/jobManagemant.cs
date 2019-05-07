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

namespace EmployeeManegmentSystem
{
    public partial class jobManagemant : Form
    {
        public jobManagemant()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (DBConnect db = new DBConnect())
            {
                String q = "INSERT INTO `salary`(`jobRole`, `basicSalary`, `hourlyRate`, `otRate`) VALUES ('" + txtJob.Text+"','"+txtsalary.Text+ "','" + txtHorlyRate.Text + "','" + txtOtRate.Text + "')";
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                cmd.ExecuteNonQuery();
                btnRefresh_Click(sender, e);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            using (DBConnect db = new DBConnect())
            {

                DataTable dt = new DataTable();
                String q = "select jobID as 'Job ID', jobRole as 'Job Role', basicSalary as 'Basic Salary',hourlyRate as 'Horly Rate',otRate as 'OT Rate' from salary";
                MySqlCommand ccmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = ccmd.ExecuteReader();
                dt.Load(r);

                dgvJob.DataSource = dt;
            }
        }

        private void jobManagemant_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void dgvJob_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtJob.Text = dgvJob.Rows[dgvJob.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
            txtsalary.Text = dgvJob.Rows[dgvJob.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
            txtHorlyRate.Text = dgvJob.Rows[dgvJob.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString();
            txtOtRate.Text = dgvJob.Rows[dgvJob.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString();


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHorlyRate.Clear();
            txtJob.Clear();
            txtOtRate.Clear();
            txtsalary.Clear();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (DBConnect db = new DBConnect())
            {

                DataTable dt = new DataTable();
                String q = "UPDATE `salary` SET `jobRole`='" + txtJob.Text + "',`basicSalary`='" + txtsalary.Text + "',`hourlyRate`=" + txtHorlyRate.Text + "',`otRate`='" + txtOtRate.Text + "' WHERE 1 ";

            }
        

    }
}
}
