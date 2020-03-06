using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsOnlineServices")]
    public class OnlineService : FullAuditedEntity
    {
        public const int MaxNameLength = 100;
        public const int MaxDescLength = 500;
        /// <summary>
        /// 多語言key：對應多語言名稱
        /// </summary>
        public virtual Guid Name { get; set; }
        /// <summary>
        /// 默認顯示名稱，多語言沒有維護時顯示
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string DisplayName { get; set; }
        /// <summary>
        /// 類型：1 qq ,2：外部客服： 3：Wechat：必填QrCode  4，MSN，5：Skype
        /// </summary>
        public virtual int TypeId { get; set; }
        /// <summary>
        /// 訪問地址
        /// </summary>
        [StringLength(MaxDescLength)]
        public virtual string TargetURL { get; set; }
        /// <summary>
        /// 圖標地址
        /// </summary>
        [StringLength(MaxDescLength)]
        public virtual string LogoSrc { get; set; }
        /// <summary>
        ///排序  越小越靠前顯示
        /// </summary>
        public virtual int OrderNo { get; set; }
        //qq客服
        [StringLength(MaxNameLength)]
        public virtual string QQ1 { get; set; }
        [StringLength(MaxNameLength)]
        public virtual string QQ2 { get; set; }
        [StringLength(MaxNameLength)]
        public virtual string QQ3 { get; set; }

        [StringLength(MaxNameLength)]
        public virtual string MSN { get; set; }
        /// <summary>
        /// 微信客服，二維碼
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string Wechat1 { get; set; }
        [StringLength(MaxNameLength)]
        public virtual string Wechat2 { get; set; }
        [StringLength(MaxNameLength)]
        public virtual string QrCode1 { get; set; }
        [StringLength(MaxNameLength)]
        public virtual string QrCode2 { get; set; }
        [StringLength(MaxNameLength)]
        public virtual string Skype { get; set; }

    }
}
