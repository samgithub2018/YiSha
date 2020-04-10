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
using YiSha.Entity.WarehouseManage;
using YiSha.Business.WarehouseManage;
using YiSha.Model.Param.WarehouseManage;

namespace YiSha.Admin.Web.Areas.WarehouseManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-29 21:50
    /// 描 述：采购明细控制器类
    /// </summary>
    [Area("WarehouseManage")]
    public class PurchaseDetailController :  BaseController
    {
        private PurchaseDetailBLL purchaseDetailBLL = new PurchaseDetailBLL();

        #region 视图功能
        [AuthorizeFilter("warehouse:purchasedetail:view")]
        public ActionResult PurchaseDetailIndex()
        {
            return View();
        }

        public ActionResult PurchaseDetailForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("warehouse:purchasedetail:search")]
        public async Task<ActionResult> GetListJson(PurchaseDetailListParam param)
        {
            TData<List<PurchaseDetailEntity>> obj = await purchaseDetailBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("warehouse:purchasedetail:search")]
        public async Task<ActionResult> GetPageListJson(PurchaseDetailListParam param, Pagination pagination)
        {
            TData<List<PurchaseDetailEntity>> obj = await purchaseDetailBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<PurchaseDetailEntity> obj = await purchaseDetailBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("warehouse:purchasedetail:add,warehouse:purchasedetail:edit")]
        public async Task<ActionResult> SaveFormJson(PurchaseDetailEntity entity)
        {
            TData<string> obj = await purchaseDetailBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("warehouse:purchasedetail:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await purchaseDetailBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
