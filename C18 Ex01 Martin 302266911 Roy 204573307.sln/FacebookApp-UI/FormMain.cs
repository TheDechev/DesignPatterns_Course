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

namespace FacebookApp_UI
{
    internal partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            picture_smallPictureBox.Image = Resource.EmptyPicture;
            FacebookWrapper.FacebookService.s_CollectionLimit = 200;
            FacebookWrapper.FacebookService.s_FbApiVersion = 2.8f;
        }

        private User m_LoggedInUser;
        private User m_SelectedFriend;

        protected override void OnLoad(EventArgs e)
        {
            this.formInit();
            base.OnLoad(e);
        }

        private void loginAndInit()
        {
            try
            {
                LoginResult result = FacebookService.Login("980644158781216", "email");

                if (!string.IsNullOrEmpty(result.AccessToken))
                {
                    m_LoggedInUser = result.LoggedInUser;
                    buttonLogin.Visible = false;
                    buttonLogin.Enabled = false;
                    buttonLogout.Visible = true;
                    buttonLogout.Enabled = true;
                    fetchUserInfo();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage);
                }
            }
            catch
            {
                MessageBox.Show("There was a problem with logging in! Try again.", "Log-in Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fetchUserInfo()
        {
            picture_smallPictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            userNameLabel.Text = "Welcome, " + m_LoggedInUser.FirstName + " " + m_LoggedInUser.LastName + "!";
            buttonSetStatus.Enabled = true;
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
            loadInfo();
        }

        private void buttonSetStatus_Click(object sender, EventArgs e)
        {
            try
            {
                Status postedStatus = m_LoggedInUser.PostStatus(textBoxStatus.Text);
                MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
            }
            catch (Exception)
            {
                MessageBox.Show("There is a problem with posting :(", "Post Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.Logout(null);
            picture_smallPictureBox.Image = Resource.EmptyPicture;
            userNameLabel.Text = string.Empty;
            buttonSetStatus.Enabled = false;
            buttonLogout.Visible = false;
            buttonLogout.Enabled = false;
            buttonLogin.Visible = true;
            buttonLogin.Enabled = true;
            listBoxCommonEvents.Enabled = false;
            listBoxCommonPages.Enabled = false;
        }

        private void loadInfo()
        {
            try
            {
                fetchFeaturesInfo();
            }
            catch
            {
                MessageBox.Show("Couldn't load info for user. Try manually fetching.", "Fetch Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonFetchInfo.Visible = true;
                buttonFetchInfo.Enabled = true;
            }
        }

        private void fetchFeaturesInfo()
        {
            foreach (User friend in m_LoggedInUser.Friends)
            {
                comboBoxFriends.Items.Add(friend);
                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }

            
        }

        private void formInit()
        {
            comboBoxFriends.SelectedIndexChanged += ComboBoxFriends_OnSelectedIndexChanged;
        }

        private void ComboBoxFriends_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_SelectedFriend = comboBoxFriends.SelectedItem as User;

            if(this.m_SelectedFriend != null)
            {
                CommonInfoHelper commonInfo = new CommonInfoHelper(this.m_LoggedInUser, this.m_SelectedFriend);
                listBoxCommonEvents.Enabled = true;
                listBoxCommonPages.Enabled = true;
                addCommonItemsToLists(commonInfo);
            }
        }

        private void addCommonItemsToLists(CommonInfoHelper i_CommonInfo)
        {


            foreach(Page currentPage in i_CommonInfo.LikedPages)
            {
                listBoxCommonPages.Items.Add(currentPage);
            }

            foreach (Event currentEvent in i_CommonInfo.AttendedEvents)
            {
                listBoxCommonEvents.Items.Add(currentEvent);
            }
        }
    }
}
