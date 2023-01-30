using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Time_Clock.UI
{
    public partial class frmPasswordChange : Form
    {
        frmTimeClock parent;
        public frmPasswordChange(frmTimeClock Parent, string ID)
        {
            InitializeComponent();
            this.parent = Parent;
            lblID.Text = ID;
        }

        private string sendDetails(string ID, string oldPass, string newPass)
        {
            if (!parent.connect())  return "Connection Failed";
            string insert = "declare @Employee_Code int, @Answer varchar(100)\r\nselect @Employee_Code = (select Code from Employee where ID = @ID)\r\nif exists( select Employee.* from Employee inner join Passwords on Employee.Code = Passwords.Employee_Code where ID = @id and password = @oldPass)\r\nbegin\r\n\r\n\tif @newPass not in (select password from Passwords where Employee_Code = @Employee_Code)\r\n\t\tbegin\r\n\t\t\tupdate Passwords set is_active = 0 where Employee_Code = @Employee_Code\r\n\t\t\tinsert Passwords  (Employee_Code, password, Expiry, is_active) values (@Employee_Code, @newPass, GETDATE() + 180, 1) \r\n\t\t\tselect @Answer = 'The new password has been updated to '  +@newPass\r\n\t\t\t\r\n\t\tend\r\n\telse\r\n\t\tbegin\r\n\t\t\tselect @Answer = 'The password has already been used, please try again!'\r\n\t\tend\r\nend\r\nselect @Answer";
            SqlCommand command= new SqlCommand(insert, parent.connection);
            //adding parameters
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.Add("@oldPass", SqlDbType.VarChar, 10);
            command.Parameters["@oldPass"].Value = oldPass;
            command.Parameters.Add("@newPass", SqlDbType.VarChar, 10);
            command.Parameters["@newPass"].Value = newPass;
            string answer = command.ExecuteScalar().ToString();
            parent.connection.Close();
            return answer;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text != txtNewConfirm.Text || txtNewPass.Text == "")
            {
                MessageBox.Show("Error in new password, please try again");
                return;
            }
            MessageBox.Show(sendDetails(lblID.Text, txtOldPass.Text, txtNewPass.Text));
        }
    }
}
