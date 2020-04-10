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
using YiSha.Entity.OrganizationManage;
using YiSha.Business.OrganizationManage;
using YiSha.Model.Param.OrganizationManage;

namespace YiSha.Admin.Web.Areas.OrganizationManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-23 22:28
    /// 描 述：控制器类
    /// </summary>
    [Area("OrganizationManage")]
    public class DepartmentTypeController :  BaseController
    {
        private DepartmentTypeBLL departmentTypeBLL = new DepartmentTypeBLL();

        #region 视图功能
        [AuthorizeFilter("organization:departmenttype:view")]
        public ActionResult DepartmentTypeIndex()
        {
            return View();
        }

        public ActionResult DepartmentTypeForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("organization:departmenttype:search")]
        public async Task<ActionResult> GetListJson(DepartmentTypeListParam param)
        {
            TData<List<DepartmentTypeEntity>> obj = await departmentTypeBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("organization:departmenttype:search")]
        public async Task<ActionResult> GetPageListJson(DepartmentTypeListParam param, Pagination pagination)
        {
            TData<List<DepartmentTypeEntity>> obj = await departmentTypeBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<DepartmentTypeEntity> obj = await departmentTypeBLL.GetEntity(id);
            return Json(obj);
        }

        public async Task<IActionResult> GetDepartmentTypeSelectListJson(DepartmentTypeListParam param)
        {
            var objList = await departmentTypeBLL.GetDepartmentTypeSelectList(param);
            return Json(objList);
        }

        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("organization:departmenttype:add,organization:departmenttype:edit")]
        public async Task<ActionResult> SaveFormJson(DepartmentTypeEntity entity)
        {
            TData<string> obj = await departmentTypeBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("organization:departmenttype:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await departmentTypeBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
