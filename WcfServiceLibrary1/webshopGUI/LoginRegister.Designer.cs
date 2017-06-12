namespace webshopGUI
{
    partial class LoginRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.loginTab = new System.Windows.Forms.TabPage();
            this.loginButton = new System.Windows.Forms.Button();
            this.errorMessageLogin = new System.Windows.Forms.Label();
            this.passwordLoginText = new System.Windows.Forms.TextBox();
            this.usernameLoginText = new System.Windows.Forms.TextBox();
            this.passwordLoginLabel = new System.Windows.Forms.Label();
            this.usernameLoginLabel = new System.Windows.Forms.Label();
            this.registerTab = new System.Windows.Forms.TabPage();
            this.registerButton = new System.Windows.Forms.Button();
            this.errorMessageRegister = new System.Windows.Forms.Label();
            this.usernameRegisterText = new System.Windows.Forms.TextBox();
            this.usernameRegisterLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.loginTab.SuspendLayout();
            this.registerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.loginTab);
            this.tabControl1.Controls.Add(this.registerTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(409, 293);
            this.tabControl1.TabIndex = 0;
            // 
            // loginTab
            // 
            this.loginTab.Controls.Add(this.loginButton);
            this.loginTab.Controls.Add(this.errorMessageLogin);
            this.loginTab.Controls.Add(this.passwordLoginText);
            this.loginTab.Controls.Add(this.usernameLoginText);
            this.loginTab.Controls.Add(this.passwordLoginLabel);
            this.loginTab.Controls.Add(this.usernameLoginLabel);
            this.loginTab.Location = new System.Drawing.Point(4, 25);
            this.loginTab.Name = "loginTab";
            this.loginTab.Padding = new System.Windows.Forms.Padding(3);
            this.loginTab.Size = new System.Drawing.Size(401, 264);
            this.loginTab.TabIndex = 0;
            this.loginTab.Text = "Login";
            this.loginTab.UseVisualStyleBackColor = true;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(196, 169);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // errorMessageLogin
            // 
            this.errorMessageLogin.AutoSize = true;
            this.errorMessageLogin.Location = new System.Drawing.Point(101, 134);
            this.errorMessageLogin.Name = "errorMessageLogin";
            this.errorMessageLogin.Size = new System.Drawing.Size(0, 17);
            this.errorMessageLogin.TabIndex = 4;
            // 
            // passwordLoginText
            // 
            this.passwordLoginText.Location = new System.Drawing.Point(104, 64);
            this.passwordLoginText.Name = "passwordLoginText";
            this.passwordLoginText.PasswordChar = '*';
            this.passwordLoginText.Size = new System.Drawing.Size(167, 22);
            this.passwordLoginText.TabIndex = 3;
            // 
            // usernameLoginText
            // 
            this.usernameLoginText.Location = new System.Drawing.Point(104, 27);
            this.usernameLoginText.Name = "usernameLoginText";
            this.usernameLoginText.Size = new System.Drawing.Size(167, 22);
            this.usernameLoginText.TabIndex = 2;
            // 
            // passwordLoginLabel
            // 
            this.passwordLoginLabel.AutoSize = true;
            this.passwordLoginLabel.Location = new System.Drawing.Point(8, 64);
            this.passwordLoginLabel.Name = "passwordLoginLabel";
            this.passwordLoginLabel.Size = new System.Drawing.Size(69, 17);
            this.passwordLoginLabel.TabIndex = 1;
            this.passwordLoginLabel.Text = "Password";
            // 
            // usernameLoginLabel
            // 
            this.usernameLoginLabel.AutoSize = true;
            this.usernameLoginLabel.Location = new System.Drawing.Point(6, 27);
            this.usernameLoginLabel.Name = "usernameLoginLabel";
            this.usernameLoginLabel.Size = new System.Drawing.Size(73, 17);
            this.usernameLoginLabel.TabIndex = 0;
            this.usernameLoginLabel.Text = "Username";
            // 
            // registerTab
            // 
            this.registerTab.Controls.Add(this.registerButton);
            this.registerTab.Controls.Add(this.errorMessageRegister);
            this.registerTab.Controls.Add(this.usernameRegisterText);
            this.registerTab.Controls.Add(this.usernameRegisterLabel);
            this.registerTab.Location = new System.Drawing.Point(4, 25);
            this.registerTab.Name = "registerTab";
            this.registerTab.Padding = new System.Windows.Forms.Padding(3);
            this.registerTab.Size = new System.Drawing.Size(401, 264);
            this.registerTab.TabIndex = 1;
            this.registerTab.Text = "Register";
            this.registerTab.UseVisualStyleBackColor = true;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(188, 171);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(75, 23);
            this.registerButton.TabIndex = 3;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // errorMessageRegister
            // 
            this.errorMessageRegister.AutoSize = true;
            this.errorMessageRegister.Location = new System.Drawing.Point(101, 135);
            this.errorMessageRegister.Name = "errorMessageRegister";
            this.errorMessageRegister.Size = new System.Drawing.Size(0, 17);
            this.errorMessageRegister.TabIndex = 2;
            // 
            // usernameRegisterText
            // 
            this.usernameRegisterText.Location = new System.Drawing.Point(104, 27);
            this.usernameRegisterText.Name = "usernameRegisterText";
            this.usernameRegisterText.Size = new System.Drawing.Size(160, 22);
            this.usernameRegisterText.TabIndex = 1;
            // 
            // usernameRegisterLabel
            // 
            this.usernameRegisterLabel.AutoSize = true;
            this.usernameRegisterLabel.Location = new System.Drawing.Point(6, 27);
            this.usernameRegisterLabel.Name = "usernameRegisterLabel";
            this.usernameRegisterLabel.Size = new System.Drawing.Size(73, 17);
            this.usernameRegisterLabel.TabIndex = 0;
            this.usernameRegisterLabel.Text = "Username";
            // 
            // LoginRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 293);
            this.Controls.Add(this.tabControl1);
            this.Name = "LoginRegister";
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.LoginRegister_Load);
            this.tabControl1.ResumeLayout(false);
            this.loginTab.ResumeLayout(false);
            this.loginTab.PerformLayout();
            this.registerTab.ResumeLayout(false);
            this.registerTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage loginTab;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label errorMessageLogin;
        private System.Windows.Forms.TextBox passwordLoginText;
        private System.Windows.Forms.TextBox usernameLoginText;
        private System.Windows.Forms.Label passwordLoginLabel;
        private System.Windows.Forms.Label usernameLoginLabel;
        private System.Windows.Forms.TabPage registerTab;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label errorMessageRegister;
        private System.Windows.Forms.TextBox usernameRegisterText;
        private System.Windows.Forms.Label usernameRegisterLabel;
    }
}