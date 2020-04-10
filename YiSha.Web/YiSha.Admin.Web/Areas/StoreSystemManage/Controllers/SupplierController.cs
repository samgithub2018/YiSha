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
using YiSha.Entity.StoreSystemManage;
using YiSha.Business.StoreSystemManage;
using YiSha.Model.Param.StoreSystemManage;
using YiSha.Model.Result;

namespace YiSha.Admin.Web.Areas.StoreSystemManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 14:41
    /// 描 述：供应商控制器类
    /// </summary>
    [Area("StoreSystemManage")]
    public class SupplierController :  BaseController
    {
        private SupplierBLL supplierBLL = new SupplierBLL();

        #region 视图功能
        [AuthorizeFilter("storesystem:supplier:view")]
        public ActionResult SupplierIndex()
        {
            return View();
        }

        public ActionResult SupplierForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("storesystem:supplier:search")]
        public async Task<ActionResult> GetListJson(SupplierListParam param)
        {
            TData<List<SupplierEntity>> obj = await supplierBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("storesystem:supplier:search")]
        public async Task<ActionResult> GetPageListJson(SupplierListParam param, Pagination pagination)
        {
            TData<List<SupplierEntity>> obj = await supplierBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<SupplierEntity> obj = await supplierBLL.GetEntity(id);
            return Json(obj);
        }

        public async Task<ActionResult> GetZtreeList()
        {
            TData<List<ZtreeInfo>> obj = await supplierBLL.GetZtreeList();
            return Json(obj);
        }

        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("storesystem:supplier:add,storesystem:supplier:edit")]
        public async Task<ActionResult> SaveFormJson(SupplierEntity entity)
        {
            TData<string> obj = await supplierBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("storesystem:supplier:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await supplierBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
