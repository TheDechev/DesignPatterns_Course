namespace FacebookAppLogic
{
    public delegate void LoginStatusChangeDelegate(bool i_LoginStatus);

    public class RadioButtonSubject
    {
        private LoginStatusChangeDelegate m_LoginStatusChangeDelegates;

        public void NotifyObservers(bool i_LoginStatus)
        {
            if(this.m_LoginStatusChangeDelegates != null)
            {
                this.m_LoginStatusChangeDelegates.Invoke(i_LoginStatus);
            }
        }

        public void Attach(LoginStatusChangeDelegate i_ObserverDelegate)
        {
            m_LoginStatusChangeDelegates += i_ObserverDelegate;
        }

        public void Detach(LoginStatusChangeDelegate i_ObserverDelegate)
        {
            m_LoginStatusChangeDelegates -= i_ObserverDelegate;
        }
    }
}
