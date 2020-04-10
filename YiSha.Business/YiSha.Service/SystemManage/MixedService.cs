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
using YiSha.Entity.SystemManage;
using YiSha.Model.Param.SystemManage;

namespace YiSha.Service.SystemManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-04-02 21:08
    /// 描 述：枚举维护服务类
    /// </summary>
    public class MixedService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<MixedEntity>> GetList(MixedListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<MixedEntity>> GetPageList(MixedListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<MixedEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<MixedEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(MixedEntity entity)
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
            await this.BaseRepository().Delete<MixedEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<MixedEntity, bool>> ListFilter(MixedListParam param)
        {
            var expression = LinqExtensions.True<MixedEntity>();
            if (param != null)
            {
                if (!param.TypeName.IsEmpty())
                {
                    expression = expression.And(a => a.TypeName == param.TypeName);
                }
                if (!param.TypeCode.IsEmpty())
                {
                    expression = expression.And(a => a.TypeCode == param.TypeCode);
                }
            }
            expression = expression.And(a => a.BaseIsDelete == 0);
            return expression;
        }
        #endregion
    }
}
