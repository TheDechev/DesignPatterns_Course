using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookAppLogic
{
    interface IFilterStrategy
    {
        FacebookObjectCollection<User> FilterFriends(Filter i_FilterBy);
    }
}
