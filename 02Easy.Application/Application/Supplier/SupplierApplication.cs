using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Application.Application.Supplier.AddDomainEvents;
using Easy.Application.Models;
using Easy.Domain.Application;
using Easy.Application.Models.Supplier;
using M=Easy.Domain.Model;

namespace Easy.Application.Application
{
    /// <summary>
    /// 餐厅应用服务
    /// </summary>
    public class SupplierApplication:BaseApplication
    {
        /// <summary>
        /// 创建餐厅
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IReturn Add(AddSupplierModel model)
        {
            M.Supplier supplier = model.ToSupplier();
            if (supplier.Validate())
            {
                M.RepositoryRegistry.Supplier.Add(supplier);

                return this.WriteAndPublishDomainEvent<M.Supplier,AddDomainEvent>("Add", supplier, new AddDomainEvent(supplier.Id,supplier.Name,supplier.Tel,supplier.Address,supplier.CreateDate));
            }
            return this.Write("Add", supplier);
        }

        /// <summary>
        /// 获取餐厅信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IReturn GetById(int id)
        {
            M.Supplier supplier= M.RepositoryRegistry.Supplier.FindBy(id);
            return this.Write("GetById", supplier);
        }

        /// <summary>
        /// 删除餐厅信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IReturn Remove(int id)
        {
            var supplier= M.RepositoryRegistry.Supplier.FindBy(id);
            return this.Write("Remove", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IReturn RemoveAll()
        {
            M.RepositoryRegistry.Supplier.RemoveAll();

            return this.Write("RemoveAll", true);
        }

        /// <summary>
        /// 查询一批餐厅详细信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IReturn FindByIds(int[] ids)
        {
             List<M.Supplier> list= M.RepositoryRegistry.Supplier.FindByIds(ids).ToList();
             return this.Write("FindByIds", list);
        }

        /// <summary>
        /// 更新餐厅信息
        /// </summary>
        /// <param name="supplierId">餐厅ID</param>
        /// <param name="model">餐厅信息</param>
        /// <returns></returns>
        public IReturn Update(int supplierId,AddSupplierModel model)
        {
            M.Supplier supplier= M.RepositoryRegistry.Supplier.FindBy(supplierId);
            if (supplier!=null)
            {
                model.ToSupplier(supplier);
                if (supplier.Validate())
                {
                    M.RepositoryRegistry.Supplier.Update(supplier);
                }
            }
            return this.Write("Update", supplier);
        }


        /// <summary>
        /// 查询餐厅列表
        /// </summary>
        /// <param name="pageSize">每页返回记录数</param>
        /// <param name="pageIndex">页码 ，起始页=1</param>
        /// <returns></returns>
        public IReturn Select(int pageSize=20,int pageIndex=1)
        {
            int totalRows = 0;
            List<M.Supplier> list= M.RepositoryRegistry.Supplier.Select(pageSize, pageIndex, out totalRows).ToList();

            return this.Write("Select", new PageList<M.Supplier>() {TotalRows = totalRows, Collections = list});
        }

        /// <summary>
        /// 开始营业
        /// </summary>
        /// <param name="id">餐厅ID</param>
        /// <returns></returns>
        public IReturn Open(int id)
        {
            M.Supplier supplier = M.RepositoryRegistry.Supplier.FindBy(id);
            if (supplier!=null)
            {
                supplier.Open();
                M.RepositoryRegistry.Supplier.Update(supplier);
            }
            return this.Write("Open", supplier);
        }

        /// <summary>
        /// 停止营业
        /// </summary>
        /// <param name="id">餐厅ID</param>
        /// <returns></returns>
        public IReturn Close(int id)
        {
            M.Supplier supplier= M.RepositoryRegistry.Supplier.FindBy(id);
            if (supplier!=null)
            {
                supplier.Close();
                M.RepositoryRegistry.Supplier.Update(supplier);
            }
            return this.Write("Close", supplier);
        }

    }
}
