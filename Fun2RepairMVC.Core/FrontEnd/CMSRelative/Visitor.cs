using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsVisitors")]
    public class Visitor : CreationAuditedEntity<long>
    {
        public const int MaxCodeLength = 50;
        public const int MaxNameLength = 200;
        public const int MaxDescLength = 1000;
        /// <summary>
        /// 來訪IP
        /// </summary>
        [StringLength(MaxCodeLength)]
        public virtual string IpAdress { get; set; }
        /// <summary>
        /// 來訪時間
        /// </summary>
        public virtual DateTime AccessTime { get; set; }
        /// <summary>
        /// 訪問的頁面
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string VisitPage { get; set; }
        /// <summary>
        /// 來路頁面：暫停
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string AntePage { get; set; }
        /// <summary>
        /// 訪問的欄目Id
        /// </summary>
        public virtual int? ColumeId { get; set; }
        /// <summary>
        /// 所用瀏覽器
        /// </summary>
        [StringLength(MaxCodeLength)]
        public virtual string Browser { get; set; }
        /// <summary>
        /// 來訪網絡類型
        /// </summary>
        [StringLength(MaxCodeLength)]
        public virtual string NetWork { get; set; }
        /// <summary>
        /// 來訪語言
        /// </summary>
        [StringLength(MaxCodeLength)]
        public virtual string Lang { get; set; }
    }
}
