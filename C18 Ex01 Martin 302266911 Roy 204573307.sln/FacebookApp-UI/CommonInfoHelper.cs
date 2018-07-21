using FacebookWrapper.ObjectModel;

namespace FacebookApp_UI
{
    internal class CommonInfoHelper
    {
        private FacebookObjectCollection<Page> m_LikedPages;
        private FacebookObjectCollection<Event> m_AttendedEvents;
        private User m_Friend;
        private User m_LoggedInUser;

        public CommonInfoHelper(User i_LoggedUser, User i_Friend)
        {
            m_Friend = i_Friend;
            m_LoggedInUser = i_LoggedUser;

            findCommonPages();
            findCommonAttendedEvents();
        }

        public FacebookObjectCollection<Page> LikedPages
        {
            get
            {
                return m_LikedPages;
            }
        }

        public FacebookObjectCollection<Event> AttendedEvents
        {
            get
            {
                return m_AttendedEvents;
            }
        }

        public User Friend
        {
            get
            {
                return m_Friend;
            }

            set
            {
                this.m_Friend = value;
                m_LikedPages = new FacebookObjectCollection<Page>();
                m_AttendedEvents = new FacebookObjectCollection<Event>();
                findCommonPages();
                findCommonAttendedEvents();
            }
        }

        private void findCommonAttendedEvents()
        {
            m_AttendedEvents = new FacebookObjectCollection<Event>();

            foreach (Event currentEvent in m_LoggedInUser.Events)
            {
                if (m_Friend.Events.Contains(currentEvent))
                {
                    this.m_AttendedEvents.Add(currentEvent);
                }
            }
        }

        private void findCommonPages() 
        {
            m_LikedPages = new FacebookObjectCollection<Page>();

            foreach (Page currentPage in m_LoggedInUser.LikedPages)
            {
                if (m_Friend.LikedPages.Contains(currentPage))
                {
                    this.m_LikedPages.Add(currentPage);
                }
            }
        }
    }
}