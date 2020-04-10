using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.WarehouseManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-03-29 21:50
    /// 描 述：采购明细实体类
    /// </summary>
    [Table("purchase_detail")]
    public class PurchaseDetailEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 门店关联
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? DepartmentId { get; set; }
        /// <summary>
        /// 采购商品
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ProductId { get; set; }
        /// <summary>
        /// 结算时间
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? SettlementTime { get; set; }
    }
}
