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
            if (usernameLoginText.Text == "" || passwordLoginText.Text == "")
            {
                errorMessageLogin.ForeColor = System.Drawing.Color.Red;
                errorMessageLogin.Text = "Please fill in a valid username or password.";
                return;
            }

            if (login.LogIn(usernameLoginText.Text, passwordLoginText.Text))
            {
                this.Hide();
                new Shop(usernameLoginText.Text).ShowDialog();
            }
            else
            {
                errorMessageLogin.ForeColor = System.Drawing.Color.Red;
                errorMessageLogin.Text = "Wrong username or password.";
            }


        }

        private void LoginRegister_Load(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if(usernameRegisterText.Text == "")
            {
                errorMessageRegister.ForeColor = System.Drawing.Color.Red;
                errorMessageRegister.Text = "Please fill in a valid username.";
                return;
            }
            errorMessageRegister.ForeColor = System.Drawing.Color.Green;
            errorMessageRegister.Text = register.RegisterUser(usernameRegisterText.Text);
        }
    }
}
