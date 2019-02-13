using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schd
{
    class Results
    {
        public String schedulingType;
        public String schedulingName;
        public int compuTime;
        public int responseTime;
        public Results(String schedulingType, String schedulingName, int compuTime, int responseTime)
        {
            this.schedulingType = schedulingType;
            this.schedulingName = schedulingName;
            this.compuTime = compuTime;
            this.responseTime = responseTime;
        }
        
    }
}
