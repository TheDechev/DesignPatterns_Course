using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    class FilterByBirth : IFilterStrategy
    {
        public FacebookObjectCollection<User> FilterFriends(Filter i_FilterBy)
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();

            if (i_FilterBy.User != null)
            {
            string birthday = i_FilterBy.User.Birthday;
            int monthOfBirth = int.Parse(string.Format("{0}{1}", birthday[3], birthday[4]));
            int friendMonthOfBirth;

                foreach (User friend in i_FilterBy.User.Friends)
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
