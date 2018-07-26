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
        private const string k_AppID = "980644158781216";
        private User m_LoggedInUser;

        public AppSettings AppSettings { get; set; }

        public LoginResult LoginResult { get; set; }

        public eLoginStatus m_LoginStatus = eLoginStatus.LoggedOut;

        public User LoggedUser
        {
            get
            {
                return m_LoggedInUser;
            }

            set
            {
                m_LoggedInUser = value;
            }
        }

        public string AppID
        {
            get
            {
                return k_AppID;
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

        public FacebookObjectCollection<User> filterFriendsByLanguage(string i_SelectedLanguage)
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();

            foreach (User friend in LoggedUser.Friends)
            {
                if (friend.Languages != null)
                {
                    foreach (Page page in friend.Languages)
                    {
                        if(page.Name == i_SelectedLanguage)
                        {
                            resCollection.Add(friend);
                        }
                    }
                }
            }

            return resCollection;
        }

        public FacebookObjectCollection<User> filterFriendsByYearDifference(int i_SelectedValue)
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();

            string birthday = LoggedUser.Birthday;
            int yearOfBirth = int.Parse(string.Format("{0}{1}{2}{3}", birthday[6], birthday[7], birthday[8], birthday[9]));
            int friendYearOfBirth;

            foreach (User friend in LoggedUser.Friends)
            {
                birthday = friend.Birthday;
                if (birthday != null)
                {
                    friendYearOfBirth = int.Parse(string.Format("{0}{1}{2}{3}", birthday[6], birthday[7], birthday[8], birthday[9]));
                    if (friendYearOfBirth == yearOfBirth - i_SelectedValue || friendYearOfBirth == yearOfBirth + i_SelectedValue)
                    {
                        resCollection.Add(friend);
                    }
                }
            }

            return resCollection;
        }

        public FacebookObjectCollection<User> filterFriendsByGender(User.eGender i_Gender)
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();

            foreach (User friend in LoggedUser.Friends)
            {
                if (friend.Gender == i_Gender)
                {
                    resCollection.Add(friend);
                }
            }

            return resCollection;
        }

        public FacebookObjectCollection<User> filterFriendsBySameBirthMonth()
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();

            string birthday = LoggedUser.Birthday;
            int monthOfBirth = int.Parse(string.Format("{0}{1}", birthday[3], birthday[4]));
            int friendMonthOfBirth;

            foreach (User friend in LoggedUser.Friends)
            {
                birthday = friend.Birthday;
                if (birthday != null)
                {
                    friendMonthOfBirth = int.Parse(string.Format("{0}{1}", birthday[3], birthday[4]));
                    if (friendMonthOfBirth == monthOfBirth)
                    {
                        resCollection.Add(friend);
                    }
                }
            }

            return resCollection;
        }
    }
}
