using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.Extras
{
    /// <summary>
    /// 附件
    /// </summary>
    [Table("extAttachments")]
    public partial class Attachment:CreationAuditedEntity<long>
    {
        public const int MaxNameLength = 50;
        public const int MaxPathLength = 200;
        //原始文件名
        public virtual string OriginName { get; set; }
        //系統保存的唯一名稱：可能是重命名的
        [Required]
        [StringLength(MaxNameLength)]
        public virtual string UniqueName { get; set; }
        //用戶友好顯示名稱，基本與原始文件名相同，除非特別固定名稱的文件
        [Required]
        [StringLength(MaxNameLength)]
        public virtual string DisplayName { get; set; }
        //文件保存路徑
        [Required]
        [StringLength(MaxPathLength)]
        public virtual string FilePath { get; set; }
        //文件大小
        public virtual int? FileSize { get; set; }

    }
}
