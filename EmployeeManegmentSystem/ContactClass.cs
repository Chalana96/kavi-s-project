﻿using EmployeeManegmentSystem;
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
        public String ContactNo { get; set; }
        public String Address { get; set; }
        public String Gender { get; set; }
        public String  DateOfBirth { get; set; }
  
        public String RoomType { get; set; }

        public int Room { get; set; } 
   

        public void InsertCustomer()
        {
             String q = "insert into Customers(FirstName,LastName,ContactNumber,Address,Gender,DateOfBirth,RoomType,Rooms) values ('" + FirstName + "','" + LastName + "','" + ContactNo + "','" + Address + "','" + Gender + "','" + this.DateOfBirth + "','" + RoomType + "','" + Room + "')";

            try
            {
                using (DBConnect db = new DBConnect())
                {

                   bool ok = db.insert(q);

                    if (ok)
                    {
                        MessageBox.Show("User inserted successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else
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
            String q = "update Customers set FirstName ='" + FirstName + "',LastName = '" + LastName + "' ,ContactNumber = '" + ContactNo + "' ,Address = '" + Address + "' ,Gender = '" + Gender + "',DateOfBirth = '" + this.DateOfBirth +  "',RoomType = '" + RoomType + "',Rooms = '" + Room + "' Where ContactID = '" + ContactID + "'";

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
            using (DBConnect db = new DBConnect()) { 
            String q = "select * from Customers where " + condition;
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    this.ContactID = Int32.Parse(r[0].ToString());
                    this.FirstName = r[1].ToString();
                    this.LastName  = r[2].ToString();
                    this.ContactNo = r[3].ToString();
                    this.Address   = r[4].ToString();
                    this.Gender    = r[5].ToString();
                    this.DateOfBirth = r[6].ToString();
                    this.RoomType    = r[7].ToString();
                     this.Room        = Int32.Parse(r[8].ToString());
                 
                }

                return this;


}


        }

        public void deleteCustomer()
         {


            String q = "delete from Customers Where ContactID = '" + ContactID + "'";

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
