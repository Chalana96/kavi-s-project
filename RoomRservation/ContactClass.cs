using MySql.Data.MySqlClient;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomRservation
{
    class ContactClass
    {

        public int ContactID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public String NIC { get; set; }
        public String ContactNo { get; set; }
        public String Address { get; set; }
        public String Gender { get; set; }
        public String checkin { get; set; }
        public String checkout { get; set; }
        public String adults { get; set; }
        public string children { get; set; }
        public String DeluxeRoom { get; set; }
        public String SuiteRoom { get; set; }
        public String StandardRoom { get; set; }

        // public String  DateOfBirth { get; set; }

      // RoomType { get; set; }

      //  public int Room { get; set; }


        public void InsertCustomer()
        {
            String q = "insert into customers(FirstName,LastName,NIC,ContactNumber,Address,Gender,checkin,checkout,adults,children,DeluxeRoom,SuiteRoom,StandardRoom) values ('" + FirstName + "','" + LastName + "','" + NIC + "','" + ContactNo + "','" + Address + "','" + Gender + "','" + this.checkin + "','" + this.checkout + "','" + adults + "','" + children + "','" + DeluxeRoom + "','" + SuiteRoom + "','" + StandardRoom + "')";

            try
            {
                using (DBConect db = new DBConect())
                {

                    bool ok = db.insert(q);

                    if (ok)
                    {
                        MessageBox.Show("User inserted successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("User insertion failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }


        }

        public void UpdateCustomer()
        {
            String q = "update customers set FirstName ='" + FirstName + "',LastName = '" + LastName + "', NIC = '" + NIC + "' ,ContactNumber = '" + ContactNo + "' , Address = '" + Address + "' , Gender = '" + Gender + "',checkin = '" + this.checkin + "',checkout = '" + this.checkout + "',adults = '" + adults + "',children = '" + children + "',DeluxeRoom = '" + DeluxeRoom + "',SuiteRoom = '" + SuiteRoom + "',StandardRoom = '" + StandardRoom + "' Where ContactID = '" + ContactID + "'";

            try
            {
                using (DBConect db = new DBConect())
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



                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            // throw new NotImplementedException();
        }
        public ContactClass Search(String condition)
        {
            using (DBConect db = new DBConect())
            {
                String q = "select * from Customers where " + condition;
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    this.ContactID = Int32.Parse(r[0].ToString());
                    this.FirstName = r[1].ToString();
                    this.LastName = r[2].ToString();
                    this.NIC = r[3].ToString();
                    this.ContactNo = r[4].ToString();
                    this.Address = r[5].ToString();
                    this.Gender = r[6].ToString();
                    this.checkin = r[7].ToString();
                    this.checkout = r[8].ToString();
                    this.adults = r[9].ToString();
                    this.children = r[10].ToString();
                    this.DeluxeRoom = r[11].ToString();
                    this.SuiteRoom = r[12].ToString();
                    this.StandardRoom = r[13].ToString();

                    //this.Room        = Int32.Parse(r[8].ToString());

                }

                return this;


            }


        }

        public void deleteCustomer()
        {


            String q = "delete from customers Where ContactID = '" + ContactID + "'";

            try
            {
                using (
                    DBConect db = new DBConect())
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
