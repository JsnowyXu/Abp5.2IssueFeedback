using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.Repairs
{
    public class RepairStatus:CreationAuditedEntity<long>
    {
        //對應報修單號
        public virtual long RepairApplyId { get; set; }
        //狀態代碼，基礎參數中
        [StringLength(10)]
        public virtual string StatusCode { get; set; }
        //備註
        [StringLength(500)]
        public virtual string Remark { get; set; }
        //責任人
        [StringLength(50)]
        public virtual string Responser { get; set; }
        //是否通過
        public virtual bool IsApproval { get; set; }
        //是否支付成功
        public virtual bool IsPay { get; set; }

        [ForeignKey("RepairApplyId")]
        public virtual RepairApply RepairApply { get; set; }
    }
}
