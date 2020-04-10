using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.StoreSystemManage;
using YiSha.Model.Param.StoreSystemManage;
using YiSha.Service.StoreSystemManage;
using YiSha.Web.Code;
using YiSha.Model.Result;

namespace YiSha.Business.StoreSystemManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 14:41
    /// 描 述：供应商业务类
    /// </summary>
    public class SupplierBLL
    {
        private SupplierService supplierService = new SupplierService();

        #region 获取数据
        public async Task<TData<List<SupplierEntity>>> GetList(SupplierListParam param)
        {
            TData<List<SupplierEntity>> obj = new TData<List<SupplierEntity>>();
            obj.Result = await supplierService.GetList(param);
            obj.TotalCount = obj.Result.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SupplierEntity>>> GetPageList(SupplierListParam param, Pagination pagination)
        {
            TData<List<SupplierEntity>> obj = new TData<List<SupplierEntity>>();
            obj.Result = await supplierService.GetPageList(param, pagination);
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<SupplierEntity>> GetEntity(long id)
        {
            TData<SupplierEntity> obj = new TData<SupplierEntity>();
            obj.Result = await supplierService.GetEntity(id);
            if (obj.Result != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }

        public async Task<TData<List<ZtreeInfo>>> GetZtreeList()
        {
            TData<List<ZtreeInfo>> rList = new TData<List<ZtreeInfo>>();
            rList.Result = new List<ZtreeInfo>();
            List<SupplierEntity> list = await supplierService.GetList(null);
            foreach (SupplierEntity item in list)
            {
                rList.Result.Add(new ZtreeInfo() { name = item.Name, id = item.Id });
            }
            rList.Tag = 1;
            return rList;
        }


        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(SupplierEntity entity)
        {
            TData<string> obj = new TData<string>();
            entity.DepartmentId = Operator.Instance.Current().Result.DepartmentstoreId;
            await supplierService.SaveForm(entity);
            obj.Result = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await supplierService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
