using Easy.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Public;

namespace Easy.Infrastructure.Repository
{
    public class Sql
    {
        public static string BaseSelectSql()
        {
            return @"SELECT id, name, address, tel, business_status, createdate, 
                    1 AS split,
                    coordinates_longitude, coordinates_latitude, 
                    1 AS split,
                    businesstime_start, businesstime_end, 
                    1 AS split,
                    deliverytime
	            FROM supplier";
        }

        public static Supplier SelectConvert(Supplier s, object c, object o1, object o2)
        {
            var coordinatesDic = c as IDictionary<string, object>;
            var coordinates = new Coordinates(coordinatesDic["coordinates_longitude"].ToString(), coordinatesDic["coordinates_latitude"].ToString());

            s.Coordinates = coordinates;

            var bussinestimeDic = o1 as IDictionary<string, object>;

            var bussinestime = new BusinessTime(TimeHelper.StringToTime(bussinestimeDic["businesstime_start"].ToString()), TimeHelper.StringToTime(bussinestimeDic["businesstime_end"].ToString()));

            s.BusinessTime = bussinestime;

            var deliverytimeDic = o2 as IDictionary<string, object>;


            s.DeliveryTime = TimeHelper.StringArrayToTimeArray(deliverytimeDic["deliverytime"].ToString());
            return s;
        }

        public static Tuple<string, dynamic> FindByIdSql(int id)
        {
            string sql = string.Join(" ", BaseSelectSql(), "WHERE", "id=@Id");

            return new Tuple<string, dynamic>(sql, new { Id = id });
        }

        public static Tuple<string, dynamic> AddSql(Supplier item)
        {
            const string sql = @"INSERT INTO supplier
	(name, address, tel, coordinates_longitude, coordinates_latitude, createdate, businesstime_start, businesstime_end, deliverytime, business_status)
	VALUES (@Name, @Address, @Tel, @CoordnateLongitude, @CoordnateLatitude,@CreateDate, @BusinesstimeStart, @BusinesstimeEnd, @DeliveryTime, @BusinessStatus);SELECT LAST_INSERT_ID()";
            return new Tuple<string, dynamic>(sql, InsertAndUpdateData(item));
        }

        public static String RemoveAllSql()
        {
            return "DELETE FROM supplier";
        }

        public static Tuple<string, dynamic> Remove(int id)
        {
            string sql = string.Join(" ", RemoveAllSql(), "WHERE", "id=@Id");

            return new Tuple<string, dynamic>(sql, new { Id = id });
        }


        public static Tuple<string,dynamic> UpdateSql(Supplier item)
        {
            string sql = @"UPDATE supplier
	                        SET
		                        name=@Name,
		                        address=@Address,
		                        tel=@Tel,
		                        coordinates_longitude=@CoordnateLongitude,
		                        coordinates_latitude=@CoordnateLatitude,
		                        createdate=@CreateDate,
		                        businesstime_start=@BusinesstimeStart,
		                        businesstime_end=@BusinesstimeEnd,
		                        deliverytime=@DeliveryTime,
		                        business_status=@BusinessStatus
	                        WHERE id=@Id";

            return new Tuple<string, dynamic>(sql, InsertAndUpdateData(item));
        }


        public static string FindByIdsSql(int[] supplierIds)
        {
            string sql = string.Join(" ", BaseSelectSql(), "WHERE", "id IN({0})");
            string data = string.Join(",", supplierIds);
            return string.Format(sql, data);
        }


        public static Tuple<string, string, dynamic> Select(int pageIndex, int pageSize)
        {
            string sqlcount = "SELECT COUNT(*) AS Count FROM supplier;";

            string selectsql = string.Join(" ", BaseSelectSql(), "ORDER BY id DESC", "LIMIT @Limit OFFSET @Offset;");

            return new Tuple<string, string, dynamic>(sqlcount, selectsql, new
            {
                Limit = pageSize,
                Offset = (pageIndex - 1) * pageSize
            });
        }

        private static dynamic InsertAndUpdateData(Supplier item)
        {
            var data = new
            {
                Id = item.Id,
                Name = item.Name,
                Address = item.Address,
                Tel = item.Tel,
                CoordnateLongitude = NullHelper.IfNull(item.Coordinates, "", m => m.Longitude),
                CoordnateLatitude = NullHelper.IfNull(item.Coordinates, "", m => m.Latitude),
                BusinesstimeStart = NullHelper.IfNull(item.BusinessTime, "", m => NullHelper.IfNull(m.Start, "", t => t.ToString())),
                BusinesstimeEnd = NullHelper.IfNull(item.BusinessTime, "", m => NullHelper.IfNull(m.End, "", t => t.ToString())),
                DeliveryTime = NullHelper.IfNull(item.DeliveryTime, "", m => string.Join("|", m.Select(t => t.Start + "-" + t.End).ToArray())),
                CreateDate = item.CreateDate,
                BusinessStatus = item.BusinessStatus
            };
            return data;
        }









       
    }
}
