using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Easy.Domain.Model;
using Easy.Domain.RepositoryFramework;
using Easy.Public;


namespace Easy.Infrastructure.Repository
{
    public class SupperRepository:ISupplierRepository,IDao
    {
        private static readonly EntityPropertyHelper<Supplier> propertyHelper = new EntityPropertyHelper<Supplier>();
        public IEnumerable<Supplier> Select(int pageSize, int pageIndex, out int totalRows)
        {
            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            if (pageSize <= 0 || pageSize > 100)
            {
                pageSize = 100;
            }

            using (var conn = DataBase.Open())
            {
                var tuple = Sql.Select(pageIndex, pageSize);

                SqlMapper.GridReader reader = conn.QueryMultiple(tuple.Item1 + tuple.Item2, (object)tuple.Item3);

                var result = reader.Read<object>().First() as IDictionary<string, object>;
                totalRows = Convert.ToInt32(result["Count"]);

                return reader.Read<Supplier, object, object, object, Supplier>(Sql.SelectConvert, splitOn: "split");
            }
        }

        public IEnumerable<Supplier> FindByIds(int[] supplierIds)
        {
            if (supplierIds == null || supplierIds.Length == 0)
            {
                return new List<Supplier>(0);
            }

            using (var conn = DataBase.Open())
            {
                string sql = Sql.FindByIdsSql(supplierIds);
                return conn.Query<Supplier, object, object, object, Supplier>(sql, Sql.SelectConvert, splitOn: "split");
            }
        }

        public void Add(Supplier item)
        {
            using (var conn=DataBase.Open())
            {
                var tuple = Sql.AddSql(item);
                int id=conn.ExecuteScalar<int>(tuple.Item1, (object) tuple.Item2);
                propertyHelper.SetValue(m=>m.Id,item,id);
            }
        }

        public IList<Supplier> FindAll()
        {
            throw new NotImplementedException();
        }

        public Supplier FindBy(int key)
        {
            using (var conn=DataBase.Open())
            {
                var tuple = Sql.FindByIdSql(key);
                return conn.Query<Supplier, object, object, object, Supplier>(tuple.Item1, Sql.SelectConvert, (object)tuple.Item2, splitOn: "split").SingleOrDefault();
            }
        }

        public void Remove(Supplier item)
        {
            using (var conn=DataBase.Open())
            {
                var tuple = Sql.Remove(item.Id);
                conn.Execute(tuple.Item1, (object) tuple.Item2);
            }
        }

        public void RemoveAll()
        {
            using (var conn=DataBase.Open())
            {
                string sql = Sql.RemoveAllSql();
                conn.Execute(sql);
            }
        }

        public void Update(Supplier item)
        {
            using (var conn=DataBase.Open())
            {
                var tuple = Sql.UpdateSql(item);
                conn.Execute(tuple.Item1, (object) tuple.Item2);
            }
        }
    }
}
