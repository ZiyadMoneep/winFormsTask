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
    public partial class MainPageForm : Form
    {
        public MainPageForm()
        {
            InitializeComponent();
            // Set form properties
            this.Text = "Main Page";
            this.Size = new Size(1426, 1335);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightBlue;

            InitializeSidePanel();
            InitializeMainContent();
        }

        #region Control Initialization
        private void InitializeSidePanel()
        {
            // Create and configure the side panel for navigation
            Panel sidePanel = new Panel
            {
                Size = new Size(200, this.ClientSize.Height),
                Dock = DockStyle.Left,
                BackColor = Color.Gray
            };

            // Create buttons for navigation
            Button btnSettings = new Button { Text = "Settings", Dock = DockStyle.Top, Height = 50 };
            Button btnLogout = new Button { Text = "Logout", Dock = DockStyle.Top, Height = 50 };

            // Add buttons to the side panel
            sidePanel.Controls.Add(btnLogout);
            sidePanel.Controls.Add(btnSettings);

            // Add side panel to the form
            this.Controls.Add(sidePanel);

            // Add event handlers for buttons
            btnSettings.Click += BtnSettings_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void InitializeMainContent()
        {
            // Create a label in the main content area (e.g., welcome message)
            Label lblWelcome = new Label
            {
                Text = "Welcome to the Main Page! \n \n Your Current Email: " + UserDataStore.CurrentUser.Email,
                Location = new Point(220, 50),
                AutoSize = true,
                Font = new Font("Arial", 16)
            };

            // Add the label to the form
            this.Controls.Add(lblWelcome);
        }
        #endregion

        #region Event Handlers
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            // Open Settings form
            SettingsForms settingsForm = new SettingsForms();
            settingsForm.Show();
            this.Hide();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            // Handle logout, show the LoginForm and close the current one
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
        #endregion
    }
}
