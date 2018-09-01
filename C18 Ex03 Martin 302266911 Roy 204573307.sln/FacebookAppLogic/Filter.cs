using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookAppLogic
{
    public class Filter
    {
        public User User { get; set; }

        public string Language { get; set; }

        public int YearDifference { get; set; }

        public User.eGender Gender { get; set; }
    }
}
