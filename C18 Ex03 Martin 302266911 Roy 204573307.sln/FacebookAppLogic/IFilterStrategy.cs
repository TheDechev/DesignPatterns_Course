using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    public interface IFilterStrategy
    {
        FacebookObjectCollection<User> FilterFriends(Filter i_FilterBy);
    }
}
