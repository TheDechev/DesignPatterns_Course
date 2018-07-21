using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            picture_smallPictureBox.LoadAsync(r_facebookIcon);
            FacebookWrapper.FacebookService.s_CollectionLimit = 200;
            FacebookWrapper.FacebookService.s_FbApiVersion = 2.8f;
        }

        User m_LoggedInUser;
        private readonly string r_facebookIcon = "http://icons.iconarchive.com/icons/fasticon/web-2/256/FaceBook-icon.png";

        private void loginAndInit()
        {
            LoginResult result = FacebookService.Login("980644158781216", "email");

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
                fetchUserInfo();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }

        private void fetchUserInfo()
        {
            picture_smallPictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            userNameLabel.Text = "Welcome " + m_LoggedInUser.FirstName + " " + m_LoggedInUser.LastName + "!";
            buttonSetStatus.Enabled = true;
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void buttonSetStatus_Click(object sender, EventArgs e)
        {
            Status postedStatus = m_LoggedInUser.PostStatus(textBoxStatus.Text);
            MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.Logout(null);
            picture_smallPictureBox.LoadAsync(r_facebookIcon);
            userNameLabel.Text = "";
            buttonSetStatus.Enabled = false;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }
    }
}
