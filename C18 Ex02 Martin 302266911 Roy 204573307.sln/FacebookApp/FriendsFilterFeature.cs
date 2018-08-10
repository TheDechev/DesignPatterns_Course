using FacebookWrapper.ObjectModel;

namespace FacebookApp
{
    internal class FriendsFilterFeature
    {
        public User LoggedUser { get; set; }

        public FriendsFilterFeature(User i_LoggedUser)
        {
            LoggedUser = i_LoggedUser;
        }

        public FacebookObjectCollection<User> FilterByLanguage(string i_SelectedLanguage)
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();
            if(LoggedUser != null)
            {
                foreach (User friend in LoggedUser.Friends)
                {
                    if (friend.Languages != null)
                    {
                        foreach (Page page in friend.Languages)
                        {
                            if (page.Name == i_SelectedLanguage)
                            {
                                resCollection.Add(friend);
                            }
                        }
                    }
                }
            }

            return resCollection;
        }

        public FacebookObjectCollection<User> FilterByYearDifference(int i_SelectedValue)
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();

            if(LoggedUser != null)
            {
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
            }

            return resCollection;
        }

        public FacebookObjectCollection<User> FilterByGender(User.eGender i_Gender)
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();

            if(LoggedUser != null)
            {
                foreach (User friend in LoggedUser.Friends)
                {
                    if (friend.Gender == i_Gender)
                    {
                        resCollection.Add(friend);
                    }
                }
            }

            return resCollection;
        }

        public FacebookObjectCollection<User> FilterBySameBirthMonth()
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();

            if(LoggedUser != null)
            {
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
            }

            return resCollection;
        }
    }
}
