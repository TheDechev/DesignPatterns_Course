using System;
using System.Xml;
using System.Windows.Forms;
using System.Diagnostics;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace FacebookApp
{
    internal partial class AppForm : Form
    {
        private readonly AppLogic r_AppLogic = new AppLogic();
        private FacebookObjectCollection<User> m_FilteredFriends;

        public AppForm()
        {
            InitializeComponent();
            r_AppLogic.AppSettings = AppSettings.LoadFromFile();
            StartPosition = FormStartPosition.Manual;
            Location = this.r_AppLogic.AppSettings.LastWindowLocation;
            checkBoxRememberMe.Checked = this.r_AppLogic.AppSettings.RememberUser;
            FacebookService.s_CollectionLimit = 200;
            FacebookService.s_FbApiVersion = 2.8f;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (this.r_AppLogic.AppSettings.RememberUser && !string.IsNullOrEmpty(this.r_AppLogic.AppSettings.LastAccessToken))
            {
                this.r_AppLogic.Connect(this.r_AppLogic.AppSettings.LastAccessToken);
                this.r_AppLogic.m_LoginStatus = eLoginStatus.LoggedIn;
                this.r_AppLogic.LoggedUser = this.r_AppLogic.LoginResult.LoggedInUser;
                if (this.r_AppLogic.LoggedUser != null)
                {
                    this.pictureBoxProfile.LoadAsync(this.r_AppLogic.LoggedUser.PictureLargeURL);
                    loginAndInit();
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (this.checkBoxRememberMe.Checked && this.buttonLogout.Visible == true)
            {
                this.updateAppSettings();
            }
            else
            {
                if (r_AppLogic.m_LoginStatus == eLoginStatus.LoggedIn)
                {
                    this.r_AppLogic.AppSettings.deleteFile();
                }
            }
        }

        private void updateAppSettings()
        {
            this.r_AppLogic.AppSettings.LastWindowLocation = this.Location;
            this.r_AppLogic.AppSettings.RememberUser = this.checkBoxRememberMe.Checked;
            if (this.r_AppLogic.LoggedUser != null)
            {
                this.r_AppLogic.AppSettings.LastAccessToken = this.r_AppLogic.AppSettings.RememberUser
                                                                  ? this.r_AppLogic.LoginResult.AccessToken
                                                                  : null;
            }

            this.r_AppLogic.AppSettings.SaveToFile();
        }

        private void loginAndInit()
        {
            try
            {
                if (this.r_AppLogic.Login())
                {
                    buttonLogin.Visible = false;
                    buttonLogin.Enabled = false;
                    buttonLogout.Visible = true;
                    buttonLogout.Enabled = true;
                    fetchUserInfo();
                    loadCityAdvisorInfo();
                }
            }
            catch
            {
                MessageBox.Show("There was a problem with logging in! Try again.", "Log-in Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fetchUserInfo()
        {
            pictureBoxProfile.LoadAsync(r_AppLogic.LoggedUser.PictureNormalURL);
            userNameLabel.Text = "Welcome, " + r_AppLogic.LoggedUser.FirstName + " " + r_AppLogic.LoggedUser.LastName + "!";
            buttonPostStatus.Enabled = true;
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;
        }

        private void buttonPostStatus_Click(object sender, EventArgs e)
        {
            try
            {
                Status postedStatus = r_AppLogic.LoggedUser.PostStatus(textBoxStatus.Text);
                MessageBox.Show("Status Posted! ID: " + postedStatus.Id);
            }
            catch (Exception)
            {
                MessageBox.Show("There is a problem with posting :(", "Post Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.Logout(null);
            pictureBoxProfile.Image = Resource.EmptyPicture;
            userNameLabel.Text = string.Empty;
            buttonPostStatus.Enabled = false;
            buttonLogout.Visible = false;
            buttonLogout.Enabled = false;
            buttonLogin.Visible = true;
            buttonLogin.Enabled = true;
            listBoxFilteredFriends.Enabled = false;
        }

        // ===================== ====================== ====================== 
        // ======================== First Feature Code =======================
        // ===================== ====================== ====================== 
        private void loadCityAdvisorInfo()
        {
            try
            {
                foreach (User friend in r_AppLogic.LoggedUser.Friends)
                {
                    if (friend.Location != null)
                    {
                        fetchCityAdvisorFeatureInfo(friend.Location.Name);
                    }

                    friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
                }

                if (r_AppLogic.LoggedUser != null)
                {
                    fetchCityAdvisorFeatureInfo(r_AppLogic.LoggedUser.Location.Name);
                }
            }
            catch
            {
                MessageBox.Show("Couldn't load firends' cities. Try re-logging to fix it..", "Fetch Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void fetchCityAdvisorFeatureInfo(string i_FriendCity)
        {
            if (!comboBoxCity.Items.Contains(i_FriendCity))
            {
                comboBoxCity.Items.Add(i_FriendCity);
            }
        }

        private void ComboBoxCity_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = comboBoxCity.SelectedItem as string;
            listBoxFriendsFromSelectedCity.Items.Clear();
            listBoxCityWeather.Items.Clear();
            pictureBoxCityFriend.Image = Resource.EmptyPicture;
            if (selectedCity != null)
            {
                // Add all friends that live in selectedCity to friends list box:
                foreach (User friend in r_AppLogic.LoggedUser.Friends)
                {
                    if (friend.Location != null && friend.Location.Name.Equals(selectedCity))
                    {
                        listBoxFriendsFromSelectedCity.Items.Add(friend);
                    }
                }

                if (this.r_AppLogic.LoggedUser.Location != null && this.r_AppLogic.LoggedUser.Location.Name.Equals(selectedCity))
                {
                    listBoxFriendsFromSelectedCity.Items.Add(this.r_AppLogic.LoggedUser);
                }

                // Add city information to weather list box:
                try
                {
                    if (selectedCity.Contains(", Israel"))
                    {
                        selectedCity = selectedCity.Replace(", Israel", string.Empty);
                    }

                    fetchCityInfoToListBox(selectedCity);
                }
                catch (Exception)
                {
                    MessageBox.Show("City information is missing :(");
                }
            }
        }

        private void fetchCityInfoToListBox(string i_SelectedCity)
        {
            r_AppLogic.CityAdvisor.fetchXML(i_SelectedCity);
            fetchCityNameToListBox(i_SelectedCity);
            fetchCurrentTemperatureToListBox();
            fetchHumidityPercentageToListBox();
            fetchSunTimesToListBox();
            fetchWikipediaLinkToListBox(i_SelectedCity);
            this.listBoxFriendsFromSelectedCity.Enabled = true;
            this.listBoxCityWeather.Enabled = true;
        }

        private void fetchCityNameToListBox(string selectedCity)
        {
            string cityNameString = "City Name: " + selectedCity;
            listBoxCityWeather.Items.Add(cityNameString);
        }

        private void fetchCurrentTemperatureToListBox()
        {
            string temperatureStr = r_AppLogic.CityAdvisor.fetchTemperatureString();
            listBoxCityWeather.Items.Add(temperatureStr);
        }

        private void fetchHumidityPercentageToListBox()
        {
            string humidityString = r_AppLogic.CityAdvisor.fetchHumidityString();
            listBoxCityWeather.Items.Add(humidityString);
        }

        private void fetchSunTimesToListBox()
        {
            string sunriseTime = r_AppLogic.CityAdvisor.fetchSunriseTime();
            listBoxCityWeather.Items.Add(sunriseTime);
            string sunsetTime = r_AppLogic.CityAdvisor.fetchSunsetTime();
            listBoxCityWeather.Items.Add(sunsetTime);
        }

        private void fetchWikipediaLinkToListBox(string selectedCity)
        {
            linkCityWikipedia.Links.Clear();
            LinkLabel.Link wiki = new LinkLabel.Link();
            string linkByCity = "https://en.wikipedia.org/wiki/" + selectedCity;
            wiki.LinkData = linkByCity;
            linkCityWikipedia.Links.Add(wiki);
            linkCityWikipedia.Enabled = true;
        }

        private void linkCityWikipedia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void listBoxFriendsFromSelectedCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedUser = listBoxFriendsFromSelectedCity.SelectedItem as User;
            if (selectedUser != null)
            {
                pictureBoxCityFriend.LoadAsync(selectedUser.PictureNormalURL);
            }
        }

        // ===================== ====================== ====================== 
        // ======================= Second Feature Code =======================
        // ===================== ====================== ====================== 
        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            addFriendsByGender(User.eGender.male);
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            addFriendsByGender(User.eGender.female);
        }
        
        private void radioButtonLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLanguage.Checked == false)
            {
                comboBoxCommonLanguage.Enabled = false;
            }
            else
            {
                if (this.r_AppLogic.LoggedUser.Languages != null)
                {
                    comboBoxCommonLanguage.Enabled = true;
                    comboBoxCommonLanguage.Items.Clear();
                    foreach (Page page in this.r_AppLogic.LoggedUser.Languages)
                    {
                        comboBoxCommonLanguage.Items.Add(page.Name);
                    }
                }
            }
        }

        private void radioButtonYears_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonYears.Checked == false)
            {
                numericUpDownYearsRange.Enabled = false;
                buttonCheckYear.Enabled = false;
            }
            else
            {
                numericUpDownYearsRange.Enabled = true;
                buttonCheckYear.Enabled = true;
            }
        }

        private void radioButtonSameMonth_CheckedChanged(object sender, EventArgs e)
        {
            listBoxFilteredFriends.Items.Clear();
            this.m_FilteredFriends = this.r_AppLogic.FriendsFilter.filterBySameBirthMonth();
            DisplayOnEmptyList(string.Format("Nobody from your friendlist is born on this day :)", Environment.NewLine));
        }

        private void comboBoxCommonLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxFilteredFriends.Items.Clear();
            this.m_FilteredFriends = this.r_AppLogic.FriendsFilter.filterByLanguage(comboBoxCommonLanguage.SelectedItem as string);
            DisplayOnEmptyList("Nobody from your friends speaks this language! (Or hasn't updated it)");
        }

        private void listBoxFilteredFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedUser = listBoxFilteredFriends.SelectedItem as User;
            if (selectedUser != null)
            {
                pictureBoxFriends.LoadAsync(selectedUser.PictureNormalURL);
            }
        }

        private void buttonCheckYear_Click(object sender, EventArgs e)
        {
            if(numericUpDownYearsRange.Enabled == true)
            {
                listBoxFilteredFriends.Items.Clear();
                m_FilteredFriends = r_AppLogic.FriendsFilter.filterByYearDifference(Convert.ToInt32(numericUpDownYearsRange.Value));
                DisplayOnEmptyList("Nobody matches this year range!");
            }
        }

        private void addFriendsByGender(User.eGender i_Gender)
        {
            listBoxFilteredFriends.Items.Clear();
            m_FilteredFriends = r_AppLogic.FriendsFilter.filterByGender(i_Gender);
            DisplayOnEmptyList("No one from the friends stated this gender :(");
        }

        private void DisplayOnEmptyList(string i_Msg)
        {
            if (m_FilteredFriends.Count != 0)
            {
                listBoxFilteredFriends.Enabled = true;

                foreach(User friend in m_FilteredFriends)
                {
                    listBoxFilteredFriends.Items.Add(friend);
                }
            }

            if (listBoxFilteredFriends.Items.Count == 0 || listBoxFilteredFriends.Enabled == false)
            {
                listBoxFilteredFriends.Items.Clear();
                listBoxFilteredFriends.Items.Add(i_Msg);
                listBoxFilteredFriends.Enabled = false;
            }
        }
    }
}