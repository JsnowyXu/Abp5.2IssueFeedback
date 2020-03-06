using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.Repairs
{
    public class IssueType:FullAuditedEntity
    {
        //分類碼，自動生成S01 S01-001
        [StringLength(20)]
        public virtual string Code { get; set; }
        //問題分類
        [StringLength(100)]
        public virtual string Name { get; set; }
        //問題描述
        [StringLength(100)]
        public virtual string Description { get; set; }
        //問題類別：一級分類，二階分類。
        public virtual int? BigIssueId { get; set; }

        [ForeignKey("BigIssueId")]
        public virtual IssueType BigIssue { get; set; }

    }
}
