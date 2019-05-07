using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManegmentSystem
{
    class Employee
    {
        String employeeID;
        String name;
        String nic;
        String dob;
        String address;
        String contactNo;
        String jobRole;
        byte[] image;
        String gender;
        String state;
        
    //Form details getters and Setters
        public string EmployeeID
        {
            get
            {
                return employeeID;
            }

            set
            {
                employeeID = value;
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

        public string Dob
        {
            get
            {
                return dob;
            }

            set
            {
                dob = value;
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

        public string JobRole
        {
            get
            {
                return jobRole;
            }

            set
            {
                jobRole = value;
            }
        }

        public byte[] Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        //Isert Employee Details 
        public void InsertEmployee()
        {
            String q = "INSERT INTO `employee`(`name`, `nic`, `dob`, `state`, `address`, `contactNo`, `jobRole`, `image`, `gender`) VALUES ('" + Name + "','" + Nic + "','" + Dob + "','" + State + "','" + Address + "','" + ContactNo + "','" + JobRole + "','" + Image + "','" + Gender + "')";
                           
            try
            {
                using (DBConnect db = new DBConnect())
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

        //Search Employee Details
        public Employee Search(String condition)
        {
            using (DBConnect db = new DBConnect())
            {
                String q = "select * from Employee where " + condition;
                MySqlCommand cmd = new MySqlCommand(q, db.con);
                MySqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    this.EmployeeID = r[0].ToString();
                    this.Name = r[1].ToString();
                    this.Nic = r[2].ToString();
                    this.Dob = r[3].ToString();
                    this.State = r[4].ToString();
                    this.Address = r[5].ToString();
                    this.ContactNo = r[6].ToString();
                    this.JobRole = r[7].ToString();

                }

                return this;
            }

        }

        //Delete Employee Row
        public void deleteEmployee()
        {
            String q = "delete from Employee WHERE employeeID = '" + EmployeeID + "'";
            try
            {
                using (DBConnect db = new DBConnect())
                {
                    bool ok = db.delete(q);

                    if (ok)
                    {
                        MessageBox.Show("User Deleted successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("User Delete failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            }

        //Update Employee details

        public void updateEmployee()
        {
            String q = "UPDATE `employee` SET `name`='" + Name + "',`nic`='" + Nic + "',`dob`='" + this.Dob + "',`state`='" + State + "',`address`='" + Address + "',`contactNo`='" + ContactNo + "',`jobRole`='" + JobRole + "',`image`='" + Image + "',`gender`='" + Gender + "' WHERE employeeID  = '" + EmployeeID + "'";

            try
            {
                using (DBConnect db = new DBConnect())
                {
                    bool ok = db.update(q);

                    if (ok)
                    {
                        MessageBox.Show("User Updated successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("User Updated failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
