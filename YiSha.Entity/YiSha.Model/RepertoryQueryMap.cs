using System;
using System.Collections.Generic;
using System.Text;
using YiSha.Entity.ProductManage;
using YiSha.Entity.WarehouseManage;

namespace YiSha.Model
{
    public class RepertoryQueryMap
    {

        public long RepertoryId { get; set; }
        public long ProductId { get; set; }
        public long SupplierId { get; set; }
        public long WarehouseId { get; set; }
        public long ProductClassId { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 商品品牌
        /// </summary>
        public string ProductBrand { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public int CosePrice { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        public int SalesPrice { get; set; }
        /// <summary>
        /// 货位置
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string ProductSpec { get; set; }
        /// <summary>
        /// 适用车型
        /// </summary>
        public string UsingModels { get; set; }
        public string ProductUnit { get; set; }

        /// <summary>
        /// 商品分类
        /// </summary>
        public string ProductClassName { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }

    }
}
