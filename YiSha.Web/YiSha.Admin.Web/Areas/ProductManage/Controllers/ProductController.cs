using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Entity;
using YiSha.Model;
using YiSha.Admin.Web.Controllers;
using YiSha.Entity.ProductManage;
using YiSha.Business.ProductManage;
using YiSha.Model.Param.ProductManage;

namespace YiSha.Admin.Web.Areas.ProductManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 00:05
    /// 描 述：商品信息控制器类
    /// </summary>
    [Area("ProductManage")]
    public class ProductController : BaseController
    {
        private ProductBLL productBLL = new ProductBLL();

        #region 视图功能
        [AuthorizeFilter("product:product:view")]
        public ActionResult ProductIndex()
        {
            return View();
        }

        public ActionResult ProductForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("product:product:search")]
        public async Task<ActionResult> GetListJson(ProductListParam param)
        {
            TData<List<ProductEntity>> obj = await productBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("product:product:search")]
        public async Task<ActionResult> GetPageListJson(ProductListParam param, Pagination pagination)
        {
            TData<List<ProductEntity>> obj = await productBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<ProductEntity> obj = await productBLL.GetEntity(id);
            return Json(obj);
        }

        //public async Task<string> CreateProductCode(long productClassId)
        //{
        //    string obj = await productBLL.CreateProductCode(productClassId);
        //    return obj;
        //}
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("product:product:add,product:product:edit")]
        public async Task<ActionResult> SaveFormJson(ProductEntity entity)
        {
            TData<string> obj = await productBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("product:product:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await productBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
