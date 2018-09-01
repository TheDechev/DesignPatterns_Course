using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookAppLogic
{
    public interface IObserver
    {
        void Update(bool i_Enable);
    }
}
