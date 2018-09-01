using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    class FilterByYear : IFilterStrategy
    {
        public FacebookObjectCollection<User> FilterFriends(Filter i_FilterBy)
        {
            FacebookObjectCollection<User> resCollection = new FacebookObjectCollection<User>();

            if (i_FilterBy.User != null)
            {
            string birthday = i_FilterBy.User.Birthday;
            int yearOfBirth = int.Parse(string.Format("{0}{1}{2}{3}", birthday[6], birthday[7], birthday[8], birthday[9]));
            int friendYearOfBirth;

                foreach (User friend in i_FilterBy.User.Friends)
                {
                    birthday = friend.Birthday;
                    if (birthday != null)
                    {
                        friendYearOfBirth = int.Parse(string.Format("{0}{1}{2}{3}", birthday[6], birthday[7], birthday[8], birthday[9]));
                        if (friendYearOfBirth == yearOfBirth - i_FilterBy.YearDifference || friendYearOfBirth == yearOfBirth + i_FilterBy.YearDifference)
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
