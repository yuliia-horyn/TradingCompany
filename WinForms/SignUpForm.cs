using BLL.Interfaces;
using System;
using System.Windows.Forms;

namespace WinForms
{
    public partial class SignUpForm : Form
    {
        protected readonly IAuthentication _auth;
        protected readonly IRegistered _reg;
        public SignUpForm(IAuthentication auth, IRegistered reg)
        {
            InitializeComponent();
            _auth = auth;
            _reg = reg;
        }
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            var registered = this._auth.Register(
                   tbFirstName.Text,
                   tbLastName.Text,
                   tbLogin.Text,
                   tbPassword.Text,
                   tbKeyword.Text,
                   checkBox1.Checked,
                   tbAddress.Text,
                   tbEmail.Text,
                   tbPhoneNumber.Text,
                   tbBankCard.Text              
               );
            if (registered)
            {
                MessageBox.Show("Registered successfully");
                Program.CurrentUserID = _auth.GetUserByLogin(tbLogin.Text);
                ShoesForm form2 = new ShoesForm(_reg);
                form2.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Error occured");
            }

        }
    }
}
