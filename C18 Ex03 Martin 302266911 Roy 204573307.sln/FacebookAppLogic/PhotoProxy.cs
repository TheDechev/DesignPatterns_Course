using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookAppLogic
{
    public class PhotoProxy
    {
        public FacebookWrapper.ObjectModel.Photo Photo { get; set; }

        public static implicit operator string(PhotoProxy v)
        {
            return v.ToString();
        }

        public override string ToString()
        {
            string resString = string.Empty;

            if(Photo != null)
            {
                resString = Photo.PictureNormalURL;
            }

            return resString;
        }

        public string GetDaysSinceToday()
        {
            return string.Format("{0} days ago", (DateTime.Today - Photo.CreatedTime.Value).Days);
        }

        public string[] GetTaggedFriends()
        {
            List<string> resList = new List<string>();
            if(Photo.Tags != null)
            {
                for (int i = 0; i < Photo.Tags.Count; i++)
                {
                    resList.Add(Photo.Tags[i].User.Name);
                }
            }

            return resList.ToArray();
        }
    }
}