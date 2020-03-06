using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.Repairs
{
    public class Issue:FullAuditedEntity
    {
        //故障標題
        [StringLength(200)]
        public virtual string Title { get; set; }
        //故障解決內容
        [Column(TypeName = "ntext")]
        public virtual string Content { get; set; }
        //置頂問題
        public virtual bool IsTop { get; set; }
        public virtual bool IsHot { get; set; }
        public virtual int Browser { get; set; }
        public virtual int ThumbUp { get; set; }

        //所屬分類，對應二級分類
        public virtual int IssueTypeId { get; set; }
    }
}
