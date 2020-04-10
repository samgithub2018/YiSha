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
using YiSha.Model.Result;

namespace YiSha.Admin.Web.Areas.WarehouseManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 14:08
    /// 描 述：仓库信息控制器类
    /// </summary>
    [Area("WarehouseManage")]
    public class WarehouseController :  BaseController
    {
        private WarehouseBLL warehouseBLL = new WarehouseBLL();

        #region 视图功能
        [AuthorizeFilter("warehouse:warehouse:view")]
        public ActionResult WarehouseIndex()
        {
            return View();
        }

        public ActionResult WarehouseForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("warehouse:warehouse:search")]
        public async Task<ActionResult> GetListJson(WarehouseListParam param)
        {
            TData<List<WarehouseEntity>> obj = await warehouseBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("warehouse:warehouse:search")]
        public async Task<ActionResult> GetPageListJson(WarehouseListParam param, Pagination pagination)
        {
            TData<List<WarehouseEntity>> obj = await warehouseBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<WarehouseEntity> obj = await warehouseBLL.GetEntity(id);
            return Json(obj);
        }

        public async Task<ActionResult> GetZtreeList() 
        {
            TData<List<ZtreeInfo>> obj = await warehouseBLL.GetZtreeList();
            return Json(obj);
        }

             

        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("warehouse:warehouse:add,warehouse:warehouse:edit")]
        public async Task<ActionResult> SaveFormJson(WarehouseEntity entity)
        {
            TData<string> obj = await warehouseBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("warehouse:warehouse:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await warehouseBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
