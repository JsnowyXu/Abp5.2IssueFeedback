using Abp.Domain.Entities.Auditing;
using Fun2RepairMVC.Authorization.Users;
using Fun2RepairMVC.Common.PublicCode;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsMessages")]
    public class Message : FullAuditedEntity<long>
    {
        public const int MaxCodeLength = 50;
        public const int MaxNameLength = 200;
        public const int MaxDescLength = 1000;
        /// <summary>
        ///留言標題
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string Ttile { get; set; }
        /// <summary>
        /// 留言內容
        /// </summary>
        [StringLength(MaxDescLength)]
        public virtual string Content { get; set; }
        /// <summary>
        /// 留言時間
        /// </summary>
        public virtual DateTime AddTime { get; set; }
        /// <summary>
        /// 是否審核并顯示：0 未審核  1：審核通過不顯示  2 審核通過并顯示
        /// </summary>
        public virtual bool IsShow { get; set; }
        /// <summary>
        /// 留言人姓名
        /// </summary>
        [StringLength(MaxCodeLength)]
        public virtual string Name { get; set; }
        /// <summary>
        /// 電話
        /// </summary>
        [StringLength(MaxCodeLength)]
        public virtual string PhoneNumber { get; set; }
        /// <summary>
        /// 郵箱
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string EmailAddress { get; set; }
        [StringLength(MaxCodeLength)]
        public virtual string IPAdress { get; set; }
        //其他聯繫方式

        [StringLength(MaxNameLength)]
        public virtual string OtherContact { get; set; }
        /// <summary>
        /// 會員ID 如果為空則為遊客
        /// </summary>
        public virtual long? CustomerId { get; set; }

        //回复状态:主要用於管理員識別待回復信息
        public virtual int? ReplyStatusId { get; set; }

        [ForeignKey("ReplyStatusId")]
        public virtual Parameter ReplyStatus { get; set; }
        public virtual int? MessageTypeId { get; set; }
        [ForeignKey("MessageTypeId")]
        public virtual Parameter MessageType { get; set; }

    }
}
