using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace FacebookApp
{
    internal class AppLogic
    {
        private readonly string r_AppID = "980644158781216";
        private User m_LoggedInUser;
        private CityAdvisorFeature m_CityAdvisor;
        private FriendsFilterFeature m_Filter;
        public eLoginStatus m_LoginStatus = eLoginStatus.LoggedOut;

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
                m_Filter.LoggedUser = value;
            }
        }

        public CityAdvisorFeature CityAdvisor
        {
            get
            {
                return m_CityAdvisor;
            }
        }

        public FriendsFilterFeature FriendsFilter
        {
            get
            {
                return m_Filter;
            }
        }

        public AppLogic()
        {
            m_CityAdvisor = new CityAdvisorFeature();
            m_Filter = new FriendsFilterFeature(m_LoggedInUser);
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

        internal void Connect(string i_LastAccessToken)
        {
            LoginResult = FacebookService.Connect(i_LastAccessToken);
        }
    }
}
