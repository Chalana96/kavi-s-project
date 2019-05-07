using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManagement
{
    class Event
    {
        public int CustomerEId { get; set; }
        public String EName { get; set; }
        public String EContactNo { get; set; }
        public String ENic { get; set; }
        public String EAddress { get; set; }
        public String EStandards { get; set; }
        public String EType { get; set; }
        public String EDate { get; set; }
        public int ECount { get; set; }


        public Event Search(String condition)
        {
            using (DBConnect db = new DBConnect())
            {
                String q = "select * from customerevent where " + condition;

                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    this.CustomerEId = Int32.Parse(r[0].ToString());
                    this.EName = r[1].ToString();
                    this.EContactNo = r[2].ToString();
                    this.ENic = r[3].ToString();
                    this.EAddress = r[4].ToString();
                    this.EStandards = r[5].ToString();
                    this.EType = r[6].ToString();
                    this.EDate = r[7].ToString();
                    this.ECount = Int32.Parse(r[8].ToString());

                }

                return this;


            }

        }

        public void UpdateEvent()
        {
            String q = "update customerevent set EName ='" + EName + "',EContactNo = '" + EContactNo + "' ,ENic = '" + ENic + "' ,EAddress = '" + EAddress + "' ,EStandards = '" + EStandards + "' ,EType = '" + EType + "',EDate = '" + this.EDate + "',ECount = '" + ECount + "' Where CustomerEId = '" + CustomerEId + "'";


            try
            {
                using (DBConnect db = new DBConnect())
                {

                    bool ok = db.eupdate(q);

                    if (ok)
                    {
                        MessageBox.Show("User updated successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("User updation failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //    MySqlCommand cmd = new MySqlCommand(q, db.con);
                    //    cmd.ExecuteNonQuery();
                    //    MessageBox.Show("User updated successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            // throw new NotImplementedException();
        }

        public void deleteEvent()
        {


            String q = "delete from customerevent Where CustomerEId = '" + CustomerEId + "'";

            try
            {
                using (
                    DBConnect db = new DBConnect())
                {

                    bool ok = db.edelete(q);

                    if (ok)
                    {
                        MessageBox.Show("User Deleted successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("User deleted failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        public void InsertEvent()
        {
            String q = "INSERT INTO `customerevent`(`EName`, `EContactNo`, `ENic`, `EAddress`,`EStandards`, `EType`, `EDate`, `ECount`) VALUES ('" + EName + "','" + EContactNo + "','" + ENic + "','" + EAddress + "','" + EStandards + "','" + EType + "','" + EDate + "','" + ECount + "')";

            try
            {
                using (DBConnect db = new DBConnect())
                {

                    bool ok = db.einsert(q);

                    if (ok)
                    {
                        MessageBox.Show("User inserted successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("User insertion failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //SqlCommand cmd = new SqlCommand(q, db.con);
                    //cmd.ExecuteNonQuery();
                    //MessageBox.Show("User inserted successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //clearTexts();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
