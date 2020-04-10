using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.ProductManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-28 00:05
    /// 描 述：商品信息实体类
    /// </summary>
    [Table("product")]
    public class ProductEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? DeparmentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ProductClassId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Spec { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string UsingModels { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Brand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Barcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? CostPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? SalesPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? TradePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? MinInventory { get; set; }
    }
}
