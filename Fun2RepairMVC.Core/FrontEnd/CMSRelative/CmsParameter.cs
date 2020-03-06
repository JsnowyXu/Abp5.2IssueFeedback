using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Fun2RepairMVC.Common.PublicCode;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsParameters")]
    public class CmsParameter : FullAuditedEntity<long>,IMultiLingualEntity<CmsParameterTranslation>
    {
        public const int MaxNameLength = 200;
        public const int MaxDescLength = 500;
        /// <summary>
        /// 一級欄目
        /// </summary>
        public virtual int? ColumnId1 { get; set; }
        /// <summary>
        /// 二級欄目
        /// </summary>
        public virtual int? ColumnId2 { get; set; }
        /// <summary>
        /// 三級欄目
        /// </summary>
        public virtual int? ColumnId3 { get; set; }

        /// <summary>
        /// 默認名稱：取繁體中文作為默認
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string DisplayName { get; set; }
        /// <summary>
        /// 備註：用於結束該字段用途
        /// </summary>
        [StringLength(MaxNameLength)]
        public virtual string Description { get; set; }
        /// <summary>
        /// 1：簡短2：下拉3：文本4：多選5：單選6：附件  保存到參數表中
        /// </summary>
        public virtual int ParaTypeId { get; set; }
        //是否必填
        public virtual bool IsMandatory { get; set; }
        /// <summary>
        /// 所屬模塊
        /// </summary>
        public virtual int? ModuleId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public virtual  int OrderNo { get; set; }
        /// <summary>
        /// 是否顯示
        /// </summary>
        public virtual bool IsDisplay { get; set; }
        [ForeignKey("ColumnId1")]
        public virtual Column Column1 { get; set; }
        [ForeignKey("ColumnId2")]
        public virtual Column Column2 { get; set; }
        [ForeignKey("ColumnId3")]
        public virtual Column Column3 { get; set; }
        [ForeignKey("ModuleId")]
        public virtual Module Module { get; set; }

        [ForeignKey("ParaTypeId")]
        public virtual Parameter ParaType { get; set; }
        /// <summary>
        /// 特殊不需要保存在paraoption用
        /// </summary>
        [Column(TypeName = "ntext")]
        public virtual string OptionValues { get; set; }

        public virtual ICollection<CmsParameterTranslation> Translations { get; set; }
    }
}
