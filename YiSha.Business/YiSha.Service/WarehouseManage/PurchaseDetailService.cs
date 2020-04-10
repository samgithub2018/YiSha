using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Data;
using YiSha.Data.Repository;
using YiSha.Entity.WarehouseManage;
using YiSha.Model.Param.WarehouseManage;

namespace YiSha.Service.WarehouseManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-29 21:50
    /// 描 述：采购明细服务类
    /// </summary>
    public class PurchaseDetailService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<PurchaseDetailEntity>> GetList(PurchaseDetailListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<PurchaseDetailEntity>> GetPageList(PurchaseDetailListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<PurchaseDetailEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<PurchaseDetailEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(PurchaseDetailEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                await entity.Modify();
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<PurchaseDetailEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<PurchaseDetailEntity, bool>> ListFilter(PurchaseDetailListParam param)
        {
            var expression = LinqExtensions.True<PurchaseDetailEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
