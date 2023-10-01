using GAPtest_Desktop.Models;
using GAPtest_Desktop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAPtest_Desktop
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        UserChangePasswordService userChangePasswordService = new UserChangePasswordService();
        LogErrorService logErrorService = new LogErrorService();
        private void btnSave_Click(object sender, EventArgs e) //SAVE NEW PASSWORD
        {
            try          
             {
                List<string> emptyFields = new List<string>();

                if (string.IsNullOrEmpty(txtChangeUsername.Text))
                    emptyFields.Add("USERNAME");

                if (string.IsNullOrEmpty(txtChangePassword.Text))
                    emptyFields.Add("PASSWORD");

                if (string.IsNullOrEmpty(txtQuestionChange.Text))
                    emptyFields.Add("QUESTION");

                if (emptyFields.Count > 0)
                {
                    string fields = string.Join(", ", emptyFields);
                    MessageBox.Show(fields + " Cannot be empty");
                    return;
                }


                Users user = new Users();               
                user.username = txtChangeUsername.Text;
                user.pw = txtChangePassword.Text;               
                user.Question = txtQuestionChange.Text;
                bool result = userChangePasswordService.ChangeUserPassword(user);
                if (result==true)
                {
                    user.username = txtChangeUsername.Text;
                    userChangePasswordService.ActiveUser(user);
                    MessageBox.Show("Your password has been successfully changed");                   
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The username or the question you specified is incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Change PASSWORD " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
        }
    }
}
