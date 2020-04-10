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
    /// 日 期：2020-03-28 17:42
    /// 描 述：采购入库控制器类
    /// </summary>
    [Area("WarehouseManage")]
    public class PurchaseController : BaseController
    {
        private PurchaseBLL purchaseBLL = new PurchaseBLL();

        #region 视图功能
        [AuthorizeFilter("warehouse:purchase:view")]
        public ActionResult PurchaseIndex()
        {
            return View();
        }

        public ActionResult PurchaseForm()
        {
            return View();
        }

        public ActionResult PurchasePrint()
        {

            return View();
        }

        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("warehouse:purchase:search")]
        public async Task<ActionResult> GetListJson(PurchaseListParam param)
        {
            TData<List<PurchaseEntity>> obj = await purchaseBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("warehouse:purchase:search")]
        public async Task<ActionResult> GetPageListJson(PurchaseListParam param, Pagination pagination)
        {
            TData<List<PurchaseEntity>> obj = await purchaseBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<PurchaseEntity> obj = await purchaseBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("warehouse:purchase:add,warehouse:purchase:edit")]
        public async Task<ActionResult> SaveFormJson(PurchaseEntity entity)
        {
            TData<string> obj = await purchaseBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("warehouse:purchase:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await purchaseBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
