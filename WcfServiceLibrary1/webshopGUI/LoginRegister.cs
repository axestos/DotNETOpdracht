using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceLibrary1;

namespace webshopGUI
{
    public partial class LoginRegister : Form
    {
        ILogInService login = new LogInService();
        IRegisterService register = new RegisterService();
        public LoginRegister()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameLoginText.Text.Trim() == "" || passwordLoginText.Text.Trim() == "")
            {
                errorMessageLogin.ForeColor = Color.Red;
                errorMessageLogin.Text = "Please fill in a valid username or password.";
                return;
            }

            if (login.LogIn(usernameLoginText.Text, passwordLoginText.Text))
            {
                Shop shop = new Shop(usernameLoginText.Text);
                this.Hide();
                this.Owner = shop;
                shop.ShowDialog();
            }
            else
            {
                errorMessageLogin.ForeColor = Color.Red;
                errorMessageLogin.Text = "Wrong username or password.";
            }


        }

        private void LoginRegister_Load(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if(usernameRegisterText.Text.Trim() == "")
            {
                errorMessageRegister.ForeColor = Color.Red;
                errorMessageRegister.Text = "Please fill in a valid username.";
                return;
            }

            string password = register.RegisterUser(usernameRegisterText.Text);
            if (password == "")
            {
                errorMessageRegister.ForeColor = Color.Red;
                errorMessageRegister.Text = "This username is already taken.";
                return;
            }
            else if (password != "")
            {
                errorMessageRegister.ForeColor = Color.Green;
                errorMessageRegister.Text = "User: "+ usernameRegisterText.Text + "    Your password: "+password;
            }
        }
    }
}
