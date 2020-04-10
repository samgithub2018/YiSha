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
    /// 日 期：2020-03-29 21:50
    /// 描 述：采购明细业务类
    /// </summary>
    public class PurchaseDetailBLL
    {
        private PurchaseDetailService purchaseDetailService = new PurchaseDetailService();

        #region 获取数据
        public async Task<TData<List<PurchaseDetailEntity>>> GetList(PurchaseDetailListParam param)
        {
            TData<List<PurchaseDetailEntity>> obj = new TData<List<PurchaseDetailEntity>>();
            obj.Result = await purchaseDetailService.GetList(param);
            obj.TotalCount = obj.Result.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<PurchaseDetailEntity>>> GetPageList(PurchaseDetailListParam param, Pagination pagination)
        {
            TData<List<PurchaseDetailEntity>> obj = new TData<List<PurchaseDetailEntity>>();
            obj.Result = await purchaseDetailService.GetPageList(param, pagination);
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<PurchaseDetailEntity>> GetEntity(long id)
        {
            TData<PurchaseDetailEntity> obj = new TData<PurchaseDetailEntity>();
            obj.Result = await purchaseDetailService.GetEntity(id);
            if (obj.Result != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(PurchaseDetailEntity entity)
        {
            TData<string> obj = new TData<string>();
            await purchaseDetailService.SaveForm(entity);
            obj.Result = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await purchaseDetailService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
