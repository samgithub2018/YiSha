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
using YiSha.Model;

namespace YiSha.Business.WarehouseManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 15:17
    /// 描 述：库存信息业务类
    /// </summary>
    public class RepertoryBLL
    {
        private RepertoryService repertoryService = new RepertoryService();

        #region 获取数据
        public async Task<TData<List<RepertoryEntity>>> GetList(RepertoryListParam param)
        {
            TData<List<RepertoryEntity>> obj = new TData<List<RepertoryEntity>>();
            obj.Result = await repertoryService.GetList(param);
            obj.TotalCount = obj.Result.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<RepertoryEntity>>> GetPageList(RepertoryListParam param, Pagination pagination)
        {
            TData<List<RepertoryEntity>> obj = new TData<List<RepertoryEntity>>();
            obj.Result = await repertoryService.GetPageList(param, pagination);
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<RepertoryQueryMap>>> GetPageListJsonForMap()
        {
            TData<List<RepertoryQueryMap>> obj = new TData<List<RepertoryQueryMap>>();
            obj.Result = await repertoryService.GetDataForMapping();
            obj.Tag = 1;
            return obj;
        }



        public async Task<TData<RepertoryEntity>> GetEntity(long id)
        {
            TData<RepertoryEntity> obj = new TData<RepertoryEntity>();
            obj.Result = await repertoryService.GetEntity(id);
            if (obj.Result != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(RepertoryEntity entity)
        {
            TData<string> obj = new TData<string>();
            await repertoryService.SaveForm(entity);
            obj.Result = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await repertoryService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
