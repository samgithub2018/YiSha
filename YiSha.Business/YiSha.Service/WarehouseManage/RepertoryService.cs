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
using YiSha.Model;

namespace YiSha.Service.WarehouseManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 15:17
    /// 描 述：库存信息服务类
    /// </summary>
    public class RepertoryService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<RepertoryEntity>> GetList(RepertoryListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<RepertoryEntity>> GetPageList(RepertoryListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<RepertoryEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<RepertoryEntity>(id);
        }

        public async Task<List<Model.RepertoryQueryMap>> GetDataForMapping()
        {
            string sql = @"select
                w.name as WarehouseName,
                p.name as ProductName,
                p.code as ProductCode,
                pc.name as ProductClassName,
                p.spec as ProductSpec,
                p.using_models as UsingModels,
                p.unit as ProductUnit,
                p.brand as ProductBrand,
                r.quantity as Quantity,
                r.coseprice as CosePrice,
                p.sales_price as SalesPrice,
                s.name as SupplierName,
                r.location as Location,
                r.id as RepertoryId,
                p.id as ProductClassId,
                pc.id as ProductId,
                s.id as SupplierId,
                w.id as WarehouseId
                from repertory r 
                join product p on r.product_id = p.id
                join product_class pc on pc.id = p.product_class_id
                join supplier s on s.id = r.supplier_id
                join warehouse w on w.id = r.warehourse_id";
            var r = await BaseRepository().FindList<RepertoryQueryMap>(sql);
            return r.ToList();
        }

        #endregion

        #region 提交数据
        public async Task SaveForm(RepertoryEntity entity)
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
            await this.BaseRepository().Delete<RepertoryEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<RepertoryEntity, bool>> ListFilter(RepertoryListParam param)
        {
            var expression = LinqExtensions.True<RepertoryEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
