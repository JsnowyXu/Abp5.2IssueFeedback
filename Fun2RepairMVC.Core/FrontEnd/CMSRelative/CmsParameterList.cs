using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Fun2RepairMVC.FrontEnd.CMS;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    //動態字段內容表
    [Table("cmsParametersList")]
    public class CmsParameterList : CreationAuditedEntity<long>
    {
        /// <summary>
        /// 參數表Id，例如會員性別
        /// </summary>
        public virtual long ParaId { get; set; }
        /// <summary>
        /// 參數應用的對象ID：如某一個用戶
        /// </summary>
        public virtual long? ListId { get; set; }
        /// <summary>
        /// 動態字段值：如女
        /// </summary>
        [Column(TypeName = "ntext")]
        public virtual string ParaValue { get; set; }
        /// <summary>
        /// 類型是附件時，上傳的文件名稱
        /// </summary>
        [StringLength(100)]
        public virtual string AttachmentName { get; set; }
        //對應模塊ID
        public virtual int? ModuleId { get; set; }

        [ForeignKey("ParaId")]
        public virtual CmsParameter Para { get; set; }

        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }


    }
}
