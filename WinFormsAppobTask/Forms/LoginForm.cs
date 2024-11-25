using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppobTask.Services;

namespace WinFormsAppobTask
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Login";
            this.Size = new Size(1426, 1335);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeControls();
        }

        #region Controls Setup
        private void InitializeControls()
        {
            // Create controls dynamically
            Label lblEmail = new Label
            {
                Text = "Email:",
                Location = new Point(200, 250),
                AutoSize = true,
                Font = new Font("Arial", 20)
            };
            TextBox txtEmail = new TextBox
            {
                Name = "txtEmail",
                Location = new Point(450, 250),
                Width = 800,
                Font = new Font("Arial", 18),
                Height = 50
            };

            Label lblPassword = new Label
            {
                Text = "Password:",
                Location = new Point(160, 300),
                AutoSize = true,
                Font = new Font("Arial", 20)
            };

            TextBox txtPassword = new TextBox
            {
                Name = "txtPassword",
                Location = new Point(450, 300),
                Width = 600,
                Height = 50,
                PasswordChar = '*',
                Font = new Font("Arial", 18)
            };

            Button btnLogin = new Button
            {
                Text = "Login",
                Location = new Point(560, 420),
                Width = 300,
                Height = 80,
                Font = new Font("Arial", 20)
            };
            btnLogin.Click += BtnLogin_Click;

            Button btnRegister = new Button
            {
                Text = "Register",
                Location = new Point(560, 520),
                Width = 300,
                Height = 80,
                Font = new Font("Arial", 20)
            };
            btnRegister.Click += BtnGoToRegister_Click;

            // Add controls to the form
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnRegister);
        }
        #endregion

        #region Event Handlers
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = this.Controls["txtEmail"].Text;
            string password = this.Controls["txtPassword"].Text;

            if (UserDataStore.IsUserValid(email, password))
            {
                MessageBox.Show("Login successful!");
                MainPageForm mainForm = new MainPageForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid credentials!");
            }
        }

        private void BtnGoToRegister_Click(object sender, EventArgs e)
        {
            // Hide current registration form and show login form
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }
        #endregion
    }
}
