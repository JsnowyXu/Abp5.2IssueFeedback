using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Fun2RepairMVC.Common.PublicCode;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsColumns")]
    public class Column : FullAuditedEntity
    {
        public const int MaxCodeLength = 50;
        public const int MaxNameLength = 100;
        public const int MaxDescLength = 500;

        //欄位代碼，多語言代碼
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }

        //默認顯示名稱，多語言沒有維護時顯示
        [StringLength(MaxNameLength)]
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// 所屬模塊
        /// </summary>
        public virtual int ModuleId { get; set; }

        /// <summary>
        /// 排序，越小越靠前
        /// </summary>
        public virtual int OrderNo { get; set; }

        /// <summary>
        /// 是否是外部模塊
        /// </summary>
        public virtual bool IsExternal { get; set; }

        /// <summary>
        /// 欄目顯示方式 0:頭部導航 1:尾部導航 2:都顯示 3：左側顯示 
        /// </summary>
        public virtual int ShowTypeId { get; set; }

        /// <summary>
        /// 上級欄目Id
        /// </summary>
        public virtual int? BigClassId { get; set; }

        /// <summary>
        /// 欄目級別：1一級欄目，2二級欄目，3三級欄目
        /// </summary>
        public virtual int ClassType { get; set; }

        /// <summary>
        /// 靜態頁面名稱：開啟偽靜態使用
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string StaticName { get; set; }

        /// <summary>
        /// 訪問路徑
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string TargetUrl { get; set; }

        /// <summary>
        /// ""：當前窗體打開
        /// "target='_blank'":新窗體打開
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string TargetWindow { get; set; }
        /// <summary>
        ///SEO:頁面Title
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string SEOTitle { get; set; }
        /// <summary>
        /// SEO：關鍵字
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string SEOKeywords { get; set; }
        /// <summary>
        /// SEO：meta 描述
        /// </summary>
        [StringLength(MaxDescLength)]
        public virtual string SEODescription { get; set; }

        /// <summary>
        /// 列表页排序方式：1：更新时间2：发布时间3：点击次数4：ID倒序5：ID顺序
        /// </summary>
        public virtual int OrderType { get; set; }
        /// <summary>
        /// 外部模塊鏈接：只限外部模塊
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string OutUrl { get; set; }
        /// <summary>
        ///  是否需要權限驗證
        /// </summary>
        public virtual bool RequiresAuthentication { get; set; }
        /// <summary>
        /// 欄目圖片
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string ColumnImg { get; set; }

        /// <summary>
        /// 標識圖片：用於首頁
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string IndexImg { get; set; }

        /// <summary>
        /// 是否允許添加內容，非簡介模塊不允許添加內容
        /// </summary>
        public virtual bool IsContent { get; set; }

        /// <summary>
        /// 1：顯示   0：不顯示
        /// </summary>
        public virtual bool IsDisplay { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public virtual bool IsActive { get; set; }
        //欄目圖標
        [StringLength(MaxCodeLength)]
        public virtual string Icon { get; set; }
        /// <summary>
        /// 不分租戶，默認為3
        /// </summary>
        public Abp.MultiTenancy.MultiTenancySides MultiTenancySides { get; set; }

        /// <summary>
        /// Banner 顯示方式  0：單圖默認  1：大圖輪播 2:關閉
        /// </summary>
        public virtual int? BannerTypeId { get; set; }

        [ForeignKey("BannerTypeId")]
        public virtual Parameter BannerType { get; set; }

        [ForeignKey("ShowTypeId")]
        public virtual Parameter ShowType { get; set; }
        /// <summary>
        ///banner 高度
        /// </summary>
        public virtual int Height { get; set; }

        //外鍵關係
        /// <summary>
        /// 模塊外鍵
        /// </summary>
        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }
        /// <summary>
        /// 上級欄目外鍵
        /// </summary>
        [ForeignKey("BigClassId")]
        public virtual Column BigClass { get; set; }

        public virtual ICollection<Column> Children { get; set; }
        public virtual ICollection<ColumnBanner> Banners { get; set; }

    }
}
