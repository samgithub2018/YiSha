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
using YiSha.Web.Code;

namespace YiSha.Service.WarehouseManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 14:08
    /// 描 述：仓库信息服务类
    /// </summary>
    public class WarehouseService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<WarehouseEntity>> GetList(WarehouseListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<WarehouseEntity>> GetPageList(WarehouseListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<WarehouseEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<WarehouseEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(WarehouseEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                entity.DepartmentId = Operator.Instance.Current().Result.DepartmentstoreId;
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
            await this.BaseRepository().Delete<WarehouseEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<WarehouseEntity, bool>> ListFilter(WarehouseListParam param)
        {
            var expression = LinqExtensions.True<WarehouseEntity>();
            if (param != null)
            {
            }
            long storeid = Operator.Instance.Current().Result.DepartmentstoreId.ParseToLong();
            expression = expression.And(d => d.BaseIsDelete == 0);
            expression = expression.And(d => d.DepartmentId == storeid);
            return expression;
        }
        #endregion
    }
}
