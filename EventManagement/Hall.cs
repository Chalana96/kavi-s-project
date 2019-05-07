using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace EventManagement
{
    class Hall
    {

        public int HallId { get; set; }
        public String Name { get; set; }
        public String ContactNo { get; set; }
        public String Nic { get; set; }
        public String Address { get; set; }
        public String HallType { get; set; }
        public String HallDate { get; set; }
        public String HallCount { get; set; }
        //  public String Room { get; set; }
        /*public int Room { get; set; }

        String hall_Id;
        String name;
        String contactNo;
        String nic;
        String address;
        String hallType;
        String date;
        String count;

        public string HallID
        {
            get
            {
                return hall_Id;
            }

            set
            {
                hall_Id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string ContactNo
        {
            get
            {
                return contactNo;
            }

            set
            {
                contactNo = value;
            }
        }

        public string Nic
        {
            get
            {
                return nic;
            }

            set
            {
                nic = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string HallType
        {
            get
            {
                return hallType;
            }

            set
            {
                hallType = value;
            }
        }

        public string HallDate
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string HallCount
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }*/

        //public string Date { get; internal set; }

        /*public Hall Search(String condition)
        {
            using (DBConnect db = new DBConnect())
            {
                String q = "select * from Employee where " + condition;
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    this.HallID = r[0].ToString();
                    this.Name = r[1].ToString();
                    this.ContactNo = r[2].ToString();
                    this.Nic = r[3].ToString();
                    this.Address = r[4].ToString();
                    this.HallType = r[5].ToString();
                    this.HallDate = r[6].ToString();
                    this.HallCount = r[7].ToString();

                }

                return this;
            }
        }*/


        public void InsertHall()
        {
            String q = "INSERT INTO `customerhall`(`Name`, `ContactNo`, `Nic`, `Address`, `HallType`, `HallDate`, `HallCount`) VALUES ('" + Name + "','" + ContactNo + "','" + Nic + "','" + Address + "','" + HallType + "','" + HallDate + "','" + HallCount + "')";


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



        public Hall Search(String condition)
        {
            using (DBConnect db = new DBConnect())
            {
                String q = "select * from customerhall where " + condition;
      
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    this.HallId = Int32.Parse(r[0].ToString());
                    this.Name = r[1].ToString();
                    this.ContactNo = r[2].ToString();
                    this.Nic = r[3].ToString();
                    this.Address = r[4].ToString();
                    this.HallType = r[5].ToString();
                    this.HallDate = r[6].ToString();
                    this.HallCount = r[7].ToString();

                }

                return this;


            }

        }

        

        public void UpdateHall()
        {
            String q = "update customerhall set Name ='" + Name + "',ContactNo = '" + ContactNo + "' ,Nic = '" + Nic + "' ,Address = '" + Address + "' ,HallType = '" + HallType + "',HallDate = '" + this.HallDate + "',HallCount = '" + HallCount + "' Where HallId = '" + HallId + "'";


            try
            {
                using (DBConnect db = new DBConnect())
                {

                    bool ok = db.update(q);

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

        public void deleteHall()
        {


            String q = "delete from customerhall Where HallId = '" + HallId + "'";

            try
            {
                using (
                    DBConnect db = new DBConnect())
                {

                    bool ok = db.delete(q);

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

        

    }
}
