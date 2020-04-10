using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.SystemManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-04-02 21:08
    /// 描 述：枚举维护实体类
    /// </summary>
    [Table("sys_mixed")]
    public class MixedEntity : BaseExtensionEntity
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string MixedValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string MixedCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? MixedOrder { get; set; }
    }
}
