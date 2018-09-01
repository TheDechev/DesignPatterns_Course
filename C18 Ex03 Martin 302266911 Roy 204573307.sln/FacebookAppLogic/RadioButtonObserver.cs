using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookAppLogic
{
    public class RadioButtonObserver : IObserver
    {
        private RadioButton m_RadioButton;

        public RadioButtonObserver(RadioButton i_RadioButton)
        {
            m_RadioButton = i_RadioButton;
        }

        public void Update(bool i_EnableStatus)
        {
            this.m_RadioButton.Enabled = i_EnableStatus;
        }
    }
}
