using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanochJoseftest.Business
{
    public class TimerVirtual
    {
        public virtual int TimerConverter(int Timer)
        {
            int NewTime = Timer * 10;
            return NewTime;
        }
    }
}
