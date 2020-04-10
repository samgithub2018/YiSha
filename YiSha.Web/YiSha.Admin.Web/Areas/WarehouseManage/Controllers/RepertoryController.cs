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
    /// 日 期：2020-03-28 15:17
    /// 描 述：库存信息控制器类
    /// </summary>
    [Area("WarehouseManage")]
    public class RepertoryController : BaseController
    {
        private RepertoryBLL repertoryBLL = new RepertoryBLL();

        #region 视图功能
        [AuthorizeFilter("warehouse:repertory:view")]
        public ActionResult RepertoryIndex()
        {
            return View();
        }

        public ActionResult RepertoryForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("warehouse:repertory:search")]
        public async Task<ActionResult> GetListJson(RepertoryListParam param)
        {
            TData<List<RepertoryEntity>> obj = await repertoryBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("warehouse:repertory:search")]
        public async Task<ActionResult> GetPageListJson(RepertoryListParam param, Pagination pagination)
        {
            TData<List<RepertoryEntity>> obj = await repertoryBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("warehouse:repertory:search")]
        public async Task<ActionResult> GetPageListJsonForMap(RepertoryListParam param, Pagination pagination)
        {
            TData<List<RepertoryQueryMap>> obj = await repertoryBLL.GetPageListJsonForMap();
            return Json(obj);
        }


        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<RepertoryEntity> obj = await repertoryBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("warehouse:repertory:add,warehouse:repertory:edit")]
        public async Task<ActionResult> SaveFormJson(RepertoryEntity entity)
        {
            TData<string> obj = await repertoryBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("warehouse:repertory:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await repertoryBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
