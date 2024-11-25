using WinFormsAppobTask.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WinFormsAppobTask
{
    public partial class RegistrationForm : Form
    {
        private readonly RegistrationService _registrationService;

        public RegistrationForm()
        {
            InitializeComponent();
            _registrationService = new RegistrationService();
            ConfigureForm();
            AddControls();
        }

        #region Form Configuration
        private void ConfigureForm()
        {
            this.Text = "Registration Form";
            this.Size = new Size(1426, 1335);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion

        #region UI Elements Initialization
        private void AddControls()
        {
            // Name Label and TextBox
            Label lblName = CreateLabel("Name:", new Point(100, 150));
            TextBox NameTextBox = CreateTextBox("txtName", new Point(500, 150));

            // Email Label and TextBox
            Label lblEmail = CreateLabel("Email:", new Point(100, 250));
            TextBox EmailTextBox = CreateTextBox("txtEmail", new Point(500, 250));

            // Password Label and TextBox
            Label lblPassword = CreateLabel("Password:", new Point(100, 350));
            TextBox PasswordBox = CreatePasswordBox("txtPassword", new Point(500, 350));

            // Confirm Password Label and TextBox
            Label lblConfirmPassword = CreateLabel("Confirm Password:", new Point(100, 450));
            TextBox confPasswordBox = CreatePasswordBox("txtConfirmPassword", new Point(500, 450));

            // Register Button
            Button buttonRegister = CreateButton("Register", new Point(350, 650), new Size(200, 50));
            buttonRegister.Click += buttonRegister_Click;

            // Go to Login Button
            Button btnGoToLogin = CreateButton("Already have an account? Go to Login", new Point(350, 750), new Size(600, 50));
            btnGoToLogin.Click += BtnGoToLogin_Click;

            // Add controls to the form
            this.Controls.Add(lblName);
            this.Controls.Add(NameTextBox);
            this.Controls.Add(lblEmail);
            this.Controls.Add(EmailTextBox);
            this.Controls.Add(lblPassword);
            this.Controls.Add(PasswordBox);
            this.Controls.Add(lblConfirmPassword);
            this.Controls.Add(confPasswordBox);
            this.Controls.Add(buttonRegister);
            this.Controls.Add(btnGoToLogin);
        }
        #endregion

        #region Helper Methods
        private Label CreateLabel(string text, Point location)
        {
            return new Label
            {
                Text = text,
                Location = location,
                AutoSize = true,
                Font = new Font("Arial", 16)
            };
        }

        private TextBox CreateTextBox(string name, Point location)
        {
            return new TextBox
            {
                Name = name,
                Location = location,
                Width = 600,
                Font = new Font("Arial", 16)
            };
        }

        private TextBox CreatePasswordBox(string name, Point location)
        {
            return new TextBox
            {
                Name = name,
                Location = location,
                Width = 600,
                Font = new Font("Arial", 16),
                PasswordChar = '*'
            };
        }

        private Button CreateButton(string text, Point location, Size size)
        {
            return new Button
            {
                Text = text,
                Location = location,
                Width = size.Width,
                Height = size.Height,
                Font = new Font("Arial", 16)
            };
        }
        #endregion

   

        #region Event Handlers
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string name = this.Controls["txtName"].Text;
            string email = this.Controls["txtEmail"].Text;
            string password = this.Controls["txtPassword"].Text;
            string confirmPassword = this.Controls["txtConfirmPassword"].Text;

            var (success, message) = _registrationService.RegisterUser(name, email, password, confirmPassword);


            // Display message and handle result
            MessageBox.Show(message);
            if (success)
            {
                // Navigate to login form on successful registration
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
        

        private void BtnGoToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        #endregion
    }
}
