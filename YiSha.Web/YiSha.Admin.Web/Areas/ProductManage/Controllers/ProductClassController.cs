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
using YiSha.Model.Result;

namespace YiSha.Admin.Web.Areas.ProductManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-27 21:56
    /// 描 述：控制器类
    /// </summary>
    [Area("ProductManage")]
    public class ProductClassController :  BaseController
    {
        private ProductClassBLL productClassBLL = new ProductClassBLL();

        #region 视图功能
        [AuthorizeFilter("product:productclass:view")]
        public ActionResult ProductClassIndex()
        {
            return View();
        }

        public ActionResult ProductClassForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("product:productclass:search")]
        public async Task<ActionResult> GetListJson(ProductClassListParam param)
        {
            TData<List<ProductClassEntity>> obj = await productClassBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("product:productclass:search")]
        public async Task<ActionResult> GetPageListJson(ProductClassListParam param, Pagination pagination)
        {
            TData<List<ProductClassEntity>> obj = await productClassBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<ProductClassEntity> obj = await productClassBLL.GetEntity(id);
            return Json(obj);
        }

        public async Task<ActionResult> GetZtreeInfoJson() 
        {
            TData<List<ZtreeInfo>> obj = await productClassBLL.GetZeeInfoJson();
            return Json(obj);
        }

        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("product:productclass:add,product:productclass:edit")]
        public async Task<ActionResult> SaveFormJson(ProductClassEntity entity)
        {
            TData<string> obj = await productClassBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("product:productclass:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await productClassBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
