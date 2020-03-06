using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsModules")]
    public class Module : FullAuditedEntity, IMultiLingualEntity<ModuleTranslation>
    {
        public const int MaxCodeLength = 50;
        public const int MaxNameLength = 200;
        public const int MaxDescLength = 500;
        [StringLength(MaxCodeLength)]
        /// <summary>
        /// 模塊代碼：模塊代碼
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// 模塊描述
        /// </summary>
        [StringLength(MaxDescLength)]
        public virtual string Description { get; set; }
        /// <summary>
        /// 圖標名稱：不用上傳直接輸入，到指定目錄去讀取即可
        /// </summary>
        [StringLength(MaxCodeLength)]
        public virtual string Icon { get; set; }

        [StringLength(MaxNameLength)]
        public virtual string TargetUrl { get; set; }
        /// <summary>
        /// 是否激活 0：未激活  1：已激活
        /// </summary>
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// 是否需要維護內容
        /// </summary>
        public virtual bool IsContent { get; set; }
        /// <summary>
        /// 是否在內容管理中顯示
        /// </summary>
        public virtual bool IsShowInManage { get; set; }

        public ICollection<ModuleTranslation> Translations { get; set; }


    }
}
