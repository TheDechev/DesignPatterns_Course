using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace FacebookAppLogic
{
    public class AppLogic
    {
        private readonly string r_AppID = "980644158781216";
        private User m_LoggedInUser;
        private FriendsFilterFeature m_Filter;
        public eLoginStatus m_LoginStatus = eLoginStatus.LoggedOut;

        public AppLogic()
        {
            m_Filter = new FriendsFilterFeature(m_LoggedInUser);
        }

        public AppSettings AppSettings { get; set; }

        public LoginResult LoginResult { get; set; }

        public User LoggedUser
        {
            get
            {
                return m_LoggedInUser;
            }

            set
            {
                m_LoggedInUser = value;
                m_Filter.Filter.User = value;
            }
        }

        public string AppID
        {
            get
            {
                return r_AppID;
            }
        }

        public bool Login()
        {
            bool res = false;

            this.LoginResult = FacebookService.Login(
            AppID,
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

            if (!string.IsNullOrEmpty(this.LoginResult.AccessToken))
            {
                LoggedUser = this.LoginResult.LoggedInUser;
                res = true;
            }

            return res;
        }

        public void Connect(string i_LastAccessToken)
        {
            try
            {
                LoginResult = FacebookService.Connect(i_LastAccessToken);
            }
            catch
            {
                Login();
            }
        }

        public List<PhotoProxy> GetLatestPhotos(int i_NumOfItems)
        {
            List<PhotoProxy> resPhotos = new List<PhotoProxy>();

            int counter = 0;
            
            foreach(Album album in LoggedUser.Albums)
            {
                for(int i = 0; i < album.Photos.Count; i++)
                {
                    if (counter > i_NumOfItems)
                    {
                        break;
                    }

                    resPhotos.Add(new PhotoProxy { Photo = album.Photos[i] });
                    counter++;
                }
            }

            return resPhotos;
        }

        public List<Post> GetLatestPosts(int i_NumOfItems)
        {
            List<Post> resPosts = new List<Post>();

            for (int i = 0; i < i_NumOfItems; i++)
            {
                if(i >= this.LoggedUser.Friends.Count)
                {
                    break;
                }

                resPosts.Add(this.LoggedUser.NewsFeed[i]);
            }

            return resPosts;    
        }

        public List<string> GetCityAdvisorInfo(string i_CityName)
        {
            List<string> cityInfoList = new List<string>();
            CityData[] cityData = new CityData[] { new Temperature(), new Humidity(), new Sunrise(), new Sunset() };

            cityInfoList.Add("City Name: " + i_CityName);

            for (int i = 0; i < cityData.Length; i++)
            {
                cityInfoList.Add(cityData[i].FetchValue(i_CityName));
            }

            return cityInfoList;
        }

        public List<string> GetFriendsLanguages()
        {
            List<string> resList = new List<string>();

            if(LoggedUser != null)
            {
                foreach (Page page in LoggedUser.Languages)
                {
                    resList.Add(page.Name);
                }
            }

            return resList;
        }

        public void UpdateAppSettings(System.Drawing.Point i_Location, bool i_RememberMe, string i_AccessToken)
        {
            AppSettings.LastWindowLocation = i_Location;
            AppSettings.RememberUser = i_RememberMe;
            AppSettings.LastAccessToken = i_AccessToken;
            AppSettings.SaveToFile();
        }

        public FacebookObjectCollection<User> FilterBySameBirthMonth()
        {
            return this.m_Filter.FilterBySameBirthMonth();
        }

        public FacebookObjectCollection<User> FilterByLanguage(string i_Language)
        {
            return this.m_Filter.FilterByLanguage(i_Language);
        }

        public FacebookObjectCollection<User> FilterByYearDifference(int i_YearsDifference)
        {
            return this.m_Filter.FilterByYearDifference(i_YearsDifference);
        }

        public FacebookObjectCollection<User> FilterByGender(User.eGender i_Gender)
        {
            return this.m_Filter.FilterByGender(i_Gender);
        }
    }
}
