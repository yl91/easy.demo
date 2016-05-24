using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Domain.Model
{
    public class BusinessStatusService
    {
        public BusinessStatus GetStatus(BusinessStatus status, BusinessTime time)
        {
            if (status == BusinessStatus.Close)
            {
                return BusinessStatus.Close;
            }
            var now = DateTime.Now;
            if (now >= time.Start.GetDateTime() && now < time.End.GetDateTime())
            {
                return BusinessStatus.Open;
            }
            return BusinessStatus.Close;
        }
    }
}
