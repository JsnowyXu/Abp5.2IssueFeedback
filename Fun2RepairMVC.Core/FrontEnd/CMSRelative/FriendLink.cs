using Abp.Domain.Entities.Auditing;
using Fun2RepairMVC.Common.PublicCode;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsFriendLink")]
    public class FriendLink : FullAuditedEntity
    {
        public const int MaxNameLength = 200;
        public const int MaxDescLength = 500;
        /// <summary>
        /// 友情鏈接名稱
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }
        /// <summary>
        /// 鏈接類型 0：文字鏈接 默認      1：圖片鏈接
        /// </summary>
        public virtual int LinkTypeId { get; set; }
        /// <summary>
        /// 鏈接地址
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string TargetUrl { get; set; }
        /// <summary>
        /// 鏈接logo:用於圖片鏈接,保存路徑
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string TargetLogo { get; set; }
        /// <summary>
        /// keyword 顯示為a標籤的alt 
        /// </summary>
        [StringLength(MaxDescLength)]
        public virtual string Kerwords { get; set; }
        /// <summary>
        ///排序  越小越靠前顯示
        /// </summary>
        public virtual int OrderNo { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// 聯繫方式
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string LinkContact { get; set; }

        [ForeignKey("LinkTypeId")]
        public virtual Parameter LinkType { get; set; }
    }
}
