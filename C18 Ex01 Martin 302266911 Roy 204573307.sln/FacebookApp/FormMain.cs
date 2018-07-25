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
using System.Xml;
using System.Diagnostics;

namespace FacebookApp
{
    internal partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBoxProfile.Image = Resource.EmptyPicture;
            pictureBoxProfile.Image = Resource.EmptyPicture;
            FacebookService.s_CollectionLimit = 200;
            FacebookService.s_FbApiVersion = 2.8f;
        }

        private User m_LoggedInUser;

        protected override void OnLoad(EventArgs e)
        {
            this.formInit();
            base.OnLoad(e);
        }

        private void loginAndInit()
        {
            try
            {

                LoginResult result = FacebookService.Login("980644158781216",
                "email", 
                "public_profile",
                "user_friends",
                "user_likes",
                "user_photos",
                "user_posts",
                "user_birthday",
                "user_events",
                "manage_pages",
                "user_location",
                "user_gender");

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

        // 

        private void fetchUserInfo()
        {
            pictureBoxProfile.LoadAsync(m_LoggedInUser.PictureNormalURL);
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
            pictureBoxProfile.Image = Resource.EmptyPicture;
            userNameLabel.Text = string.Empty;
            buttonSetStatus.Enabled = false;
            buttonLogout.Visible = false;
            buttonLogout.Enabled = false;
            buttonLogin.Visible = true;
            buttonLogin.Enabled = true;
            listBoxFilteredFriends.Enabled = false;
            //listBoxCommonPages.Enabled = false;
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
                //comboBoxFriends.Items.Add(friend);

                if(friend.Location != null)
                {
                    fetchCityVisitorFeatureInfo(friend.Location.Name);
                }

                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }
            if (m_LoggedInUser != null)
            {
                fetchCityVisitorFeatureInfo(m_LoggedInUser.Location.Name);

            }
        }

        // ===================== ====================== ====================== 
        // ======================== First Fetaure Code =======================
        // ===================== ====================== ====================== 

        private void fetchCityVisitorFeatureInfo(string friendCity)
        {
            if (!comboBoxCity.Items.Contains(friendCity))
            {
                comboBoxCity.Items.Add(friendCity);
            }
        }

        private void formInit()
        {
            //comboBoxFriends.SelectedIndexChanged += ComboBoxFriends_OnSelectedIndexChanged;
            comboBoxCity.SelectedIndexChanged += ComboBoxCity_OnSelectedIndexChanged;
        }

        private void ComboBoxCity_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = comboBoxCity.SelectedItem as string;
            listBoxFriendsFromSelectedCity.Items.Clear();
            listBoxCityWeather.Items.Clear();
            pictureBoxCityFriend.Image = global::FacebookApp.Resource.EmptyPicture;
            if (selectedCity != null)
            {
                // Add all friends that live in selectedCity to friends list box:
                foreach (User friend in m_LoggedInUser.Friends)
                {
                    if (friend.Location != null && friend.Location.Name.Equals(selectedCity))
                    {
                        listBoxFriendsFromSelectedCity.Items.Add(friend);
                    }
                }
                // Add city information to weather list box:
                try
                {
                    if (selectedCity.Contains(", Israel"))
                    {
                        selectedCity = selectedCity.Replace(", Israel", "");
                    }

                    fetchCityInfoToListBox(selectedCity);
                }
                catch (Exception)
                {
                    MessageBox.Show("City information is missing :(");
                }
            }
        }

        void fetchCityInfoToListBox(string selectedCity)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + selectedCity +
                    ",il&mode=xml&appid=0a08b75b9e93b7524a2642d309468a15";
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(url);
            XmlElement root = doc1.DocumentElement;
            fetchCityNameToListBox(selectedCity);
            fetchCurrentTemperatureToListBox(root);
            fetchHumidityPercentageToListBox(root);
            fetchSunTimesToListBox(root);
            fetchWikipediaLinkToListBox(selectedCity);
            this.listBoxFriendsFromSelectedCity.Enabled = true;
            this.listBoxCityWeather.Enabled = true;
        }

        void fetchCityNameToListBox(string selectedCity)
        {
            string cityNameString = "City Name: " + selectedCity;
            listBoxCityWeather.Items.Add(cityNameString);
        }

        void fetchCurrentTemperatureToListBox(XmlElement root)
        {
            XmlNodeList temperature = root.SelectNodes("/current/temperature");
            string currentKelvinTemperature = temperature[0].Attributes[0].Value;
            int currentCelsiusTemperature = kelvinToCelsius(float.Parse(currentKelvinTemperature));
            string temperatureStr = String.Format("Temperature (celsius): {0} degrees", currentCelsiusTemperature);
            listBoxCityWeather.Items.Add(temperatureStr);
        }

        private int kelvinToCelsius(float kelvinTemperature)
        {
            return (int)(kelvinTemperature - 273.15);
        }

        void fetchHumidityPercentageToListBox(XmlElement root)
        {
            XmlNodeList humidity = root.SelectNodes("/current/humidity");
            string humidityString = String.Format("Humidity: {0}%", humidity[0].Attributes[0].Value);
            listBoxCityWeather.Items.Add(humidityString);
        }

        void fetchSunTimesToListBox(XmlElement root)
        {
            XmlNodeList sun = root.SelectNodes("/current/city/sun");
            string sunrise = String.Format("Sunrise (GMT): {0}", sun[0].Attributes[0].Value);
            listBoxCityWeather.Items.Add(sunrise);
            string sunset = String.Format("Sunset (GMT): {0}", sun[0].Attributes[1].Value);
            listBoxCityWeather.Items.Add(sunset);
        }

        void fetchWikipediaLinkToListBox(string selectedCity)
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
        // ======================= Second Fetaure Code =======================
        // ===================== ====================== ====================== 

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            addFriendsByGender(User.eGender.male);
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            addFriendsByGender(User.eGender.female);
        }
        
        private void addFriendsByGender(User.eGender i_Gender)
        {
            listBoxFilteredFriends.Items.Clear();

            foreach (User friend in m_LoggedInUser.Friends)
            {
                if (friend.Gender == i_Gender)
                {
                    listBoxFilteredFriends.Enabled = true;
                    listBoxFilteredFriends.Items.Add(friend);
                }
            }

             DisplayOnEmptyList("No one from the friends stated this gender :(");
        }

        private void radioButtonLanguage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLanguage.Checked == false)
            {
                comboBoxCommonLanguage.Enabled = false;
            }
            else
            {
                if (this.m_LoggedInUser.Languages != null)
                {
                    comboBoxCommonLanguage.Enabled = true;
                    if (comboBoxCommonLanguage.Items.Count == 0)
                    {
                        foreach (Page page in this.m_LoggedInUser.Languages)
                        {
                            comboBoxCommonLanguage.Items.Add(page.Name);
                        }
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

        private void comboBoxCommonLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLanguage = comboBoxCommonLanguage.SelectedItem as string;
            listBoxFilteredFriends.Items.Clear();
            foreach (User friend in m_LoggedInUser.Friends)
            {
                if (friend.Languages != null)
                {
                    foreach (Page page in friend.Languages)
                    {
                        if (page.Name == selectedLanguage)
                        {
                            listBoxFilteredFriends.Enabled = true;
                            listBoxFilteredFriends.Items.Add(friend);
                        }
                    }
                }
            }
            DisplayOnEmptyList("Nobody from your friends speaks this language! (Or hasn't updated it)");

        }

        private void DisplayOnEmptyList(string i_Msg)
        {
            if (listBoxFilteredFriends.Items.Count == 0 || listBoxFilteredFriends.Enabled == false)
            {
                listBoxFilteredFriends.Items.Clear();
                listBoxFilteredFriends.Items.Add(i_Msg);
                listBoxFilteredFriends.Enabled = false;
            }
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
                int selectedValue = Convert.ToInt32(numericUpDownYearsRange.Value);
                string birthday = this.m_LoggedInUser.Birthday;
                int yearOfBirth = int.Parse(string.Format("{0}{1}{2}{3}", birthday[6], birthday[7], birthday[8], birthday[9]));
                int friendYearOfBirth;

                foreach (User friend in this.m_LoggedInUser.Friends)
                {
                    birthday = friend.Birthday;
                    if (birthday != null)
                    {
                        friendYearOfBirth = int.Parse(string.Format("{0}{1}{2}{3}", birthday[6], birthday[7], birthday[8], birthday[9]));
                        if (friendYearOfBirth == yearOfBirth - selectedValue || friendYearOfBirth == yearOfBirth + selectedValue)
                        {
                            listBoxFilteredFriends.Enabled = true;
                            listBoxFilteredFriends.Items.Add(friend);
                        }
                    }
                }

                DisplayOnEmptyList("Nobody matches this year range!");
            }
        }

        private void radioButtonSameMonth_CheckedChanged(object sender, EventArgs e)
        {
            string birthday = this.m_LoggedInUser.Birthday;
            int monthOfBirth = int.Parse(string.Format("{0}{1}", birthday[3], birthday[4]));
            int friendMonthOfBirth;

            foreach (User friend in this.m_LoggedInUser.Friends)
            {
                birthday = friend.Birthday;
                if (birthday != null)
                {
                    friendMonthOfBirth = int.Parse(string.Format("{0}{1}", birthday[3], birthday[4]));
                    if (friendMonthOfBirth == monthOfBirth)
                    {
                        listBoxFilteredFriends.Enabled = true;
                        listBoxFilteredFriends.Items.Add(friend);
                    }
                }
            }

            DisplayOnEmptyList("You're a special snowflake! Nobody from your friendlist is born on this day :)");
        }
    }
}
