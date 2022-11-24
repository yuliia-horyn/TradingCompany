using BLL.Interfaces;
using System;
using System.Windows.Forms;

namespace WinForms
{
    public partial class LoginForm : Form
    {

        protected readonly IAuthentication _auth;
        protected readonly IRegistered _reg;
        public LoginForm(IAuthentication auth, IRegistered reg)
        {
            InitializeComponent();
            _auth = auth;
            _reg = reg;
        }
        private void doLogin()
        {
            if (_auth.Login(tbLogin.Text, tbPassword.Text))
            {
                DialogResult = DialogResult.OK;
                Program.CurrentUserID = _auth.GetUserByLogin(tbLogin.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            doLogin();
        }
        private void tbLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tbPassword.Select();
            }
        }
        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                doLogin();
            }
        }
        private void buttonLoginCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
 
            SignUpForm form = new SignUpForm(_auth, _reg);
            form.Show();
        }

        private void linkLabelForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotForm form = new ForgotForm(_auth);
            form.Show();
        }
    }
}
