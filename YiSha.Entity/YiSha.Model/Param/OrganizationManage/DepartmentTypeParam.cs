using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.OrganizationManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-23 20:00
    /// 描 述：部门类型实体查询类
    /// </summary>
    public class DepartmentTypeListParam
    {
        public string TypeCode { get; set; }
        public string Id { get; set; }
        public int BaseIsDelete { get; set; }
    }
}
