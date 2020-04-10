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
using YiSha.Entity.OrganizationManage;
using YiSha.Model.Param.OrganizationManage;
using YiSha.Service.Base;

namespace YiSha.Service.OrganizationManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-23 22:28
    /// 描 述：服务类
    /// </summary>
    public class DepartmentTypeService : BaseService
    {
        #region 获取数据
        public async Task<List<DepartmentTypeEntity>> GetList(DepartmentTypeListParam param)
        {
            //var r = await base.GetEntitys<DepartmentTypeListParam, DepartmentTypeEntity>(param);

            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<DepartmentTypeEntity>> GetPageList(DepartmentTypeListParam param, Pagination pagination)
        {
            //param.Id = "162336077758074880";
            //var r = await base.GetEntitys<DepartmentTypeListParam, DepartmentTypeEntity>(param);

            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<DepartmentTypeEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<DepartmentTypeEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(DepartmentTypeEntity entity)
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
            await this.BaseRepository().Delete<DepartmentTypeEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<DepartmentTypeEntity, bool>> ListFilter(DepartmentTypeListParam param)
        {
            var expression = LinqExtensions.True<DepartmentTypeEntity>();
            if (param != null)
            {
                if (!param.TypeCode.IsEmpty())
                {
                    expression = expression.And(d => d.TypeCode == param.TypeCode);
                }
                expression = expression.And(d => d.BaseIsDelete == 0);
            }
            return expression;
        }
        #endregion
    }
}
