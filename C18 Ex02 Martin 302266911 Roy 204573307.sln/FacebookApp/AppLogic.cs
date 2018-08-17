using System.Collections.Generic;
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

        public AppLogic()
        {
            m_CityAdvisor = CityAdvisorFeature.CityAdvisorInstance;
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
            try
            {
                LoginResult = FacebookService.Connect(i_LastAccessToken);
            }
            catch
            {
                Login();
            }
        }

        public List<string> GetLatestPhotos(int i_NumOfItems)
        {
            List<string> resPhotos = new List<string>();

            int counter = 0;

            foreach(Album album in LoggedUser.Albums)
            {
                for(int i = 0; i < album.Photos.Count; i++)
                {
                    resPhotos.Add(album.Photos[i].PictureNormalURL);
                    counter++;
                    if (counter > i_NumOfItems)
                    {
                        break;
                    }
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
    }
}
