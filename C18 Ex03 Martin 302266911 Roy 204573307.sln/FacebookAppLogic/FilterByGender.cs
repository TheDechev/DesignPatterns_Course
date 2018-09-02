using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    public class FilterByGender : IFilterStrategy
    {
        public FacebookObjectCollection<User> FilterFriends(Filter i_FilterBy)
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();

            if(i_FilterBy.User != null)
            {
                foreach (User friend in i_FilterBy.User.Friends)
                {
                    if (friend.Gender == i_FilterBy.Gender)
                    {
                        resCollection.Add(friend);
                    }
                }
            }

            return resCollection;
        }
    }
}
