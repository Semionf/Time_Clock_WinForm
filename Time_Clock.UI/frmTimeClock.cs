using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time_Clock.UI
{
    public partial class frmTimeClock : Form
    {
        string connectionString = "data source=MSI\\SQLEXPRESS; initial catalog=EventGuests;Integrated Security=SSPI;";
        public SqlConnection connection;
        public frmTimeClock()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }
        public bool checkID(string ID)
        {

            return true;
        }
        private string sendDetails(string ID, string password)
        {
            if(!connect())
            {
                return "Connection failed";
            }
            //all the SQL commands
            string insert = "declare  @employee_code int,\r\n@answer varchar(100)\r\n\r\nselect @employee_code=(select Code from Employee where ID=@ID)\r\nif @employee_code is null\r\n\r\nbegin\r\n\tselect @answer = 'Incorect ID or Password, 2 attempts left'\r\nend\r\n\r\nelse\r\nbegin\r\nif not exists( select Code from Passwords where password=@password and\r\nis_active=1\r\nand Employee_Code=@employee_code)\r\n\r\nbegin\r\nselect @answer = 'Incorect ID or Password, 1 attempts left'\r\nend\r\n\r\nelse\r\nbegin\r\nif not exists( select Code from Passwords where password=@password and\r\nis_active=1\r\nand Employee_Code=@employee_code and Expiry>getdate())\r\n\r\nbegin\r\nselect @answer = 'The password exiperd, please change password'\r\nend\r\n\r\nelse\r\nbegin\r\nif not exists (select * from Times where\r\nEmployee_Code=@employee_code\r\nand Exit_Time is null)\r\n\r\nbegin\r\ninsert into Times values(@employee_code,getdate(),null)\r\nselect @answer='Entry time' + CONVERT(varchar(20),getdate(),103)\r\n+ ' '+CONVERT(varchar(20),getdate(),108)\r\nend\r\nelse\r\n\r\nbegin\r\nupdate Times set Exit_Time =getdate() where\r\nEmployee_Code=@employee_code\r\nand Exit_Time is null\r\nselect @answer='Exit Time ' + CONVERT(varchar(20),getdate(),103)\r\n+ ' '+CONVERT(varchar(20),getdate(),108)\r\nend\r\nend\r\nend\r\nend\r\nselect @answer";
            //creation of the execution object, adding the sql command and connection
            SqlCommand command = new SqlCommand(insert, connection);
            //adding parameters
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.Add("@password", SqlDbType.VarChar, 10);
            command.Parameters["@password"].Value = password;
            string answer = command.ExecuteScalar().ToString();
            connection.Close();
            return answer;
        }
        public bool connect()
        {
            
            try
            {
                connection.Open();
               // MessageBox.Show("Connected successfully");
                return true;
            }
            catch (SqlException ex)
            {
               // MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(txtID.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                MessageBox.Show("There's no employee ID or Password");
                return;
            }
            else
            {
                MessageBox.Show("Enter");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            if(ID == string.Empty)
            {
                 ID =  Microsoft.VisualBasic.Interaction.InputBox("Please enter ID","Password Change");
            }
            frmPasswordChange password = new frmPasswordChange(this,ID);
            password.Show();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtID.Text.Length == 0 || txtPassword.Text.Length == 0)
                {
                    MessageBox.Show("There's no employee ID or Password");
                    return;
                }
                else
                {
                    MessageBox.Show(sendDetails(txtID.Text, txtPassword.Text).ToString());
                }
            }
           
        }
    }
}
