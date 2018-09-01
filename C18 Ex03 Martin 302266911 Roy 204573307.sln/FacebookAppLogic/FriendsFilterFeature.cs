using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    internal class FriendsFilterFeature
    {
        public Filter Filter { get; private set; }

        private IFilterStrategy m_FilterStrategy;

        public FriendsFilterFeature(User i_LoggedUser)
        {
            this.Filter = new Filter();
            Filter.User = i_LoggedUser;
        }

        public FacebookObjectCollection<User> FilterByLanguage(string i_SelectedLanguage)
        {
            Filter.Language = i_SelectedLanguage;
            m_FilterStrategy = new FilterByLanguage();
            return m_FilterStrategy.FilterFriends(Filter);
        }

        public FacebookObjectCollection<User> FilterByYearDifference(int i_SelectedValue)
        {
            Filter.YearDifference = i_SelectedValue;
            m_FilterStrategy = new FilterByYear();
            return m_FilterStrategy.FilterFriends(Filter);
        }

        public FacebookObjectCollection<User> FilterByGender(User.eGender i_Gender)
        {
            Filter.Gender = i_Gender;
            m_FilterStrategy = new FilterByGender();
            return m_FilterStrategy.FilterFriends(Filter);
        }

        public FacebookObjectCollection<User> FilterBySameBirthMonth()
        {
            m_FilterStrategy = new FilterByBirth ();
            return m_FilterStrategy.FilterFriends(Filter);
        }
    }
}
