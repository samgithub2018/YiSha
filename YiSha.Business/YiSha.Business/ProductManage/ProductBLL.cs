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

namespace YiSha.Business.ProductManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 00:05
    /// 描 述：商品信息业务类
    /// </summary>
    public class ProductBLL
    {
        private ProductService productService = new ProductService();
        private ProductClassService productClassService = new ProductClassService();

        #region 获取数据
        public async Task<TData<List<ProductEntity>>> GetList(ProductListParam param)
        {
            TData<List<ProductEntity>> obj = new TData<List<ProductEntity>>();
            obj.Result = await productService.GetList(param);
            obj.TotalCount = obj.Result.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ProductEntity>>> GetPageList(ProductListParam param, Pagination pagination)
        {
            TData<List<ProductEntity>> obj = new TData<List<ProductEntity>>();
            obj.Result = await productService.GetPageList(param, pagination);
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<ProductEntity>> GetEntity(long id)
        {
            TData<ProductEntity> obj = new TData<ProductEntity>();
            obj.Result = await productService.GetEntity(id);
            if (obj.Result != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }


        private async Task<string> CreateProductCode(long? productClassId)
        {
            long id = productClassId.ParseToLong();
            ProductClassEntity productClassEntity = await this.productClassService.GetEntity(id);
            string rCode = string.Format("{0}{1}", productClassEntity.Code, DateTime.Now.ToString("HHmmssms"));
            return rCode;

        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(ProductEntity entity)
        {
            TData<string> obj = new TData<string>();
            if (entity.Id == 0)
            {
                entity.Code = await this.CreateProductCode(entity.ProductClassId);
            }
            await productService.SaveForm(entity);
            obj.Result = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await productService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
