using BLL.Interfaces;
using System;
using System.Windows.Forms;

namespace WinForms
{
    public partial class ForgotForm : Form
    {
        protected readonly IAuthentication _auth;
        protected readonly IRegistered _reg;
        public ForgotForm(IAuthentication auth)
        {
            InitializeComponent(); 
            _auth = auth;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            var result = _auth.ResetPassword(
               tbLogin.Text,
               tbKeyword.Text,
               tbNewPassword.Text
               );

            if (result)
            {
                MessageBox.Show("Password Reset successfully");
                this.Close();             
                
            }
            else
            {
                MessageBox.Show("Error occured");
            }
        }
    }
}
