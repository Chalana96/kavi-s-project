using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManagement
{
    /*class DbHallOperation
    {
        /*public static bool insertHall(Hall hl)
        {
            try
            {
                using (DBConnect db = new DBConnect())
                {
                    String q = "INSERT INTO `customerhall`(`name`, `contactNo`, `nic`, `address`, `hallType`, `date`, `count`) VALUES ('" + hl.Name + "','" + hl.ContactNo + "','" + hl.Nic + "','" + hl.Address + "','" + hl.HallType + "','" + hl.HallDate + "','" + hl.HallCount + "')";
                    MySqlCommand cmd = new MySqlCommand(q, db.con);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }*/

        



        /*public void UpdateHall()
        {
            //String q = "INSERT INTO `customerhall`(`name`, `contactNo`, `nic`, `address`, `hallType`, `date`, `count`) VALUES ('" + h.Name + "','" + h.ContactNo + "','" + h.Nic + "','" + h.Address + "','" + h.HallType + "','" + h.HallDate + "','" + h.HallCount + "')";
            String q = "update customerhall set Name ='" + Name + "',LastName = '" + LastName + "' ,ContactNumber = '" + ContactNo + "' ,Address = '" + Address + "' ,Gender = '" + Gender + "',DateOfBirth = '" + this.DateOfBirth + "',RoomType = '" + RoomType + "',Rooms = '" + Room + "' Where ContactID = '" + ContactID + "'";


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

        
    }*/
}
