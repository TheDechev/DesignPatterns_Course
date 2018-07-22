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
                fetchCityVisitorFeatureInfo(friend.Location.Location.City);
                friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
            }
            //fetchCityInfoToListBox("Jerusalem"); // Uncomment to fetch city info manually (check only)
        }

        private int kelvinToCelsius(float kelvinTemperature)
        {
            return (int)(kelvinTemperature - 273.15);
        }

        private void fetchCityVisitorFeatureInfo(string friendCity)
        {
            if (friendCity != null)
            {
                if (!comboBoxCity.Items.Contains(friendCity))
                {
                    comboBoxCity.Items.Add(friendCity);
                }
            }
        }

        private void formInit()
        {
            comboBoxFriends.SelectedIndexChanged += ComboBoxFriends_OnSelectedIndexChanged;
            comboBoxCity.SelectedIndexChanged += ComboBoxCity_OnSelectedIndexChanged;
        }

        private void ComboBoxFriends_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_SelectedFriend = comboBoxFriends.SelectedItem as User;

            if (this.m_SelectedFriend != null)
            {
                CommonInfoHelper commonInfo = new CommonInfoHelper(this.m_LoggedInUser, this.m_SelectedFriend);
                listBoxCommonEvents.Enabled = true;
                listBoxCommonPages.Enabled = true;
                addCommonItemsToLists(commonInfo);
            }
        }

        private void ComboBoxCity_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = comboBoxCity.SelectedItem as string;

            if (selectedCity != null)
            {
                // Add all friends that live in selectedCity to friends list box:
                foreach (User friend in m_LoggedInUser.Friends)
                {
                    if (friend.Location.Location.City.Equals(selectedCity))
                    {
                        listBoxFriendsFromSelectedCity.Items.Add(friend.Name);
                    }
                }
                // Add city information to weather list box:
                try
                {
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
            LinkLabel.Link wiki = new LinkLabel.Link();
            string linkByCity = "https://en.wikipedia.org/wiki/" + selectedCity;
            wiki.LinkData = linkByCity;
            linkCityWikipedia.Links.Add(wiki);
            linkCityWikipedia.Enabled = true;
        }

        private void addCommonItemsToLists(CommonInfoHelper i_CommonInfo)
        {
            foreach (Page currentPage in i_CommonInfo.LikedPages)
            {
                listBoxCommonPages.Items.Add(currentPage);
            }

            foreach (Event currentEvent in i_CommonInfo.AttendedEvents)
            {
                listBoxCommonEvents.Items.Add(currentEvent);
            }
        }

        private void linkCityWikipedia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}
