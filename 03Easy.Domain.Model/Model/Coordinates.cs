using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Domain.Model
{
    public class Coordinates
    {
        public Coordinates(string longitude,string latitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// 经度
        /// </summary>
        public String Longitude 
        { 
            get;
            private set; 
        }

        /// <summary>
        /// 纬度
        /// </summary>
        public String Latitude
        {
            get; 
            private set;
        }

        public override bool Equals(object obj)
        {
            if (obj==null||obj as Coordinates==null)
            {
                return false;
            }
            Coordinates c = obj as Coordinates;
            if (this.Latitude==c.Latitude&&this.Longitude==c.Longitude)
            {
                return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Latitude.GetHashCode() ^ this.Longitude.GetHashCode();
        }
    }
}
