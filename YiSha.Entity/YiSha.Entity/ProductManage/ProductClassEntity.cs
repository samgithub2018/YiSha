using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.ProductManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-27 21:56
    /// 描 述：实体类
    /// </summary>
    [Table("product_class")]
    public class ProductClassEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? DepartmentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Code { get; set; }
    }
}
