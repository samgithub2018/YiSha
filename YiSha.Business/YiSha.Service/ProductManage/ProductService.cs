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
using YiSha.Entity.ProductManage;
using YiSha.Model.Param.ProductManage;
using YiSha.Web.Code;

namespace YiSha.Service.ProductManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 00:05
    /// 描 述：商品信息服务类
    /// </summary>
    public class ProductService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<ProductEntity>> GetList(ProductListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<ProductEntity>> GetPageList(ProductListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<ProductEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<ProductEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ProductEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                entity.DeparmentId = Operator.Instance.Current().Result.DepartmentstoreId;
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
            await this.BaseRepository().Delete<ProductEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<ProductEntity, bool>> ListFilter(ProductListParam param)
        {
            var expression = LinqExtensions.True<ProductEntity>();
            if (param != null)
            {
            }
            long storeid = Operator.Instance.Current().Result.DepartmentstoreId.ParseToLong();
            expression = expression.And(d => d.BaseIsDelete == 0);
            expression = expression.And(d => d.DeparmentId == storeid);
            return expression;
        }
        #endregion
    }
}
