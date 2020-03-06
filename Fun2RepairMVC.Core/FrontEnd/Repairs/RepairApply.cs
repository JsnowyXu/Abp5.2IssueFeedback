using Abp.Domain.Entities.Auditing;
using Fun2RepairMVC.Common.Extras;
using Fun2RepairMVC.Common.PublicCode;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.Repairs
{
    [Table("rpRepairApply")]
    public class RepairApply:FullAuditedEntity<long>
    {
        //報修單號：自動生成，日期流水碼 R202001010009
        [StringLength(50)]
        public virtual string ApplyCode { get; set; }
        //報修原因
        [StringLength(500)]
        public virtual string Reason { get; set; }
       

        public virtual string StatusCode { get; set; }
        public virtual bool IsPay { get; set; }

        #region //物流

        //寄件物流碼：正向物流
        [StringLength(50)]
        public virtual string DeliveryCode { get; set; }
        //收件物流碼：逆向物流
        [StringLength(50)]
        public virtual string ReceiveCode { get; set; }
        [StringLength(50)]
        //維修中心跑過來的報修單號 1:1 本系統報修單號
        public virtual string RepairCode { get; set; }
        #endregion

        #region //產品信息
        [Required]
        [StringLength(15)]
        public virtual string IMEI { get; set; }
        [StringLength(20)]
        public virtual string Model { get; set; }
        [StringLength(20)]
        public virtual string Brand { get; set; }

        //附件圖片
        public virtual ICollection<RepairAttachment> RepairAttachments { get; set; }
        #endregion

        #region //寄件人信息
        [StringLength(50)]
        public virtual string Name { get; set; }
        [StringLength(20)]
        public virtual string Phone { get; set; }
        [StringLength(100)]
        public virtual string Email { get; set; }
        public virtual int? ProvinceId { get; set; }
        public virtual int? CityId { get; set; }
        public virtual int? TownId { get; set; }
        [StringLength(200)]
        public virtual string DetailAddress { get; set; }
        #endregion

        #region //收件人信息
        [StringLength(50)]
        public virtual string ReceiverName { get; set; }
        [StringLength(20)]
        public virtual string ReceiverPhone { get; set; }
        [StringLength(100)]
        public virtual string ReceiverEmail { get; set; }
        public virtual int? ReceiverProvinceId { get; set; }
        public virtual int? ReceiverCityId { get; set; }
        public virtual int? ReceiverTownId { get; set; }
        [StringLength(200)]
        public virtual string ReceiverDetailAddress { get; set; }
        #endregion

        #region 報價信息
        [StringLength(100)]
        public virtual string CheckChargeName { get; set; }
        //檢測費用
        public virtual decimal? CheckPrice { get; set; }
        [StringLength(100)]
        public virtual string RepairChargeName { get; set; }
        //維修費用
        public virtual decimal? RepairPrice { get; set; }

        public virtual decimal? TotalPrice { get; set; }
        //報價備註
        [StringLength(500)]
        public virtual string RepairMemo { get; set; }
        #endregion
        #region 支付及發票信息
        //付款方式:ATM櫃員機
        public virtual int? PayTypeId { get; set; }
        //用戶說是一個虛擬賬號，先保留
        [StringLength(50)]
        public virtual string VirtualAccount { get; set; }
        //發票類型
        public virtual int? InvoiceType { get; set; }
        //公司發票專用
        public virtual string SystemCode { get; set; }
        public virtual string CompanyTitle { get; set; }

        //個人發票類型：綠界會員載具，手機載具，自然人憑證，索取紙本
        public virtual int PersonalInvoice { get; set; }
        //手機載具動態碼
        [StringLength(50)]
        public virtual string PhoneCode { get; set; }
        [StringLength(50)]
        //自然人憑證嗎
        public virtual string CertificateCode { get; set; }

        //發票收貨地址
        public virtual int? InvoiceProvinceId { get; set; }
        public virtual int? InvoiceCityId { get; set; }
        public virtual int? InvoiceTownId { get; set; }
        [StringLength(200)]
        public virtual string InvoiceDetailAddress { get; set; }
        //支付備註
        [StringLength(500)]
        public virtual string PayMemo { get; set; }

        #endregion

        [ForeignKey("TownId")]
        public virtual Town Town { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        [ForeignKey("ReceiverTownId")]
        public virtual Town ReceiverTown { get; set; }
        [ForeignKey("ReceiverCityId")]
        public virtual City ReceiverCity { get; set; }
        [ForeignKey("ReceiverProvinceId")]
        public virtual Province ReceiverProvince { get; set; }

        [ForeignKey("InvoiceTownId")]
        public virtual Town InvoiceTown { get; set; }
        [ForeignKey("InvoiceCityId")]
        public virtual City InvoiceCity { get; set; }
        [ForeignKey("InvoiceProvinceId")]
        public virtual Province InvoiceProvince { get; set; }



    }
}
