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
    /// 日 期：2020-03-28 17:42
    /// 描 述：采购入库服务类
    /// </summary>
    public class PurchaseService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<PurchaseEntity>> GetList(PurchaseListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<PurchaseEntity>> GetPageList(PurchaseListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<PurchaseEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<PurchaseEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(PurchaseEntity entity)
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
            await this.BaseRepository().Delete<PurchaseEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<PurchaseEntity, bool>> ListFilter(PurchaseListParam param)
        {
            var expression = LinqExtensions.True<PurchaseEntity>();
            if (param != null)
            {
            }
            expression = expression.And(a => a.BaseIsDelete == 0);
            return expression;
        }
        #endregion
    }
}
