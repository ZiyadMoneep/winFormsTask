using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsAppobTask.Services;

namespace WinFormsAppobTask
{
    public partial class SettingsForms : Form
    {
        #region Constructor

        public SettingsForms()
        {
            InitializeComponent();
            InitializeFormSettings();
            CheckUserLoginStatus();
            InitializeSidePanel();
            InitializeSettingsControls();
        }

        #endregion

        #region Form Initialization

        private void InitializeFormSettings()
        {
            this.Text = "Settings";
            this.Size = new Size(1426, 1335);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightBlue;
        }

        private void CheckUserLoginStatus()
        {
            if (UserDataStore.CurrentUser == null)
            {
                MessageBox.Show("Please log in first.");
                this.Close();

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        #endregion

        #region Side Panel Initialization

        private void InitializeSidePanel()
        {
            Panel sidePanel = new Panel
            {
                BackColor = Color.LightGray,
                Size = new Size(250, this.ClientSize.Height),
                Location = new Point(0, 0),
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom
            };

            Button btnBackToMain = new Button
            {
                Text = "Back to Main",
                Location = new Point(50, 100),
                Width = 150,
                Height = 50,
                Font = new Font("Arial", 16)
            };
            btnBackToMain.Click += BtnBackToMain_Click;

            sidePanel.Controls.Add(btnBackToMain);
            this.Controls.Add(sidePanel);
        }

        #endregion

        #region Settings Controls Initialization

        private void InitializeSettingsControls()
        {
            Font defaultFont = new Font("Arial", 16);

            Label lblCurrentEmail = new Label
            {
                Text = "Current Email: " + UserDataStore.CurrentUser.Email,
                Location = new Point(300, 100),
                AutoSize = true,
                Font = defaultFont
            };

            TextBox txtNewEmail = new TextBox
            {
                Name = "txtNewEmail",
                Location = new Point(300, 150),
                Width = 600,
                Font = defaultFont
            };

            Button btnUpdateEmail = new Button
            {
                Text = "Update Email",
                Location = new Point(300, 230),
                Width = 200,
                Height = 50,
                Font = defaultFont
            };
            btnUpdateEmail.Click += BtnUpdateEmail_Click;

            this.Controls.Add(lblCurrentEmail);
            this.Controls.Add(txtNewEmail);
            this.Controls.Add(btnUpdateEmail);
        }

        #endregion

        #region Button Event Handlers

        private void BtnUpdateEmail_Click(object sender, EventArgs e)
        {
            string newEmail = this.Controls["txtNewEmail"].Text;

            if (UserDataStore.UpdateEmail(newEmail))
            {
                MessageBox.Show("Email updated successfully!");
                UserDataStore.CurrentUser.Email = newEmail;

                MainPageForm mainPage = new MainPageForm();
                mainPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Email is already in use.");
            }
        }

        private void BtnBackToMain_Click(object sender, EventArgs e)
        {
            MainPageForm mainPage = new MainPageForm();
            mainPage.Show();
            this.Hide();
        }

        #endregion
    }
}
