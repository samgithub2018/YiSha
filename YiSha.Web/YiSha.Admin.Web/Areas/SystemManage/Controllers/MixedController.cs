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
using YiSha.Entity.SystemManage;
using YiSha.Business.SystemManage;
using YiSha.Model.Param.SystemManage;
using YiSha.Model.Result;

namespace YiSha.Admin.Web.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-04-02 21:08
    /// 描 述：枚举维护控制器类
    /// </summary>
    [Area("SystemManage")]
    public class MixedController : BaseController
    {
        private MixedBLL mixedBLL = new MixedBLL();

        #region 视图功能
        [AuthorizeFilter("system:mixed:view")]
        public ActionResult MixedIndex()
        {
            return View();
        }

        public ActionResult MixedForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("system:mixed:search")]
        public async Task<ActionResult> GetListJson(MixedListParam param)
        {
            TData<List<MixedEntity>> obj = await mixedBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("system:mixed:search")]
        public async Task<ActionResult> GetPageListJson(MixedListParam param, Pagination pagination)
        {
            TData<List<MixedEntity>> obj = await mixedBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MixedEntity> obj = await mixedBLL.GetEntity(id);
            return Json(obj);
        }

        public async Task<ActionResult> GetZtreeListForJzlx()
        {
            TData<List<ZtreeInfo>> data = await mixedBLL.GetZtreeListForCode(new MixedListParam() { TypeCode = "settlementType" });
            return Json(data);
        }
        public async Task<ActionResult> GetZtreeListForBuyer()
        {
            TData<List<ZtreeInfo>> data = await mixedBLL.GetZtreeListForCode(new MixedListParam() { TypeCode = "cgdjzt" });
            return Json(data);
        }
        
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("system:mixed:add,system:mixed:edit")]
        public async Task<ActionResult> SaveFormJson(MixedEntity entity)
        {
            TData<string> obj = await mixedBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("system:mixed:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await mixedBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
