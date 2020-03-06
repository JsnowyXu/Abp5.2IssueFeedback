using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun2RepairMVC.FrontEnd.CMS.CMSRelative
{
    public class MessageReply:CreationAuditedEntity<long>
    {
        //留言ID
        public virtual long MessageId {get;set;}
        //回復人
        public virtual long? ReplierId { get; set; }
        [StringLength(50)]
        //回復人暱稱
        public virtual long ReplierName { get; set; }
        //回復時間
        public virtual DateTime ReplyTime { get; set; }
        
        //用戶類型：如果是管理員回復則為0 ，其他為1
        public virtual int UserType { get; set; }

        //父節點信息:保存的是當前樓層的ID，不管回復的是哪個評論，初始評論為0
        public virtual long SuperReplyId { get; set; }

        //被回復的評論ID
        public virtual long? ParentReplyId { get; set; }
        //被回復的評論人名稱
        [StringLength(50)]
        public virtual string TargetReplierName { get; set; }
        //評論內容
        [Column(TypeName = "ntext")]
        public virtual string Content { get; set; }




    }
}
