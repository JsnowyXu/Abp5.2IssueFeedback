using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.CMS
{

    [Table("cmsBanners")]
    public class Banner : FullAuditedEntity
    {
        public const int MaxCodeLength = 50;
        public const int MaxNameLength = 200;
        public const int MaxDescLength = 500;
        /// <summary>
        ///banner 標題
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string ImgTitle { get; set; }
        /// <summary>
        ///banner路徑
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string ImgUrl { get; set; }
        /// <summary>
        ///banner鏈接
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string ImgLink { get; set; }
        /// <summary>
        ///banner swf 路徑
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string FlashPath { get; set; }
        /// <summary>
        ///背景圖片
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string FlashBack { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int OrderNo { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [StringLength(MaxDescLength)]
        public virtual string Description { get; set; }
        /// <summary>
        /// 寬度
        /// </summary>
        public virtual int Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public virtual int Height { get; set; }

        public virtual ICollection<ColumnBanner> Columns { get; set; }
    }

}
