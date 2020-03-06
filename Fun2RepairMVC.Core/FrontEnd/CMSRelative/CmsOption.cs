using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsOptions")]
    public class CmsOption : FullAuditedEntity<long>,IMultiLingualEntity<CmsOptionTranslation>
    {
        /// <summary>
        /// 字段表id
        /// </summary>
        public virtual long ParaId { get; set; }
        /// <summary>
        /// 字段內容,保存繁體中文的內容
        /// </summary>
        [Column(TypeName = "ntext")]
        public virtual string OptionValue { get; set; }

        public virtual int OrderNo { get; set; }


        [ForeignKey("ParaId")]
        public virtual CmsParameter Para { get; set; }

        public virtual ICollection<CmsOptionTranslation> Translations { get; set; }


    }
}
