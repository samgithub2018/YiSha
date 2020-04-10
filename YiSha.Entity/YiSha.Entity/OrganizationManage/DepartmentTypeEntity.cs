using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.OrganizationManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-23 22:28
    /// 描 述：实体类
    /// </summary>
    [Table("sys_departmenttype")]//不能使用_type 关键字问题，框架会自动转成sys_department_type
    public class DepartmentTypeEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string TypeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string TypeName { get; set; }
    }
}
