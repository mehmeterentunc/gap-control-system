using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GAPtest_Desktop.Services;
using GAPtest_Desktop.Models;
using System.Net;

namespace GAPtest_Desktop
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString);

        UserRoleService userRoleService = new UserRoleService();
        UserChangePasswordService userChangePaswordService = new UserChangePasswordService();
        LogErrorService logErrorService = new LogErrorService();

        private int wrongAttempts = 0; //VARIABLE FOR WRONG INPUT
        private void btnLogin_Click(object sender, EventArgs e) //LOGIN
        {
            try
            {
                List<string> emptyFields = new List<string>();

                if (string.IsNullOrEmpty(txtUsername.Text))
                    emptyFields.Add("USERNAME");

                if (string.IsNullOrEmpty(txtPassword.Text))
                    emptyFields.Add("PASSWORD");

                if (emptyFields.Count > 0)
                {
                    string fields = string.Join(", ", emptyFields);
                    MessageBox.Show(fields + " Cannot be empty");
                    return;
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_KullaniciGiris", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pw", txtPassword.Text);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    Users userWithRole = userRoleService.GetUserRole(txtUsername.Text);                   
                    
                    if (userWithRole != null)
                    {
                        FormGCS formGCS = new FormGCS(userWithRole);
                        formGCS.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("username or password not correct.");
                    }
                }
                else
                {
                    wrongAttempts++;
                    MessageBox.Show("Username or password not correct. Wrong attempts:" + wrongAttempts);
                    if (wrongAttempts==3)
                    {
                        Users user = new Users();
                        user.username = txtUsername.Text;
                        userChangePaswordService.PassiveUser(user);
                        FormChangePassword formChangePassword = new FormChangePassword();   
                        formChangePassword.Show();
                        wrongAttempts = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "LOGIN " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
            finally
            {
                conn.Close();
            }
        }
        private void btnChangePassword_Click(object sender, EventArgs e) //CHANGE PASSWORD
        {
            FormChangePassword formChangePassword = new FormChangePassword();
            formChangePassword.Show();
        }
    }
 }

