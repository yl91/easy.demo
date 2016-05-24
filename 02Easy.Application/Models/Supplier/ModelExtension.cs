using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Public;
using M=Easy.Domain.Model;

namespace Easy.Application.Models.Supplier
{
    static class ModelExtension
    {
        public static M.Supplier ToSupplier(this AddSupplierModel model)
        {
            return ToSupplier(model, new M.Supplier());
        }

        public static M.Supplier ToSupplier(this AddSupplierModel model, M.Supplier supplier)
        {
            supplier.Name = model.Name;
            supplier.Tel = model.Tel;
            supplier.Address = model.Address;
            supplier.BusinessTime = new M.BusinessTime(model.BusinessTimeStart.ToTime(), model.BusinessTimeEnd.ToTime());

            supplier.Coordinates = new M.Coordinates(model.CoordinatesLongitude, model.CoordinatesLatitude);

            supplier.DeliveryTime = NullHelper.IfNull(model.DeliveryTime, new DeliveryTime[0]).Select(m => m.ToDeliveryTime()).ToArray();

            return supplier;
        }


        public static M.Time ToTime(this TimeModel timeModel)
        {
            var time = new M.Time(timeModel.Hour, timeModel.Minute);
            return time;
        }

        public static M.DeliveryTime ToDeliveryTime(this DeliveryTime model)
        {
            var deliveryTime = new M.DeliveryTime(model.Start.ToTime(), model.End.ToTime());
            return deliveryTime;
        }

        public static DetailSupplierModel ToDetailSupplierModel(this M.Supplier model)
        {
            var supplier = new DetailSupplierModel()
            {
                Id = model.Id,
                Tel = model.Tel,
                Address = model.Address,
                Name = model.Name,
                BusinessStatus = (int)model.CurrentBusinessStatus,
                BusinessTime = model.BusinessTime.ToBusinessTime(),
                CreateDate = model.CreateDate,
                DeliveryStatus = model.CurrentDeliveryStatus,
                DeliveryTime = model.DeliveryTime.Select(m => new DeliveryTime() { Start = m.Start.ToTimeModel(), End = m.End.ToTimeModel() }).ToArray(),
                Coordinates = new Coordinates() { Longitude = model.Coordinates.Longitude, Latitude = model.Coordinates.Latitude }
            };

            return supplier;
        }

        public static BusinessTime ToBusinessTime(this M.BusinessTime model)
        {
            var btime = new BusinessTime()
            {
                Start = model.Start.ToTimeModel(),
                End = model.End.ToTimeModel()
            };
            return btime;
        }

        public static TimeModel ToTimeModel(this M.Time model)
        {
            var time = new TimeModel()
            {
                Hour = model.Hour,
                Minute = model.Minute
            };
            return time;
        }
    }
}
