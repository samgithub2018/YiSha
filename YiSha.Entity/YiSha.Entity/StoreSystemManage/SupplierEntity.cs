using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.StoreSystemManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 14:41
    /// 描 述：供应商实体类
    /// </summary>
    [Table("supplier")]
    public class SupplierEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BankCard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BankName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Contact { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? DepartmentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Fixphone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Reamrk { get; set; }
    }
}
