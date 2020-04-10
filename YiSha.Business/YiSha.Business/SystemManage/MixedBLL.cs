using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.SystemManage;
using YiSha.Model.Param.SystemManage;
using YiSha.Service.SystemManage;
using YiSha.Model.Result;

namespace YiSha.Business.SystemManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-04-02 21:08
    /// 描 述：枚举维护业务类
    /// </summary>
    public class MixedBLL
    {
        private MixedService mixedService = new MixedService();

        #region 获取数据
        public async Task<TData<List<MixedEntity>>> GetList(MixedListParam param)
        {
            TData<List<MixedEntity>> obj = new TData<List<MixedEntity>>();
            obj.Result = await mixedService.GetList(param);
            obj.TotalCount = obj.Result.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MixedEntity>>> GetPageList(MixedListParam param, Pagination pagination)
        {
            TData<List<MixedEntity>> obj = new TData<List<MixedEntity>>();
            obj.Result = await mixedService.GetPageList(param, pagination);
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MixedEntity>> GetEntity(long id)
        {
            TData<MixedEntity> obj = new TData<MixedEntity>();
            obj.Result = await mixedService.GetEntity(id);
            if (obj.Result != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }

        public async Task<TData<List<ZtreeInfo>>> GetZtreeListForCode(MixedListParam param)
        {
            TData<List<ZtreeInfo>> rList = new TData<List<ZtreeInfo>>();
            rList.Result = new List<ZtreeInfo>();
            List<MixedEntity> list = await mixedService.GetList(param);
            foreach (MixedEntity item in list)
            {
                rList.Result.Add(new ZtreeInfo() { id = item.Id, name = item.MixedValue });
            }
            rList.Tag = 1;
            return rList;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MixedEntity entity)
        {
            TData<string> obj = new TData<string>();
            await mixedService.SaveForm(entity);
            obj.Result = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await mixedService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
