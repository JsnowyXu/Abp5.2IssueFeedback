using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsArticles")]
    public class Article : FullAuditedEntity<long>
    {
        public const int MaxCodeLength = 80;
        public const int MaxNameLength = 200;
        public const int MaxDescLength = 500;
        /// <summary>
        /// 文章標題
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string Title { get; set; }
        /// <summary>
        /// 文章簡介
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string Brief { get; set; }
        [Column(TypeName = "ntext")]
        public virtual string Content { get; set; }
        /// <summary>
        /// SEO：Title
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string CTitle { get; set; }
        /// <summary>
        /// SEO:關鍵字
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string Keywords { get; set; }
        /// <summary>
        /// SEO:描述
        /// </summary>
        [StringLength(MaxCodeLength)]
        public virtual string Description { get; set; }
        /// <summary>
        /// 一級欄目
        /// </summary>
        public virtual int? ColumnId1 { get; set; }
        /// <summary>
        /// 二級欄目
        /// </summary>
        public virtual int? ColumnId2 { get; set; }
        /// <summary>
        /// 三級欄目
        /// </summary>
        public virtual int? ColumnId3 { get; set; }
        //排序
        public virtual int OrderNo { get; set; }
        /// <summary>
        /// 縮略圖
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string ThumbUrl { get; set; }
        /// <summary>
        /// 原圖路徑，用於圖片列表
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string ImgUrl { get; set; }
        /// <summary>
        /// 是否推薦
        /// </summary>
        public virtual bool IsRecommed { get; set; }
        /// <summary>
        /// 是否熱門
        /// </summary>
        public virtual bool IsHot { get; set; }
        /// <summary>
        /// 是否置頂
        /// </summary>
        public virtual bool IsTop { get; set; }
        /// <summary>
        /// 瀏覽數量
        /// </summary>
        public virtual int BrowserNo { get; set; }
        /// <summary>
        /// 點讚數量
        /// </summary>
        public virtual int HitNo { get; set; }
        /// <summary>
        /// 收藏數量
        /// </summary>
        public virtual int ColectionNo { get; set; }
        /// <summary>
        /// 偽靜態：靜態頁面名稱.html
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string HtmlPage { get; set; }
        /// <summary>
        /// 是否有效，設置失效的將不顯示
        /// </summary>
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// 所屬語言代碼，用於區分不同語言下的內容，默認是zh-CN
        /// </summary>
        public virtual string Language { get; set; }
        /// <summary>
        /// 為文章編輯標籤
        /// </summary>
        [StringLength(MaxDescLength)]
        public virtual string Tag { get; set; }
        /// <summary>
        /// 外部鏈接地址：維護后點擊對應文章直接跳轉到鏈接地址
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string ExternalLink { get; set; }

        public virtual string SiteMemo { get; set; }
        public virtual string OtherMemo { get; set; }
        public virtual string OtherMemo1 { get; set; }

        //外鍵關係
        [ForeignKey("ColumnId1")]
        public virtual Column Column1 { get; set; }
        [ForeignKey("ColumnId2")]
        public virtual Column Column2 { get; set; }
        [ForeignKey("ColumnId3")]
        public virtual Column Column3 { get; set; }

    }
}
