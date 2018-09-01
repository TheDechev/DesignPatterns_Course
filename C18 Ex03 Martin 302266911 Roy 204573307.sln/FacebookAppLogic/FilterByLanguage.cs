using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    class FilterByLanguage : IFilterStrategy
    {
        public FacebookObjectCollection<User> FilterFriends(Filter i_FilterBy)
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();

            if(i_FilterBy.User != null)
            {
                foreach (User friend in i_FilterBy.User.Friends)
                {
                    if (friend.Languages != null)
                    {
                        foreach (Page page in friend.Languages)
                        {
                            if (page.Name == i_FilterBy.Language)
                            {
                                resCollection.Add(friend);
                            }
                        }
                    }
                }
            }

            return resCollection;
        }
    }
}
