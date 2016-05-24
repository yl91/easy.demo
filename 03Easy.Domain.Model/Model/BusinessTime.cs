using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Domain.Model
{
    /// <summary>
    /// 营业时间
    /// </summary>
    public class BusinessTime
    {
        public BusinessTime(Time start,Time end)
        {
            this.Start = start;
            this.End = end;
        }

        public Time Start
        {
            get;
            private set;
        }

        public Time End
        {
            get;
            private set;
        }
    }
}
