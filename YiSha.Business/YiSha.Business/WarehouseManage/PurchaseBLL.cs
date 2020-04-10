using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.WarehouseManage;
using YiSha.Model.Param.WarehouseManage;
using YiSha.Service.WarehouseManage;

namespace YiSha.Business.WarehouseManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 17:42
    /// 描 述：采购入库业务类
    /// </summary>
    public class PurchaseBLL
    {
        private PurchaseService purchaseService = new PurchaseService();

        #region 获取数据
        public async Task<TData<List<PurchaseEntity>>> GetList(PurchaseListParam param)
        {
            TData<List<PurchaseEntity>> obj = new TData<List<PurchaseEntity>>();
            obj.Result = await purchaseService.GetList(param);
            obj.TotalCount = obj.Result.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<PurchaseEntity>>> GetPageList(PurchaseListParam param, Pagination pagination)
        {
            TData<List<PurchaseEntity>> obj = new TData<List<PurchaseEntity>>();
            obj.Result = await purchaseService.GetPageList(param, pagination);
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<PurchaseEntity>> GetEntity(long id)
        {
            TData<PurchaseEntity> obj = new TData<PurchaseEntity>();
            obj.Result = await purchaseService.GetEntity(id);
            if (obj.Result != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(PurchaseEntity entity)
        {
            TData<string> obj = new TData<string>();
            await purchaseService.SaveForm(entity);
            obj.Result = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await purchaseService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
