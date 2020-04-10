using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.ProductManage;
using YiSha.Model.Param.ProductManage;
using YiSha.Service.ProductManage;
using YiSha.Model.Result;

namespace YiSha.Business.ProductManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-27 21:56
    /// 描 述：业务类
    /// </summary>
    public class ProductClassBLL
    {
        private ProductClassService productClassService = new ProductClassService();

        #region 获取数据
        public async Task<TData<List<ProductClassEntity>>> GetList(ProductClassListParam param)
        {
            TData<List<ProductClassEntity>> obj = new TData<List<ProductClassEntity>>();
            obj.Result = await productClassService.GetList(param);
            obj.TotalCount = obj.Result.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ProductClassEntity>>> GetPageList(ProductClassListParam param, Pagination pagination)
        {
            TData<List<ProductClassEntity>> obj = new TData<List<ProductClassEntity>>();
            obj.Result = await productClassService.GetPageList(param, pagination);
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<ProductClassEntity>> GetEntity(long id)
        {
            TData<ProductClassEntity> obj = new TData<ProductClassEntity>();
            obj.Result = await productClassService.GetEntity(id);
            if (obj.Result != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }

        public async Task<TData<List<ZtreeInfo>>> GetZeeInfoJson()
        {
            TData<List<ZtreeInfo>> rList = new TData<List<ZtreeInfo>>() { Result = new List<ZtreeInfo>() };

            var list = await productClassService.GetList(null);
            foreach (var item in list)
            {
                rList.Result.Add(new ZtreeInfo() { id = item.Id, name = item.Name });
            }
            return rList;
        }

        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(ProductClassEntity entity)
        {
            TData<string> obj = new TData<string>();
            await productClassService.SaveForm(entity);
            obj.Result = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await productClassService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
